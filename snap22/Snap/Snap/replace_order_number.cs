using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Snap
{
    public partial class replace_order_number : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public replace_order_number()
        {
            InitializeComponent();
        }

        private void replace_order_number_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        public void auto_complete_old()
        {
            MySqlCommand cmd = new MySqlCommand("select emb_order from order_number where order_number like '%" + textBox1.Text + "%'", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection mycollection = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                mycollection.Add(dr.GetString(0));
            }
            textBox1.AutoCompleteCustomSource = mycollection;
            dr.Close();
        }

        public void auto_complete_new()
        {
            MySqlCommand cmd = new MySqlCommand("select emb_order from order_number where order_number like '%" + textBox2.Text + "%'", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection mycollection = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                mycollection.Add(dr.GetString(0));
            }
            textBox2.AutoCompleteCustomSource = mycollection;
            dr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter Old Order Number");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Enter New Order NUmber");
            }
            else
            {
                DialogResult result = MessageBox.Show("DO you want to replace the order number", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE dpr_entry SET order_number='" + textBox2.Text + "' where order_number='" + textBox1.Text + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Updated");
                    textBox1.Clear();
                    textBox2.Clear();
                }
                else
                {

                }

            }
        }
    }
}
