namespace RConDevServer.Protocol.Dice.Battlefield3.CommandResponse
{
    public class InvalidPlayerNameResponse : CommandResponseBase
    {
        /// <summary>
        /// gets the basic response name
        /// </summary>
        public override string Response { get { return ResponseNames.InvalidPlayer; } }
    }
}