using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using RConDevServer.Protocol.Dice.Battlefield3.EventSender.Player;
using RConDevServer.Protocol.Dice.Battlefield3.EventSender.Punkbuster;
using RConDevServer.Protocol.Dice.Battlefield3.EventSender.Server;
using RConDevServer.Protocol.Interface;

namespace RConDevServer.Protocol.Dice.Battlefield3.Ui
{
    using EventSender;

    /// <summary>
    /// ViewModel for the Event Script
    /// </summary>
    public class EventScriptViewModel : ViewModelBase
    {
        public Battlefield3Server Server { get; set; }
        private string script = string.Empty;

        private const string space = " ";

        #region Events

        /// <summary>
        /// this event is invoked, when an event should be sent to all connected clients
        /// </summary>
        public event EventHandler<EventSenderEventArgs> EventRaised;

        public event EventHandler<MessageEventArgs> ErrorCreatingEvent;

        #endregion

        #region Constructor

        public EventScriptViewModel(Battlefield3Server server, Action<Action> synchronousInvoker)
            : base(synchronousInvoker)
        {
            Server = server;
            EventSenders = new List<ICanSendEvents>
                               {
                                   new PlayerOnAuthenticatedEventSender(),
                                   new PlayerOnJoinEventSender(),
                                   new PlayerOnLeaveEventSender(),
                                   new PlayerOnSpawnEventSender(),
                                   new PlayerOnKillEventSender(),
                                   new PlayerOnChatEventSender(),
                                   new PlayerOnSquadChangeEventSender(),
                                   new PlayerOnTeamChangeEventSender(),
                                   new PunkbusterOnMessageEventSender(),
                                   new ServerOnLevelLoadedEventSender(server.AvailableMaps),
                                   new ServerOnRoundOverEventSender(),
                                   new ServerOnMaxPlayerCountChangedEventSender(),
                               };
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// the script itself
        /// </summary>
        public string Script
        {
            get { return script; }
            set
            {
                script = value;
                InvokePropertyChanged("Script");
            }
        }

        /// <summary>
        /// list of event senders registered 
        /// </summary>
        public IEnumerable<ICanSendEvents> EventSenders { get; private set; }

        #endregion

        #region Public Methods

        public void RunScript()
        {
            var lines = Script.Split(Environment.NewLine.ToCharArray());
            foreach (var line in lines)
            {
                if (line.StartsWith("sleep"))
                {
                    var parts = line.Split(space.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 2)
                    {
                        int sleepValue = 0;
                        if (int.TryParse(parts[1], out sleepValue))
                        {
                            Thread.Sleep(sleepValue * 1000);
                        }
                    }
                    continue;
                }

                var eventSender = ParseLineForEvent(line);
                if (eventSender != null)
                {
                    InvokeEventRaised(eventSender);
                }
            }
        }

        #endregion

        #region Private Methods

        private ICanSendEvents ParseLineForEvent(string line)
        {
            ICanSendEvents eventSender = null;
            var parts = line.Split(space.ToCharArray(), 2, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length > 0)
            {
                var eventCommand = parts[0];
                eventSender = this.EventSenders.FirstOrDefault(x => x.EventCommand == eventCommand);

                if (eventSender != null)
                {
                    if (parts.Count() > 1)
                    {
                        var commandParameters = parts[1];
                        var commandParameterList = commandParameters.Split(",".ToCharArray(),
                                                                           StringSplitOptions.RemoveEmptyEntries);
                        if (!eventSender.SetParameters(commandParameterList))
                        {
                            InvokeErrorCreatingEvent("Parameters not set correctly");
                            eventSender = null;
                        }
                    }
                }
                else
                {
                    InvokeErrorCreatingEvent("Event not found");
                }
            }
            return eventSender;
        }

        #endregion

        #region Invoke Events

        internal void InvokeEventRaised(ICanSendEvents eventSender)
        {
            if (EventRaised != null)
            {
                EventRaised.Invoke(this, new EventSenderEventArgs(eventSender));
            }
        }

        internal void InvokeErrorCreatingEvent(string message)
        {
            if (ErrorCreatingEvent != null)
            {
                ErrorCreatingEvent.Invoke(this, new MessageEventArgs(message));
            }
            log.Debug(message);
        }

        #endregion
    }
}
