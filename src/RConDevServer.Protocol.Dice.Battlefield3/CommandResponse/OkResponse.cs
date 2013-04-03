namespace RConDevServer.Protocol.Dice.Battlefield3.CommandResponse
{
    using System.Collections.Generic;
    using Command;

    /// <summary>
    ///     this is the basic <see cref="ICommandResponse" /> implementation for a successfully
    ///     executed <see cref="ICommand" />
    /// </summary>
    public class OkResponse : ICommandResponse
    {
        /// <summary>
        ///     gets the basic response name
        /// </summary>
        public string ResponseName
        {
            get { return ResponseNames.Ok; }
        }

        /// <summary>
        ///     Generates the words needed to create the <see cref="RConDevServer.Protocol.Dice.Common.IPacket" />
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> ToWords()
        {
            return new[] { this.ResponseName };
        }
    }
}