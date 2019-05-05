using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoldeMoveis.DBLibs
{
    class Dbconfig
    {
        private string server;
        private string user;
        private string password;
        private string database;

        /// <param name="__server">Database Address</param>
        /// <param name="__user">Database User</param>
        /// <param name="__password">Database Password</param>
        /// <param name="__database">Database Name</param>
        public Dbconfig(string __server = "localhost", string __user = "root",
                    string __password = "root", string __database = "moveis")
        {
            this.server = __server;
            this.user = __user;
            this.password = __password;
            this.database = __database;
        }

        /// <returns>Server=localhost;Database=moveis:Uid=root;Pwd= </returns>
        public string get()
        {
            return "Server=" + this.server + ";Database=" + this.database +
                   ";Uid=" + this.user + ";Pwd=" + this.password;
        }
}
}
