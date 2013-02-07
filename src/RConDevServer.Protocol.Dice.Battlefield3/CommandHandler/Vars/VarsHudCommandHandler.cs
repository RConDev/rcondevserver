namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars
{
    using Command.Vars;

    public class VarsHudCommandHandler : VarsDefaultBoolCommandHandler<VarsHudCommand>
    {
        public override string Command
        {
            get { return Constants.COMMAND_VARS_HUD; }
        }
    }
}