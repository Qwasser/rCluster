﻿using System.Configuration;
using System.Windows;
﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Documents;
using NodeProxy;
using _common.SocketConnection;

namespace MasterNodeApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<NodeProxy.NodeProxy> _proxies = new List<NodeProxy.NodeProxy>();
        public MainWindow()
        {
            InitializeComponent();
            HostStackPanel.CanVerticallyScroll = true;

            var hostNames = new List<string>(ConfigurationManager.AppSettings["hostNames"].Split(';'));

            foreach (var hostName in hostNames)
            {
                var nodeInfoString = ConfigurationManager.AppSettings[hostName];

                var ip = nodeInfoString.Split(';')[0];
                int port;

                if (int.TryParse(nodeInfoString.Split(';')[1], out port))
                {
                    var masterNodeSocket = new MasterNodeSocket();
                    var nodeProxy = new NodeProxy.NodeProxy(masterNodeSocket, masterNodeSocket, new NodeProxyConfiguration(hostName, ip, port));
                    _proxies.Add(nodeProxy);

                    var newHost = new NodeProxyGui(nodeProxy)
                    {
                        Margin = new Thickness(4),
                    };

                    HostStackPanel.Children.Add(newHost);
                    HostStackPanel.UpdateLayout();
                }
            }
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            foreach (NodeProxy.NodeProxy proxy in _proxies)
            {
                proxy.Disconnect();
            }
        }

        private void RunAllButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            foreach (var nodeProxy in _proxies)
            {
                nodeProxy._asyncWorkerManager.AddAllWorkers();
            }
        }

        private void StopAllButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            foreach (var nodeProxy in _proxies)
            {
                nodeProxy._asyncWorkerManager.RemoveAllWorkers();
            }
        }

        private void RemoveOneWorkerButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (OnEachNodeCheckBox.IsChecked != null && OnEachNodeCheckBox.IsChecked.Value)
            {
                foreach (var nodeProxy in _proxies)
                {
                    nodeProxy._asyncWorkerManager.RemoveWorkers(1);
                }
            }
        }

        private void AddOneWorkerButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (OnEachNodeCheckBox.IsChecked != null && OnEachNodeCheckBox.IsChecked.Value)
            {
                foreach (var nodeProxy in _proxies)
                {
                    nodeProxy._asyncWorkerManager.AddWorkers(1);
                }
            }
        }






    }
}
