using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace Snap.non_fabirc
{
    public partial class purchase_report_amount : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public purchase_report_amount()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            MySqlDataAdapter da = new MySqlDataAdapter("select vendor, sum(total) as total, sum(amount) as amount from grn_view where grn_date between '"+dateTimePicker1.Value.ToString("yyyy-MM-dd")+ "' and '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' group by vendor", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["vendor"].Value = dr["vendor"].ToString();
                dataGridView1.Rows[i].Cells["without_gst"].Value = dr["amount"].ToString();
                dataGridView1.Rows[i].Cells["with_gst"].Value = dr["total"].ToString();
            }
            sum_of_amt_without_gst = 0;
            sum_of_amt_with_gst = 0;
            total_amount_cal();
        }

        private void purchase_report_amount_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        double sum_of_amt_with_gst = 0;
        double sum_of_amt_without_gst = 0;
        public void total_amount_cal()
        {
            try
            {

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    sum_of_amt_without_gst += System.Convert.ToDouble(dataGridView1.Rows[i].Cells["without_gst"].Value);
                    sum_of_amt_with_gst += System.Convert.ToDouble(dataGridView1.Rows[i].Cells["with_gst"].Value);
                }
                label18.Text = System.Convert.ToString(Math.Round(sum_of_amt_with_gst, 2));
                label3.Text = System.Convert.ToString(Math.Round(sum_of_amt_without_gst, 2));
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
