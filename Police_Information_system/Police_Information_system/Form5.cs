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
    public partial class Form5 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database1.mdf\";Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        String dName;
        String uid;
        public Form5(String UID)
        {
            InitializeComponent();
            uid = UID;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            con.Open();
            String qry1 = $"SELECT * FROM [department]";
            dr = new SqlCommand(qry1, con).ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[1]).ToString();
            }
            dr.Close();
            con.Close();
        }
        public void showDetails()
        {
            String qry1 = $"SELECT * FROM [candidate] where u_id={uid}";
            String qry2 = $"SELECT * FROM [Physical_Fitness] where UID={uid}";
            String qry3 = $"SELECT * FROM [Practical] where UID={uid}";
            String qry4 = $"SELECT * FROM [Theory] where UID={uid} ";

            con.Open();

            cmd = new SqlCommand(qry1, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            user_id.Text = dr[0].ToString();
            name.Text = dr[1].ToString()+" "+ dr[2].ToString()+" "+ dr[3].ToString();
            gender.Text = dr[4].ToString();
            address.Text = dr[5].ToString();
            dr.Close();

            cmd = new SqlCommand(qry2, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            height.Text = dr[0].ToString();
            weight.Text = dr[1].ToString();
            chest.Text = dr[2].ToString();
            shoulders.Text = dr[3].ToString();
            eyesightl.Text = dr[4].ToString();
            eyesightr.Text = dr[5].ToString();
            dr.Close();

            cmd = new SqlCommand(qry3, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            practmarks.Text = dr[0].ToString();
            practpercentage.Text = dr[1].ToString();
            dr.Close();

            cmd = new SqlCommand(qry4, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            theomarks.Text = dr[0].ToString();
            theopercentage.Text = dr[1].ToString();
            dr.Close();

            con.Close();




        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void weight_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            dName = (string)comboBox.SelectedItem;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            String qry1 = $"Insert into [selected_candidates] values({uid},(SELECT department_id FROM [department] where department_name='{dName.Trim()}'))";
            String qry2 = $"Update candidate set DSelected =(SELECT department_id FROM [department] where department_name='{dName.Trim()}') where u_id={uid}";

            if (MessageBox.Show($"Are you sure you want to add Candidate {user_id.Text} to {dName}", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                con.Open();
                cmd = new SqlCommand(qry1, con);
                dr = cmd.ExecuteReader();
                dr.Close();
                cmd = new SqlCommand(qry2, con);
                dr = cmd.ExecuteReader();
                dr.Close();
                con.Close();
                Form4 obj = new Form4();
                obj.refreshDataGridView();
                MessageBox.Show("Data added successfully");
                this.Close();
                obj.Show();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 obj=new Form4();
            obj.refreshDataGridView();
            this.Hide(); 
            

        }
    }
}
