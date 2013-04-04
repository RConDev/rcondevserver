namespace RConDevServer.Protocol.Dice.Battlefield3.CommandResponse
{
    /// <summary>
    /// Implementation of <see cref="ICommandResponse"/> with a <see cref="decimal"/> Value
    /// </summary>
    public class DecimalOkResponse : ValueOkResponse<decimal>
    {
        /// <summary>
        /// creates a new <see cref="DecimalOkResponse"/> instance
        /// </summary>
        /// <param name="value"></param>
        public DecimalOkResponse(decimal value) : base(value)
        {
        }
    }
}