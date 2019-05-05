using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;
using System.Data;
using System.Text.RegularExpressions;

namespace VoldeMoveis.DBLibs
{
    class Dbhandler
    {
        #region Private Properties
        private Dbconfig db;
        private MySqlConnection connection;
        private MySqlCommand command;
        private MySqlDataAdapter dAdapter;
        private DataSet dSet;
        #endregion

        #region Constructor
        public Dbhandler()
        {
            db = new Dbconfig();
            connection = new MySqlConnection(db.get());
        }
        #endregion

        #region Data Getter
        public DataSet get(string __query, [Optional] MySqlParameter[] __param)
        {
            this.command = new MySqlCommand(__query, this.connection);

            if (__param != null) { this.command.Parameters.AddRange(__param); }

            this.dAdapter = new MySqlDataAdapter(this.command);
            this.dSet = new DataSet();

            /* input exemplo: 'SELECT * FROM tabela WHERE id = @id'
               output: 'FROM tabela' */
            Regex rgx = new Regex("FROM\\s\\w+");
            MatchCollection matches = rgx.Matches(__query);

            /* output: 'tabela' */
            string table = matches[0].Value.Replace("FROM ", "");

            this.dAdapter.Fill(this.dSet, table);

            return this.dSet;
        }
        #endregion

        #region Data Setter
        public int set(string __query, [Optional] MySqlParameter[] __param)
        {
            this.command = new MySqlCommand(__query, this.connection);

            if (__param != null) { command.Parameters.AddRange(__param); }

            if (this.connection.State != ConnectionState.Open)
            {
                this.connection.Open();
            }

            return this.command.ExecuteNonQuery();
            // retorna o número de linhas afetadas
        }
        #endregion
    }
}
