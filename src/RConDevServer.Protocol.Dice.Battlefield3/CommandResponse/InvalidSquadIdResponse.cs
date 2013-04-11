namespace RConDevServer.Protocol.Dice.Battlefield3.CommandResponse
{
    using System.Collections.Generic;

    public class InvalidSquadIdResponse : ICommandResponse
    {
        /// <summary>
        /// gets the basic response name
        /// </summary>
        public string ResponseName { get { return ResponseNames.InvalidSquadId; } }

        /// <summary>
        /// Generates the words needed to create the <see cref="RConDevServer.Protocol.Dice.Common.IPacket" />
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ToWords()
        {
            throw new System.NotImplementedException();
        }
    }
}