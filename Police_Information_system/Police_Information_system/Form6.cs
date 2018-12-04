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
    public partial class Form6 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database1.mdf\";Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        public Form6()
        {
            InitializeComponent();
        }
        public void refreshDataGridView()
        {
            con.Open();
            String syntax = $"SELECT s.*,department_name  FROM [selected_candidates] s,department d where s.department_id=d.department_id and d.department_id not in (1) ";
            cmd = new SqlCommand(syntax, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            candidate_list.DataSource = dt;
            this.candidate_list.Refresh();
        }
        private void candidate_list_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
