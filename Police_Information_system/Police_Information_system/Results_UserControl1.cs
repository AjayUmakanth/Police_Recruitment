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
    public partial class Results_UserControl1 : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database1.mdf\";Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        private static Results_UserControl1 _instance;
        public static Results_UserControl1 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Results_UserControl1();
                return _instance;
            }
        }
        public void updateDetails()
        {
            String dno="NULL";
            String qry = $"Select DSelected from [candidate]  where u_id={Form2.uid} and Dselected is not null";
            con.Open();
            cmd = new SqlCommand(qry, con);
            dr = cmd.ExecuteReader();
            Boolean assigned = dr.HasRows;
            if (assigned)
            {
                dr.Read();
                dno = dr[0].ToString().Trim();
                dr.Close();
            }
            if (assigned)
            {
                String qry2 = $"Select department_name from department where department_id = {dno}";
                cmd = new SqlCommand(qry2, con);
                dr = cmd.ExecuteReader();
                dr.Read();
                String result = dr[0].ToString().Trim();
                if (result.Trim().Equals("Rejected"))
                    label2.Text = "Sorry you have been rejected";
                else
                    label2.Text = "Congratulations!! You have been assigned to " + result;
                dr.Close();
            }
            else
                label2.Text = "Please wait. Your results are not yet out.";
            con.Close();

        }
        public Results_UserControl1()
        {
            InitializeComponent();
        }

        private void Results_UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
