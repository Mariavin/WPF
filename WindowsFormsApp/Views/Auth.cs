using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp.Forms;

namespace WindowsFormsApp.Views
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text.Trim();
            string pass = textBox2.Text;

            if (login.Equals("admin") && pass.Equals("password"))
            {
                Admin adminForm = new Admin();
                adminForm.Show();
                this.Hide();
            }
            else
            {
                var students = UnionRepository.GetListOfStudents();
                if (students.Any(x => x.Login.Equals(login)))
                {
                    var currentStudent = students.Find(x => x.Equals(login));
                    if (currentStudent.CheckPasword(pass))
                    {
                        Form1 profOrg = new Form1(currentStudent);
                        profOrg.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Неправильное имя или пароль");
                    }
                }
                else
                {
                    MessageBox.Show("Неправильное имя или пароль");
                }
            }
        
        }
    }
}
