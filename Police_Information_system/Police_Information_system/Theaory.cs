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
    public partial class Theaory : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database1.mdf\";Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        Boolean isPresent;

        private static Theaory _instance;
        public static Theaory Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Theaory();
                return _instance;
            }
        }
        public Theaory()
        {
            InitializeComponent();
        }
        public void showDetails()
        {
            String qry = $"Select * from Theory where UID={Form2.uid}";
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
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            dr.Close();
            con.Close();
        }
        private void Theaory_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                String syntax;
                if (!isPresent)
                    syntax = $"Insert into [Theory] values('{textBox1.Text}','{textBox2.Text}','{textBox3.Text}','{Form2.uid}')";
                else
                    syntax = $"Update [Theory] set maximum_marks='{textBox1.Text}',marks_optained='{textBox2.Text}',percentage='{textBox3.Text}' where UID={Form2.uid}";
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
