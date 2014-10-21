using System.Windows;
using NodeProxy;
using _common.SocketConnection;

namespace MasterNodeApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            HostStackPanel.CanVerticallyScroll = true;

            var masterNodeSocket = new MasterNodeSocket();
            var nodeProxy = new NodeProxy.NodeProxy(masterNodeSocket, masterNodeSocket, new NodeProxyConfiguration("host 1", "127.0.0.1", 6700));

            var host1 = new NodeProxyGui(nodeProxy)
            {   
                Margin = new Thickness(5),

            };

            HostStackPanel.Children.Add(host1);
            HostStackPanel.UpdateLayout();
        }

        
    }
}
