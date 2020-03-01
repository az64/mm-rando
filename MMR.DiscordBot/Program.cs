using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using MMR.Common.Utils;

namespace MMR.DiscordBot
{
    class Program
    {
        private const string MMR_CLI = "MMR.CLI";
        private const string MMR_DISCORDBOT_TOKEN = "MMR.DiscordBot.Token";

        private readonly DiscordSocketClient _client;
        private readonly HttpClient _httpClient;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        private readonly Random _random = new Random();
        private readonly string _cliPath;
        private readonly string _discordBotToken;

        static int Main(string[] args)
        {
            return new Program().MainAsync().GetAwaiter().GetResult();
        }

        public Program()
        {
            _cliPath = Environment.GetEnvironmentVariable(MMR_CLI);
            _discordBotToken = Environment.GetEnvironmentVariable(MMR_DISCORDBOT_TOKEN);

            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromSeconds(10);
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "zoey.zolotova at gmail.com");

            // It is recommended to Dispose of a client when you are finished
            // using it, at the end of your app's lifetime.
            _client = new DiscordSocketClient();

            _client.Log += LogAsync;
            _client.Ready += ReadyAsync;
            _client.MessageReceived += MessageReceivedAsync;
        }

        public async Task<int> MainAsync()
        {
            if (string.IsNullOrWhiteSpace(_cliPath))
            {
                Console.Error.WriteLine($"Environment Variable '{MMR_CLI}' is missing.");
                return -1;
            }
            if (string.IsNullOrWhiteSpace(_discordBotToken))
            {
                Console.Error.WriteLine($"Environment Variable '{MMR_DISCORDBOT_TOKEN}' is missing.");
                return -1;
            }
            if (!Directory.Exists(_cliPath))
            {
                Console.Error.WriteLine($"'{_cliPath}' is not a valid MMR.CLI path.");
                return -1;
            }
            // Tokens should be considered secret data, and never hard-coded.
            await _client.LoginAsync(TokenType.Bot, _discordBotToken);
            await _client.StartAsync();

            // Block the program until it is closed.
            await Task.Delay(-1);
            return 0;
        }

        private Task LogAsync(LogMessage log)
        {
            Console.WriteLine(log.ToString());
            return Task.CompletedTask;
        }

        // The Ready event indicates that the client has opened a
        // connection and it is now safe to access the cache.
        private Task ReadyAsync()
        {
            Console.WriteLine($"{_client.CurrentUser} is connected!");

            return Task.CompletedTask;
        }

        private Dictionary<ulong, DateTime> _lastRequestedSeed = new Dictionary<ulong, DateTime>();

        // This is not the recommended way to write a bot - consider
        // reading over the Commands Framework sample.
        private async Task MessageReceivedAsync(SocketMessage message)
        {
            // The bot should never respond to itself.
            if (message.Author.Id == _client.CurrentUser.Id)
                return;

            if (message.Content.StartsWith("!spoiler"))
            {
                if (!_lastRequestedSeed.ContainsKey(message.Author.Id))
                {
                    await message.Channel.SendMessageAsync("You haven't generated any seeds recently.");
                    return;
                }
                var requestedLog = FileUtils.MakeFilenameValid(_lastRequestedSeed[message.Author.Id].ToString("o"));
                var spoilerLogFilename = Path.Combine(_cliPath, $@"output\{requestedLog}_SpoilerLog.txt");
                if (File.Exists(spoilerLogFilename))
                {
                    var result = await message.Channel.SendFileAsync(spoilerLogFilename);
                    File.Delete(spoilerLogFilename);
                }
                else
                {
                    await message.Channel.SendMessageAsync("Spoiler log not found.");
                }
            }
            if (message.Content == "!seed")
            {
                if (_lastRequestedSeed.ContainsKey(message.Author.Id) && (DateTime.UtcNow - _lastRequestedSeed[message.Author.Id]).TotalHours < 6)
                {
                    await message.Channel.SendMessageAsync("You may only request a seed once every 6 hours.");
                    return;
                }
                var now = DateTime.UtcNow;
                _lastRequestedSeed[message.Author.Id] = now;
                var messageResult = await message.Channel.SendMessageAsync("Generating seed...");
                new Thread(async () =>
                {
                    var filename = FileUtils.MakeFilenameValid(now.ToString("o"));
                    var success = false;
                    try
                    {
                        success = await GenerateSeed(filename);
                        var patchPath = Path.Combine(_cliPath, $@"output\{filename}.mmr");
                        if (File.Exists(patchPath))
                        {
                            var result = await message.Channel.SendFileAsync(patchPath);
                            File.Delete(patchPath);
                            await messageResult.DeleteAsync();
                        }
                        else
                        {
                            success = false;
                        }
                    }
                    catch
                    {
                        success = false;
                    }
                    if (!success)
                    {
                        _lastRequestedSeed.Remove(message.Author.Id);
                        await messageResult.ModifyAsync(mp => mp.Content = "An error occured.");
                    }
                }).Start();
            }
        }

        private async Task<bool> GenerateSeed(string filename)
        {
            var seed = await GetSeed();
            var processInfo = new ProcessStartInfo(Path.Combine(_cliPath, @"MMR.CLI.exe"));
            processInfo.WorkingDirectory = _cliPath;
            processInfo.Arguments = $"-output \"output/{filename}.mmr\" -seed {seed} -spoiler -patch";
            processInfo.ErrorDialog = false;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardOutput = true;
            processInfo.RedirectStandardError = true;

            var proc = Process.Start(processInfo);
            proc.ErrorDataReceived += (sender, errorLine) => { if (errorLine.Data != null) Trace.WriteLine(errorLine.Data); };
            proc.OutputDataReceived += (sender, outputLine) => { if (outputLine.Data != null) Trace.WriteLine(outputLine.Data); };
            proc.BeginErrorReadLine();
            proc.BeginOutputReadLine();

            proc.WaitForExit();
            return proc.ExitCode == 0;
        }

        private async Task<int> GetSeed()
        {
            await _semaphore.WaitAsync();
            int seed;
            try
            {
                var response = await _httpClient.GetStringAsync("https://www.random.org/integers/?num=1&min=-1000000000&max=1000000000&col=1&base=10&format=plain&rnd=new");
                seed = int.Parse(response) + 1000000000;
            }
            catch (HttpRequestException e)
            {
                seed = _random.Next();
            }
            _semaphore.Release();
            return seed;
        }
    }
}
