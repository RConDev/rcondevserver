namespace RConDevServer.Protocol.Dice.Common
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// the serializer for default bf3 packets sent to the remote admin console
    /// </summary>
    public class PacketSerializer : IPacketSerializer<IPacket>
    {
        public PacketSerializer()
        {
            this.PacketHeaderSize = 12;
        }

        public Encoding DefaultEncoding
        {
            get { return Encoding.GetEncoding(1252); }
        }

        public uint PacketHeaderSize { get; private set; }

        #region IPacketSerializer<Packet> Members

        public byte[] Serialize(Packet packet)
        {
            if (packet.SequenceId == null)
            {
                throw new ArgumentException("SequenceId may not be null");
            }

            // Sequence Bytes
            byte[] sequenceBytes = BitConverter.GetBytes(packet.SequenceId.Value);
            var sequenceBitArray = new BitArray(sequenceBytes);
            if (packet.Origin == PacketOrigin.Server)
            {
                sequenceBitArray[31] = true;
            }
            if (packet.IsResponse)
            {
                sequenceBitArray[30] = true;
            }
            sequenceBitArray.CopyTo(sequenceBytes, 0);

            // Word-Count Bytes
            uint wordCount = Convert.ToUInt32(packet.Words.Count);
            byte[] wordCountBytes = BitConverter.GetBytes(wordCount);

            // Words Bytes
            var wordBytes = new byte[0];
            wordBytes = packet.Words.Aggregate(wordBytes, this.EncodeWord);

            // Packet Size Bytes

            uint packetSize = Convert.ToUInt32(sequenceBytes.Length + 4 + wordCountBytes.Length + wordBytes.Length);
            byte[] packetSizeBytes = BitConverter.GetBytes(packetSize);
            var packetBytes = new byte[packetSize];

            sequenceBytes.CopyTo(packetBytes, 0);
            packetSizeBytes.CopyTo(packetBytes, sequenceBytes.Length);
            wordCountBytes.CopyTo(packetBytes, sequenceBytes.Length + packetSizeBytes.Length);
            wordBytes.CopyTo(packetBytes, sequenceBytes.Length + packetSizeBytes.Length + wordCountBytes.Length);

            return packetBytes;
        }

        public IEnumerable<Packet> Deserialize(byte[] packetData)
        {
            var packets = new List<Packet>();
            int bytesOffset = 0;
            byte[] bytes = this.GetNextPacketData(packetData, bytesOffset);
            while(bytes.Length > 0)
            {
                bytesOffset += bytes.Length;

                var packet = new Packet();
                this.EvaluateSequenceId(bytes, packet);
                packet.PacketSize = BitConverter.ToUInt32(bytes, 4);

                int iWordOffset = 0;
                uint wordsTotal = BitConverter.ToUInt32(bytes, 8);
                for (uint wordCount = 0; wordCount < wordsTotal; wordCount++)
                {
                    long wordStartPoint = this.PacketHeaderSize + iWordOffset + 4;
                    var wordLength = (int)BitConverter.ToUInt32(bytes, (int)this.PacketHeaderSize + iWordOffset);
                    string wordContent = this.DefaultEncoding.GetString(bytes, (int)wordStartPoint, wordLength);
                    packet.Words.Add(wordContent);
                    iWordOffset += wordLength + 5; // WordLength + WordSize + NullByte
                }
                packets.Add( packet);

                bytes = this.GetNextPacketData(packetData, bytesOffset);
            }
            return packets;




        }

        private byte[] GetNextPacketData(byte[] bytes, int offset)
        {
            var packetSize = BitConverter.ToUInt32(bytes, 4);
            return bytes.Skip(offset).Take(Convert.ToInt32(packetSize)).ToArray();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// determines the sequence id, isResponse and origin of the packet
        /// </summary>
        /// <param name="packetData"></param>
        /// <param name="packet"></param>
        private void EvaluateSequenceId(byte[] packetData, Packet packet)
        {
            byte[] sequenceBytes = BitConverter.GetBytes(BitConverter.ToUInt32(packetData, 0));
            var bitArray = new BitArray(sequenceBytes);
            packet.Origin = bitArray[31] ? PacketOrigin.Server : PacketOrigin.Client;
            packet.IsResponse = bitArray[30];
            bitArray[30] = false;
            bitArray[31] = false;
            bitArray.CopyTo(sequenceBytes, 0);
            packet.SequenceId = BitConverter.ToUInt32(sequenceBytes, 0);
        }

        /// <summary>
        /// encodes a packet word into bytes and concats it with the existing bytes
        /// </summary>
        /// <param name="existingWordBytes"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        private byte[] EncodeWord(byte[] existingWordBytes, string word)
        {
            // 5 = UInt32 bytes + 1 Null-Byte
            var currentWordBytes = new byte[word.Length + 5];

            byte[] wordLengthBytes = BitConverter.GetBytes(word.Length);
            wordLengthBytes.CopyTo(currentWordBytes, 0);

            char nullByteChar = Convert.ToChar(0x00);
            byte[] wordBytes = this.DefaultEncoding.GetBytes(word + nullByteChar);
            wordBytes.CopyTo(currentWordBytes, 4);

            int targetBytesLength = existingWordBytes.Length + currentWordBytes.Length;
            var targetBytes = new byte[targetBytesLength];

            // copy already encoded words to target
            existingWordBytes.CopyTo(targetBytes, 0);
            currentWordBytes.CopyTo(targetBytes, existingWordBytes.Length);
            return targetBytes;
        }

        #endregion
    }
}