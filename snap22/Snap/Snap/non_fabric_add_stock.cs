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
    public partial class non_fabric_add_stock : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public non_fabric_add_stock()
        {
            InitializeComponent();
        }

        private void non_fabric_add_stock_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            auto_complete();
        }

        public void auto_complete()
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

        private void textBox1_Leave(object sender, EventArgs e)
        {
             if(textBox1.Text=="")
             {

             }
             else
             {
                 int i = 0;
                 MySqlDataAdapter da = new MySqlDataAdapter("select * from item where item_code='" + textBox1.Text + "' and item_type='NON-FABRIC'", con);
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 i = System.Convert.ToInt32(dt.Rows.Count.ToString());
                 {
                     if(i==0)
                     {
                         MessageBox.Show("Item Code is incorrect");
                         textBox2.Clear();
                     }
                     else
                     {
                         foreach(DataRow dr in dt.Rows)
                         {
                             textBox2.Text = dr["inventory"].ToString();
                             textBox4.Text = dr["inventory"].ToString();
                             label5.Text = dr["uom"].ToString();
                             label6.Text = dr["uom"].ToString();
                             label7.Text = dr["uom"].ToString();
                         }
                     }
                 }
             }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {            
            try
            {
                if(textBox3.Text=="")
                {
                    textBox4.Text = System.Convert.ToString(0 + System.Convert.ToDouble(textBox2.Text));
                }
                else
                {
                    textBox4.Text = System.Convert.ToString(System.Convert.ToDouble(textBox3.Text) + System.Convert.ToDouble(textBox2.Text));
                }
            }
            catch(Exception)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("Error");
            }
            else
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update item set inventory='" + textBox4.Text + "' where item_code='"+textBox1.Text+"'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Inventory Update");
                clear();

            }
        }

        public void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
    }
}
