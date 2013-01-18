namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Admin
{
    using System;
    using System.Collections.Generic;

    public class EventsEnabledCommand : ICommand
    {
        public EventsEnabledCommand(bool? isEnabled = null)
        {
            this.IsEnabled = isEnabled;
        }

        public bool? IsEnabled { get; private set; }

        /// <summary>
        ///     The command name
        /// </summary>
        public string Command
        {
            get { return CommandNames.AdminEventsEnabled; }
        }

        /// <summary>
        ///     Generates the words needed to create the <see cref="RConDevServer.Protocol.Dice.Common.IPacket" />
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ToWords()
        {
            var words = new List<string> {this.Command};
            if (this.IsEnabled.HasValue)
            {
                words.Add(Convert.ToString(this.IsEnabled).ToLower());
            }
            return words;
        }
    }
}