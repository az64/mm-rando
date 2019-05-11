using MMRando.Constants;
using MMRando.Models.Rom;
using System;
using System.Collections.Generic;
using System.Linq;
using static MMRando.RomData;

namespace MMRando.Utils
{

    public static class MessageUtils
    {
        //todo - allow rebuilding text file

        private static void WriteMessage(int addr, byte[] msg)
        {
            int fileIndex = RomUtils.GetFileIndexForWriting(Addresses.TextFile);
            ReadWriteHelpers.Arr_Insert(msg, 0, msg.Length, MMFileList[fileIndex].Data, addr);
        }

        private static MMMesssage FindMesssage(int address)
        {
            int fileIndex = RomUtils.GetFileIndexForWriting(Addresses.TextTable);
            int baseAddress = Addresses.TextTable - MMFileList[fileIndex].Addr;

            MMMesssage message = new MMMesssage();

            while (true)
            {
                int x = (MMFileList[fileIndex].Data[baseAddress] << 8)
                    + MMFileList[fileIndex].Data[baseAddress + 1];

                if (address == x)
                {
                    var data = MMFileList[fileIndex].Data;
                    message.Address = (int)(ReadWriteHelpers.Arr_ReadU32(data, baseAddress + 4) & 0xFFFFFF);
                    message.Size = (int)(ReadWriteHelpers.Arr_ReadU32(data, baseAddress + 12) & 0xFFFFFF) - message.Address;
                    break;
                }

                if (x > address)
                {
                    return null;
                }

                baseAddress += 8;
            }

            return message;
        }

        public static bool IsBadMesssage(string message)
        {
            return message.Contains("a segment of health") || message.Contains("currency") ||
                message.Contains("money") || message.Contains("cash") ||
                message.Contains("wealth") || message.Contains("riches and stuff") ||
                message.Contains("increased life");
        }

        public static void WriteGossipMessage(List<string> messages, Random RNG)
        {

            for (int i = Addresses.GossipStart; i < Addresses.GossipEnd; i++)
            {
                if (Addresses.GossipExclude.Contains(i))
                {
                    continue;
                }

                MMMesssage message = FindMesssage(i);
                if (message == null)
                {
                    continue;
                }

                int randomMessageIndex;
                int length = message.Size + 1;
                do
                {
                    randomMessageIndex = RNG.Next(messages.Count);

                    if (IsBadMesssage(messages[randomMessageIndex]) && RNG.Next(8) != 0)
                    {
                        continue;
                    }

                    length = messages[randomMessageIndex].Length + Values.MessageHeader.Count;

                } while (length > message.Size);

                byte[] data = new byte[length];
                ReadWriteHelpers.Arr_Insert(Values.MessageHeader.ToArray(), 0, Values.MessageHeader.Count, data, 0);

                for (int k = 0; k < messages[randomMessageIndex].Length; k++)
                {
                    data[k + Values.MessageHeader.Count] = (byte)messages[randomMessageIndex][k];
                }

                WriteMessage(message.Address, data);
                messages.RemoveAt(randomMessageIndex);
            };
        }

    }

}