using System;

namespace RConDevServer.Protocol.Dice.Battlefield3.Ui
{
    public class SessionViewModelEventArgs : EventArgs
    {
        public SessionViewModel SessionViewModel { get; private set; }

        public SessionViewModelEventArgs(SessionViewModel viewModel)
        {
            this.SessionViewModel = viewModel;
        }
    }
}
