namespace RConDevServer.Protocol.Dice.Battlefield3.CommandResponse
{
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of <see cref="ICommandResponse"/> for a list of strings to be returned after a 
    /// success message
    /// </summary>
    public class StringListOkResponse : ValueOkResponse<IEnumerable<string>>
    {
        /// <summary>
        ///     creates a new <see cref="ValueOkResponse{TValue}" /> instance
        /// </summary>
        /// <param name="value"></param>
        public StringListOkResponse(IEnumerable<string> value) : base(value)
        {
        }

        /// <summary>
        ///     Generates the words needed to create the <see cref="RConDevServer.Protocol.Dice.Common.IPacket" />
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<string> ToWords()
        {
            var words = new List<string> {this.ResponseName};
            words.AddRange(Value);
            return words;
        }
    }
}