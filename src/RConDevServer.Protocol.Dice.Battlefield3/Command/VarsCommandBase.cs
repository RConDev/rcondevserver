namespace RConDevServer.Protocol.Dice.Battlefield3.Command
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     base class for all vars commands
    /// </summary>
    /// <typeparam name="T">the type the value of var is of</typeparam>
    public abstract class VarsCommandBase<T> : IVarsCommand<T>
    {
        /// <summary>
        ///     The command name
        /// </summary>
        public abstract string Command { get; }

        /// <summary>
        ///     Generates the words needed to create the <see cref="RConDevServer.Protocol.Dice.Common.IPacket" />
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> ToWords()
        {
            var words = new List<string> {this.Command};
            if (this.Value != null)
            {
                var value = Convert.ToString(this.Value);
                if (this.Value is bool?)
                {
                    value = value.ToLower();
                }
                words.Add(value);
            }
            return words;
        }

        /// <summary>
        ///     get or set the value
        /// </summary>
        public T Value { get; set; }
    }
}