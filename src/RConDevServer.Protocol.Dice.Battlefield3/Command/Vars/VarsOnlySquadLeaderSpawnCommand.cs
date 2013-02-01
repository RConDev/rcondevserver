namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     Set if players can only spawn on their squad leader
    ///     Delay: Instantaneous
    /// </summary>
    public class VarsOnlySquadLeaderSpawnCommand : VarsCommandBase<bool?>
    {
        /// <summary>
        ///     creates a new <see cref="VarsOnlySquadLeaderSpawnCommand" /> instance
        /// </summary>
        /// <param name="value"></param>
        public VarsOnlySquadLeaderSpawnCommand(bool? value = null)
        {
            this.Value = value;
        }

        /// <summary>
        ///     The command name
        /// </summary>
        public override string Command
        {
            get { return CommandNames.VarsOnlySquadLeaderSpawn; }
        }
    }
}