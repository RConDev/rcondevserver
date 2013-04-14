using System.Collections.Generic;

namespace RConDevServer.Protocol.Dice.Battlefield3.CommandResponse
{
    /// <summary>
    /// This interface describes a response from a processed command
    /// </summary>
    public interface ICommandResponse
    {
        /// <summary>
        /// gets the basic response name
        /// </summary>
        string Response { get; }

        /// <summary>
        /// Generates the words needed to create the <see cref="RConDevServer.Protocol.Dice.Common.IPacket" />
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> ToWords();
    }
}
