using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using NodeProxy;
using _common.Protocol;

namespace MasterNodeApp
{
    /// <summary>
    /// Interaction logic for NodeProxyGui.xaml
    /// </summary>
    public partial class NodeProxyGui : INodeProxyListener
    {
        private readonly NodeProxy.NodeProxy _nodeProxy;
        private LoadStatus _currStatus;
        private int _maxWorkersLimit;

        public NodeProxyGui(NodeProxy.NodeProxy nodeProxy)
        {
            _nodeProxy = nodeProxy;
            _nodeProxy.AddListener(this);

            InitializeComponent();

            HostNameLabel.Content = nodeProxy.Configuration.Name;
            HostNameLabelIn.Content = nodeProxy.Configuration.Name;
            AdressLabel.Content = "Adderess: " + nodeProxy.Configuration.Ip + ":" +  nodeProxy.Configuration.Port;

        }

        private void SettingsExpander_Expanded(object sender, RoutedEventArgs e)
        {
            Height = 145;
        }

        private void SettingsExpander_Collapsed(object sender, RoutedEventArgs e)
        {
            Height = 40;
        }

        public void OnWorkersCountRetreived(int count)
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.BeginInvoke(new Action(delegate
                {
                    WorkersCountLabel.Content = count.ToString(CultureInfo.InvariantCulture);
                }));

                return;
            }

            WorkersCountLabel.Content = count.ToString(CultureInfo.InvariantCulture);
        }

        public void OnWorkerManagerError(string error)
        {
            throw new NotImplementedException();
        }

        public void OnRedisIpRetrived(string ip)
        {
            throw new NotImplementedException();
        }

        public void OnWorkersLoadRetreived(float load)
        {
            load = (float) Math.Round(load);

            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.BeginInvoke(new Action(delegate
                {
                    WorkersLoadLabel.Content = load.ToString(CultureInfo.InvariantCulture);
                    SystemInfoLabel.Content = "Load: " + load.ToString(CultureInfo.InvariantCulture);
                }));

                return;
            }

            WorkersLoadLabel.Content = load.ToString(CultureInfo.InvariantCulture);
            SystemInfoLabel.Content = "Load: " + load.ToString(CultureInfo.InvariantCulture);
        }

        public void OnWorkersMemoryRetreived(float memory)
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.BeginInvoke(new Action(delegate
                {
                    WorkersMemoryLabel.Content = memory.ToString(CultureInfo.InvariantCulture);
                }));

                return;
            }
            
            WorkersMemoryLabel.Content = memory.ToString(CultureInfo.InvariantCulture);
        }

        public void OnLibraryListRetreived(List<string> libraryList)
        {
            throw new NotImplementedException();
        }

        public void OnHasLibrary(string libraryName, bool hasLibrary)
        {
            throw new NotImplementedException();
        }

        public void OnLibraryInstalled(string libraryName)
        {
            throw new NotImplementedException();
        }

        public void OnLibraryManagerError(string msg)
        {
            throw new NotImplementedException();
        }

        public void OnWorkersMaxLimitRetreived(int limit)
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.BeginInvoke(new Action(delegate
                {
                    _maxWorkersLimit = limit;
                    MaxWorkerLimitLabel.Content = "Max Workers Limit: " + _maxWorkersLimit.ToString(CultureInfo.InvariantCulture);
                }));

                return;
            }
            
            _maxWorkersLimit = limit;
            MaxWorkerLimitLabel.Content = "Max Workers Limit: " + _maxWorkersLimit.ToString(CultureInfo.InvariantCulture);
        }

        public void OnWorkersCurrentLimitRetreived(int limit)
        {
            throw new NotImplementedException();
        }

        public void OnTotalMemoryRetreived(float memory)
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.BeginInvoke(new Action(delegate
                {
                    NodeMemoryLabel.Content = memory.ToString(CultureInfo.InvariantCulture);
                }));

                return;
            }

            NodeMemoryLabel.Content = memory.ToString(CultureInfo.InvariantCulture);
        }

        public void OnTotalLoadRetreived(float load)
        {
            load = (float)Math.Round(load);

            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.BeginInvoke(new Action(delegate
                {
                    NodeLoadLabel.Content = load.ToString(CultureInfo.InvariantCulture);
                    
                }));

                return;
            }

            NodeLoadLabel.Content = load.ToString(CultureInfo.InvariantCulture);
        }

        public void OnConnectionError()
        {
            throw new NotImplementedException();
        }

        public void OnDisconnected()
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.BeginInvoke(new Action(delegate
                {
                    ConnectionPanel.Visibility = Visibility.Hidden;
                    NotConnectedPanel.Visibility = Visibility.Visible;

                    NodeSettingsButton.IsEnabled = false;
                    LoadSettingsButton.IsEnabled = false;
                    DisconnectButton.IsEnabled = false;

                    ConnectStateLabel.Content = "Not Connected";
                    ConnectButton.IsEnabled = true;
                }));

                return;
            }

            ConnectionPanel.Visibility = Visibility.Hidden;
            NotConnectedPanel.Visibility = Visibility.Visible;

            NodeSettingsButton.IsEnabled = false;
            LoadSettingsButton.IsEnabled = false;
            DisconnectButton.IsEnabled = false;

            ConnectStateLabel.Content = "Not Connected";
            ConnectButton.IsEnabled = true;
        }

        public void OnConnected()
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.BeginInvoke(new Action(delegate
                {
                    ConnectionPanel.Visibility = Visibility.Visible;
                    NotConnectedPanel.Visibility = Visibility.Hidden;

                    NodeSettingsButton.IsEnabled = true;
                    LoadSettingsButton.IsEnabled = true;
                    DisconnectButton.IsEnabled = true;
                }));

                return;
            }

            ConnectionPanel.Visibility = Visibility.Visible;
            NotConnectedPanel.Visibility = Visibility.Hidden;

            NodeSettingsButton.IsEnabled = true;
            LoadSettingsButton.IsEnabled = true;
            DisconnectButton.IsEnabled = true;
        }

        public void OnConnecting()
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.BeginInvoke(new Action(delegate
                {
                    ConnectStateLabel.Content = "Connecting...";
                    ConnectButton.IsEnabled = false;
                }));

                return;
            }

            ConnectStateLabel.Content = "Connecting...";
            ConnectButton.IsEnabled = false;
        }

        public void OnLoadStatusChanged(LoadStatus status)
        {
            LoadStatusChanged(status);
        }

        public void OnLoadStatusRetreived(LoadStatus status)
        {
            LoadStatusChanged(status);
        }

        private void LoadStatusChanged(LoadStatus status)
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.BeginInvoke(new Action(delegate
                {
                    _currStatus = status;
                    WorkersSettingsLabel.Content = "Worker Settings: " + status;

                    switch (status.LoadType)
                    {
                        case LoadStatusType.Limited:
                        {
                            WorkersLimitLabel.Content = status.Limit.ToString(CultureInfo.InvariantCulture);
                            break;
                        }

                        case LoadStatusType.Free:
                        {
                            WorkersLimitLabel.Content = _maxWorkersLimit.ToString(CultureInfo.InvariantCulture);
                            break;
                        }

                        case LoadStatusType.Locked:
                        {
                            WorkersLimitLabel.Content = "0";
                            break;
                        }
                    }
                }));

                return;
            }

            _currStatus = status;
            WorkersSettingsLabel.Content = "Worker Settings: " + status;

            switch (status.LoadType)
            {
                case LoadStatusType.Limited:
                    {
                        WorkersLimitLabel.Content = status.Limit.ToString(CultureInfo.InvariantCulture);
                        break;
                    }

                case LoadStatusType.Free:
                    {
                        WorkersLimitLabel.Content = _maxWorkersLimit.ToString(CultureInfo.InvariantCulture);
                        break;
                    }

                case LoadStatusType.Locked:
                    {
                        WorkersLimitLabel.Content = "0";
                        break;
                    }
            }
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            _nodeProxy.Connect();
        }

        private void AddWorkerButton_Click(object sender, RoutedEventArgs e)
        {
            _nodeProxy._asyncWorkerManager.AddWorkers(1);
        }

        private void RemoveWorkerButton_Click(object sender, RoutedEventArgs e)
        {
            _nodeProxy._asyncWorkerManager.RemoveWorkers(1);
        }

        private void DisconnectButton_Click(object sender, RoutedEventArgs e)
        {
            _nodeProxy.Disconnect();
        }
    }
}
