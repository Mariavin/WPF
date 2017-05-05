using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public class Events
    {
        private static string strConnection = @"Data Source=LENOVO-PC\SQLEXPRESS;Initial Catalog=Profcom;Integrated Security=True;";
        private static SqlConnection con = new SqlConnection(strConnection);

        /*
        public static void OpenConnection()
        {
            con.Open();
        }

        public static void CloseConnection()
        {
            con.Close();
        }
        */
        public static DataTable GetEvents()
        {
            con.Open();
            string sql = "SELECT * FROM [Events];";

            SqlCommand cmd = new SqlCommand(sql, con);
            DataTable tab = new DataTable();
            tab.Load(cmd.ExecuteReader());
            con.Close();
            return tab;
        }

        public static DataTable GetEvents(DateTime time)
        {
            con.Open();
            string sql = "SELECT * FROM [Events] where [Date] = '" + time + "'";

            SqlCommand cmd = new SqlCommand(sql, con);
            DataTable tab = new DataTable();
            tab.Load(cmd.ExecuteReader());
            con.Close();
            return tab;
        }

        public static async void AddEvent(string name, string place, DateTime time)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO [Events] (Event name,Adress,Date) VALUES(@Event name,@Adress,@Date);", con);
            cmd.Parameters.AddWithValue("@Event name", name);
            cmd.Parameters.AddWithValue("@Adress", place);
            cmd.Parameters.AddWithValue("@Date", time);
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }

        public static async void UpdateEvent(string name, string place, DateTime time)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE [Events] SET [Event name]@Event name,[Adress]= @Adress,[Date]=@Date) where [№]=@№", con);
            cmd.Parameters.AddWithValue("@№", name);
            cmd.Parameters.AddWithValue("@Event name", name);
            cmd.Parameters.AddWithValue("@Adress", place);
            cmd.Parameters.AddWithValue("@Date", time);
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }
    }
}
