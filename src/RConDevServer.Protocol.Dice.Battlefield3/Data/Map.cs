using System;
using System.Collections.Generic;

namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    /// <summary>
    /// This class holds all information for a map
    /// </summary>
    public class Map : IEquatable<Map>
    {


        /// <summary>
        /// the unique code for the map 
        /// </summary>
        public virtual string Code { get; set; }

        /// <summary>
        /// the map's display name 
        /// </summary>
        public virtual string Display { get; set; }

        /// <summary>
        /// the map's supported game modes
        /// </summary>
        public virtual IEnumerable<GameMode> SupportedModes { get; set; }

        public virtual Map Instance { get { return this; } }

        public virtual long Key { get; set; }

        public virtual string ToWord()
        {
            return this.Code ?? string.Empty;
        }

        public virtual bool Equals(Map other)
        {
            return Code == other.Code;
        }

        public override bool Equals(object obj)
        {
            if (obj is Map)
            {
                return Equals(obj as Map);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (this.Code != null ? this.Code.GetHashCode() : 0);
        }
    }
}
