namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler
{
    using System;
    using System.Collections.Generic;
    using Command;
    using Common;
    using log4net;

    public class CommandHandlers

    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(CommandHandlers));

        protected readonly IDictionary<string, IHandleClientCommands> RegisteredCommandHandlers;

        #region Constructor

        public CommandHandlers()
        {
            this.RegisteredCommandHandlers = new Dictionary<string, IHandleClientCommands>();
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Adds a new <see cref="ICanHandleClientCommands{TCommand}" /> instance to the handler list
        /// </summary>
        /// <param name="handler"></param>
        /// <returns>true if it was successfully added, false if it is already registered</returns>
        public bool RegisterCommandHandler(IHandleClientCommands handler)
        {
            string commandName = handler.Command.ToLower();
            bool isAlreadyRegistered = this.RegisteredCommandHandlers.ContainsKey(commandName);
            if (!isAlreadyRegistered)
            {
                this.RegisteredCommandHandlers.Add(commandName, handler);
                return true;
            }
            return false;
        }

        public bool ProcessCommand(object sender, ClientCommandEventArgs args)
        {
            var session = sender as PacketSession;

            // exit if session is not correctly initialized
            if (session == null || session.Server == null)
            {
                return false;
            }

            // exit if no automatic response is requested
            if (!session.Server.IsAutomaticResponse)
            {
                return false;
            }

            // process registered handlers
            Packet requestPacket = args.PacketData;

            if (requestPacket == null)
            {
                throw new ArgumentNullException("requestPacket");
            }

            if (requestPacket.SequenceId != null && requestPacket.Words.Count > 0)
            {
                string currentCommand = requestPacket.Words[0];
                if (this.RegisteredCommandHandlers.ContainsKey(currentCommand.ToLower()))
                {
                    var commandHandler = this.RegisteredCommandHandlers[currentCommand.ToLower()];
                    var responsePacket = new Packet(requestPacket.Origin,
                                                    true,
                                                    requestPacket.SequenceId.Value);

                    bool responseCreated = false;
                    try
                    {
                        responseCreated = commandHandler.OnCreatingResponse(session, args.Command, requestPacket, responsePacket);
                    }
                    catch (Exception ex)
                    {
                        logger.Error("Failed to create command response", ex);
                    }

                    if (responseCreated)
                    {
                        session.SendToClient(responsePacket);
                        if (commandHandler.CommandEvents.Count > 0)
                        {
                            session.Server.PublishEvents(commandHandler.CommandEvents);
                            commandHandler.CommandEvents.Clear();
                        }
                        return true;
                    }
                }

                return false;
            }
            return false;
        }

        #endregion
    }
}