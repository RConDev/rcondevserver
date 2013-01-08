namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory
{
    using System.Collections.Generic;
    using Command;

    public interface ICommandFactory<out TCommand> where TCommand : class, ICommand
    {
        TCommand FromWords(IEnumerable<string> commandWords);

        TCommand Parse(string commandString);
    }
}
