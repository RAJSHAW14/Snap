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
using Excel = Microsoft.Office.Interop.Excel;

namespace Snap.accessiories_forms
{
    public partial class access_item : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public access_item()
        {
            InitializeComponent();
        }

        private void access_item_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            datagride_add_data();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            item_cart cart = new item_cart();
            cart.Show();
        }

        public void datagride_add_data()
        {
            MySqlCommand cmd3 = con.CreateCommand();
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "select * from item where item_type='ACC'";
            cmd3.ExecuteNonQuery();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd3);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = dr["id"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = dr["item_name"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = dr["item_code"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = dr["item_catagory"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = dr["color"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = dr["uom"].ToString();
                dataGridView1.Rows[n].Cells[6].Value = dr["gst"].ToString();
                dataGridView1.Rows[n].Cells[7].Value = dr["hsn"].ToString();
                dataGridView1.Rows[n].Cells[8].Value = dr["inventory"].ToString();
                dataGridView1.Rows[n].Cells[9].Value = dr["last_purchase_price"].ToString();
            }

        }

        int item_id = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                item_id = System.Convert.ToInt32(row.Cells["id"].Value.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (item_id == 0)
            {
                MessageBox.Show("Select Item first");
            }

            else
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from item where id = '" + item_id.ToString() + "' ";
                cmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                item_cart cart = new item_cart();
                foreach (DataRow dr in dt.Rows)
                {
                    //cart.item_id = dr["id"].ToString();
                    cart.textBox1.Text = dr["item_code"].ToString();
                    cart.comboBox5.Text = dr["item_name"].ToString();
                    cart.textBox2.Text = dr["color"].ToString();
                    cart.comboBox1.Text = dr["item_catagory"].ToString();
                    cart.comboBox2.Text = dr["uom"].ToString();
                    cart.textBox3.Text = dr["unit_price"].ToString();
                    cart.comboBox3.Text = dr["gst"].ToString();
                    cart.comboBox4.Text = dr["hsn"].ToString();
                    cart.textBox4.Text = dr["current_valuation"].ToString();
                    cart.textBox5.Text = dr["inventory"].ToString();
                    cart.textBox6.Text = dr["last_purchase_price"].ToString();
                }
                cart.textBox1.ReadOnly = true;
                cart.button1.Enabled = false;
                cart.Show();
            }
        }

        public void datagride_reload()
        {
            dataGridView1.Rows.Clear();
            datagride_add_data();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            datagride_reload();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Text = "Please Wait....";
            button6.Enabled = false;
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            int i = 0;
            int j = 0;

            for (i = 0; i <= dataGridView1.RowCount - 1; i++)
            {
                for (j = 0; j <= dataGridView1.ColumnCount - 1; j++)
                {
                    DataGridViewCell cell = dataGridView1[j, i];
                    xlWorkSheet.Cells[i + 1, j + 1] = cell.Value;
                }
            }
            xlWorkBook.SaveAs("Export.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
            MessageBox.Show("Excel File Created , You can find c:\\Export.xls");
            button6.Text = "EXPORT";
            button6.Enabled = true;
        }

        public void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Item Code")
            {
                dataGridView1.Rows.Clear();
                MySqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "select * from item where item_type='ACC' and item_code like '%" + textBox1.Text + "%'";
                cmd3.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd3);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = dr["id"].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = dr["item_name"].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = dr["item_code"].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = dr["item_catagory"].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = dr["color"].ToString();
                    dataGridView1.Rows[n].Cells[5].Value = dr["uom"].ToString();
                    dataGridView1.Rows[n].Cells[6].Value = dr["gst"].ToString();
                    dataGridView1.Rows[n].Cells[7].Value = dr["hsn"].ToString();
                    dataGridView1.Rows[n].Cells[8].Value = dr["inventory"].ToString();
                    dataGridView1.Rows[n].Cells[9].Value = dr["last_purchase_price"].ToString();
                }
            }

            else if (comboBox1.Text == "Categories")
            {
                dataGridView1.Rows.Clear();
                MySqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "select * from item where item_type='ACC' and item_name like '%" + textBox1.Text + "%'";
                cmd3.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd3);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = dr["id"].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = dr["item_name"].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = dr["item_code"].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = dr["item_catagory"].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = dr["color"].ToString();
                    dataGridView1.Rows[n].Cells[5].Value = dr["uom"].ToString();
                    dataGridView1.Rows[n].Cells[6].Value = dr["gst"].ToString();
                    dataGridView1.Rows[n].Cells[7].Value = dr["hsn"].ToString();
                    dataGridView1.Rows[n].Cells[8].Value = dr["inventory"].ToString();
                    dataGridView1.Rows[n].Cells[9].Value = dr["last_purchase_price"].ToString();
                }
            }

            else if (comboBox1.Text == "Sub Categories")
            {
                dataGridView1.Rows.Clear();
                MySqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "select * from item where item_type='ACC' and item_catagory like '%" + textBox1.Text + "%'";
                cmd3.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd3);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = dr["id"].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = dr["item_name"].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = dr["item_code"].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = dr["item_catagory"].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = dr["color"].ToString();
                    dataGridView1.Rows[n].Cells[5].Value = dr["uom"].ToString();
                    dataGridView1.Rows[n].Cells[6].Value = dr["gst"].ToString();
                    dataGridView1.Rows[n].Cells[7].Value = dr["hsn"].ToString();
                    dataGridView1.Rows[n].Cells[8].Value = dr["inventory"].ToString();
                    dataGridView1.Rows[n].Cells[9].Value = dr["last_purchase_price"].ToString();
                }
            }
            else if (textBox1.Text == "")
            {
                datagride_reload();
            }
            else
            {
                datagride_reload();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double stock = 0;
            MySqlDataAdapter da = new MySqlDataAdapter("Select * from item where id='" + item_id + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                stock=System.Convert.ToDouble(dr["inventory"].ToString());
            }
            if(stock==0)
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from item where id='"+item_id+"'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Item Deleted Sucessfully");
                datagride_reload();
            }
            else
            {
                MessageBox.Show("Stock is Available for this item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
