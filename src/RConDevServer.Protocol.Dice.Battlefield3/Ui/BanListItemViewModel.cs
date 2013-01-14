namespace RConDevServer.Protocol.Dice.Battlefield3.Ui
{
    using System;
    using Data;

    /// <summary>
    ///     the view model for a single <see cref="BanListItem" />
    /// </summary>
    public class BanListItemViewModel : ViewModelBase
    {
        #region Constructors

        public BanListItemViewModel(Action<Action> synchronousInvoker) : base(synchronousInvoker)
        {
            this.Item = new BanListItem();
        }

        /// <summary>
        ///     Creates a new instance of <see cref="BanListItemViewModel" />
        /// </summary>
        /// <param name="item"></param>
        /// <param name="synchronousInvoker"></param>
        public BanListItemViewModel(BanListItem item, Action<Action> synchronousInvoker)
            : this(synchronousInvoker)
        {
            this.Item = item;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     the wrapped <see cref="BanListItem" />
        /// </summary>
        public BanListItem Item { get; private set; }

        public IdType IdType
        {
            get { return this.Item.IdType; }
            set
            {
                this.Item.IdType = value;
                this.InvokePropertyChanged("IdType");
            }
        }

        public string IdValue
        {
            get { return this.Item.IdValue; }
            set
            {
                this.Item.IdValue = value;
                this.InvokePropertyChanged("IdValue");
            }
        }

        public BanType BanType
        {
            get { return this.Item.BanType; }
            set
            {
                this.Item.BanType = value;
                this.InvokePropertyChanged("BanType");
            }
        }

        public string Reason
        {
            get { return this.Item.Reason; }
            set
            {
                this.Item.Reason = value;
                this.InvokePropertyChanged("Reason");
            }
        }

        public int Rounds
        {
            get { return this.Item.Rounds; }
            set
            {
                this.Item.Rounds = value;
                this.InvokePropertyChanged("Rounds");
            }
        }

        public int Seconds
        {
            get { return this.Item.Seconds; }
            set
            {
                this.Item.Seconds = value;
                this.InvokePropertyChanged("Seconds");
            }
        }

        #endregion
    }
}