namespace RConDevServer.Protocol.Dice.Battlefield3.Ui
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using EventSender;
    using EventSender.Player;
    using EventSender.Punkbuster;
    using EventSender.Server;

    /// <summary>
    ///     ViewModel for the Event Script
    /// </summary>
    public class EventScriptViewModel : ViewModelBase
    {
        private const string space = " ";

        #region Events

        /// <summary>
        ///     this event is invoked, when an event should be sent to all connected clients
        /// </summary>
        public event EventHandler<EventSenderEventArgs> EventRaised;

        public event EventHandler<MessageEventArgs> ErrorCreatingEvent;

        #endregion

        #region Constructor

        public EventScriptViewModel(Battlefield3Server server, Action<Action> synchronousInvoker)
            : base(synchronousInvoker)
        {
            this.Server = server;
            this.EventSenders = new List<ICanSendEvents>
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
        ///     the script itself
        /// </summary>
        public string Script
        {
            get { return this.script; }
            set
            {
                this.script = value;
                this.InvokePropertyChanged("Script");
            }
        }

        /// <summary>
        ///     list of event senders registered
        /// </summary>
        public IEnumerable<ICanSendEvents> EventSenders { get; private set; }

        #endregion

        #region Public Methods

        public void RunScript()
        {
            string[] lines = this.Script.Split(Environment.NewLine.ToCharArray());
            foreach (string line in lines)
            {
                if (line.StartsWith("sleep"))
                {
                    string[] parts = line.Split(space.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 2)
                    {
                        int sleepValue = 0;
                        if (int.TryParse(parts[1], out sleepValue))
                        {
                            Thread.Sleep(sleepValue*1000);
                        }
                    }
                    continue;
                }

                ICanSendEvents eventSender = this.ParseLineForEvent(line);
                if (eventSender != null)
                {
                    this.InvokeEventRaised(eventSender);
                }
            }
        }

        #endregion

        #region Private Methods

        private ICanSendEvents ParseLineForEvent(string line)
        {
            ICanSendEvents eventSender = null;
            string[] parts = line.Split(space.ToCharArray(), 2, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length > 0)
            {
                string eventCommand = parts[0];
                eventSender = this.EventSenders.FirstOrDefault(x => x.EventCommand == eventCommand);

                if (eventSender != null)
                {
                    if (parts.Count() > 1)
                    {
                        string commandParameters = parts[1];
                        string[] commandParameterList = commandParameters.Split(",".ToCharArray(),
                                                                                StringSplitOptions.RemoveEmptyEntries);
                        if (!eventSender.SetParameters(commandParameterList))
                        {
                            this.InvokeErrorCreatingEvent("Parameters not set correctly");
                            eventSender = null;
                        }
                    }
                }
                else
                {
                    this.InvokeErrorCreatingEvent("Event not found");
                }
            }

            return eventSender;
        }

        #endregion

        #region Invoke Events

        internal void InvokeEventRaised(ICanSendEvents eventSender)
        {
            if (this.EventRaised != null)
            {
                this.EventRaised.Invoke(this, new EventSenderEventArgs(eventSender));
            }
        }

        internal void InvokeErrorCreatingEvent(string message)
        {
            if (this.ErrorCreatingEvent != null)
            {
                this.ErrorCreatingEvent.Invoke(this, new MessageEventArgs(message));
            }
            log.Debug(message);
        }

        #endregion

        private string script = string.Empty;
        public Battlefield3Server Server { get; set; }
    }
}