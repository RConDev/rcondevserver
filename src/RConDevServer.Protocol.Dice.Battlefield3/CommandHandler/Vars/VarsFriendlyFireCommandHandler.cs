namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars
{
    public class VarsFriendlyFireCommandHandler : VarsDefaultBoolCommandHandler
    {
        public override string Command
        {
            get { return Constants.COMMAND_VARS_FRIENDLY_FIRE; }
        }
    }
}