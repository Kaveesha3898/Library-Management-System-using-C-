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
    public partial class IssueBooks : Form
    {
        public IssueBooks()
        {
            InitializeComponent();
        }

        private void IssueBooks_Load(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "data source = localhost;port=3306;username=root;password=;database=library";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            con.Open();

            cmd = new MySqlCommand("select BookName from newbook", con);
            MySqlDataReader Sdr = cmd.ExecuteReader();

            while (Sdr.Read())
            {
                for (int i = 0; i < Sdr.FieldCount; i++)
                {
                    comboBoxBooks.Items.Add(Sdr.GetString(i));
                }
            }
            Sdr.Close();
            con.Close();
        }
        int count;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtEnrollment.Text != "")
            {
                String edi = txtEnrollment.Text;
                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = "data source = 127.0.0.1;port=3306;username=root;password=;database=library";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;

                cmd.CommandText = " select * from newstudent where enroll = '" + edi + "'";
                MySqlDataAdapter DA = new MySqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                //----------------------------------------------------------------------
                //Code to Count how many book has been issued on this enrollment number

                cmd.CommandText = " select count(std_Enroll) from irbook where std_Enroll = '" + edi + "' and book_return_date is null";
                MySqlDataAdapter DA1 = new MySqlDataAdapter(cmd);
                DataSet DS1 = new DataSet();
                DA.Fill(DS1);

                count = int.Parse(DS1.Tables[0].Rows[0][0].ToString());
                //-----------------------------------------------------------------------


                if (DS.Tables[0].Rows.Count != 0)
                {
                    txtName.Text = DS.Tables[0].Rows[0][1].ToString();
                    txtDepartment.Text = DS.Tables[0].Rows[0][3].ToString();
                    txtSemester.Text = DS.Tables[0].Rows[0][4].ToString();
                    txtContact.Text = DS.Tables[0].Rows[0][5].ToString();
                    txtEmail.Text = DS.Tables[0].Rows[0][6].ToString();
                }
                else
                {
                    txtName.Clear();
                    txtDepartment.Clear();
                    txtSemester.Clear();
                    txtContact.Clear();
                    txtEmail.Clear();
                    MessageBox.Show("Invalid Enrollment No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                if (comboBoxBooks.SelectedIndex != -1 && count <= 2)
                {
                    String enroll = txtEnrollment.Text;
                    String sname = txtName.Text;
                    String sdep = txtDepartment.Text;
                    String sem = txtSemester.Text;
                    Int64 contact = Int64.Parse(txtContact.Text);
                    String email = txtEmail.Text;
                    String bookname = comboBoxBooks.Text;
                    String bookIssueDate = dateTimePicker1.Text;
                   

                    String eid = txtEnrollment.Text;
                    MySqlConnection con = new MySqlConnection();
                    con.ConnectionString = "data source = localhost;port=3306;username=root;password=;database=library";
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = cmd.CommandText = "insert into irbook (std_Enroll,std_Name,std_dep,std_sem,std_contact,std_email,book_name,book_issue_date) values ('" + enroll + "','" + sname + "','" + sdep + "','" + sem + "'," + contact + ",'" + email + "','" + bookname + "','" + bookIssueDate + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Book Issued.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Select Book or Maximum number of Book has been ISSUED", "No Book Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Enter valid Enrollment No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtEnrollment_TextChanged(object sender, EventArgs e)
        {
            if (txtEnrollment.Text == "")
            {
                txtName.Clear();
                txtDepartment.Clear();
                txtSemester.Clear();
                txtContact.Clear();
                txtEmail.Clear();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtEnrollment.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}

