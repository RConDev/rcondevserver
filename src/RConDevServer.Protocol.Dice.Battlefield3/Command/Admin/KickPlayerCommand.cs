namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Admin
{
    using System.Collections.Generic;

    /// <summary>
    /// the command for kicking a player from the server
    /// </summary>
    public class KickPlayerCommand : ICommand
    {
        /// <summary>
        /// create a new <see cref="KickPlayerCommand" />
        /// </summary>
        /// <param name="soldierName">The Name of the soldier to be kicked</param>
        /// <param name="reason">The reason for kicking the soldier</param>
        public KickPlayerCommand(string soldierName, string reason)
        {
            this.SoldierName = soldierName;
            this.Reason = reason;
        }

        /// <summary>
        /// the name of the soldier to be kicked
        /// </summary>
        public string SoldierName { get; private set; }

        /// <summary>
        /// the reason for kicking the soldier
        /// </summary>
        public string Reason { get; private set; }

        /// <summary>
        /// The command name 
        /// </summary>
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