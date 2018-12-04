using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Police_Information_system
{
    public partial class Candidate_Details : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database1.mdf\";Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        Boolean isPresent;

  //      this is not new. dont change this
        private static Candidate_Details _instance;
        public static Candidate_Details Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Candidate_Details();
                return _instance;
            }
        }
        String[] Gender = new String[] { "Male", "Female", "Others" };
        public Candidate_Details()
        {
            InitializeComponent();
            isPresent = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void showDetails()
        {
            String qry = $"Select * from candidate where u_id={Form2.uid}";
            label6.Text = Form2.uid;
            con.Open();
            cmd = new SqlCommand(qry, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                isPresent = true;
                textBox1.Text = dr[1].ToString();
                textBox2.Text = dr[2].ToString();
                textBox3.Text = dr[3].ToString();
                comboBox1.Text = dr[4].ToString();
                textBox4.Text = dr[5].ToString();
            }
            else
            {

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                comboBox1.Text = "";
                textBox4.Text = "";
            }
            dr.Close();
            con.Close();
        }
        private void Candidate_Details_Load(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                String syntax;
                if(!isPresent)
                    syntax= $"Insert into [candidate] values({Form2.uid},'{textBox1.Text}','{textBox2.Text}','{textBox3.Text}','{comboBox1.Text}','{textBox4.Text}',NULL)";
                else
                    syntax = $"Update [candidate] set First_Name='{textBox1.Text}',Mid_Name='{textBox2.Text}',Last_Name='{textBox3.Text}',Gender='{comboBox1.Text}',Address='{textBox4.Text}' where u_id={Form2.uid}";
                cmd = new SqlCommand(syntax, con);
                dr = cmd.ExecuteReader();
                dr.Close();
                con.Close();
                MessageBox.Show("Data added succesfully");
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
