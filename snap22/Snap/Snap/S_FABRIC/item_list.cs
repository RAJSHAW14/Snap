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
using System.Configuration;
using Excel = Microsoft.Office.Interop.Excel;


namespace Snap.S_FABRIC
{
    public partial class item_list : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public item_list()
        {
            InitializeComponent();
        }

        private void item_list_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            datagride_add_data();
        }

        public void datagride_add_data()
        {
            MySqlCommand cmd3 = con.CreateCommand();
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "select * from item where item_type='S-FABRIC'";
            cmd3.ExecuteNonQuery();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd3);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells["id"].Value = dr["id"].ToString();
                dataGridView1.Rows[n].Cells["item_code"].Value = dr["item_code"].ToString();
                dataGridView1.Rows[n].Cells["item_name"].Value = dr["item_name"].ToString();
                dataGridView1.Rows[n].Cells["catagory"].Value = dr["item_catagory"].ToString();
                dataGridView1.Rows[n].Cells["uom"].Value = dr["uom"].ToString();
                dataGridView1.Rows[n].Cells["gst"].Value = dr["gst"].ToString();
                dataGridView1.Rows[n].Cells["hsn"].Value = dr["hsn"].ToString();
                dataGridView1.Rows[n].Cells["inventory"].Value = dr["inventory"].ToString();
                dataGridView1.Rows[n].Cells["Rate"].Value = dr["last_purchase_price"].ToString();
                dataGridView1.Rows[n].Cells["purc_uom"].Value = dr["purchase_uom"].ToString();
                dataGridView1.Rows[n].Cells["purc_rate"].Value = dr["purchase_rate"].ToString();
            }
        }

        public void reload()
        {
            dataGridView1.Rows.Clear();
            datagride_add_data();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                reload();
            }
            else if (comboBox1.Text == "Fabric Code")
            {
                dataGridView1.Rows.Clear();
                MySqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "select * from item where item_type='S-FABRIC' and item_code like '%" + textBox1.Text + "%'";
                cmd3.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd3);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells["id"].Value = dr["id"].ToString();
                    dataGridView1.Rows[n].Cells["item_code"].Value = dr["item_code"].ToString();
                    dataGridView1.Rows[n].Cells["item_name"].Value = dr["item_name"].ToString();
                    dataGridView1.Rows[n].Cells["catagory"].Value = dr["item_catagory"].ToString();
                    dataGridView1.Rows[n].Cells["uom"].Value = dr["uom"].ToString();
                    dataGridView1.Rows[n].Cells["gst"].Value = dr["gst"].ToString();
                    dataGridView1.Rows[n].Cells["hsn"].Value = dr["hsn"].ToString();
                    dataGridView1.Rows[n].Cells["inventory"].Value = dr["inventory"].ToString();
                    dataGridView1.Rows[n].Cells["Rate"].Value = dr["last_purchase_price"].ToString();
                    dataGridView1.Rows[n].Cells["purc_uom"].Value = dr["purchase_uom"].ToString();
                    dataGridView1.Rows[n].Cells["purc_rate"].Value = dr["purchase_rate"].ToString();
                }
            }
            else if (comboBox1.Text == "Name")
            {
                dataGridView1.Rows.Clear();
                MySqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "select * from item where item_type='S-FABRIC' and item_name like '%" + textBox1.Text + "%'";
                cmd3.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd3);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells["id"].Value = dr["id"].ToString();
                    dataGridView1.Rows[n].Cells["item_code"].Value = dr["item_code"].ToString();
                    dataGridView1.Rows[n].Cells["item_name"].Value = dr["item_name"].ToString();
                    dataGridView1.Rows[n].Cells["catagory"].Value = dr["item_catagory"].ToString();
                    dataGridView1.Rows[n].Cells["uom"].Value = dr["uom"].ToString();
                    dataGridView1.Rows[n].Cells["gst"].Value = dr["gst"].ToString();
                    dataGridView1.Rows[n].Cells["hsn"].Value = dr["hsn"].ToString();
                    dataGridView1.Rows[n].Cells["inventory"].Value = dr["inventory"].ToString();
                    dataGridView1.Rows[n].Cells["Rate"].Value = dr["last_purchase_price"].ToString();
                    dataGridView1.Rows[n].Cells["purc_uom"].Value = dr["purchase_uom"].ToString();
                    dataGridView1.Rows[n].Cells["purc_rate"].Value = dr["purchase_rate"].ToString();
                }
            }
            else if (comboBox1.Text == "Sub Categories")
            {
                dataGridView1.Rows.Clear();
                MySqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "select * from item where item_type='S-FABRIC' and item_catagory like '%" + textBox1.Text + "%'";
                cmd3.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd3);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells["id"].Value = dr["id"].ToString();
                    dataGridView1.Rows[n].Cells["item_code"].Value = dr["item_code"].ToString();
                    dataGridView1.Rows[n].Cells["item_name"].Value = dr["item_name"].ToString();
                    dataGridView1.Rows[n].Cells["catagory"].Value = dr["item_catagory"].ToString();
                    dataGridView1.Rows[n].Cells["uom"].Value = dr["uom"].ToString();
                    dataGridView1.Rows[n].Cells["gst"].Value = dr["gst"].ToString();
                    dataGridView1.Rows[n].Cells["hsn"].Value = dr["hsn"].ToString();
                    dataGridView1.Rows[n].Cells["inventory"].Value = dr["inventory"].ToString();
                    dataGridView1.Rows[n].Cells["Rate"].Value = dr["last_purchase_price"].ToString();
                    dataGridView1.Rows[n].Cells["purc_uom"].Value = dr["purchase_uom"].ToString();
                    dataGridView1.Rows[n].Cells["purc_rate"].Value = dr["purchase_rate"].ToString();
                }
            }
            else
            {
                reload();
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

        private void button5_Click(object sender, EventArgs e)
        {
            reload();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            item_cart cart = new item_cart();
            cart.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (item_id == 0)
            {
                MessageBox.Show("Please select the cell to Edit");
            }
            else
            {
                item_cart cart = new item_cart();
                cart.textBox9.Text = item_id.ToString();
                cart.fill_data();
                cart.Show();
            }
        }

        string stock = "", item_code_check = "";
        private void button3_Click(object sender, EventArgs e)
        {
            if (item_id == 0)
            {
                MessageBox.Show("Please select the cell to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select * from item where ID='" + item_id.ToString() + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    stock = dr["inventory"].ToString();
                    item_code_check = dr["item_code"].ToString();
                }
                if (stock == "0")
                {
                    DialogResult result = MessageBox.Show("Do You Want to delete item " + item_code_check, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        MySqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "delete from item where ID='" + item_id.ToString() + "'";
                        cmd.ExecuteNonQuery();
                        MessageBox.Show(item_code_check + " Deleted Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reload();
                        item_id = 0;
                    }
                }
                else
                {
                    MessageBox.Show("Stock Already Available for this item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
    }
}
