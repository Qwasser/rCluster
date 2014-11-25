using System;
using System.Windows.Forms;
using _common.NodeInterfaces;
using _common.Protocol;

namespace WorkerNodeApp
{
    public partial class MainForm : Form, ILoadManagerListener
    {
        private readonly IAsyncLoadManager _loadManager;
        private readonly IAsyncWorkerManager _workerManager;
        
        public MainForm(IAsyncLoadManager loadManager, IAsyncWorkerManager workerManager)
        {
            _loadManager = loadManager;
            _workerManager = workerManager;

            _loadManager.AddListener(this);

            InitializeComponent();

            this.FormClosing += MainForm_Closing;

            loadManager.GetMaxLimit();
            loadManager.GetStatus();
        }

        private void WokersUserLimitNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (WorkersUserLimitNumericUpDown.Value == 0)
            {
                LockedRadioButton.Checked = true;
            }

            ApplyButton.Enabled = true;
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

        public void OnWorkersMaxLimitRetreived(int limit)
        {
            WorkersUserLimitNumericUpDown.Maximum = limit;
        }

        public void OnWorkersCurrentLimitRetreived(int limit)
        {
            throw new NotImplementedException();
        }

        public void OnLoadStatusRetreived(LoadStatus status)
        {
            ApplyStaus(status);
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
                        if (FreeRadioButton.InvokeRequired)
                        {
                            FreeRadioButton.Invoke(new MethodInvoker(delegate { FreeRadioButton.Checked = true; }));
                        }
                        else
                        {
                            FreeRadioButton.Checked = true;
                        }
                        break;
                    }
                case LoadStatusType.Limited:
                    {
                        if (LimitedRadioButton.InvokeRequired)
                        {
                            WorkersUserLimitNumericUpDown.Invoke(new MethodInvoker(delegate
                            {
                                WorkersUserLimitNumericUpDown.Value = status.Limit;
                            }));

                            LimitedRadioButton.Invoke(new MethodInvoker(delegate { LimitedRadioButton.Checked = true; }));
                        }
                        else
                        {
                            WorkersUserLimitNumericUpDown.Value = status.Limit;
                            LimitedRadioButton.Checked = true;    
                        }
                        break;
                    }
                case LoadStatusType.Locked:
                    {
                        if (LockedRadioButton.InvokeRequired)
                        {
                            LockedRadioButton.Invoke(new MethodInvoker(delegate { LockedRadioButton.Checked = true; }));
                        }
                        else
                        {
                            LockedRadioButton.Checked = true;
                        }
                        break;
                    }
                case LoadStatusType.Adaptive:
                    {
                        break;
                    }
            }
            
            ApplyButton.Enabled = false;
            LoadStatusLabel.Text = status.ToString();
        }

        private void ApplyButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (LimitedRadioButton.Checked)
            {
                WorkersUserLimitNumericUpDown.Enabled = true;

                _loadManager.SetStatus(new LoadStatus() { Limit = (int)WorkersUserLimitNumericUpDown.Value, LoadType = LoadStatusType.Limited });
            }

            if (FreeRadioButton.Checked)
            {
                WorkersUserLimitNumericUpDown.Enabled = false;

                _loadManager.SetStatus(new LoadStatus() { LoadType = LoadStatusType.Free });
            }

            if (LockedRadioButton.Checked)
            {
                WorkersUserLimitNumericUpDown.Enabled = false;

                _loadManager.SetStatus(new LoadStatus() { LoadType = LoadStatusType.Locked });
            }

            ApplyButton.Enabled = false;
        }

        private void LockedRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (LockedRadioButton.Checked)
            {
                WorkersUserLimitNumericUpDown.Enabled = false;
            }

            ApplyButton.Enabled = true;
        }

        private void LimitedRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (LimitedRadioButton.Checked)
            {
                WorkersUserLimitNumericUpDown.Enabled = true;
            }

            ApplyButton.Enabled = true;
        }

        private void FreeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (FreeRadioButton.Checked)
            {
                WorkersUserLimitNumericUpDown.Enabled = false;
            }

            ApplyButton.Enabled = true;
        }

        private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _common.SocketConnection.WorkerNodeSocket.StopListening();
        }
    }
}
