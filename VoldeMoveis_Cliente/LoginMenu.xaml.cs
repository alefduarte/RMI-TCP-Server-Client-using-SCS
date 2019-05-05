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
using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.ScsServices.Client;
using VoldeMoveis_CommonLib;
using VoldeMoveis_CommonLib.Model;

namespace VoldeMoveis_Cliente
{
    /// <summary>
    /// Interaction logic for LoginMenu.xaml
    /// </summary>
    public partial class LoginMenu : Window
    {
        #region Public Properties
        public string Ip = "127.0.0.1";
        public int Port = 10048;
        public User _user = new User();
        #endregion


        #region Constructor
        public LoginMenu()
        {
            InitializeComponent();
        }
        #endregion

        #region Button Behaviour
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox_username.Text))
            {
                MessageBox.Show("Usuário não pode estar vazio.", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(PasswordBox.Password.ToString()))
            {
                MessageBox.Show("Senha não pode estar vazia.", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var client = ScsServiceClientBuilder.CreateClient<IVoldeMoveisService>(new ScsTcpEndPoint(this.Ip, this.Port));
                client.Connect();

                User user = new User
                {
                    Username = TextBox_username.Text,
                    Password = PasswordBox.Password.ToString()
                };

                _user = client.ServiceProxy.Login(user);


                if (string.IsNullOrEmpty(_user.Name.ToString()))
                {
                    MessageBox.Show("Usuário não cadastrado", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                else
                {
                    var mainWindow = new MainWindow(client, _user);
                    mainWindow.userName.Content = _user.Name;
                    switch ((int)_user.Role)
                    {
                        //retailer
                        case 1:
                            mainWindow.buttonWoodwork.IsEnabled = false;
                            mainWindow.buttonStock.IsEnabled = false;
                            mainWindow.buttonBuy.IsEnabled = false;
                            mainWindow.Show();
                            this.Hide();
                            break;
                        //stockist
                        case 2:
                            mainWindow.buttonWoodwork.IsEnabled = false;
                            mainWindow.buttonSale.IsEnabled = false;
                            mainWindow.buttonBuy.IsEnabled = false;
                            mainWindow.Show();
                            this.Hide();
                            break;
                        //employee
                        case 3:
                            mainWindow.buttonSale.IsEnabled = false;
                            mainWindow.buttonStock.IsEnabled = false;
                            mainWindow.Show();
                            this.Hide();
                            break;
                        //manager
                        case 4:
                            mainWindow.Show();
                            this.Hide();
                            break;
                        //admin
                        case 5:
                            mainWindow.Show();
                            this.Hide();
                            break;
                        default:
                            break;

                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível conectar ao servidor. Erro: " + ex.Message, "Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //Open Connection Window
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TextBox_IP.Text = this.Ip;
            TextBox_Port.Text = this.Port.ToString();

            LoginPage.Opacity = 0.5;
            GridConexao.Visibility = Visibility.Visible;
        }

        //Save Changes to Connection
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Ip = TextBox_IP.Text;
            this.Port = int.Parse(TextBox_Port.Text);
            GridConexao.Visibility = Visibility.Hidden;
            LoginPage.Opacity = 1;
        }

        //Close Window
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            GridConexao.Visibility = Visibility.Hidden;
            LoginPage.Opacity = 1;
        }
        #endregion
    }
}
