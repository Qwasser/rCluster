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

            var section =
                (NodeProxyConfigurationsSection)ConfigurationManager.GetSection("NodeProxyConfigurationsSection");

            section.NodesInfo

            var masterNodeSocket = new MasterNodeSocket();
            var nodeProxy = new NodeProxy.NodeProxy(masterNodeSocket, masterNodeSocket, new NodeProxyConfiguration("host 1", "127.0.0.1", 6700));
            _proxies.Add(nodeProxy);

            var host1 = new NodeProxyGui(nodeProxy)
            {   
                Margin = new Thickness(5),

            };

            HostStackPanel.Children.Add(host1);
            HostStackPanel.UpdateLayout();
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            foreach (NodeProxy.NodeProxy proxy in _proxies)
            {
                proxy.Disconnect();
            }
        }


    }
}
