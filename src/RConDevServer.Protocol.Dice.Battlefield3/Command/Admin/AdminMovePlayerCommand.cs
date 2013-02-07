namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Admin
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     Move a player to another team and/or squad
    /// </summary>
    /// <remarks>
    ///     Only works if player is dead. This command will kill player if forceKill is true
    /// </remarks>
    public class AdminMovePlayerCommand : ICommand
    {
        /// <summary>
        ///     create a new instance of <see cref="AdminMovePlayerCommand" />
        /// </summary>
        /// <param name="soldierName"></param>
        /// <param name="teamId"></param>
        /// <param name="squadId"></param>
        /// <param name="force"></param>
        public AdminMovePlayerCommand(string soldierName, int teamId, int squadId, bool force)
        {
            this.SoldierName = soldierName;
            this.TeamId = teamId;
            this.SquadId = squadId;
            this.Force = force;
        }

        /// <summary>
        ///     the name of the soldier / player to be moved
        /// </summary>
        public string SoldierName { get; private set; }

        /// <summary>
        ///     target team id the player should be moved to
        /// </summary>
        public int TeamId { get; private set; }

        /// <summary>
        ///     target squad id the player should be moved to
        /// </summary>
        public int SquadId { get; private set; }

        /// <summary>
        ///     force move the player and kill him before moving him
        /// </summary>
        public bool Force { get; private set; }

        /// <summary>
        ///     The command name
        /// </summary>
        public string Command
        {
            get { return CommandNames.AdminMovePlayer; }
        }

        /// <summary>
        ///     Generates the words needed to create the <see cref="RConDevServer.Protocol.Dice.Common.IPacket" />
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ToWords()
        {
            return new[]
                {
                    this.Command,
                    this.SoldierName,
                    Convert.ToString(this.TeamId),
                    Convert.ToString(this.SquadId),
                    Convert.ToString(this.Force).ToLower()
                };
        }
    }
}