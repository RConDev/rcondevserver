namespace RConDevServer.Protocol.Dice.Battlefield3.Ui
{
    using System;

    public class SessionViewModelEventArgs : EventArgs
    {
        public SessionViewModelEventArgs(SessionViewModel viewModel)
        {
            this.SessionViewModel = viewModel;
        }

        public SessionViewModel SessionViewModel { get; private set; }
    }
}