namespace RConDevServer.Protocol.Dice.Battlefield3.Command.ReservedSlotsList
{
    using System.Collections.Generic;

    public class ReservedSlotsListClearCommand : ICommand
    {
        /// <summary>
        ///     The command name
        /// </summary>
        public string Command
        {
            get { return CommandNames.ReservedSlotsListClear; }
        }

        /// <summary>
        ///     Generates the words needed to create the <see cref="RConDevServer.Protocol.Dice.Common.IPacket" />
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ToWords()
        {
            return new[] {this.Command};
        }
    }
}