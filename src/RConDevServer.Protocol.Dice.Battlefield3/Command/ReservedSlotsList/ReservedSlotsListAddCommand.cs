namespace RConDevServer.Protocol.Dice.Battlefield3.Command.ReservedSlotsList
{
    using System.Collections.Generic;

    /// <summary>
    ///     Add player to VIP list
    /// </summary>
    public class ReservedSlotsListAddCommand : ICommand
    {
        /// <summary>
        ///     create a new <see cref="ReservedSlotsListAddCommand" /> instance
        /// </summary>
        /// <param name="id"></param>
        public ReservedSlotsListAddCommand(string id)
        {
            this.Id = id;
        }

        /// <summary>
        ///     the id to identify the player on the vip list
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        ///     The command name
        /// </summary>
        public string Command
        {
            get { return CommandNames.ReservedSlotsListAdd; }
        }

        /// <summary>
        ///     Generates the words needed to create the <see cref="RConDevServer.Protocol.Dice.Common.IPacket" />
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ToWords()
        {
            return new[] {this.Command, this.Id};
        }
    }
}