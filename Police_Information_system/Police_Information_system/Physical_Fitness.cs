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
    public partial class Physical_Fitness : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database1.mdf\";Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        Boolean isPresent;

        //copy the above three lines and replace in the new user control forms where you make changes

        private static Physical_Fitness _instance;
        public static Physical_Fitness Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Physical_Fitness();
                return _instance;
            }
        }
        public void showDetails()
        {
            String qry = $"Select * from Physical_Fitness where UID={Form2.uid}";
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
                textBox4.Text = dr[4].ToString();
                textBox5.Text = dr[5].ToString();
                textBox6.Text = dr[6].ToString();
            }
            else
            {

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
            }
            dr.Close();
            con.Close();
        }
        public Physical_Fitness()
        {
            InitializeComponent();
        }

        private void Height_Click(object sender, EventArgs e)
        {

        }

        private void Physical_Fitness_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                String syntax;
                if (!isPresent)
                    syntax = $"Insert into [Physical_Fitness] values('{textBox1.Text}','{textBox2.Text}','{textBox3.Text}','{textBox4.Text}','{textBox5.Text}','{textBox6.Text}','{Form2.uid}')";
                else
                    syntax = $"Update [Physical_Fitness] set height='{textBox1.Text}',weight='{textBox2.Text}',chest='{textBox3.Text}',shoulders='{textBox4.Text}',l_eyeshight='{textBox5.Text}',r_eyesight='{textBox6.Text}' where UID={Form2.uid}";
                cmd = new SqlCommand(syntax, con);
                dr = cmd.ExecuteReader();
                dr.Close();
                con.Close();
                MessageBox.Show("Data added succesfully");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
                dr.Close();
                con.Close();

            }
        }
    }
}
