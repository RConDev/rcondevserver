namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars
{
    using Command;
    using Util;

    public abstract class VarsDefaultBoolCommandHandler<TVarsCommand> 
        : VarsDefaultCommandHandler<TVarsCommand, bool?>
        where TVarsCommand : class, IVarsCommand<bool?>
    {
        protected override bool? ConvertToValue(string valueString)
        {
            return Bool.SafeParse(valueString);
        }
    }
}