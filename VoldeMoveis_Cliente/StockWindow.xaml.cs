using Hik.Communication.ScsServices.Client;
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
using System.Windows.Shapes;
using VoldeMoveis_CommonLib.Model;

namespace VoldeMoveis_Cliente
{
    /// <summary>
    /// Lógica interna para StockWindow.xaml
    /// </summary>
    public partial class StockWindow : Window
    {
        #region Public Properties
        MainWindow _parent;
        public IScsServiceClient<VoldeMoveis_CommonLib.IVoldeMoveisService> client;
        public User _user = new User();
        #endregion

        #region Constructor
        public StockWindow()
        {
            InitializeComponent();
        }

        public StockWindow(MainWindow parent, IScsServiceClient<VoldeMoveis_CommonLib.IVoldeMoveisService> client, User user)
        {
            this._parent = parent;
            this._user = user;
            this.client = client;
            InitializeComponent();
        }
        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this._parent.Show();
            this.Close();
        }
    }
}
