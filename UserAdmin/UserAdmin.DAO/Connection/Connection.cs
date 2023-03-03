using System.Data.SqlClient;
using System.Data;

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
        public bool CrudConnectionDb(string stringCommad)
        {
            try
            {
                var command = new SqlCommand();
                command.CommandText = stringCommad;
                command.Connection = ConnectionDb();
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch
            {

                return false;
            }
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
    }
}
