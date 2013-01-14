namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars
{
    public class VarsKillCamCommandHandler : VarsDefaultBoolCommandHandler
    {
        public override string Command
        {
            get { return Constants.COMMAND_VARS_KILLCAM; }
        }
    }
}