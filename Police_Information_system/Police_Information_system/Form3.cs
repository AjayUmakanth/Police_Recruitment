using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Police_Information_system
{
    public partial class Form3 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database1.mdf\";Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private String authenticate(String uid)
        {

            con.Open();
            String syntax = "SELECT password FROM [recruiter] WHERE r_id=" + Convert.ToInt32(uid);
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            String temp = "";
            if (dr.HasRows)
            {
                dr.Read();
                temp = dr[0].ToString().Trim();
                dr.Close();
            }
            con.Close();
            return temp;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            String uid = textBox1.Text, pass = authenticate(uid).ToString(), typedPass = textBox2.Text.ToString();
            if (pass.Equals(typedPass))
            {
                Form4 obj = new Form4();
                this.Hide();
                obj.Show();
            }
            else
                MessageBox.Show("Error");
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            String uid = textBox1.Text, pass = authenticate(uid).ToString(), typedPass = textBox2.Text.ToString();
            if (pass.Equals(typedPass))
            {
                Form4 obj = new Form4();
                Form2.uid = uid;
                this.Hide();
                obj.Show();
            }
            else
                MessageBox.Show("Error");
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }
    }
}
