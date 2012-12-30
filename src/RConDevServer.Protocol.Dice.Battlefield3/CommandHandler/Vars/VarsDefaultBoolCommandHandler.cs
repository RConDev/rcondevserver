namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars
{
    public abstract class VarsDefaultBoolCommandHandler : VarsDefaultCommandHandler
    {
        protected override object ConvertToValue(string valueString)
        {
            bool boolValue = false;
            if (bool.TryParse(valueString, out boolValue))
            {
                return boolValue;
            }
            return null;
        }
    }
}