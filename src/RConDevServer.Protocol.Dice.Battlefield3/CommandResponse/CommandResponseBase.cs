namespace RConDevServer.Protocol.Dice.Battlefield3.CommandResponse
{
    using System.Collections.Generic;

    /// <summary>
    /// Abstract base class for <see cref="ICommandResponse"/> instances
    /// </summary>
    public abstract class CommandResponseBase : ICommandResponse
    {
        /// <summary>
        /// gets the basic response name
        /// </summary>
        public abstract string Response { get; }

        /// <summary>
        /// Generates the words needed to create the <see cref="RConDevServer.Protocol.Dice.Common.IPacket" />
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ToWords()
        {
            return new[] {this.Response};
        }
    }
}