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
        ///     Generates the words needed to create the <see cref="IPacket" />
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ToWords()
        {
            throw new NotImplementedException();
        }
    }
}