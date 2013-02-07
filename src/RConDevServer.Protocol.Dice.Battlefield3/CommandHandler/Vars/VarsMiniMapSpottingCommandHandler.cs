namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars
{
    using Command.Vars;

    public class VarsMiniMapSpottingCommandHandler 
        : VarsDefaultBoolCommandHandler<VarsMiniMapSpottingCommand>
    {
        public override string Command
        {
            get { return Constants.COMMAND_VARS_MINI_MAP_SPOTTING; }
        }
    }
}