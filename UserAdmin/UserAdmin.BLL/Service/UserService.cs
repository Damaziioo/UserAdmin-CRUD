using System.Data;
using System.Data.SqlClient;
using UserAdmin.UserAdmin.BLL.Interfaces;
using UserAdmin.UserAdmin.DAO.Connection;
using UserAdmin.UserAdmin.DAO.Entities;

namespace UserAdmin.UserAdmin.BLL.Service
{
    public class UserService : IUserService
    {
        Connection connection;

        public UserService()
        {
            connection = new Connection();
        }

        public bool Cadastrar(Usuario usuario)
        {
            if (ValidationCPF(usuario) && ValidationEmail(usuario) && ValidationTelefone(usuario))
            {
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO UsersCrud ([nome],[email],[cpf],[telefone],[foto]) VALUES(@nome,@email,@cpf,@telefone,'foto')");
                sqlCommand.Parameters.Add("@nome", SqlDbType.VarChar).Value = usuario.Nome;
                sqlCommand.Parameters.Add("@email", SqlDbType.VarChar).Value = usuario.Email;
                sqlCommand.Parameters.Add("@cpf", SqlDbType.VarChar).Value = usuario.Cpf;
                sqlCommand.Parameters.Add("@telefone", SqlDbType.VarChar).Value = usuario.Telefone;
                return connection.CrudConnectionDb(sqlCommand);
            }
            return false;

        }

        public DataSet Listar()
        {
            var command = new SqlCommand("SELECT * FROM UsersCrud");
            return connection.SelectUser(command);
        }

        public bool Deletar(Usuario usuario)
        {
            SqlCommand sqlCommand = new SqlCommand("DELETE FROM UsersCrud WHERE id = @id");
            sqlCommand.Parameters.Add("@id", SqlDbType.VarChar).Value = usuario.Id;

            return connection.CrudConnectionDb(sqlCommand);
        }
        public bool Alterar(Usuario usuario)
        {
            if (ValidationCPF(usuario) && ValidationEmail(usuario) && ValidationTelefone(usuario))
            {

                SqlCommand sqlCommand = new SqlCommand("UPDATE UsersCrud SET nome = @nome, email = @email, cpf = @cpf, telefone = @telefone, foto = 'foto' WHERE id = @id");
                sqlCommand.Parameters.Add("@id", SqlDbType.VarChar).Value = usuario.Id;
                sqlCommand.Parameters.Add("@nome", SqlDbType.VarChar).Value = usuario.Nome;
                sqlCommand.Parameters.Add("@email", SqlDbType.VarChar).Value = usuario.Email;
                sqlCommand.Parameters.Add("@cpf", SqlDbType.VarChar).Value = usuario.Cpf;
                sqlCommand.Parameters.Add("@telefone", SqlDbType.VarChar).Value = usuario.Telefone;
                return connection.CrudConnectionDb(sqlCommand);
            }
            return false;
        }

        public bool ValidationCPF(Usuario usuario)
        {

            SqlCommand sqlCommand = new SqlCommand("SELECT cpf FROM UsersCrud");
            if (connection.Select_CPF_Users(sqlCommand, usuario.Cpf))
                return true;
            else
                return false;
        }
        public bool ValidationEmail(Usuario usuario)
        {

            SqlCommand sqlCommand = new SqlCommand("SELECT email FROM UsersCrud");
            if (connection.Select_Email_Users(sqlCommand, usuario.Email))
                return true;
            else
                return false;
        }
        public bool ValidationTelefone(Usuario usuario)
        {

            SqlCommand sqlCommand = new SqlCommand("SELECT telefone FROM UsersCrud");
            if (connection.Select_Telefone_Users(sqlCommand, usuario.Telefone))
                return true;
            else
                return false;
        }
    }
}
