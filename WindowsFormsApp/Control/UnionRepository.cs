using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp.Models;

namespace WindowsFormsApp
{
    static class UnionRepository
    {
        private const string StrConnection = @"Data Source=LENOVO-PC\SQLEXPRESS;Initial Catalog=Profcom;Integrated Security=True;";
        private static SqlConnection con = new SqlConnection(StrConnection);

        public static List<Student> GetListOfStudents()
        {
            string sql = "SELECT * FROM [List_of_Students]";
            return GetStudentsByRequest(sql);
        }

        public static Student GetStudentById(int id)
        {
            Student student = null;
            if (con.State != ConnectionState.Open) con.Open();
            string sql = $"SELECT * from [List_of_Students] WHERE ID = {id}";
            var cmd = new SqlCommand(sql, con);
            var sqlDataReader = cmd.ExecuteReader();
            if (sqlDataReader.HasRows&& sqlDataReader.Read())
            { 
                student = new Student(
                    Convert.ToInt32(sqlDataReader["id"].ToString()),
                    sqlDataReader["Имя"].ToString(), 
                    sqlDataReader["Фамилия"].ToString(), 
                    sqlDataReader["Отчество"].ToString(), 
                    sqlDataReader["Логин"].ToString(), 
                    sqlDataReader["Пароль"].ToString(), 
                    sqlDataReader["Факультет"].ToString(), 
                    sqlDataReader["Группа"].ToString());
            }
            con.Close();
            return student;
        }

        private static List<Student> GetStudentsByRequest(string sql)
        {
            if (con.State != ConnectionState.Open) con.Open();

            var cmd = new SqlCommand(sql, con);

            var students = new List<Student>();

            var sqlDataReader = cmd.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    var student = new Student(
                        Convert.ToInt32(sqlDataReader["id"].ToString()),
                        sqlDataReader["Имя"].ToString(),
                        sqlDataReader["Фамилия"].ToString(),
                        sqlDataReader["Отчество"].ToString(),
                        sqlDataReader["Логин"].ToString(),
                        sqlDataReader["Пароль"].ToString(),
                        sqlDataReader["Факультет"].ToString(),
                        sqlDataReader["Группа"].ToString());
                    students.Add(student);
                }
            }
            con.Close();
            return students;
        }

        public static bool AddStudent(Student student)
        {
            if (con.State != ConnectionState.Open) con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO [List_of_Students] (Фамилия,Имя,Отчество,Логин,Пароль,Факультет,Группа) VALUES (@Фамилия,@Имя,@Отчество,@Логин,@Пароль,@Факультет,@Группа)", con);
            cmd.Parameters.AddWithValue("@Фамилия", student.LastName);
            cmd.Parameters.AddWithValue("@Имя", student.FirstName);
            cmd.Parameters.AddWithValue("@Логин", student.Login);
            cmd.Parameters.AddWithValue("@Пароль", student.Password);
            cmd.Parameters.AddWithValue("@Отчество", student.FatherName);
            cmd.Parameters.AddWithValue("@Факультет", student.Faculty);
            cmd.Parameters.AddWithValue("@Группа", student.Group);
            var result = cmd.ExecuteNonQuery();
            con.Close();
            return result > 0;
        }

        public static bool DaleteStudent(Student student)
        {
            return DeleteStudentById(student.ID);
        }

        public static bool DeleteStudentById(int id)
        {
            if (con.State != ConnectionState.Open) con.Open();
            var cmd = new SqlCommand("DELETE from[List_of_Students] WHERE [id]=@id", con);
            cmd.Parameters.AddWithValue("@id", id.ToString());
            var result = cmd.ExecuteNonQuery();
            con.Close();
            return result > 0;
        }

        public static bool UpdateStudent(Student oldStudent, Student newStudent)
        {
            if (con.State != ConnectionState.Open) con.Open();
            var cmd = new SqlCommand("UPDATE [List_of_Students] SET [Фамилия]=@Фамилия,[Имя]=@Имя,[Отчество]=@Отчество,[Факультет]=@Факультет,[Группа]=@Группа WHERE [id]=@id", con);
            cmd.Parameters.AddWithValue("@Фамилия", newStudent.LastName);
            cmd.Parameters.AddWithValue("@Имя", newStudent.FirstName);
            cmd.Parameters.AddWithValue("@Отчество", newStudent.FatherName);
            cmd.Parameters.AddWithValue("@Факультет", newStudent.Faculty);
            cmd.Parameters.AddWithValue("@Группа", newStudent.Group);
            cmd.Parameters.AddWithValue("@id", oldStudent.ID);
            var result = cmd.ExecuteNonQuery();
            con.Close();
            return result > 0;
        }

        public static List<UnionEvent> GetListOfEvents()
        {
            
            string sql = "SELECT name, Adress, date FROM [Events_];";
            return GetListOfEventsBySqlRequest(sql);
        }

        public static List<UnionEvent> GetListOfEventsByDate(DateTime time)
        {
            string sql = "SELECT name, Adress, date FROM [Events_]where [Date] = '" + time + "'"; 
            return GetListOfEventsBySqlRequest(sql);
        }

        private static List<UnionEvent> GetListOfEventsBySqlRequest(string sql)
        {
            if (con.State != ConnectionState.Open) con.Open();
            var cmd = new SqlCommand(sql, con);
            var events = new List<UnionEvent>();

            var sqlDataReader = cmd.ExecuteReader();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    var unionEvent = new UnionEvent(
                        Convert.ToInt32(sqlDataReader["id"].ToString()),
                        sqlDataReader["name"].ToString(),
                        Convert.ToDateTime(sqlDataReader["date"]),
                        sqlDataReader["Adress"].ToString());

                    //while() - get members
                    // unionEvent.FollowUser(findedStudent)
                }
            }

            con.Close();
            return events;
        }

        public static bool AddEvent(UnionEvent unionEvent)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO [Events_] (name,Adress,Date) VALUES(@name,@Adress,@Date);", con);
            cmd.Parameters.AddWithValue("@name", unionEvent.Name);
            cmd.Parameters.AddWithValue("@Adress", unionEvent.Place);
            cmd.Parameters.AddWithValue("@Date", unionEvent.Date);
            var result = cmd.ExecuteNonQuery();
            con.Close();
            return result > 0;
        }

        public static bool UpdateEvent(UnionEvent oldEvent, UnionEvent newEvent)
        {
            con.Open();
            var cmd = new SqlCommand("UPDATE [Events_] SET [name]=@name,[Adress]= @Adress,[Date]=@Date where [id]=@id", con);
            cmd.Parameters.AddWithValue("@id", oldEvent.Id);
            cmd.Parameters.AddWithValue("@name", newEvent.Name);
            cmd.Parameters.AddWithValue("@Adress", newEvent.Place);
            cmd.Parameters.AddWithValue("@Date", newEvent.Date);
            var result = cmd.ExecuteNonQuery();
            con.Close();
            return result > 0;
        }
    }
}
