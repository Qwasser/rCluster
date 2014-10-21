using System;
using System.Windows;

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
            var host1 = new NodeProxyGui(null)
            {   
                Margin = new Thickness(5),

            };

            HostStackPanel.Children.Add(host1);
            var host2 = new NodeProxyGui(null)
            {
                Margin = new Thickness(5),

            };
            HostStackPanel.Children.Add(host2);

            host2 = new NodeProxyGui(null)
            {
                Margin = new Thickness(5),

            };
            HostStackPanel.Children.Add(host2);

            host2 = new NodeProxyGui(null)
            {
                Margin = new Thickness(5),

            };
            HostStackPanel.Children.Add(host2);

            host2 = new NodeProxyGui(null)
            {
                Margin = new Thickness(5),

            };
            HostStackPanel.Children.Add(host2);

            HostStackPanel.UpdateLayout();
        }

        
    }
}
