using MMRando.Models.Rom;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using static MMRando.RomData;

namespace MMRando.Utils
{

    public static class MessageUtils
    {
        const int MESSAGE_DATA_ADDRESS = 0xAD1000;
        const int MESSAGE_TABLE_ADDRESS = 0xC5D0D8;

        const int GOSSIP_START_ID = 0x20B0;
        const int GOSSIP_END_ID = 0x2116;

        static ReadOnlyCollection<int> GossipExclude
            = new ReadOnlyCollection<int>(new int[] {
                0x20D0,
                0x20D1,
                0x20D2,
                0x20F3,
                0x20F7,
                0x20F8,
                0x20F9,
            });

        static ReadOnlyCollection<byte> MessageHeader
            = new ReadOnlyCollection<byte>(new byte[] {
                2, 0, 0xFE, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF
        });

        //todo - allow rebuilding text file

        private static void WriteMessage(int addr, byte[] msg)
        {
            int fileIndex = RomUtils.GetFileIndexForWriting(MESSAGE_DATA_ADDRESS);
            ReadWriteUtils.Arr_Insert(msg, 0, msg.Length, MMFileList[fileIndex].Data, addr);
        }

        private static Dictionary<ushort, MessageEntry> GetMessageTable()
        {
            Dictionary<ushort, MessageEntry> messageTable = new Dictionary<ushort, MessageEntry>();

            int fileIndex = RomUtils.GetFileIndexForWriting(MESSAGE_TABLE_ADDRESS);
            MMFile file = MMFileList[fileIndex];
            int baseAddress = MESSAGE_TABLE_ADDRESS - file.Addr;
            var data = file.Data;

            while (true)
            {
                ushort textId = ReadWriteUtils.Arr_ReadU16(data, baseAddress);
                if (textId >= 0xFFFD) //This id is still valid, but hard to determine it's size
                {
                    break;
                }

                int address = ReadWriteUtils.Arr_ReadS32(data, baseAddress + 4) & 0xFFFFFF;
                int addressNext = ReadWriteUtils.Arr_ReadS32(data, baseAddress + 12) & 0xFFFFFF;

                MessageEntry message = new MessageEntry()
                {
                    Id = textId,
                    Address = address,
                    Size = addressNext - address
                };
                messageTable.Add(textId, message);
                baseAddress += 8;
            }

            return messageTable;
        }

        private static bool IsBadMessage(string message)
        {
            return message.Contains("a segment of health") || message.Contains("currency") ||
                message.Contains("money") || message.Contains("cash") ||
                message.Contains("wealth") || message.Contains("riches and stuff") ||
                message.Contains("increased life");
        }

        public static void WriteGossipHints(List<string> hints, Random random)
        {
            var messageList = GetMessageTable();
            for (ushort textId = GOSSIP_START_ID; textId < GOSSIP_END_ID; textId++)
            {
                if (GossipExclude.Contains(textId)
                    || !messageList.TryGetValue(textId, out MessageEntry message))
                {
                    continue;
                }

                int selectedIndex;
                string selectedHint;
                int length = message.Size + 1;
                do
                {
                    selectedIndex = random.Next(hints.Count);
                    selectedHint = hints[selectedIndex];

                    if (IsBadMessage(selectedHint) && random.Next(8) != 0)
                    {
                        continue;
                    }

                    length = selectedHint.Length + MessageHeader.Count;

                } while (length > message.Size);

                byte[] data = new byte[length];
                byte[] msg = Array.ConvertAll(selectedHint.ToCharArray(), item => (byte)item);

                MessageHeader.ToArray().CopyTo(data, 0);
                msg.CopyTo(data, MessageHeader.Count);

                WriteMessage(message.Address, data);
                hints.RemoveAt(selectedIndex);
            }
        }
    }
}