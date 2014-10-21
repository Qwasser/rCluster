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
            var host1 = new NodeProxyGui(null);
            HostStackPanel.Children.Add(host1);

            host1 = new NodeProxyGui(null);
            HostStackPanel.Children.Add(host1);

            HostStackPanel.UpdateLayout();
        }

        
    }
}
