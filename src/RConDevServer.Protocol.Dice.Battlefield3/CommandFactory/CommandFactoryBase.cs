namespace RConDevServer.Protocol.Dice.Battlefield3.CommandFactory
{
    using System;
    using System.Collections.Generic;
    using Admin;
    using Command;
    using log4net;

    public abstract class CommandFactoryBase<TCommand> : ICommandFactory<TCommand>
        where TCommand : class, ICommand
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof (KickPlayerCommandFactory));
        
        public abstract TCommand FromWords(IEnumerable<string> commandWords);

        public abstract TCommand Parse(string commandString);

        public bool TryParse(string commandString, out TCommand command)
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
    }
}