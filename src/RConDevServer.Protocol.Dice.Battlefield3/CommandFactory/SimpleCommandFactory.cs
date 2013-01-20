namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory
{
    using System.Collections.Generic;
    using System.Linq;
    using Command;
    using Command.MapList;
    using Util;

    public abstract class SimpleCommandFactory<TCommand> : CommandFactoryBase<TCommand> 
        where TCommand : class, ICommand
    {
        protected TCommand SimpleCommandFromWords(IEnumerable<string> commandWords, string commandName)
            
        {
            string[] words = commandWords.ToArray();
            Requires.SequenceLength(words, 1, "words");
            Requires.Equal(words[0], commandName, "commandName");
            return default(TCommand);
        }
    }
}