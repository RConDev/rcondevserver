namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory.Admin
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.Admin;
    using Util;

    /// <summary>
    ///     implementation of <see cref="ICommandFactory{TCommand}" /> for <see cref="AdminEventsEnabledCommand" />
    /// </summary>
    public class EventsEnabledCommandFactory : CommandFactoryBase<AdminEventsEnabledCommand>
    {
        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public override AdminEventsEnabledCommand FromWords(IEnumerable<string> commandWords)
        {
            string[] words = commandWords.ToArray();
            Requires.Equal(words[0], CommandNames.AdminEventsEnabled, "commandName");
            bool? isEnabled = null;
            if (words.Length >= 2)
            {
                isEnabled = Bool.SafeParse(words[1]);
            }
            return new AdminEventsEnabledCommand(isEnabled);
        }
    }
}