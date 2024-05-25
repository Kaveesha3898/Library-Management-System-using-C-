using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Library_Management_System
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm?", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtEnrollment.Clear();
            txtDepartment.Clear();
            txtStuSem.Clear();
            txtStuCon.Clear();
            txtEmail.Clear();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtEnrollment.Text != "" && txtDepartment.Text != "" && txtStuSem.Text != "" && txtStuCon.Text != "" && txtEmail.Text != "")
            {
                String name = txtName.Text;
                String enroll = txtEnrollment.Text;
                String dep = txtDepartment.Text;
                String sem = txtStuSem.Text;
                Int64 mobile = Int64.Parse(txtStuCon.Text);
                String email = txtEmail.Text;

                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = "data source = 127.0.0.1;port=3306;username=root;password=;database=library";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "Insert into newstudent (Name,Enroll,Dep,Sem,Contact,Email) values ('" + name + "','" + enroll + "','" + dep + "','" + sem + "'," + mobile + ",'" + email + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please Fill Empty Fields", "Suggestion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
