namespace RConDevServer.Protocol.Dice.Battlefield3.Command
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Common;

    /// <summary>
    /// this class represents a complete string which stands for <see cref="ICommand"/>
    /// </summary>
    public class CommandString
    {
        private const string SplitChar = " ";

        private const string Quote = "\"";

        private readonly string commandString;

        /// <summary>
        /// creates a new <see cref="CommandString"/> instance for a <see cref="string"/>
        /// </summary>
        /// <param name="commandString"></param>
        public CommandString(string commandString)
        {
            this.commandString = commandString;
        }

        /// <summary>
        /// converts the command string to seperated words needed for <see cref="IPacket"/>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ToCommandWords()
        {
            string[] parts = this.commandString.Split(SplitChar.ToCharArray(),
                                                      StringSplitOptions.RemoveEmptyEntries);

            return this.EnsureQuoted(parts);
        }

        private IEnumerable<string> EnsureQuoted(IEnumerable<string> parts)
        {
            if (!this.commandString.Contains(Quote))
            {
                return parts;
            }

            List<string> partsList = parts.ToList();
            var resultParts = new List<string>();
            var currentPart = new StringBuilder();
            foreach (string part in partsList)
            {
                if (part.StartsWith(Quote))
                {
                    currentPart.Append(part.Replace(Quote, string.Empty))
                               .Append(SplitChar);
                }
                else if (part.EndsWith(Quote))
                {
                    currentPart.Append(part.Replace(Quote, string.Empty));
                    resultParts.Add(currentPart.ToString());
                    currentPart = new StringBuilder();
                }
                else if (currentPart.Length == 0)
                {
                    resultParts.Add(part);
                }
                else if (currentPart.Length > 0)
                {
                    currentPart.Append(part)
                               .Append(SplitChar);
                }
            }

            return resultParts;
        }
    }
}