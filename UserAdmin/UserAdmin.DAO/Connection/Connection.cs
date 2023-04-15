using System.Data.SqlClient;
using System.Data;
using UserAdmin.UserAdmin.DAO.Entities;

namespace UserAdmin.UserAdmin.DAO.Connection
{
    public class Connection
    {
        private string connectionString = "Data Source=DAMAZIO\\SQLEXPRESS; Initial Catalog=dbAdminUser; Integrated Security=True";
        SqlConnection connection;

        public SqlConnection ConnectionDb()
        {
            connection = new SqlConnection(connectionString);
            return connection;

        }
        public bool CrudConnectionDb(SqlCommand command)
        {
            try
            {
                var commandCrud = command;
                commandCrud.Connection = ConnectionDb();
                connection.Open();
                commandCrud.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch
            {

                return false;
            }
        }
        public DataSet SelectUser(SqlCommand sqlCommand)
        {
            DataSet dataSetds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            try
            {
                var command = new SqlCommand();
                command = sqlCommand;
                command.Connection = ConnectionDb();
                adapter.SelectCommand = command;
                connection.Open();
                adapter.Fill(dataSetds);
                connection.Close();
                return dataSetds;
            }
            catch
            {

                return dataSetds;
            }


        }
        public Usuario Select_User_Info(SqlCommand command)
        {

            Usuario usuario = new Usuario();
            command.Connection = ConnectionDb();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                usuario.Nome = reader.GetString(1);
                usuario.Email = reader.GetString(2);
                usuario.Cpf = reader.GetString(3);
                usuario.Telefone = reader.GetString(4);
                usuario.FotoUsuario = (byte[])reader["foto"];
            }
            connection.Close();
            return usuario;

        }
        public bool Select_CPF_Users(SqlCommand command, string cpf)
        {

            command.Connection = ConnectionDb();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<string> list = new List<string>();
            while (reader.Read())
            {
                list.Add(reader.GetString(0));
            }
            foreach (var item in list)
            {
                if (item == cpf)
                {
                    MessageBox.Show($"Já existe um usuário com este CPF: {cpf}");
                    connection.Close();
                    return false;
                }
            }
            connection.Close();
            return true;
        }
        public byte[] Select_Foto_Users(SqlCommand command)
        {
            command.Connection = ConnectionDb();
            connection.Open();
            byte[] imagem = (byte[])command.ExecuteScalar();
            connection.Close();
            return imagem;

        }
        public bool Select_Email_Users(SqlCommand command, string email)
        {
            command.Connection = ConnectionDb();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<string> list = new List<string>();
            while (reader.Read())
            {
                list.Add(reader.GetString(0));
            }
            foreach (var item in list)
            {
                if (item == email)
                {
                    MessageBox.Show($"Já existe um usuário com este Email: {email}");
                    connection.Close();
                    return false;
                }
            }
            connection.Close();
            return true;
        }
        public bool Select_Telefone_Users(SqlCommand command, string telefone)
        {
            command.Connection = ConnectionDb();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<string> list = new List<string>();
            while (reader.Read())
            {
                list.Add(reader.GetString(0));
            }
            foreach (var item in list)
            {
                if (item == telefone)
                {
                    MessageBox.Show($"Já existe um usuário com este Telefone: {telefone}");
                    connection.Close();
                    return false;
                }
            }
            connection.Close();
            return true;
        }


    }
}
