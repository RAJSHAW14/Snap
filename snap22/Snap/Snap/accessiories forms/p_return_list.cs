﻿using System;
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

namespace Snap.accessiories_forms
{
    public partial class p_return_list : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public p_return_list()
        {
            InitializeComponent();
        }

        private void p_return_list_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            fill_data();
        }

        public void fill_data()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from acc_transactions where transaction_type='P-RETURN'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dr["number"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = dr["date"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = dr["vendor"].ToString();
                dataGridView1.Rows[i].Cells[4].Value = dr["bill_number"].ToString();
                dataGridView1.Rows[i].Cells[5].Value = dr["bill_date"].ToString();
                dataGridView1.Rows[i].Cells[6].Value = dr["reff_po_number"].ToString();
                dataGridView1.Rows[i].Cells[7].Value = dr["item_code"].ToString();
                dataGridView1.Rows[i].Cells[8].Value = dr["qty"].ToString();
                dataGridView1.Rows[i].Cells[9].Value = dr["uom"].ToString();
                dataGridView1.Rows[i].Cells[10].Value = dr["gst_amt"].ToString();
                dataGridView1.Rows[i].Cells["final_amt"].Value = dr["inc_tax_amt"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p_return_cart cart = new p_return_cart();
            cart.button2.Enabled = false;
            cart.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (p_return == 0)
            {
                MessageBox.Show("Please select the cell first");
            }
            else
            {
                p_return_cart cart = new p_return_cart();
                cart.button1.Enabled = false;
                cart.textBox2.Text = p_return.ToString();
                cart.fill_data();
                cart.Show();
            }
        }

        int p_return = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                p_return = System.Convert.ToInt32(row.Cells["grn"].Value.ToString());
            }
        }

        public void data_reload()
        {
            dataGridView1.Rows.Clear();
            fill_data();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            data_reload();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (p_return == 0)
            {
                MessageBox.Show("Please select the cell first");
            }
            else
            {
                p_return_cart cart = new p_return_cart();
                cart.button1.Enabled = false;
                cart.textBox2.Text = p_return.ToString();
                cart.fill_data();
                cart.Show();
            }
        }

    }
}
