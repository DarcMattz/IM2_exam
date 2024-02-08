using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; 

namespace exam
{
    public partial class Form1 : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader reader;
        public static string username;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            username = textBox1.Text;
            string password = textBox2.Text;
            conn.Open();
            string sql = $"SELECT * FROM account WHERE email='{username}'";
            cmd = new MySqlCommand(sql, conn);
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (reader.GetString(1) == password)
                    {
                        Form3 form3 = new Form3();
                        MessageBox.Show("Login Successful!");
                        form3.Show();
                        this.Hide();
                        break;
                    }
                    else
                    {
                        MessageBox.Show("User not found or incorrect password.");
                    }
                }
                
                conn.Close();
            }
            else
            {
                MessageBox.Show("User not found or incorrect password.");
                conn.Close();
            }

        }
    }
}
