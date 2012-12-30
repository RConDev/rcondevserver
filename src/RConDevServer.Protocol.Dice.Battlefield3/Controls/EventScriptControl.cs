using System;
using System.ComponentModel;
using System.Windows.Forms;
using RConDevServer.Protocol.Dice.Battlefield3.Ui;
using RConDevServer.Resource.Properties;

namespace RConDevServer.Protocol.Dice.Battlefield3.Controls
{
    /// <summary>
    /// This user control is responsible for the user interface for scripting server events
    /// </summary>
    public partial class EventScriptControl : UserControl
    {
        private EventScriptViewModel dataContext;

        #region Constructor

        public EventScriptControl()
        {
            InitializeComponent();

            this.pbRunScript.Image = Resources.gnome_web_start;
        }

        #endregion

        #region Public Properties

        public EventScriptViewModel DataContext
        {
            get { return this.dataContext; }
            set
            {
                this.dataContext = value;
                if (this.dataContext != null)
                {
                    this.dbsEventScript.DataSource = dataContext;
                    this.dbsEventScript.ResetBindings(false);
                }
            }
        }

        #endregion

        #region Event Handler

        private void PbRunScriptClick(object sender, EventArgs e)
        {
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += BackgroundWorkerOnDoWork;
            backgroundWorker.RunWorkerCompleted += BackgroundWorkerOnRunWorkerCompleted;
            this.pbRunScript.Image = Resources.gnome_web_pause;
            this.rtbScript.Enabled = false;
            backgroundWorker.RunWorkerAsync(this.dataContext);
        }

        private void BackgroundWorkerOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
            this.pbRunScript.Image = Resources.gnome_web_start;
            this.rtbScript.Enabled = true;
        }

        private void BackgroundWorkerOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            var scriptViewModel = doWorkEventArgs.Argument as EventScriptViewModel;
            if (scriptViewModel != null)
            {
                scriptViewModel.RunScript();
            }
        }

        #endregion

        #region Private Methods



        #endregion
    }
}
