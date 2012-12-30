using System.Collections.ObjectModel;

namespace RConDevServer.Protocol.Dice.Battlefield3.Ui
{
    public class SessionCollection : ObservableCollection<SessionViewModel>
    {
        private volatile object syncRoot = new object();

        public new void Add(SessionViewModel viewModel)
        {
            lock (syncRoot)
            {
                base.Add(viewModel);
            }
        }

        public new void Remove(SessionViewModel viewModel)
        {
            lock(syncRoot)
            {
                base.Remove(viewModel);
            }
        }
    }
}
