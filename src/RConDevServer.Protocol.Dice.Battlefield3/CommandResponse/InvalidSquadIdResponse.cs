namespace RConDevServer.Protocol.Dice.Battlefield3.CommandResponse
{
    using System.Collections.Generic;
    using System.ComponentModel;

    public class InvalidSquadIdResponse : ICommandResponse
    {
        /// <summary>
        /// gets the basic response name
        /// </summary>
        public string Response { get { return ResponseNames.InvalidSquadId; } }

        /// <summary>
        /// Generates the words needed to create the <see cref="RConDevServer.Protocol.Dice.Common.IPacket" />
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ToWords()
        {
            return new [] {this.Response};
        }
    }
}