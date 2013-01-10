namespace RConDevServer.Protocol.Dice.Battlefield3.Command
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CommandString
    {
        private const string SplitChar = " ";

        private const string Quote = "\"";

        private readonly string commandString;

        public CommandString(string commandString)
        {
            this.commandString = commandString;
        }

        public IEnumerable<string> CommandWords()
        {
            var parts = this.commandString.Split(SplitChar.ToCharArray(),
                                           StringSplitOptions.RemoveEmptyEntries);
            
            return EnsureQuoted(parts);
        }

        private IEnumerable<string> EnsureQuoted(IEnumerable<string> parts)
        {
            if (!this.commandString.Contains(Quote))
            {
                return parts;
            }

            var partsList = parts.ToList();
            var resultParts = new List<string>();
            var currentPart = new StringBuilder();
            foreach (var part in partsList)
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