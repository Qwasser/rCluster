using System;
using System.Windows.Forms;
using WorkerNode;
using _common.Protocol;

namespace WorkerNodeApp
{
    public partial class MainForm : Form
    {
        private readonly ILoadManager _loadManager;
        private readonly IWorkerManager _workerManager;
        private bool _initialized;

        public MainForm(ILoadManager loadManager, IWorkerManager workerManager)
        {
            _initialized = false;


            _loadManager = loadManager;
            _workerManager = workerManager;

            InitializeComponent();

            WokersUserLimitNumericUpDown.Value = _loadManager.GetMaxLimit();
            WokersUserLimitNumericUpDown.Maximum = _loadManager.GetMaxLimit();

            switch (_loadManager.GetStatus().LoadType)
            {
                case LoadStatusType.Free:
                {
                    FreeRadioButton.Checked = true;
                    break;
                }
                case LoadStatusType.Limited:
                {
                    WokersUserLimitNumericUpDown.Value = _loadManager.GetStatus().Limit;
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


            _workerManager.AddAllWorkers();

            _initialized = true;
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


    }
}
