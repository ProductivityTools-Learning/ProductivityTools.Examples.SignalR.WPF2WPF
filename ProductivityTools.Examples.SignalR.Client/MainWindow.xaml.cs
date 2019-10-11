using Microsoft.AspNet.SignalR.Client;
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

namespace ProductivityTools.Examples.SignalR.Client
{
    public partial class MainWindow : Window
    {
        public IHubProxy HubProxy { get; set; }
        const string ServerURI = "http://localhost:8080/";
        public HubConnection Connection { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnConnectClick(object sender, RoutedEventArgs e)
        {
            Connection = new HubConnection(ServerURI);
            HubProxy = Connection.CreateHubProxy("ExampleHub");
            HubProxy.On<string>("Send", (text) => this.Dispatcher.Invoke(() => lblIncome.Content  = text));

            try
            {
                Connection.Start().Wait();
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void btnSendClick(object sender, RoutedEventArgs e)
        {
            HubProxy.Invoke("Send", txtInput.Text);
        }
    }
}
