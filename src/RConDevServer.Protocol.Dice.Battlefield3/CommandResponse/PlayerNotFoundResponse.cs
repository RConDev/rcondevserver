namespace RConDevServer.Protocol.Dice.Battlefield3.CommandResponse
{
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of <see cref="ICommandResponse"/> for the case a player could not be found
    /// </summary>
    public class PlayerNotFoundResponse : ICommandResponse
    {
        /// <summary>
        /// gets the basic response name
        /// </summary>
        public string ResponseName { get { return ResponseNames.PlayerNotFound; } }

        /// <summary>
        /// Generates the words needed to create the <see cref="RConDevServer.Protocol.Dice.Common.IPacket" />
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ToWords()
        {
            return new[] {this.ResponseName};
        }
    }
}