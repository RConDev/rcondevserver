using System;
using System.Collections.Generic;
 

namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler
{
    public class CommandHandlers
    {
     protected readonly IDictionary<string, ICanHandleClientCommands> CommandReveiverAccess;

        #region Constructor

        public CommandHandlers()
        {
            CommandReveiverAccess = new Dictionary<string, ICanHandleClientCommands>(); 
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds a new <see cref="ICanHandleClientCommands"/> instance to the handler list
        /// </summary>
        /// <param name="handler"></param>
        /// <returns>true if it was successfully added, false if it is already registered</returns>
        public bool RegisterCommandHandler(ICanHandleClientCommands handler)
        {
            bool isAlreadyRegistered = CommandReveiverAccess.ContainsKey(handler.Command.ToLower());
            if (!isAlreadyRegistered)
            {
                CommandReveiverAccess.Add(handler.Command.ToLower(), handler);
                return true;
            }
            return false;
        }

        public bool ProcessCommand(object sender, PacketDataEventArgs args)
        {
            var session = sender as PacketSession;

            // exit if session is not correctly initialized
            if (session == null || session.Server == null) return false;

            // exit if no automatic response is requested
            if (!session.Server.IsAutomaticResponse) return false;

            // process registered handlers
            Packet requestPacket = args.PacketData;

            if (requestPacket == null) throw new ArgumentNullException("requestPacket");

            if (requestPacket.SequenceId != null && requestPacket.Words.Count > 0)
            {
                var currentCommand = requestPacket.Words[0];
                if (CommandReveiverAccess.ContainsKey(currentCommand.ToLower()))
                {
                    var commandHandler = CommandReveiverAccess[currentCommand.ToLower()];
                    var responsePacket = new Packet(requestPacket.Origin,
                                                    true,
                                                    requestPacket.SequenceId.Value,
                                                    new List<string>());
                    if (commandHandler.OnCreatingResponse(session, requestPacket, responsePacket))
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