using Hik.Communication.ScsServices.Service;
using System.Data;
using VoldeMoveis_CommonLib.Model;

namespace VoldeMoveis_CommonLib
{
    [ScsService(Version = "1.1.1.1")]
    public interface IVoldeMoveisService
    {
        #region Menu Interface
        /// <param name="userInfo">Informações do Usuário</param>
        User Login(User userInfo);

        void Logout();
        #endregion

        #region Estoque Interface
        /// <param name="produto">Produto Class</param>
        /// <returns>integer informing process: 200 success, 500 fail</returns>
        int CadastrarProduto(Produto produto);

        /// <param name="produto">Produto Class</param>
        /// <returns>integer informing process: 200 success, 500 fail</returns>
        int AtualizarProduto(Produto produto);

        /// <param name="produtoId">Produto ID</param>
        /// <returns>integer informing process: 200 success, 500 fail</returns>
        int RemoverProduto(int produtoId);
        #endregion

        #region Gerencia Interface
        /// <param name="user">User Class</param>
        /// <returns>integer informing process: 200 success, 500 fail</returns>
        int CadastrarUsuario(User user);

        /// <param name="userId">User ID</param>
        /// <returns>integer informing process: 200 success, 500 fail</returns>
        int RemoverUsuario(int userId);

        void RelatorioVendas();
        #endregion

        #region Venda Interface
        /// <param name="produto">Produto Class</param>
        /// <returns>integer informing process: 200 success, 500 fail</returns>
        int CadastrarVenda(Venda venda);

        /// <param name="vendaId">Venda ID</param>
        /// <returns>integer informing process: 200 success, 500 fail</returns>
        int CancelarVenda(int vendaId);

        /// <param name="cliente">Cliente Class</param>
        /// <returns>integer informing process: 200 success, 500 fail</returns>
        int CadastrarCliente(Cliente cliente);

        /// <returns>DataSet of Client</returns>
        DataSet GetCliente();

        /// <param name="cliente">Cliente Class</param>
        /// <returns>integer informing process: 200 success, 500 fail</returns>
        int AtualizarCliente(Cliente cliente);

        /// <param name="clienteId">Cliente Class</param>
        /// <returns>integer informing process: 200 success, 500 fail</returns>
        int RemoverCliente(int clienteId);
        #endregion
    }

}
