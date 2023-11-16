using Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServer
{
    public class DataBase
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-NQ4AHNK7;Initial Catalog=l3;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public void openConnection()
        {
            con.Open();
        }
        public void closeConnection()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
        public SqlConnection GetConnection()
        {
            return con;
        }
    }
    public class Login : ILogin
    {
        public static DataBase database = new DataBase();

        public int Log_in(string username, string password)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string queryString = $"select id, login, pass from registr where login = '{username}' and pass = '{password}'";

            SqlCommand cmd = new SqlCommand(queryString, database.GetConnection());
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Registration(string username, string password)
        {
            if (checkUser(username))
                return 0;
            string querystring = $"insert into registr(login, pass) values('{username}','{password}')";

            SqlCommand cmd = new SqlCommand(querystring, database.GetConnection());
            database.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
            database.closeConnection();
        }
        private Boolean checkUser(string loginUser)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            string querystring = $"select * from registr where login = '{loginUser}'";
            SqlCommand cmd = new SqlCommand(querystring, database.GetConnection());
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
