namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     base class for all vars commands
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class VarsCommandBase<T> : IVarsCommand<T> where T : struct
    {
        /// <summary>
        ///     The command name
        /// </summary>
        public abstract string Command { get; }

        /// <summary>
        ///     Generates the words needed to create the <see cref="RConDevServer.Protocol.Dice.Common.IPacket" />
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ToWords()
        {
            var words = new List<string> {this.Command};
            if (this.Value != null)
            {
                words.Add(Convert.ToString(this.Value));
            }
            return words;
        }

        /// <summary>
        ///     get or set the value
        /// </summary>
        public T? Value { get; set; }
    }
}