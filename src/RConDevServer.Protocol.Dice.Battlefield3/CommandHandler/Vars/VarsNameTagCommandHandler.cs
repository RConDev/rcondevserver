namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars
{
    using Command.Vars;

    public class VarsNameTagCommandHandler : VarsDefaultBoolCommandHandler<VarsNameTagCommand>
    {
        public override string Command
        {
            get { return Constants.COMMAND_VARS_NAME_TAG; }
        }
    }
}