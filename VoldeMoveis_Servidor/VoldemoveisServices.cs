using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hik.Communication.ScsServices.Service;
using VoldeMoveis_CommonLib;
using VoldeMoveis_CommonLib.Model;
using MySql.Data.MySqlClient;
using System.Data;
using VoldeMoveis.DBLibs;

namespace VoldeMoveis_Servidor
{
    public class VoldemoveisServices : ScsService, IVoldeMoveisService
    {
        #region Private Fields
        private User _user;
        private Dbhandler dbQuery = new Dbhandler();

        #endregion

        #region Constructor
        public VoldemoveisServices()
        {
            _user = new User();
        }

        #endregion

        #region IMenu Implementation
        public User Login(User userInfo)
        {
            MySqlParameter[] _sqlParams = new MySqlParameter[] {
                new MySqlParameter("@username", userInfo.Username),
                new MySqlParameter("@password",userInfo.Password)
            };

            DataSet dUser = dbQuery.get("SELECT * FROM usuario as user " + 
                "WHERE user.login = @username AND user.senha = @password", _sqlParams);
            if (dUser.Tables[0].Rows.Count > 0)
            {
                _user.ID = int.Parse(dUser.Tables[0].Rows[0]["id"].ToString());
                _user.Name = dUser.Tables[0].Rows[0]["nome"].ToString();
                _user.Role = (RoleEnum)Enum.Parse(typeof(RoleEnum), dUser.Tables[0].Rows[0]["role"].ToString());
                _user.Password = dUser.Tables[0].Rows[0]["senha"].ToString();
                _user.Username = dUser.Tables[0].Rows[0]["login"].ToString();
                Console.WriteLine(_user.Name.ToString() + " acabou de se conectar!");
                return _user;
            }

            return _user;
        }

        public void Logout()
        {
            Console.WriteLine(_user.Name.ToString() + " acabou de se desconectar!");
            _user = new User();
        }
        #endregion

        #region IVenda Implementation
        public int CadastrarVenda(Venda venda)
        {
            MySqlParameter[] _sqlParams = new MySqlParameter[] {
                new MySqlParameter("@produto_id", venda.Produto.ID),
                new MySqlParameter("@preco", venda.Preco),
            };

            int dCliente = dbQuery.set("INSERT INTO venda(produto_id, preco)" +
                "VALUES(@produto_id, @preco)", _sqlParams);

            if (dCliente > 0)
            {
                return 200;
            }

            return 500;
        }

        public int CancelarVenda(int vendaId)
        {
            MySqlParameter[] _sqlParams = new MySqlParameter[] {
                new MySqlParameter("@id", vendaId),
            };

            int dCliente = dbQuery.set("DELETE FROM produto" +
                "WHERE id=@id", _sqlParams);

            if (dCliente > 0)
            {
                return 200;
            }

            return 500;
        }

        public int CadastrarCliente(Cliente cliente)
        {
            MySqlParameter[] _sqlParams = new MySqlParameter[] {
                new MySqlParameter("@nome", cliente.Nome),
                new MySqlParameter("@endereco", cliente.Endereco),
                new MySqlParameter("@telefone", cliente.Telefone),
                new MySqlParameter("@cpf", cliente.Cpf),
            };

            int dCliente = dbQuery.set("INSERT INTO cliente(nome, endereco, telefone, cpf)" +
                "VALUES(@nome, @endereco, @telefone, @cpf)", _sqlParams);

            if (dCliente > 0)
            {
                return 200;
            }

            return 500;
        }

        public DataSet GetCliente()
        {
            DataSet dSetClientes = dbQuery.get("SELECT * FROM cliente");

            return dSetClientes;
        }

        public int AtualizarCliente(Cliente cliente)
        {
            MySqlParameter[] _sqlParams = new MySqlParameter[] {
                new MySqlParameter("@id", cliente.ID),
                new MySqlParameter("@nome", cliente.Nome),
                new MySqlParameter("@endereco", cliente.Endereco),
                new MySqlParameter("@telefone", cliente.Telefone),
                new MySqlParameter("@cpf", cliente.Cpf),
            };

            int dCliente = dbQuery.set("UPDATE cliente " +
                "SET nome= @nome, endereco= @endereco, telefone= @telefone, cpf= @cpf " +
                "WHERE id = @id", _sqlParams);

            if (dCliente > 0)
            {
                return 200;
            }

            return 500;
        }

        /// <param name="clienteId">Cliente Class</param>
        /// <returns>integer informing process: 200 success, 500 fail</returns>
        public int RemoverCliente(int clienteId)
        {
            MySqlParameter[] _sqlParams = new MySqlParameter[] {
                new MySqlParameter("@id", clienteId),
            };

            int dCliente = dbQuery.set("DELETE FROM cliente " +
                "WHERE id=@id", _sqlParams);

            if (dCliente > 0)
            {
                return 200;
            }

            return 500;
        }
        #endregion

        #region IGerencia Implementation

        public int CadastrarUsuario(User user)
        {
            MySqlParameter[] _sqlParams = new MySqlParameter[] {
                new MySqlParameter("@nome", user.Name),
                new MySqlParameter("@login", user.Username),
                new MySqlParameter("@senha", user.Password),
                new MySqlParameter("@role", user.Role),
            };

            int dCliente = dbQuery.set("INSERT INTO usuario(nome, login, senha, role)" +
                "VALUES(@nome, @login, @senha, @role)", _sqlParams);

            if (dCliente > 0)
            {
                return 200;
            }

            return 500;
        }

        public int RemoverUsuario(int userId)
        {
            MySqlParameter[] _sqlParams = new MySqlParameter[] {
                new MySqlParameter("@id", userId),
            };

            int dCliente = dbQuery.set("DELETE FROM usuario" +
                "WHERE id=@id", _sqlParams);

            if (dCliente > 0)
            {
                return 200;
            }

            return 500;
        }

        public void RelatorioVendas()
        {
            throw new NotImplementedException();
        }


        #endregion

        #region IEstoque Implementation

        public int CadastrarProduto(Produto produto)
        {
            MySqlParameter[] _sqlParams = new MySqlParameter[] {
                new MySqlParameter("@nome", produto.Nome),
                new MySqlParameter("@altura", produto.Altura),
                new MySqlParameter("@largura", produto.Largura),
                new MySqlParameter("@espessura", produto.Espessura),
                new MySqlParameter("@madeira_id", produto.Madeira.ID),
                new MySqlParameter("@tinta_id", produto.Tinta.ID),
                new MySqlParameter("@quantidade", produto.Quantidade),
            };

            int dCliente = dbQuery.set("INSERT INTO produto(nome, altura, largura, espessura, madeira_id, tinta_id, quantidade)" +
                "VALUES(@nome, @altura, @largura, @espessura, @madeira_id, @tinta_id, @quantidade)", _sqlParams);

            if (dCliente > 0)
            {
                return 200;
            }

            return 500;
        }

        public int AtualizarProduto(Produto produto)
        {
            MySqlParameter[] _sqlParams = new MySqlParameter[] {
                new MySqlParameter("@id", produto.ID),
                new MySqlParameter("@nome", produto.Nome),
                new MySqlParameter("@altura", produto.Altura),
                new MySqlParameter("@largura", produto.Largura),
                new MySqlParameter("@espessura", produto.Espessura),
                new MySqlParameter("@madeira_id", produto.Madeira.ID),
                new MySqlParameter("@tinta_id", produto.Tinta.ID),
                new MySqlParameter("@quantidade", produto.Quantidade),
            };

            int dCliente = dbQuery.set("UPDATE produto" +
                "SET nome= @nome, altura= @altura, largura= @largura, espessura = @espessura, madeira_id = @madeira_id, " +
                "tinta_id = @tinta_id, quantidade = @quantidade " +
                "WHERE id = @id", _sqlParams);

            if (dCliente > 0)
            {
                return 200;
            }

            return 500;
        }

        public int RemoverProduto(int produtoId)
        {
            MySqlParameter[] _sqlParams = new MySqlParameter[] {
                new MySqlParameter("@id", produtoId),
            };

            int dCliente = dbQuery.set("DELETE FROM produto" +
                "WHERE id=@id", _sqlParams);

            if (dCliente > 0)
            {
                return 200;
            }

            return 500;
        }
        #endregion
    }
}
