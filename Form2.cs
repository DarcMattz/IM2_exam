using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exam
{
    public partial class Form2 : Form
    {

        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader reader;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                string cs = "host=localhost;user=root;password=;database=im_exam";
                conn = new MySqlConnection(cs);
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("can't connect to the database");
            }

            string query = "SELECT * FROM account";
            cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string name = textBox1.Text;
            string sex = radioButton1.Checked ? "Male" : "Female";

            if(username != "" &&  password != "" && name != "")
            {
                try
                {
                    string sql = $"INSERT INTO `account`(`email`, `password`, `name`, `sex`) VALUES ('{username}','{password}','{name}','{sex}')";
                    conn.Open();
                    cmd = new MySqlCommand(sql, conn);
                    reader = cmd.ExecuteReader();
                    
                    MessageBox.Show("Registered Successfully!");
                    Form1 form1 = new Form1();
                    this.Close();
                    form1.Show();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Registration Failed!");
                }
            }
            else
            {
                MessageBox.Show("Registration Failed");
            }

            conn.Close();

        }
    }
}
