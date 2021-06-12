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
    public partial class non_fabirc_issue_view : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public non_fabirc_issue_view()
        {
            InitializeComponent();
        }

        private void non_fabirc_issue_view_Load(object sender, EventArgs e)
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
            MySqlDataAdapter da = new MySqlDataAdapter("select * from non_fabric_item_issue where issue_date between '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'", con);
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
                    dataGridView1.Rows[i].Cells[2].Value = System.Convert.ToDateTime(dr["issue_date"].ToString());
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
                sum_of_amt = 0;
                total_amount_cal();
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
            catch
            {

            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
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

            for (int k = 1; k < dataGridView1.Columns.Count + 1; k++)
            {
                xlWorkSheet.Cells[1, k] = dataGridView1.Columns[k - 1].HeaderText;
                xlWorkSheet.Cells[1, k].Font.Bold = true;
            }

            for (i = 0; i <= dataGridView1.RowCount - 1;i++ )
            {
                for(j=0;j<=dataGridView1.ColumnCount-1;j++)
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
            catch(Exception ex)
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
            if (id_value==0)
            {
                MessageBox.Show("Select the cell first");
            }
            else
            {
                non_fabric_issue issue=new non_fabric_issue();
                MySqlDataAdapter da=new MySqlDataAdapter("select * from non_fabric_item_issue where id='"+id_value+"'",con);
                DataTable dt=new DataTable();
                da.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    issue.textBox2.Text=dr["req_number"].ToString();
                    issue.dateTimePicker1.Value=System.Convert.ToDateTime(dr["issue_date"].ToString());
                    issue.textBox3.Text=dr["batchcode"].ToString();
                    issue.textBox4.Text=dr["department"].ToString();
                    issue.textBox5.Text=dr["designer"].ToString();
                    issue.textBox6.Text=dr["item_code"].ToString();
                    issue.textBox7.Text=dr["name"].ToString();
                    issue.textBox8.Text=dr["rate"].ToString();
                    issue.textBox11.Text=dr["qty"].ToString();
                    issue.textBox9.Text=dr["unit"].ToString();
                    issue.textBox12.Text=dr["amount"].ToString();
                    issue.textBox13.Text=dr["for_vendor"].ToString();
                    issue.textBox18.Text = dr["item"].ToString();
                    issue.textBox15.Text=dr["id"].ToString();
                    issue.textBox16.Text=dr["qty"].ToString();
                    issue.textBox17.Text=dr["item_code"].ToString();
                }
                issue.button2.Enabled=false;
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

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
