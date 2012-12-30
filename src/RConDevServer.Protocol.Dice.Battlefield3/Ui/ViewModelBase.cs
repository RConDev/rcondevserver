using System;
using System.ComponentModel;
using RConDevServer.Util;

namespace RConDevServer.Protocol.Dice.Battlefield3.Ui
{
    /// <summary>
    /// the basic view model 
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        private readonly object syncRoot = new object();
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
        /// invokes the <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="propertyName">Name of the Property for which the event is invoked</param>
        internal void InvokePropertyChanged(string propertyName)
        {
            lock (syncRoot)
            {
                if (this.PropertyChanged == null) return;

                SynchronousInvoker.Invoke(() =>
                                              {
                                                  var invokationList = PropertyChanged.GetInvocationList();
                                                  foreach (var invDelegate in invokationList)
                                                  {
                                                      invDelegate.DynamicInvoke(this,
                                                                                new PropertyChangedEventArgs(
                                                                                    propertyName));
                                                  }
                                              });
            }
        }

        #endregion
    }
}