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

namespace Snap.CMC
{
    public partial class add_mat : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public add_mat()
        {
            InitializeComponent();
        }

        private void add_mat_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            auto_complete_mat_code();
        }

        public void auto_complete_mat_code()
        {
            MySqlCommand cmd = new MySqlCommand("select item_code from item where item_type='NON-FABRIC'", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection autocomplete = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                autocomplete.Add(dr.GetString(0));

            }
            textBox1.AutoCompleteCustomSource = autocomplete;
            dr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("Please Enter Material code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(textBox4.Text=="")
            {
                MessageBox.Show("Please Enter Minimum Qty Level", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int i=0;
                MySqlDataAdapter da = new MySqlDataAdapter("select * from cmc_mat where mat_code='" + textBox1.Text + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if(i==0)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into cmc_mat (mat_code,mat_type,uom,min_stock) Values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("MAT Inserted Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Material Already Inserted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            int i = 0;
            MySqlDataAdapter da = new MySqlDataAdapter("select * from item where item_code='" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            i=System.Convert.ToInt32(dt.Rows.Count.ToString());
            if(i==0)
            {
                MessageBox.Show("Mat code is Incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach(DataRow dr in dt.Rows)
                {
                    textBox2.Text=dr["item_name"].ToString();
                    textBox3.Text = dr["uom"].ToString();
                }
            }
        }
    }
}
