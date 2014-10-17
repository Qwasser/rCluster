using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NodeProxy;
using _common.Protocol;

namespace MasterNodeApp
{
    /// <summary>
    /// Interaction logic for NodeProxyGui.xaml
    /// </summary>
    public partial class NodeProxyGui : INodeProxyListener
    {
        public NodeProxyGui()
        {
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void OnWorkersMemoryRetreived(float memory)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void OnWorkersCurrentLimitRetreived(int limit)
        {
            throw new NotImplementedException();
        }

        public void OnTotalMemoryRetreived(float memory)
        {
            throw new NotImplementedException();
        }

        public void OnTotalLoadRetreived(float load)
        {
            throw new NotImplementedException();
        }

        public void OnConnectionError()
        {
            throw new NotImplementedException();
        }

        public void OnDisconnected()
        {
            throw new NotImplementedException();
        }

        public void OnConnected()
        {
            throw new NotImplementedException();
        }

        public void OnConnecting()
        {
            throw new NotImplementedException();
        }

        public void OnLoadStatusChanged(LoadStatus status)
        {
            throw new NotImplementedException();
        }

        public void OnLoadStatusRetreived(LoadStatus status)
        {
            throw new NotImplementedException();
        }
    }
}
