using System.Data;
using UserAdmin.UserAdmin.DAO.Entities;

namespace UserAdmin.UserAdmin.BLL.Interfaces
{
    public interface IUserService
    {
        bool Cadastrar(Usuario usuario);
        DataSet Listar();
        bool Deletar(Usuario usuario);
        bool Alterar(Usuario usuario);
    }
}
