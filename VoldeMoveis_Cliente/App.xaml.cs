using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using VoldeMoveis_CommonLib.Model;

namespace VoldeMoveis_Cliente
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public App()
        {
            Startup += AppStartUp;
        }

        static void AppStartUp(object sender, StartupEventArgs e)
        { 
            var loginMenu = new LoginMenu();
            loginMenu.Show();
        }
    }
}
