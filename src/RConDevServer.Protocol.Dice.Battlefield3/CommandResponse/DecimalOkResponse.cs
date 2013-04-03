namespace RConDevServer.Protocol.Dice.Battlefield3.CommandResponse
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Implementation of <see cref="ICommandResponse"/> with a <see cref="decimal"/> Value
    /// </summary>
    public class DecimalOkResponse : OkResponse
    {
        /// <summary>
        /// the value within the response
        /// </summary>
        public decimal Value { get; private set; }

        /// <summary>
        /// creates a new <see cref="DecimalOkResponse"/> instance
        /// </summary>
        /// <param name="value"></param>
        public DecimalOkResponse(decimal value)
        {
            this.Value = value;
        }

        /// <summary>
        ///     Generates the words needed to create the <see cref="RConDevServer.Protocol.Dice.Common.IPacket" />
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<string> ToWords()
        {
            var words = base.ToWords().ToList();
            words.Add(Convert.ToString(this.Value));
            return words;
        }
    }
}