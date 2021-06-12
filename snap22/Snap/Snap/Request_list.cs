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

namespace Snap
{
    public partial class Request_list : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public Request_list()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Text = "Please Wait....";
            button3.Enabled = false;
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
            button3.Text = "EXPORT";
            button3.Enabled = true;
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

        private void Request_list_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            fill_data1();
        }

        public void fill_data1()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from non_fabric_request where pending_qty>0", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dr["req_number"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = dr["batchcode"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = dr["department"].ToString();
                dataGridView1.Rows[i].Cells[4].Value = dr["designer"].ToString();
                dataGridView1.Rows[i].Cells[5].Value = dr["item_code"].ToString();
                dataGridView1.Rows[i].Cells[6].Value = dr["item_name"].ToString();
                dataGridView1.Rows[i].Cells[7].Value = dr["pending_qty"].ToString();
                dataGridView1.Rows[i].Cells[8].Value = dr["unit"].ToString();
                dataGridView1.Rows[i].Cells[9].Value = dr["req_date"].ToString();
                dataGridView1.Rows[i].Cells[10].Value = dr["req_date"].ToString();
            }
        }

        public void fill_data()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from non_fabric_request where req_number='" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dr["req_number"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = dr["batchcode"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = dr["department"].ToString();
                dataGridView1.Rows[i].Cells[4].Value = dr["designer"].ToString();
                dataGridView1.Rows[i].Cells[5].Value = dr["item_code"].ToString();
                dataGridView1.Rows[i].Cells[6].Value = dr["item_name"].ToString();
                dataGridView1.Rows[i].Cells[7].Value = dr["qty"].ToString();
                dataGridView1.Rows[i].Cells[8].Value = dr["unit"].ToString();
                dataGridView1.Rows[i].Cells[9].Value = dr["req_date"].ToString();
                dataGridView1.Rows[i].Cells[10].Value = dr["req_date"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fill_data();
        }

        int id_value = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                id_value = System.Convert.ToInt32(row.Cells["id"].Value.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(id_value==0)
            {
                MessageBox.Show("Select the Cell First");
            }
            else
            {
                DialogResult result = MessageBox.Show("Doy you want to delete", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result==DialogResult.Yes)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "delete from non_fabric_request where id='" + id_value + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Delete Sucessfully");
                    dataGridView1.Rows.Clear();
                    fill_data();
                }
                else
                {

                }
                
            }
        }
    }
}
