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
    public partial class view_issue : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public view_issue()
        {
            InitializeComponent();
        }

        private void view_issue_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        public void fill_data()
        {
            int j = 0;
            MySqlDataAdapter da = new MySqlDataAdapter("select * from acc_item_issue where issue_date='" + maskedTextBox1.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            j = System.Convert.ToInt32(dt.Rows.Count.ToString());
            if (j == 0)
            {
                MessageBox.Show("Date Not Found");
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dr["req_number"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dr["issue_date"].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dr["department"].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dr["designer"].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = dr["batchcode"].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = dr["p_code"].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = dr["item"].ToString();
                    dataGridView1.Rows[i].Cells[8].Value = dr["item_code"].ToString();
                    dataGridView1.Rows[i].Cells[9].Value = dr["name"].ToString();
                    //dataGridView1.Rows[i].Cells[10].Value = dr["amount"].ToString();
                    dataGridView1.Rows[i].Cells[11].Value = dr["unit"].ToString();
                    dataGridView1.Rows[i].Cells[12].Value = dr["qty"].ToString();
                    dataGridView1.Rows[i].Cells[13].Value = dr["rate"].ToString();
                    dataGridView1.Rows[i].Cells[14].Value = dr["amount"].ToString();
                    dataGridView1.Rows[i].Cells[15].Value = dr["for_vendor"].ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fill_data();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Text = "Please Wait....";
            button2.Enabled = false;
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
            button2.Text = "EXPORT";
            button2.Enabled = true;
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (id_value == 0)
            {
                MessageBox.Show("Select the cell first");
            }
            else
            {
                non_fabric_issue issue = new non_fabric_issue();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from acc_item_issue where id='" + id_value + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    issue.textBox2.Text = dr["req_number"].ToString();
                    issue.dateTimePicker1.Value = System.Convert.ToDateTime(dr["issue_date"].ToString());
                    issue.textBox3.Text = dr["batchcode"].ToString();
                    issue.textBox4.Text = dr["department"].ToString();
                    issue.textBox5.Text = dr["designer"].ToString();
                    issue.textBox6.Text = dr["item_code"].ToString();
                    issue.textBox7.Text = dr["name"].ToString();
                    issue.textBox8.Text = dr["rate"].ToString();
                    issue.textBox11.Text = dr["qty"].ToString();
                    issue.textBox9.Text = dr["unit"].ToString();
                    issue.textBox12.Text = dr["amount"].ToString();
                    issue.textBox13.Text = dr["for_vendor"].ToString();
                    issue.textBox18.Text = dr["item"].ToString();                    
                    issue.textBox15.Text = dr["id"].ToString();
                    issue.textBox16.Text = dr["qty"].ToString();
                    issue.textBox17.Text = dr["item_code"].ToString();
                }
                issue.button2.Enabled = false;
                issue.view_stock();
                issue.Show();
            }
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


    }
}
