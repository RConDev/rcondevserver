namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Admin
{
    using System.Collections.Generic;

    /// <summary>
    /// </summary>
    public class KickPlayerCommand : ICommand
    {
        /// <summary>
        ///     Create a new <see cref="KickPlayerCommand" />
        /// </summary>
        /// <param name="soldierName">The Name of the soldier to be kicked</param>
        /// <param name="reason">The reason for kicking the soldier</param>
        public KickPlayerCommand(string soldierName, string reason)
        {
            this.SoldierName = soldierName;
            this.Reason = reason;
        }

        public string SoldierName { get; private set; }

        public string Reason { get; private set; }

        public string Command
        {
            get { return CommandNames.AdminKickPlayer; }
        }

        /// <summary>
        ///     Generates the words needed to create the <see cref="IPacket" />
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ToWords()
        {
            return new[] {this.Command, this.SoldierName, this.Reason};
        }
    }
}