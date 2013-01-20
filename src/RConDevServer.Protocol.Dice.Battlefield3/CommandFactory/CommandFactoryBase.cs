namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory
{
    using System;
    using System.Collections.Generic;
    using Admin;
    using Command;
    using log4net;

    /// <summary>
    ///     abstract base implementation for <see cref="ICommandFactory{TCommand}" />
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    public abstract class CommandFactoryBase<TCommand> : ICommandFactory<TCommand>
        where TCommand : class
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof (CommandFactoryBase<TCommand>));

        /// <summary>
        ///     creates a command from the DICE <see cref="RConDevServer.Protocol.Dice.Common.Packet" /> words
        /// </summary>
        /// <param name="commandWords"></param>
        /// <returns></returns>
        public abstract TCommand FromWords(IEnumerable<string> commandWords);

        /// <summary>
        ///     parses the command out of a <see cref="string" />
        /// </summary>
        /// <param name="commandString"></param>
        /// <returns>
        ///     the <see cref="ICommand" /> implementation if found
        /// </returns>
        public TCommand Parse(string commandString)
        {
            IEnumerable<string> words = this.ExtractCommandWords(commandString);
            return this.FromWords(words);
        }

        /// <summary>
        ///     tries to parse the command string
        /// </summary>
        /// <param name="commandString">the command string</param>
        /// <param name="command">the command parsed from string</param>
        /// <returns></returns>
        protected bool TryParse(string commandString, out TCommand command)
        {
            try
            {
                command = this.Parse(commandString);
                return true;
            }
            catch (Exception)
            {
                logger.InfoFormat("Failed parsing '{0}'", commandString);
                command = null;
                return false;
            }
        }

        /// <summary>
        ///     extracts the words from the command string
        /// </summary>
        /// <param name="commandString"></param>
        /// <returns></returns>
        protected IEnumerable<string> ExtractCommandWords(string commandString)
        {
            return new CommandString(commandString)
                .CommandWords();
        }
    }
}