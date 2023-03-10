using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;
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
            if (TryParse_CPF_Telefone(usuario.Cpf, usuario.Telefone) && ValidationCPF(usuario) && ValidationEmail(usuario) && ValidationTelefone(usuario))
            {

                SqlCommand sqlCommand = new SqlCommand("INSERT INTO UsersCrud ([nome],[email],[cpf],[telefone],[foto]) VALUES(@nome,@email,@cpf,@telefone,@foto)");
                sqlCommand.Parameters.Add("@nome", SqlDbType.VarChar).Value = usuario.Nome;
                sqlCommand.Parameters.Add("@email", SqlDbType.VarChar).Value = usuario.Email;
                sqlCommand.Parameters.Add("@cpf", SqlDbType.VarChar).Value = usuario.Cpf;
                sqlCommand.Parameters.Add("@telefone", SqlDbType.VarChar).Value = usuario.Telefone;
                sqlCommand.Parameters.Add("@foto", SqlDbType.Image).Value = usuario.FotoUsuario;
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
            if (TryParse_CPF_Telefone(usuario.Cpf, usuario.Telefone))
            {

                if (!ValidationUser_Alteracao(usuario))
                {

                    SqlCommand sqlCommand = new SqlCommand("UPDATE UsersCrud SET nome = @nome, email = @email, cpf = @cpf, telefone = @telefone, foto = @foto WHERE id = @id");
                    sqlCommand.Parameters.Add("@id", SqlDbType.VarChar).Value = usuario.Id;
                    sqlCommand.Parameters.Add("@nome", SqlDbType.VarChar).Value = usuario.Nome;
                    sqlCommand.Parameters.Add("@email", SqlDbType.VarChar).Value = usuario.Email;
                    sqlCommand.Parameters.Add("@cpf", SqlDbType.VarChar).Value = usuario.Cpf;
                    sqlCommand.Parameters.Add("@telefone", SqlDbType.VarChar).Value = usuario.Telefone;
                    sqlCommand.Parameters.Add("@foto", SqlDbType.Image).Value=usuario.FotoUsuario;
                    return connection.CrudConnectionDb(sqlCommand);
                }
            }
            return false;
        }
        public Usuario Select_User_Info(int id)
        {
            SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM UsersCrud WHERE id = {id}");
            var usuario = connection.Select_User_Info(sqlCommand);


            return usuario;
        }
        //Nao estou conseguindo pegar do banco a imagem esta dando um erro de stream.
        /* public Image CapthFoto(int id)
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT foto FROM UsersCrud WHERE id = @id");
                sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
                var imagemByte= connection.Select_Foto_Users(sqlCommand);
                using (MemoryStream ms = new MemoryStream(imagemByte))
                {
                        var final = Image.FromStream(ms);
                    return final;

                }

            }*/
        public bool ValidationCPF(Usuario usuario)
        {

            SqlCommand sqlCommand = new SqlCommand("SELECT cpf FROM UsersCrud");
            if (connection.Select_CPF_Users(sqlCommand, usuario.Cpf))
                return true;
            else
                return false;
        }
        public bool ValidationUser_Alteracao(Usuario usuario)
        {

            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM UsersCrud WHERE id=@id");
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = usuario.Id;


            Usuario usuarioBd = connection.Select_User_Info(sqlCommand);
            while (true)
            {


                if (usuarioBd.Cpf != usuario.Cpf)
                {
                    if (ValidationCPF(usuario))
                    {
                        SqlCommand UpdateName = new SqlCommand("UPDATE UsersCrud SET cpf = @cpf WHERE id = @id");
                        UpdateName.Parameters.Add("@cpf", SqlDbType.VarChar).Value = usuario.Cpf;
                        UpdateName.Parameters.Add("@id", SqlDbType.Int).Value = usuario.Id;
                        connection.CrudConnectionDb(UpdateName);
                    }
                    else
                    {
                        MessageBox.Show($"Já possui este CPF, {usuario.Cpf}, na nossa Base de Dados");
                        return false;
                    }

                }
                if (usuarioBd.Telefone != usuario.Telefone)
                {
                    if (ValidationTelefone(usuario))
                    {
                        SqlCommand UpdateTelefone = new SqlCommand("UPDATE UsersCrud SET telefone = @telefone WHERE id = @id");
                        UpdateTelefone.Parameters.Add("@telefone", SqlDbType.VarChar).Value = usuario.Telefone;
                        UpdateTelefone.Parameters.Add("@id", SqlDbType.Int).Value = usuario.Id;
                        connection.CrudConnectionDb(UpdateTelefone);
                    }
                    else
                    {
                        MessageBox.Show($"Já possui este telefone, {usuario.Telefone}, na nossa Base de Dados");
                        return false;
                    }
                }
                if (usuarioBd.Email != usuario.Email)
                {
                    if (ValidationEmail(usuario))
                    {
                        SqlCommand UpdateEmail = new SqlCommand("UPDATE UsersCrud SET email = @email WHERE id = @id");
                        UpdateEmail.Parameters.Add("@email", SqlDbType.VarChar).Value = usuario.Email;
                        UpdateEmail.Parameters.Add("@id", SqlDbType.Int).Value = usuario.Id;
                        connection.CrudConnectionDb(UpdateEmail);
                    }
                    else
                    {
                        MessageBox.Show($"Já possui este Email, {usuario.Email}, na nossa Base de Dados");
                        return false;
                    }
                }
                return false;

            }
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
        public bool TryParse_CPF_Telefone(string cpf, string telefone)
        {
            long number;
            if (!long.TryParse(cpf, out number))
            {
                MessageBox.Show("O CPF teve conter apenas números!");
                return false;
            }

            if (!long.TryParse(telefone, out number))
            {
                MessageBox.Show("O Telefone teve conter apenas números!");
                return false;
            }
            return true;
        }
    }
}
