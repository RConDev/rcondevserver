namespace RConDevServer.Protocol.Dice.Battlefield3.Command.ReservedSlotsList
{
    using System.Collections.Generic;

    /// <summary>
    ///     Add player to VIP list
    /// </summary>
    public class AddCommand : ICommand
    {
        /// <summary>
        ///     create a new <see cref="AddCommand" /> instance
        /// </summary>
        /// <param name="id"></param>
        public AddCommand(string id)
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