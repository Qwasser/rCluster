﻿using System;
using System.Windows.Forms;
using WorkerNode;
using _common.Protocol;

namespace WorkerNodeApp
{
    public partial class MainForm : Form
    {
        private readonly IWorkerManager _workerManager;

        private readonly ILoadManager _loadManager;

        public MainForm(IWorkerManager workerManager = null, ILoadManager loadManager = null)
        {
            _workerManager = workerManager ?? new WorkerManager();
            _loadManager = loadManager ?? new LoadManager(_workerManager, new LoadStatus(){LoadType = LoadStatusType.Free});

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
            if (WokersUserLimitNumericUpDown.Value == 0)
            {
                LockedRadioButton.Checked = true;
            }

            _loadManager.SetStatus(new LoadStatus() { Limit = (int)WokersUserLimitNumericUpDown.Value, LoadType = LoadStatusType.Limited });
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            TrayIcon.BalloonTipTitle = "Minimize to Tray App";
            TrayIcon.BalloonTipText = "You have successfully minimized your form.";

            if (FormWindowState.Minimized == WindowState)
            {
                TrayIcon.Visible = true;
                TrayIcon.ShowBalloonTip(500);
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
