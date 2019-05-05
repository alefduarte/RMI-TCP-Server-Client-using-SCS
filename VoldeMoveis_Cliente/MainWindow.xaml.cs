using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.ScsServices.Client;
using Hik.Communication.ScsServices.Service;
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
using VoldeMoveis_CommonLib;
using VoldeMoveis_CommonLib.Model;

namespace VoldeMoveis_Cliente
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Public Properties
        public IScsServiceClient<VoldeMoveis_CommonLib.IVoldeMoveisService> client;
        public User _user = new User();
        #endregion

        #region Constructor
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(IScsServiceClient<VoldeMoveis_CommonLib.IVoldeMoveisService> client, User user)
        {
            this._user = user;
            this.client = client;
            InitializeComponent();
        }
        #endregion

        #region Button Behaviour
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var loginMenu = new LoginMenu();
            client.ServiceProxy.Logout();
            loginMenu.Show();
            this.Hide();
        }

        private void ButtonSale_Click(object sender, RoutedEventArgs e)
        {
            var saleWindow = new SaleWindow(this, client, _user);
            saleWindow.Show();
            this.Hide();
        }

        private void ButtonStock_Click(object sender, RoutedEventArgs e)
        {
            var stockWindow = new StockWindow(this, client, _user);
            stockWindow.Show();
            this.Hide();
        }

        private void ButtonBuy_Click(object sender, RoutedEventArgs e)
        {
            var shopWindow = new ShopWindow(this, client, _user);
            shopWindow.Show();
            this.Hide();
        }

        private void ButtonWoodwork_Click(object sender, RoutedEventArgs e)
        {
            var woodWindow = new WoodworkWindow(this, client, _user);
            woodWindow.Show();
            this.Hide();
        }
        #endregion
    }
}
