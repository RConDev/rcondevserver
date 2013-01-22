using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory
{
    using Command;
    using Util;

    public abstract class VarsCommandFactoryBase<TCommand, TValue> : CommandFactoryBase<TCommand>
        where TCommand : class, IVarsCommand<TValue>
    {
        protected TCommand BoolFromWords(IEnumerable<string> commandWords, string commandName)
        {
            string[] words = commandWords.ToArray();
            Requires.MinSequenceLength(words, 1, "words");
            Requires.MaxSequenceLength(words, 2, "words");
            Requires.Equal(words[0], commandName, "commandName");
            bool? value = words.Length == 1 ? null : Bool.SafeParse(words[1]);
            return Activator.CreateInstance(typeof(TCommand), value) as TCommand;
        }

        protected TCommand StringFromWords(IEnumerable<string> commandWords, string commandName)
        {
            string[] words = commandWords.ToArray();
            Requires.MinSequenceLength(words, 1, "words");
            Requires.MaxSequenceLength(words, 2, "words");
            Requires.Equal(words[0], commandName, "commandName");
            string value = words.Length == 1 ? null : words[1];
            return Activator.CreateInstance(typeof(TCommand), value) as TCommand;
        }
    }
}
