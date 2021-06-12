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

namespace Snap.non_fabirc
{
    public partial class issue_report_category : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public issue_report_category()
        {
            InitializeComponent();
        }

        private void issue_report_category_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select sum(amount)as amount , sum(qty) as qty, name, unit from non_fabric_issue_cat where issue_date between '"+dateTimePicker1.Value.ToString("yyyy-MM-dd")+ "' and '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' group by name", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["name"].Value = dr["name"].ToString();
                    dataGridView1.Rows[i].Cells["amount"].Value = dr["amount"].ToString();
                    dataGridView1.Rows[i].Cells["qty"].Value = dr["qty"].ToString();
                    dataGridView1.Rows[i].Cells["uom"].Value = dr["unit"].ToString();
                }
                sum_of_amt = 0;
                total_amount_cal();
            }
            else if(radioButton2.Checked==true)
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select sum(amount)as amount , sum(qty) as qty, item_catagory, unit from non_fabric_issue_cat where issue_date between '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' group by item_catagory", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["name"].Value = dr["item_catagory"].ToString();
                    dataGridView1.Rows[i].Cells["amount"].Value = dr["amount"].ToString();
                    dataGridView1.Rows[i].Cells["qty"].Value = dr["qty"].ToString();
                    dataGridView1.Rows[i].Cells["uom"].Value = dr["unit"].ToString();
                }
                sum_of_amt = 0;
                total_amount_cal();
            }
            else
            {
                MessageBox.Show("Please Select any oiption to retrive", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        double sum_of_amt = 0;
        public void total_amount_cal()
        {
            try
            {

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    sum_of_amt += System.Convert.ToDouble(dataGridView1.Rows[i].Cells["amount"].Value);
                }
                label18.Text = System.Convert.ToString(Math.Round(sum_of_amt, 2));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

            for (int k = 1; k < dataGridView1.Columns.Count + 1; k++)
            {
                xlWorkSheet.Cells[1, k] = dataGridView1.Columns[k - 1].HeaderText;
                xlWorkSheet.Cells[1, k].Font.Bold = true;
            }

            for (i = 0; i <= dataGridView1.RowCount - 1; i++)
            {
                for (j = 0; j <= dataGridView1.ColumnCount - 1; j++)
                {
                    DataGridViewCell cell = dataGridView1[j, i];
                    xlWorkSheet.Cells[i + 2, j + 1] = cell.Value;

                }
            }
            xlWorkSheet.Columns.AutoFit();
            xlApp.Visible = true;
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
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
    }
}
