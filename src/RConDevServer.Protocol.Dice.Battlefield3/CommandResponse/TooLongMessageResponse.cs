namespace RConDevServer.Protocol.Dice.Battlefield3.CommandResponse
{
    using System.Collections.Generic;

    public class TooLongMessageResponse : ICommandResponse
    {
        /// <summary>
        /// gets the basic response name
        /// </summary>
        public string Response { get; private set; }

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