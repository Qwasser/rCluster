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
        private NodeProxy.NodeProxy _nodeProxy;
        private LoadStatus _currStatus;
        private int _maxWorkersLimit;

        public NodeProxyGui(NodeProxy.NodeProxy nodeProxy)
        {
            _nodeProxy = nodeProxy;
            InitializeComponent();
        }

        private void SettingsExpander_Expanded(object sender, RoutedEventArgs e)
        {
            Height = 200;
        }

        private void SettingsExpander_Collapsed(object sender, RoutedEventArgs e)
        {
            Height = 50;
        }

        public void OnWorkersCountRetreived(int count)
        {
            WorkersCountLabel.ContentStringFormat = count.ToString(CultureInfo.InvariantCulture);
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
            WorkersLoadLabel.ContentStringFormat = load.ToString(CultureInfo.InvariantCulture);
        }

        public void OnWorkersMemoryRetreived(float memory)
        {
            WorkersMemoryLabel.ContentStringFormat = memory.ToString(CultureInfo.InvariantCulture);
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
            _maxWorkersLimit = limit;
            MaxWorkerLimitLabel.ContentStringFormat = "Max Workers Limit: " + _maxWorkersLimit.ToString(CultureInfo.InvariantCulture);
        }

        public void OnWorkersCurrentLimitRetreived(int limit)
        {
            throw new NotImplementedException();
        }

        public void OnTotalMemoryRetreived(float memory)
        {
            NodeMemoryLabel.ContentStringFormat = memory.ToString(CultureInfo.InvariantCulture);
        }

        public void OnTotalLoadRetreived(float load)
        {
            NodeLoadLabel.ContentStringFormat = load.ToString(CultureInfo.InvariantCulture);
        }

        public void OnConnectionError()
        {
            throw new NotImplementedException();
        }

        public void OnDisconnected()
        {
            ConnectionPanel.Visibility = Visibility.Hidden;
            NotConnectedPanel.Visibility = Visibility.Visible;

            NodeSettingsButton.IsEnabled = false;
            LoadSettingsButton.IsEnabled = false;
        }

        public void OnConnected()
        {
            ConnectionPanel.Visibility = Visibility.Visible;
            NotConnectedPanel.Visibility = Visibility.Hidden;

            NodeSettingsButton.IsEnabled = true;
            LoadSettingsButton.IsEnabled = true;
        }

        public void OnConnecting()
        {
            throw new NotImplementedException();
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
            _currStatus = status;
            WorkersSettingsLabel.ContentStringFormat = "Worker Settings: " + status;

            switch (status.LoadType)
            {
                case LoadStatusType.Limited:
                    {
                        WorkersLimitLabel.ContentStringFormat = status.Limit.ToString(CultureInfo.InvariantCulture);
                        break;
                    }

                case LoadStatusType.Free:
                    {
                        WorkersLimitLabel.ContentStringFormat = _maxWorkersLimit.ToString(CultureInfo.InvariantCulture);
                        break;
                    }

                case LoadStatusType.Locked:
                    {
                        WorkersLimitLabel.ContentStringFormat = "0";
                        break;
                    }
            }
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            _nodeProxy.Connect();
        }
    }
}
