using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAdmin.DAO.Connection;
using UserAdmin.DAO.Entities;

namespace UserAdmin.BLL.Services
{
    public class UserService
    {
        Connection connection;

        public UserService()
        {
            connection = new Connection();
        }

        public bool Cadastrar(Usuario usuario)
        {
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO UsersCrud ([nome],[email],[cpf],[telefone],[foto]) VALUES(@nome,@email,@cpf,@telefone,'foto')");
            sqlCommand.Parameters.Add("@nome", SqlDbType.VarChar).Value = usuario.Nome;
            sqlCommand.Parameters.Add("@email", SqlDbType.VarChar).Value = usuario.Email;
            sqlCommand.Parameters.Add("@cpf", SqlDbType.VarChar).Value = usuario.Cpf;
            sqlCommand.Parameters.Add("@telefone", SqlDbType.VarChar).Value = usuario.Telefone;

            return connection.CrudConnectionDb(sqlCommand);
        }

        public DataSet Listar()
        {
            var command = new SqlCommand("SELECT * FROM UsersCrud");
            return connection.SelectUser(command);
        }

        public bool Deletar(Usuario usuario)
        {
            SqlCommand sqlCommand = new SqlCommand("DELETE FROM UsersCrud WHERE cpf = @cpf");
            sqlCommand.Parameters.Add("@cpf", SqlDbType.VarChar).Value = usuario.Cpf;

            return connection.CrudConnectionDb(sqlCommand);
        }
        public bool Alterar(Usuario usuario)
        {
            SqlCommand sqlCommand = new SqlCommand("UPDATE UsersCrud SET nome = @nome, email = @email, cpf = @cpf, telefone = @telefone, foto = 'foto' WHERE cpf = @cpf");
            sqlCommand.Parameters.Add("@nome", SqlDbType.VarChar).Value = usuario.Nome;
            sqlCommand.Parameters.Add("@email", SqlDbType.VarChar).Value = usuario.Email;
            sqlCommand.Parameters.Add("@cpf", SqlDbType.VarChar).Value = usuario.Cpf;
            sqlCommand.Parameters.Add("@telefone", SqlDbType.VarChar).Value = usuario.Telefone;

            return connection.CrudConnectionDb(sqlCommand);
        }
    }
}
