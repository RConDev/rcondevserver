namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars
{
    using Command.Vars;

    public class VarsOnlySquadLeaderSpawnCommandHandler
        : VarsDefaultBoolCommandHandler<VarsOnlySquadLeaderSpawnCommand>
    {
        public override string Command
        {
            get { return Constants.COMMAND_VARS_ONLY_SQUAD_LEADER_SPAWN; }
        }
    }
}