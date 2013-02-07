namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars
{
    using Command.Vars;

    public class VarsAutoBalanceCommandHandler : VarsDefaultBoolCommandHandler<VarsAutoBalanceCommand>
    {
        public override string Command
        {
            get { return Constants.COMMAND_VARS_AUTO_BALANCE; }
        }
    }
}