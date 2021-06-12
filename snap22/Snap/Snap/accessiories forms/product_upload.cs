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
using Microsoft.Office.Interop.Excel;

namespace Snap.accessiories_forms
{
    public partial class product_upload : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public product_upload()
        {
            InitializeComponent();
        }

        private void product_upload_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            maskedTextBox1.Text = DateTime.Today.ToString("dd-MM-yyyy");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application xlApp;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            Microsoft.Office.Interop.Excel.Range xlRange;

            int xlRow;
            string strfileName;
            openFileDialog1.Filter = "Excel Office | *.xls; *.xlsx";
            openFileDialog1.ShowDialog();
            strfileName = openFileDialog1.FileName;

            if(strfileName != string.Empty)
            {
                xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(strfileName);
                xlWorkSheet=xlWorkBook.Worksheets["Sheet1"];
                xlRange = xlWorkSheet.UsedRange;
                dataGridView1.Rows.Clear();
                int i = 0;
                for (xlRow = 2; xlRow <= xlRange.Rows.Count; xlRow++)
                {
                    if(xlRange.Cells[xlRow,1].Text != "")
                    {
                        i++;
                        dataGridView1.Rows.Add(i, xlRange.Cells[xlRow, 1].Text, xlRange.Cells[xlRow, 2].Text, xlRange.Cells[xlRow, 3].Text, xlRange.Cells[xlRow, 4].Text, xlRange.Cells[xlRow, 5].Text, xlRange.Cells[xlRow, 6].Text, xlRange.Cells[xlRow, 7].Text, xlRange.Cells[xlRow, 8].Text);
                    }
                }
                xlWorkBook.Close();
                xlApp.Quit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i = 0;
            for (int j = 0; j < dataGridView1.Rows.Count; j++)
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select * from acc_product where product_code='" + dataGridView1.Rows[j].Cells["product_code"].Value + "'", con);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);
                i = System.Convert.ToInt32(dt.Rows.Count.ToString());                
            }
            if(i==0)
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into acc_product(product_code,style_code,product,size,type,store,color,client,date) Values ('" + dataGridView1.Rows[j].Cells["product_code"].Value + "','" + dataGridView1.Rows[j].Cells["style_code"].Value + "','" + dataGridView1.Rows[j].Cells["product"].Value + "','" + dataGridView1.Rows[j].Cells["size"].Value + "','" + dataGridView1.Rows[j].Cells["type"].Value + "','" + dataGridView1.Rows[j].Cells["store"].Value + "','" + dataGridView1.Rows[j].Cells["color"].Value + "','" + dataGridView1.Rows[j].Cells["client"].Value + "','" + maskedTextBox1.Text + "')";
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Data Inserted Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Rows.Clear();
            }
            else
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    MySqlDataAdapter da = new MySqlDataAdapter("select * from acc_product where product_code='" + dataGridView1.Rows[j].Cells["product_code"].Value + "'", con);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    da.Fill(dt);
                    foreach(DataRow dr in dt.Rows)
                    {
                        MessageBox.Show("Product Code " + dr["product_code"].ToString() + " Already Inserted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }
    }
}
