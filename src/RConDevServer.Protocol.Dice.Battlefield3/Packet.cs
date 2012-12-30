using System;
using System.Linq;
using System.Collections.Generic;
 
using RConDevServer.Protocol.Dice.Battlefield3.Ui.Util;
using RConDevServer.Protocol.Dice.Battlefield3.Util;

namespace RConDevServer.Protocol.Dice.Battlefield3
{
    public class Packet : IPacket
    {
        #region Public Properties

        /// <summary>
        /// the unique sequence id in the client-server-session
        /// </summary>
        public uint? SequenceId { get; set; }

        /// <summary>
        /// shows on which side the packet was created
        /// </summary>
        public PacketOrigin Origin { get; set; }

        /// <summary>
        /// shows if this packet is a response to another packet
        /// </summary>
        public bool IsResponse { get; set; }

        /// <summary>
        /// shows the complete size in bytes of this packet
        /// </summary>
        public uint PacketSize { get; set; }

        /// <summary>
        /// gets the count of words within this packet
        /// </summary>
        public uint WordCount
        {
            get { return Convert.ToUInt32(Words.Count); }
        }

        /// <summary>
        /// gets the sign, if this packet contains a command initiated by the client
        /// </summary>
        public bool IsClientCommand
        {
            get { return this.Origin == PacketOrigin.Client && !this.IsResponse; }
        }

        /// <summary>
        /// gets the sign, if this packet contains a response to a server event
        /// </summary>
        public bool IsServerEventResponse
        {
            get
            {
                return Origin == PacketOrigin.Server && IsResponse;
            }
        }

        /// <summary>
        /// shows the words within the packet
        /// </summary>
        public IList<string> Words { get; private set; }

        public string WordsString
        {
            get { return StringEnumerableExtensions.DisplayWords(Words); }
        }

        #endregion

        #region Constructor

        public Packet()
        {
            Words = new List<string>();
        }

        public Packet(PacketOrigin origin, bool isResponse, uint sequenceId, IEnumerable<string> words)
        {
            this.Origin = origin;
            this.IsResponse = isResponse;
            this.SequenceId = sequenceId;
            this.Words = words.ToList();
        }

        #endregion

        #region Equality Members

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Packet)) return false;
            return Equals((Packet)obj);
        }

        public bool Equals(Packet other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.SequenceId.Equals(SequenceId)
                && Equals(other.Origin, Origin)
                && other.IsResponse.Equals(IsResponse)
                && Words.SequenceEqual(other.Words);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (SequenceId.HasValue ? SequenceId.Value.GetHashCode() : 0);
                result = (result * 397) ^ Origin.GetHashCode();
                result = (result * 397) ^ IsResponse.GetHashCode();
                result = (result * 397) ^ PacketSize.GetHashCode();
                result = (result * 397) ^ (Words != null ? Words.GetHashCode() : 0);
                return result;
            }
        }
        #endregion
    }
}