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

            DateTime date = dateTimePicker1.Value.Date;
            dataGridView1.DataSource = WindowsFormsApp.Events.GetEvents(date).DefaultView;

            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            WindowsFormsApp.Events.AddEvent(textBox1.Text, textBox2.Text, dateTimePicker2.Value.Date);

            //dataGridView1.DataSource = DataBase.GetEvents().DefaultView;
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
            WindowsFormsApp.Events.UpdateEvent(textBox1.Text, textBox2.Text, dateTimePicker2.Value.Date);
            dataGridView1.DataSource = WindowsFormsApp.Events.GetEvents().DefaultView;
        }
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
       
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
