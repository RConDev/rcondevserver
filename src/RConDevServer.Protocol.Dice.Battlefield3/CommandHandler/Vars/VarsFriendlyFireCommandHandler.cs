namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars
{
    using Command.Vars;

    public class VarsFriendlyFireCommandHandler : VarsDefaultBoolCommandHandler<VarsFriendlyFireCommand>
    {
        public override string Command
        {
            get { return Constants.COMMAND_VARS_FRIENDLY_FIRE; }
        }
    }
}