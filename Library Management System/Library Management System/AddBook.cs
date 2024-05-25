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
    public partial class AddBook : Form
    {
        public AddBook()
        {
            InitializeComponent();
        }

                    
        private void Btncancel_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void Btnsave_Click(object sender, EventArgs e)
        {
            if (txtBName.Text != "" && txtAuthur.Text != "" && txtPub.Text != "" && txtBPrice.Text != "" && txtQuantity.Text != "")
            {

                String bname = txtBName.Text;
                String bauthur = txtAuthur.Text;
                String pub = txtPub.Text;
                String pdate = dateTimePicker1.Text;
                Int64 price = Int64.Parse(txtBPrice.Text);
                Int64 quan = Int64.Parse(txtQuantity.Text);

                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = "data source = 127.0.0.1;port=3306;username=root;password=;database=library";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into newbook (BookName,BookAruthor,BookPublication,BookPDate,BookPrice,BookQuantity) values ('" + bname + "','" + bauthur + "','" + pub + "','" + pdate + "'," + price + "," + quan + ")";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBName.Clear();
                txtAuthur.Clear();
                txtBPrice.Clear();
                txtPub.Clear();
                txtQuantity.Clear();
            }
            else
            {
                MessageBox.Show("Empty Field Not Allowed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
