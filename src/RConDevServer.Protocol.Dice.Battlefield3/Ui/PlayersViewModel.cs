namespace RConDevServer.Protocol.Dice.Battlefield3.Ui
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using Data;
    using DataStore;

    public class PlayersViewModel : ViewModelBase
    {
        private readonly IPlayerList players;
        private readonly DataContractSerializer serializer = new DataContractSerializer(typeof (IEnumerable<PlayerInfo>));

        private readonly Battlefield3Server server;

        #region Constructor

        public PlayersViewModel(Battlefield3Server server, Action<Action> synchronousInvoker)
            : base(synchronousInvoker)
        {
            this.server = server;
            this.players = server.PlayerList;


            this.InitializePlayers(this.players.Players);
            this.NewPlayerInfo = new PlayerInfo();

            this.Initialize();
        }

        private void InitializePlayers(IEnumerable<PlayerInfo> playersList)
        {
            if (this.Players != null)
            {
                this.Players.CollectionChanged -= this.PlayersOnCollectionChanged;
            }
            this.Players = new ObservableCollection<PlayerInfo>(playersList);
            this.Players.CollectionChanged += this.PlayersOnCollectionChanged;
            this.InvokePropertyChanged(null);
        }

        #endregion

        public ObservableCollection<PlayerListStoreItem> PlayerListStore { get; private set; }

        public ObservableCollection<PlayerInfo> Players { get; private set; }

        public PlayerInfo NewPlayerInfo { get; set; }

        #region Public Methods

        public void Initialize()
        {
            var playerListRepository = this.server.ServiceLocator.GetService<IPlayerListStoreRepository>();
            IEnumerable<PlayerListStoreItem> playerListStore = playerListRepository.GetAll();

            this.PlayerListStore = new ObservableCollection<PlayerListStoreItem>(playerListStore);
            this.InvokePropertyChanged("PlayerListStore");
        }

        public void SavePlayerList(string listName, bool overrideExisting)
        {
            var playerListRepository = this.server.ServiceLocator.GetService<IPlayerListStoreRepository>();

            PlayerListStoreItem existingItem = null;
            if (this.PlayerListStore.Any(x => x.Label == listName))
            {
                if (!overrideExisting)
                {
                    return;
                }

                existingItem = this.PlayerListStore.FirstOrDefault(x => x.Label == listName);
            }

            byte[] bytes = null;
            using (var memoryStream = new MemoryStream())
            {
                this.serializer.WriteObject(memoryStream, this.Players);
                bytes = memoryStream.ToArray();
            }

            if (bytes != null)
            {
                existingItem = existingItem ?? new PlayerListStoreItem
                    {
                        Label = listName,
                    };
                existingItem.Store = bytes;

                playerListRepository.Save(existingItem);
            }
        }

        public void LoadPlayerList(long playerListStoreId)
        {
            var playerStore = this.server.ServiceLocator.GetService<IPlayerListStoreRepository>();
            PlayerListStoreItem item = playerStore.Get(playerListStoreId);

            LoadPlayerList(item);
        }

        public void LoadPlayerList(PlayerListStoreItem storeItem)
        {
            using (var memoryStream = new MemoryStream(storeItem.Store))
            {
                var players = this.serializer.ReadObject(memoryStream) as IEnumerable<PlayerInfo>;
                if (players != null)
                {
                    this.players.Clear();
                    foreach (PlayerInfo player in players)
                    {
                        this.players.AddPlayer(player);
                    }
                    this.InitializePlayers(this.players.Players);
                }
            }
        }

        #endregion

        #region Event Handler

        private void PlayersOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (PlayerInfo item in args.NewItems)
                    {
                        this.players.AddPlayer(item);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (PlayerInfo item in args.OldItems)
                    {
                        if (this.players.Players.Contains(item))
                        {
                            this.players.RemovePlayer(item);
                        }
                    }
                    break;
            }
            this.InvokePropertyChanged("Players");
        }

        #endregion
    }
}