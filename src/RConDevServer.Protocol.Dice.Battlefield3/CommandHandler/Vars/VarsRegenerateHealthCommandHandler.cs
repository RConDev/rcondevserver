namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars
{
    using Command.Vars;

    public class VarsRegenerateHealthCommandHandler 
        : VarsDefaultBoolCommandHandler<VarsRegenerateHealthCommand>
    {
        public override string Command
        {
            get { return Constants.COMMAND_VARS_REGENERATE_HEALTH; }
        }
    }
}