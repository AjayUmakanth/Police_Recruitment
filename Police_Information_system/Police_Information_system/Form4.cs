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
    public partial class Form4 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database1.mdf\";Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        
        
        public Form4()
        {
            InitializeComponent();
            refreshDataGridView();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
        public void refreshDataGridView()
        {
            con.Open();
            String syntax = $"SELECT * FROM [candidate] where Dselected IS NULL";
            cmd = new SqlCommand(syntax, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            candidate_list.DataSource = dt;
            this.candidate_list.Refresh();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.candidate_list.Rows[e.RowIndex];
                String selected_uid = row.Cells["u_id"].Value.ToString();
                if (MessageBox.Show($"Do you want to see user '{selected_uid}'??", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Form5 obj = new Form5(selected_uid);
                    obj.Show();
                    obj.showDetails();
                    this.Hide();
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 obj = new Form3();
            obj.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 obj = new Form6();
            obj.refreshDataGridView();
            obj.Show();
        }
    }
}
