using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAdmin.BLL.Interfaces
{
    public interface IUserAdmin
    {
        bool Cadastrar(Usuario usuario);
        DataSet Listar();
        bool Deletar(Usuario usuario);
        bool Alterar(Usuario usuario);
    }
}
