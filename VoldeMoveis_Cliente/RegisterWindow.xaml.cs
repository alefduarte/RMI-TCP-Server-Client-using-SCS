using Hik.Communication.ScsServices.Client;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Lógica interna para RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        #region Public Properties
        public IScsServiceClient<VoldeMoveis_CommonLib.IVoldeMoveisService> client;
        public User _user = new User();
        public Cliente SelectedCliente = new Cliente();
        #endregion

        #region Init
        public void Init()
        {
            DataSet cliente = client.ServiceProxy.GetCliente();
            ClienteDataGrid.ItemsSource = cliente.Tables[0].DefaultView;
        }
        #endregion


        #region Constructor
        public RegisterWindow()
        {
            InitializeComponent();
        }

        public RegisterWindow(IScsServiceClient<VoldeMoveis_CommonLib.IVoldeMoveisService> client, User user)
        {
            this._user = user;
            this.client = client;
            InitializeComponent();
            Init();
        }
        #endregion


        private void ButtonRegisterClient(object sender, RoutedEventArgs e)
        {
            ClientName.Text = "";
            ClientAddress.Text = "";
            ClientCpf.Text = "";
            ClientPhone.Text = "";
            ID.Content = 0;
            Registration.Visibility = Visibility.Visible;
            Clientes.Visibility = Visibility.Hidden;
        }

        private void ButtonCancelClient(object sender, RoutedEventArgs e)
        {
            Clientes.Visibility = Visibility.Visible;
            Registration.Visibility = Visibility.Hidden;
        }

        private void ButtonBackRegisterClient(object sender, RoutedEventArgs e)
        {
            Clientes.Visibility = Visibility.Visible;
            Registration.Visibility = Visibility.Hidden;
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSaveClient_Click(object sender, RoutedEventArgs e)
        {

            if (int.Parse(ID.Content.ToString()) == 0)
            {
                if (string.IsNullOrEmpty(ClientName.Text))
                {
                    MessageBox.Show("Nome não pode estar vazio.", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(ClientAddress.Text))
                {
                    MessageBox.Show("Endereço não pode estar vazio.", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(ClientCpf.Text))
                {
                    MessageBox.Show("CPF não pode estar vazio.", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(ClientPhone.Text))
                {
                    MessageBox.Show("Telefone não pode estar vazio.", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                Cliente _cliente = new Cliente
                {
                    Nome = ClientName.Text,
                    Telefone = ClientPhone.Text,
                    Endereco = ClientAddress.Text,
                    Cpf = ClientCpf.Text,
                };

                try
                {
                    int res = client.ServiceProxy.CadastrarCliente(_cliente);
                    Init();


                    if (res == 200)
                    {
                        MessageBox.Show("Cliente cadastrado com Sucesso", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                        Clientes.Visibility = Visibility.Visible;
                        Registration.Visibility = Visibility.Hidden;
                    }

                    else
                    {
                        MessageBox.Show("Erro ao cadastrar cliente", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível conectar ao servidor. Erro: " + ex.Message, "Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                client.ServiceProxy.AtualizarCliente(SelectedCliente);
                Init();
                Clientes.Visibility = Visibility.Visible;
                Registration.Visibility = Visibility.Hidden;
                
            }
        }

        private void ButtonChangeClient_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowview = ClienteDataGrid.SelectedItem as DataRowView;
            this.SelectedCliente = new Cliente
            {
                ID = int.Parse(rowview.Row[0].ToString()),
                Nome = rowview.Row[1].ToString(),
                Telefone = rowview.Row[2].ToString(),
                Endereco = rowview.Row[3].ToString(),
                Cpf = rowview.Row[4].ToString(),
            };
            ID.Content = this.SelectedCliente.ID;

            ClientName.Text = SelectedCliente.Nome;
            ClientAddress.Text = SelectedCliente.Endereco;
            ClientCpf.Text = SelectedCliente.Cpf;
            ClientPhone.Text = SelectedCliente.Telefone;

            Registration.Visibility = Visibility.Visible;
            Clientes.Visibility = Visibility.Hidden;
        }

        private void ButtonDeleteClient_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowview = ClienteDataGrid.SelectedItem as DataRowView;
            int ClientId = int.Parse(rowview.Row[0].ToString());

            client.ServiceProxy.RemoverCliente(ClientId);
            Init();
        }
    }
}
