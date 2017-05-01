using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Events : Form
    {
        public Events()
        {
            InitializeComponent();
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

        }

        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {         
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
