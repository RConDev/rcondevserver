namespace RConDevServer.Protocol.Dice.Battlefield3.Command.ReservedSlotsList
{
    using System.Collections.Generic;

    /// <summary>
    ///     Remove a player from the VIP list
    /// </summary>
    public class RemoveCommand : ICommand
    {
        /// <summary>
        ///     create a new <see cref="RemoveCommand" /> instance
        /// </summary>
        /// <param name="id"></param>
        public RemoveCommand(string id)
        {
            this.Id = id;
        }

        /// <summary>
        ///     the id of the player to be removed from vip list
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     The command name
        /// </summary>
        public string Command
        {
            get { return CommandNames.ReservedSlotsListRemove; }
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