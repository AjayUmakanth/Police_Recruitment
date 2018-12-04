using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Police_Information_system
{
    public partial class Form2 : Form
    {
        public static String uid = "";
        public Form2(string UID)
        {
            InitializeComponent();
            uid = UID;
            panel3.Controls.Add(Candidate_Details.Instance);
            Candidate_Details.Instance.Dock = DockStyle.Fill;
            Candidate_Details.Instance.showDetails();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(Candidate_Details.Instance))
            {
                panel3.Controls.Add(Candidate_Details.Instance);
                Candidate_Details.Instance.Dock = DockStyle.Fill;
            }
            Candidate_Details.Instance.showDetails();
            Candidate_Details.Instance.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(Physical_Fitness.Instance))
            {
                panel3.Controls.Add(Physical_Fitness.Instance);
                Physical_Fitness.Instance.Dock = DockStyle.Fill;
            }
            Physical_Fitness.Instance.showDetails();
            Physical_Fitness.Instance.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(Practical.Instance))
            {
                panel3.Controls.Add(Practical.Instance);
                Practical.Instance.Dock = DockStyle.Fill;
            }
            Practical.Instance.showDetails();
            Practical.Instance.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(Theaory.Instance))
            {
                panel3.Controls.Add(Theaory.Instance);
                Theaory.Instance.Dock = DockStyle.Fill;
            }
            Theaory.Instance.showDetails();
            Theaory.Instance.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            this.Hide();
            obj.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(Results_UserControl1.Instance))
            {
                panel3.Controls.Add(Results_UserControl1.Instance);
                Results_UserControl1.Instance.Dock = DockStyle.Fill;
            }
            Results_UserControl1.Instance.updateDetails();
            Results_UserControl1.Instance.BringToFront();
        }
    }
}
