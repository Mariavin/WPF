using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            // строка подключения к бд 
            String stringConnection = @"Data Source=LENOVO-PC\SQLEXPRESS;Initial Catalog=Profcom;Integrated Security=True;";

            //класс работающий с базой данных 
            SqlConnection con = new SqlConnection(stringConnection);

            con.Open();
            DateTime date = dateTimePicker1.Value.Date;
            string sql = "SELECT * FROM [Events] where [Date] = '" + date + "'";

            SqlCommand cmd = new SqlCommand(sql, con);
            DataTable tab = new DataTable();
            tab.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = tab.DefaultView;
            con.Close();
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            String stringConnection = @"Data Source=LENOVO-PC\SQLEXPRESS;Initial Catalog=Profcom;Integrated Security=True;";
            //класс работающий с базой данных 
            SqlConnection con = new SqlConnection(stringConnection);            
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO [Events] (Event name,Adress,Date) VALUES (@Event name,@Adress,@Date);", con);
            //cmd.Parameters.AddWithValue("@Event name", textBox1.Text);
            //cmd.Parameters.AddWithValue("@Adress", textBox2.Text);
            //cmd.Parameters.AddWithValue("@Date", dateTimePicker2.Value.Date);
            DataTable tab = new DataTable();
            //tab.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = tab.DefaultView;
            con.Close(); 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button3.Visible = false;
            button4.Visible = false;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            dateTimePicker2.Visible = true;
            button1.Visible = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            String stringConnection = @"Data Source=LENOVO-PC\SQLEXPRESS;Initial Catalog=Profcom;Integrated Security=True;";
            //класс работающий с базой данных 
            SqlConnection con = new SqlConnection(stringConnection);

            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE [Events] SET [Event name]@Event name,[Adress]= @Adress,[Date]=@Date) where [№]=@№", con);
            cmd.Parameters.AddWithValue("@№", textBox1.Text);
            cmd.Parameters.AddWithValue("@Event name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Adress", textBox2.Text);
            cmd.Parameters.AddWithValue("@Date", dateTimePicker2.Value.Date);
            DataTable tab = new DataTable();
            tab.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = tab.DefaultView;
            con.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
