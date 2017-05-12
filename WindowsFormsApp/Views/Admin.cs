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
using WindowsFormsApp.Models;

namespace WindowsFormsApp.Forms
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;

            //dataGridView1.DataSource = Class.MembersTradeUnion.GetStudents().DefaultView;
            var students = UnionRepository.GetListOfStudents();
            dataGridView1.DataSource = UnionConverter.StudentsListToTable(students).DefaultView;

            button5.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            textBox1.Visible = true; // lastname
            textBox2.Visible = true; // firstname
            textBox3.Visible = true; // fathername
            textBox4.Visible = true; // faculty
            textBox5.Visible = true; // group
            textBox6.Visible = true; // id
            button5.Visible = true;
            button6.Visible = true;

            //Class.MembersTradeUnion.UpdateStudent(textBox2.Text, textBox1.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
            var student = UnionRepository.GetStudentById(Convert.ToInt32(textBox6.Text));
            var newStudent = new Student(0, textBox2.Text, textBox1.Text, textBox3.Text, student.Login,
            student.Password, textBox4.Text, textBox5.Text);
            UnionRepository.UpdateStudent(student, newStudent);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            button5.Visible = true;
            button6.Visible = true;

            //Class.MembersTradeUnion.AddStudent(textBox2.Text, textBox1.Text, textBox3.Text, textBox4.Text, textBox5.Text);
            UnionRepository.AddStudent(new Student(0, textBox2.Text, textBox1.Text, textBox3.Text, "Login", "Password",
                textBox4.Text, textBox5.Text));

        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            button6.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label6.Visible = true;
            textBox6.Visible = true;
            button5.Visible = true;
            button6.Visible = true;

            //Class.MembersTradeUnion.DeleteStudent(textBox6.Text); 
            UnionRepository.DeleteStudentById(Convert.ToInt32(textBox6.Text));
        }
    }
}