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
    public partial class cmc_mat_stock_out : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public cmc_mat_stock_out()
        {
            InitializeComponent();
        }

        private void cmc_mat_stock_out_Load(object sender, EventArgs e)
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
            MySqlCommand cmd = new MySqlCommand("select mat_code from cmc_mat", con);
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

            int i = 0;
            MySqlDataAdapter da = new MySqlDataAdapter("select * from cmc_mat where mat_code='" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            i = System.Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 0)
            {
                MessageBox.Show("Please Enter Correct Mat Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    textBox2.Text = dr["mat_type"].ToString();
                    textBox3.Text = dr["uom"].ToString();
                    textBox4.Text = dr["stock"].ToString();
                    textBox6.Text = dr["stock"].ToString();
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox5.Text == "")
                {
                    textBox6.Text = System.Convert.ToString(System.Convert.ToDouble(textBox4.Text) - 0);
                }
                else
                {
                    textBox6.Text = System.Convert.ToString(System.Convert.ToDouble(textBox4.Text) - System.Convert.ToDouble(textBox5.Text));
                }
            }
            catch (Exception)
            {

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string date;
            date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            if (textBox1.Text == "")
            {
                MessageBox.Show("Mat code not entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into cmc_mat_stock_transaction (date,mat_code,uom,stock,entry_type,for_order_number) Values ('" + date.ToString() + "','" + textBox1.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','OUT','"+textBox7.Text+"')";
                cmd.ExecuteNonQuery();

                MySqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "update cmc_mat set stock='" + textBox6.Text + "' where mat_code ='" + textBox1.Text + "'";
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Inserted Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
            }
        }

        public void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }
    }
}
