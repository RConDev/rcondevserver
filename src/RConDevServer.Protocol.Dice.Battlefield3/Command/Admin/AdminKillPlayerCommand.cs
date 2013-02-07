namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Admin
{
    using System.Collections.Generic;

    /// <summary>
    ///     Kill a player without any stats effect
    /// </summary>
    public class AdminKillPlayerCommand : ICommand
    {
        /// <summary>
        ///     creates a new instance of <see cref="AdminKillPlayerCommand" />
        /// </summary>
        /// <param name="soldierName"></param>
        public AdminKillPlayerCommand(string soldierName)
        {
            this.SoldierName = soldierName;
        }

        /// <summary>
        ///     the name of the soldier to be killed
        /// </summary>
        public string SoldierName { get; private set; }

        /// <summary>
        ///     The command name
        /// </summary>
        public string Command
        {
            get { return CommandNames.AdminKillPlayer; }
        }

        /// <summary>
        ///     Generates the words needed to create the <see cref="RConDevServer.Protocol.Dice.Common.IPacket" />
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ToWords()
        {
            return new[] {this.Command, this.SoldierName};
        }
    }
}