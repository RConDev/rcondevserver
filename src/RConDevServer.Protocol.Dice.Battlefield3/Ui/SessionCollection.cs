namespace RConDevServer.Protocol.Dice.Battlefield3.Ui
{
    using System.Collections.ObjectModel;

    public class SessionCollection : ObservableCollection<SessionViewModel>
    {
        private volatile object syncRoot = new object();

        public new void Add(SessionViewModel viewModel)
        {
            lock (this.syncRoot)
            {
                base.Add(viewModel);
            }
        }

        public new void Remove(SessionViewModel viewModel)
        {
            lock (this.syncRoot)
            {
                base.Remove(viewModel);
            }
        }
    }
}