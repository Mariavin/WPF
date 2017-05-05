using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp.Class
{
    class MembersTradeUnion
    {
        private static string strConnection = @"Data Source=LENOVO-PC\SQLEXPRESS;Initial Catalog=Profcom;Integrated Security=True;";
        private static SqlConnection con = new SqlConnection(strConnection);

        public static DataTable GetStudents()
        {
            if (con.State != ConnectionState.Open) con.Open();
            string sql = "SELECT * FROM [List_of_Students] ";

            SqlCommand cmd = new SqlCommand(sql, con);
            DataTable tab = new DataTable();
            tab.Load(cmd.ExecuteReader());
            con.Close();
            return tab;
        }

        public static async void AddStudent(string firstName, string lastName, string fatherName, string faculty, string group)
        {
            if (con.State != ConnectionState.Open) con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO [List_of_Students] (Фамилия,Имя,Отчество,Факультет,Группа) VALUES (@Фамилия,@Имя,@Отчество,@Факультет,@Группа)", con);
            cmd.Parameters.AddWithValue("@Фамилия", lastName);
            cmd.Parameters.AddWithValue("@Имя", firstName);
            cmd.Parameters.AddWithValue("@Отчество", fatherName);
            cmd.Parameters.AddWithValue("@Факультет", faculty);
            cmd.Parameters.AddWithValue("@Группа", group);
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }

        public static async void DeleteStudent(string id)
        {
            if (con.State != ConnectionState.Open) con.Open();
            SqlCommand cmd = new SqlCommand("DELETE from[List_of_Students] WHERE [id]=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }

        public static async void UpdateStudent(string firstName, string lastName, string fatherName, string faculty, string group, string id)
        {
            if (con.State != ConnectionState.Open) con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE [List_of_Students] SET [Фамилия]=@Фамилия,[Имя]=@Имя,[Отчество]=@Отчество,[Факультет]=@Факультет,[Группа]=@Группа WHERE [id]=@id", con);
            cmd.Parameters.AddWithValue("@Фамилия", lastName);
            cmd.Parameters.AddWithValue("@Имя", firstName);
            cmd.Parameters.AddWithValue("@Отчество", fatherName);
            cmd.Parameters.AddWithValue("@Факультет", faculty);
            cmd.Parameters.AddWithValue("@Группа", group);
            cmd.Parameters.AddWithValue("@id", id);
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }
    }
}
