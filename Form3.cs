﻿using MySql.Data.MySqlClient;
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
    public partial class Form3 : Form
    {

        MySqlConnection c;
        MySqlCommand cmd;
        MySqlDataReader reader;
        public static string username = "";
        public static string password = "";
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            username = Form1.username;
            string cs = "host=localhost;user=root;password=;database=im_exam";
            c = new MySqlConnection(cs);
            c.Open();
            string select = "SELECT * FROM account WHERE email = '" + username + "'";
            cmd = new MySqlCommand(select, c);
            cmd.ExecuteNonQuery();
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                label7.Text = reader.GetString(0);
                textBox1.Text = reader.GetString(1);
                textBox2.Text = reader.GetString(2);
                if (reader.GetString(3) == "Male")
                {
                    radioButton1.Checked = true;
                }
                else radioButton2.Checked = true;
            }
            reader.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*Form4 form4 = new Form4();
            this.Hide();
            form4.ShowDialog();*/

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string sex = "";
            if (radioButton1.Checked)
            {
                sex = radioButton1.Text;
            }
            else
            {
                sex = radioButton2.Text;
            }
            string update = "UPDATE reginfos SET Password='" + textBox1.Text + "', Name= '" + textBox2.Text + "', Sex='" + sex + "'";
            cmd = new MySqlCommand(update, c);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Updated!");
        }
    }
}
