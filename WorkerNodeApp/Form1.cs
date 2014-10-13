using System;
using System.Windows.Forms;
using WorkerNode;
using _common.NodeInterfaces;
using _common.Protocol;

namespace WorkerNodeApp
{
    public partial class MainForm : Form, ILoadManagerListener
    {
        private readonly IAsyncLoadManager _loadManager;
        private readonly IAsyncWorkerManager _workerManager;
        private bool _initialized;

        public MainForm(IAsyncLoadManager loadManager, IAsyncWorkerManager workerManager)
        {
            _initialized = false;

            _loadManager = loadManager;
            _workerManager = workerManager;

            _loadManager.AddListener(this);

            InitializeComponent();

            loadManager.GetMaxLimit();
            loadManager.GetStatus();
        }

        private void LimitedRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (LimitedRadioButton.Checked)
            {
                WokersUserLimitNumericUpDown.Enabled = true;

                _loadManager.SetStatus(new LoadStatus() { Limit = (int) WokersUserLimitNumericUpDown.Value, LoadType = LoadStatusType.Limited});
            }
        }

        private void FreeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (FreeRadioButton.Checked)
            {
                WokersUserLimitNumericUpDown.Enabled = false;

                _loadManager.SetStatus(new LoadStatus() { LoadType = LoadStatusType.Free});
            }
        }

        private void LockedRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (LockedRadioButton.Checked)
            {
                WokersUserLimitNumericUpDown.Enabled = false;

                _loadManager.SetStatus(new LoadStatus() { LoadType = LoadStatusType.Locked });
            }
        }

        private void WokersUserLimitNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (_initialized)
            {
                if (WokersUserLimitNumericUpDown.Value == 0)
                {
                    LockedRadioButton.Checked = true;
                }

                _loadManager.SetStatus(new LoadStatus()
                {
                    Limit = (int) WokersUserLimitNumericUpDown.Value,
                    LoadType = LoadStatusType.Limited
                });
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                TrayIcon.Visible = true;
                Hide();
            }
            else if (FormWindowState.Normal == WindowState)
            {
                TrayIcon.Visible = false;
            }
        }

        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }


        public void OnMaxLimitRetreived(int limit)
        {
            WokersUserLimitNumericUpDown.Maximum = limit;
        }

        public void OnCurrentLimitRetreived(int limit)
        {
            throw new NotImplementedException();
        }

        public void OnLoadStatusRetreived(LoadStatus status)
        {
            ApplyStaus(status);

            if (!_initialized)
            {
                _initialized = true;
                _workerManager.AddAllWorkers();
            }
        }

        public void OnLoadStatusChanged(LoadStatus status)
        {
            ApplyStaus(status);
        }

        private void ApplyStaus(LoadStatus status)
        {
            switch (status.LoadType)
            {
                case LoadStatusType.Free:
                    {
                        FreeRadioButton.Checked = true;
                        break;
                    }
                case LoadStatusType.Limited:
                    {
                        WokersUserLimitNumericUpDown.Value = status.Limit;
                        LimitedRadioButton.Checked = true;
                        break;
                    }
                case LoadStatusType.Locked:
                    {
                        LockedRadioButton.Checked = true;
                        break;
                    }
                case LoadStatusType.Adaptive:
                    {
                        break;
                    }
            }
        }
    }
}
