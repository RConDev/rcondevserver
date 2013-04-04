namespace RConDevServer.Protocol.Dice.Battlefield3.CommandResponse
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of <see cref="ICommandResponse"/> with a <see cref="bool"/> Value
    /// </summary>
    public class BooleanOkResponse : ValueOkResponse<bool>
    {
        /// <summary>
        ///     creates a new <see cref="ValueOkResponse{TValue}" /> instance
        /// </summary>
        /// <param name="value"></param>
        public BooleanOkResponse(bool value) : base(value)
        {
        }

        /// <summary>
        ///     Generates the words needed to create the <see cref="RConDevServer.Protocol.Dice.Common.IPacket" />
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<string> ToWords()
        {
            return new[] {this.ResponseName, Convert.ToString(this.Value).ToLower()};
        }
    }
}
