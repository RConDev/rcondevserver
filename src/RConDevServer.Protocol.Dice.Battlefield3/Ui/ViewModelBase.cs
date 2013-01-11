namespace RConDevServer.Protocol.Dice.Battlefield3.Ui
{
    using System;
    using System.ComponentModel;
    using System.Reflection;
    using log4net;

    /// <summary>
    ///     the basic view model
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        protected static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #region Constructors

        public ViewModelBase(Action<Action> synchronousInvoker)
        {
            this.SynchronousInvoker = synchronousInvoker;
        }

        #endregion

        #region Public Properties

        public Action<Action> SynchronousInvoker { get; private set; }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Invoke Events

        /// <summary>
        ///     invokes the <see cref="PropertyChanged" /> event
        /// </summary>
        /// <param name="propertyName">Name of the Property for which the event is invoked</param>
        internal void InvokePropertyChanged(string propertyName)
        {
            lock (this.syncRoot)
            {
                if (this.PropertyChanged == null)
                {
                    return;
                }

                this.SynchronousInvoker.Invoke(() =>
                    {
                        Delegate[] invokationList = this.PropertyChanged.GetInvocationList();
                        foreach (Delegate invDelegate in invokationList)
                        {
                            invDelegate.DynamicInvoke(this,
                                                      new PropertyChangedEventArgs(
                                                          propertyName));
                        }
                    });
            }
        }

        #endregion

        private readonly object syncRoot = new object();
    }
}