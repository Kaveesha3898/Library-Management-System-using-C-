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
    public partial class Loginform : Form
    {
        public Loginform()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtusername_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void txtusername_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtusername.Text == "Username")
            {
                txtusername.Clear();
            }
        }

        private void txtpassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtpassword.Text == "Password")
            {
                txtpassword.Clear();
                txtpassword.PasswordChar = '*';
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "data source = 127.0.0.1;port=3306;username=root;password=;database=library";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from logintable where username = '" + txtusername.Text + "' and password = '" + txtpassword.Text + "'";
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                this.Hide();
                Dashboad dsa = new Dashboad();
                dsa.Show();
            }
            else
            {
                MessageBox.Show("Wrong Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsignup_Click(object sender, EventArgs e)
        {
            signup sup = new signup();
            sup.Show();
        }

        private void picturefacebook_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/");
        }

        private void picturetwitter_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.twitter.com/");
        }

        private void pictureyoutube_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/");
        }

        private void pictureinstegram_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/");
        }

        

       
        
    }
}
