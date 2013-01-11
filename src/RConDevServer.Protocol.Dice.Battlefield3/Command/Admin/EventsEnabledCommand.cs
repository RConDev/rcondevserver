using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Admin
{
    public class EventsEnabledCommand : ICommand
    {
        public bool? IsEnabled { get; private set; }

        public EventsEnabledCommand(bool? isEnabled = null)
        {
            IsEnabled = isEnabled;
        }

        /// <summary>
        /// The command name 
        /// </summary>
        public string Command { get { return CommandNames.AdminEventsEnabled; } }

        /// <summary>
        /// Generates the words needed to create the <see cref="IPacket"/>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ToWords()
        {
            throw new NotImplementedException();
        }
    }
}
