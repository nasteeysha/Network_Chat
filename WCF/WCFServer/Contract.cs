using Contracts;
using DocumentFormat.OpenXml.Office2010.Excel;
using Nest;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace WCFServer
{
    public class Contract : IContract
    {
        

        public static string connStr = @"Data Source=LAPTOP-NQ4AHNK7;Initial Catalog=l3;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public DataTable GetmyData()
        {
            SqlConnection myConnection = new SqlConnection(connStr);

            myConnection.Open();
            string cmd = "SELECT * FROM carshop";
            SqlCommand createCommand = new SqlCommand(cmd, myConnection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("carshop");
            dataAdp.Fill(dt);


            myConnection.Close();
            return dt;


            throw new FaultException("Ошибка получения данных.");


        }


        


        public string Proc(int id)
        {
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand command1 = new SqlCommand("findbrand");//!!!!
            command1.CommandType = CommandType.StoredProcedure;//!!!!
            command1.Parameters.AddWithValue("@id", id);

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@carbrand";
            pName.SqlDbType = SqlDbType.NVarChar;
            pName.Size = 1000;
            pName.Direction = ParameterDirection.Output;///!!!!!
            pName.Value = "";
            command1.Parameters.Add(pName);

            command1.Connection = conn;
            command1.Connection.Open();
            command1.ExecuteNonQuery();
            command1.Connection.Close();
            if ((string)pName.Value != "")
            {
                return (string)pName.Value;
            }
            else
            {
                return "Не удалось найти введенный бренд! Проверьте написание и повторите попытку снова.";
            }
        }


        public void InsertCommand(Car car2)
        {
            SqlConnection connection = new SqlConnection(connStr);
            connection.Open();
            SqlCommand insertCommand = new SqlCommand("insert into carshop (carbrand, carprice, prodactionyear, probeg, seller) values (@carbrand, @carprice, @prodactionyear, @probeg, @seller)");
            insertCommand.Connection = connection;
            
            SqlParameter parCb = new SqlParameter("@carbrand", System.Data.SqlDbType.NVarChar);
            parCb.Value = car2.CARBRAND;
            insertCommand.Parameters.Add(parCb);
            insertCommand.Parameters.AddWithValue("carprice", car2.CARPRICE);
            insertCommand.Parameters.AddWithValue("prodactionyear", car2.DATAPROIZVODSTVA);
            insertCommand.Parameters.AddWithValue("probeg", car2.PROBEG);
            insertCommand.Parameters.AddWithValue("seller", car2.SELLER);
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(Car car2, int id)
        {
            SqlConnection connection = new SqlConnection(connStr);
            connection.Open();
            SqlCommand updateCommand = new SqlCommand("update carshop set carbrand=@carbrand, carprice=@carprice, prodactionyear=@prodactionyear, probeg=@probeg, seller=@seller where id=@id");
            updateCommand.Connection = connection;

           
            updateCommand.Parameters.AddWithValue("@id", id);
            updateCommand.Parameters.AddWithValue("@carbrand", car2.CARBRAND);
            updateCommand.Parameters.AddWithValue("@carprice", car2.CARPRICE);
            updateCommand.Parameters.AddWithValue("@prodactionyear", car2.DATAPROIZVODSTVA);
            updateCommand.Parameters.AddWithValue("@probeg", car2.PROBEG);
            updateCommand.Parameters.AddWithValue("@seller", car2.SELLER);
            
            updateCommand.ExecuteNonQuery();
            connection.Close();



        }

        public Car Load()
        {
            Car car2 = new Car();
            SqlConnection connection = new SqlConnection(connStr);
            connection.Open();
            SqlCommand readerCommand = new SqlCommand("select id, carbrand, carprice, prodactionyear, probeg, seller from carshop");

            readerCommand.Connection = connection;
            SqlDataReader reader = readerCommand.ExecuteReader();
            while (reader.Read())
            {
                car2.ID = (int)reader["id"];
                car2.CARBRAND = (string)reader["carbrand"];
                car2.CARPRICE = (int)reader["carprice"];
                car2.DATAPROIZVODSTVA = (int)reader["prodactionyear"];
                car2.PROBEG = (int)reader["probeg"];
                car2.SELLER = (string)reader["seller"];
            }
            reader.Close();
            connection.Close();
            return car2;
        }

        public void Delete(int id)
        {
            SqlConnection connection = new SqlConnection(connStr);
            connection.Open();
            SqlCommand deleteCommand = new SqlCommand("delete from carshop where id=" + id);
            deleteCommand.Connection = connection;
            deleteCommand.ExecuteNonQuery();
            connection.Close();
        }



        public DataTable RefreshView(string textfilter)
        {
            SqlConnection myConnection = new SqlConnection(connStr);

            myConnection.Open();
            string cmd = "select id, carbrand, carprice, prodactionyear, probeg, seller from carshop";
            if (textfilter != "")
            {
                cmd = cmd + " where carshop.carbrand like '%" + textfilter + "%'";
            }
            SqlCommand createCommand = new SqlCommand(cmd, myConnection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("carshop");
            dataAdp.Fill(dt);


            myConnection.Close();
            return dt;

            throw new FaultException("Ошибка получения данных.");

        }





        public Car InitF2(int id)
        {
            throw new NotImplementedException();
        }

        public Car Load(int id)
        {
            throw new NotImplementedException();
        }
    }
}
