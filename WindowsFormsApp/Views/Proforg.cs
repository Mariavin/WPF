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
using WindowsFormsApp.Models;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        private List<UnionEvent> events;
        private Student currentStudent;

        public Form1(Student currentStudent)
        {
            InitializeComponent();
            this.currentStudent = currentStudent;
            events = new List<UnionEvent>() // To debug
            {
                new UnionEvent(1, "Kek", DateTime.Now, "Here"),
                new UnionEvent(2, "Lol", DateTime.Today, "Tam")
            };

        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
           
        }

         private void button1_Click(object sender, EventArgs e)
        {           
            DateTime date = dateTimePicker1.Value.Date;
            //events = UnionRepository.GetListOfEvents()

            dataGridView1.DataSource = UnionConverter.EvetsListToTable(events).DefaultView;
            dataGridView1.Visible = true;
            button1.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button3.Visible = true;
            button4.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            dateTimePicker2.Visible = true;           
            dataGridView1.Visible = true;
            button6.Visible = true;
            //WindowsFormsApp.Events.AddEvent(textBox1.Text, textBox2.Text, dateTimePicker2.Value.Date);
            
            UnionRepository.AddEvent(new UnionEvent(0, textBox1.Text, dateTimePicker2.Value.Date, textBox2.Text));
            events = UnionRepository.GetListOfEvents();
            dataGridView1.DataSource = UnionConverter.EvetsListToTable(events).DefaultView;

            //dataGridView1.DataSource = DataBase.GetEvents().DefaultView;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

       
        private void button3_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            dateTimePicker2.Visible = true;
            dataGridView1.Visible = true;
            button6.Visible = true;
            //WindowsFormsApp.Events.UpdateEvent(textBox3.Text,textBox1.Text, textBox2.Text, dateTimePicker2.Value.Date);
            //dataGridView1.DataSource = WindowsFormsApp.Events.GetEvents().DefaultView;
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

        private void button6_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            dateTimePicker2.Visible = false;
            button6.Visible = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
