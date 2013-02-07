namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars
{
    using Command.Vars;

    public class Vars3DSpottingCommandHandler : VarsDefaultBoolCommandHandler<Vars3DSpottingCommand>
    {
        public override string Command
        {
            get { return Constants.COMMAND_VARS_3_D_SPOTTING; }
        }
    }
}