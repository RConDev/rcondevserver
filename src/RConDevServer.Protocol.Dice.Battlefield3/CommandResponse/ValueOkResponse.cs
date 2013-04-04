namespace RConDevServer.Protocol.Dice.Battlefield3.CommandResponse
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///     abstract base class for response which contain a value part in their response (i.e. Vars)
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public abstract class ValueOkResponse<TValue> : OkResponse
    {
        /// <summary>
        ///     creates a new <see cref="ValueOkResponse{TValue}" /> instance
        /// </summary>
        /// <param name="value"></param>
        protected ValueOkResponse(TValue value)
        {
            this.Value = value;
        }

        /// <summary>
        ///     gets the value for the response
        /// </summary>
        public TValue Value { get; private set; }

        /// <summary>
        ///     Generates the words needed to create the <see cref="RConDevServer.Protocol.Dice.Common.IPacket" />
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<string> ToWords()
        {
            List<string> words = base.ToWords().ToList();
            words.Add(this.Value.ToString());
            return words;
        }
    }
}