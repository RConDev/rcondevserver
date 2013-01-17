namespace RConDevServer.Protocol.Dice.Battlefield3.Command.ReservedSlotsList
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     If set to true, a non-VIP player will be kicked to give room when a VIP enters the queue.
    /// </summary>
    public class AggressiveJoinCommand : ICommand
    {
        /// <summary>
        ///     create a new <see cref="AggressiveJoinCommand" /> instance
        /// </summary>
        /// <param name="enabled"></param>
        public AggressiveJoinCommand(bool? enabled)
        {
            this.Enabled = enabled;
        }

        /// <summary>
        ///     is aggressive join enabled
        /// </summary>
        public bool? Enabled { get; set; }

        /// <summary>
        ///     The command name
        /// </summary>
        public string Command
        {
            get { return CommandNames.ReservedSlotsListAggressiveJoin; }
        }

        /// <summary>
        ///     Generates the words needed to create the <see cref="RConDevServer.Protocol.Dice.Common.IPacket" />
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ToWords()
        {
            var words = new List<string> {this.Command};
            if (this.Enabled.HasValue)
            {
                words.Add(Convert.ToString(this.Enabled));
            }
            return words;
        }
    }
}