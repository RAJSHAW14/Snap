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

namespace Snap
{
    public partial class fabric_request : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public fabric_request()
        {
            InitializeComponent();
        }

        private void fabric_request_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            maskedTextBox1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            auto_complete();
        }

        public void auto_complete()
        {
            MySqlCommand cmd = new MySqlCommand("select batchcode from batch_code_master",con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection autocomplete = new AutoCompleteStringCollection();
            while(dr.Read())
            {
                autocomplete.Add(dr.GetString(0));

            }
            textBox2.AutoCompleteCustomSource = autocomplete;
            dr.Close();
        }

        string batch_id, consumtion_require,product_code_id,requestion_number;

        int max_request_id, next_request_id;

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (consumtion_require == "YES")
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (System.Convert.ToDouble(row.Cells[dataGridView1.Columns[7].Index].Value) > System.Convert.ToDouble(row.Cells[dataGridView1.Columns[6].Index].Value))
                        {
                            MessageBox.Show("Excess Quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            row.Cells[dataGridView1.Columns[7].Index].Value = row.Cells[dataGridView1.Columns[6].Index].Value;
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select MAX(request_no) AS request_no from fabric_requisition", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                max_request_id = System.Convert.ToInt32(dr["request_no"].ToString());
            }
            next_request_id = max_request_id + 1;
            requestion_number = "FAB/REQ/" + (max_request_id + 1).ToString().PadLeft(5, '0');

            if (consumtion_require == "YES")
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        MySqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "insert into fabric_requisition (request_no,requisition_number,batch_code,compoent,product_code,fabric_code,fabric_name,unit,requested_qty,pending_qty,product_fabric_consumption_id,req_date)" + Environment.NewLine
                            + "Values ('" + next_request_id + "','" + requestion_number + "','" + textBox2.Text + "','" + dataGridView1.Rows[i].Cells[2].Value + "','" + dataGridView1.Rows[i].Cells[0].Value + "','" + dataGridView1.Rows[i].Cells[3].Value + "','" + dataGridView1.Rows[i].Cells[4].Value + "','" + dataGridView1.Rows[i].Cells[5].Value + "','" + dataGridView1.Rows[i].Cells[7].Value + "','" + dataGridView1.Rows[i].Cells[7].Value + "','" + dataGridView1.Rows[i].Cells[8].Value + "','"+maskedTextBox1.Text+"')";
                        cmd.ExecuteNonQuery();

                        MySqlCommand cmd1 = con.CreateCommand();
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = "update product_fabric_consumption set requested_qty=requested_qty+'" + dataGridView1.Rows[i].Cells[7].Value + "' where id='" + dataGridView1.Rows[i].Cells[8].Value + "'";
                        cmd1.ExecuteNonQuery();
                        
                    }
                    MessageBox.Show("Fabric Request Sent Sucessfully, Your Request Number is " + requestion_number, "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Insert Data First");
                }
            }
            else
            {
                if (dataGridView1.Rows.Count > 1)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        MySqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "insert into fabric_requisition (request_no,requisition_number,batch_code,compoent,product_code,fabric_code,fabric_name,unit,requested_qty,pending_qty,product_fabric_consumption_id,req_date)" + Environment.NewLine
                            + "Values ('" + max_request_id + "','" + requestion_number + "','" + textBox2.Text + "','" + dataGridView1.Rows[i].Cells[2].Value + "','" + dataGridView1.Rows[i].Cells[0].Value + "','" + dataGridView1.Rows[i].Cells[3].Value + "','" + dataGridView1.Rows[i].Cells[4].Value + "','" + dataGridView1.Rows[i].Cells[5].Value + "','" + dataGridView1.Rows[i].Cells[7].Value + "','" + dataGridView1.Rows[i].Cells[7].Value + "','" + dataGridView1.Rows[i].Cells[8].Value + "','"+maskedTextBox1.Text+"')";
                        cmd.ExecuteNonQuery();
                        
                    }
                    MessageBox.Show("Fabric Request Sent Sucessfully, Your Request Number is " + requestion_number, "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Insert Data First");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(System.Convert.ToInt32(listBox1.SelectedItems.Count)<=0)
            {
                MessageBox.Show("Please select the product code");
            }
            else
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select product_code_id from product_id where product_code='"+listBox1.SelectedItem.ToString()+"' ";
                cmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    product_code_id = dr["product_code_id"].ToString();
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            if (string.Equals(dataGridView1[0,i].Value as string,listBox1.SelectedItem.ToString()))
                            {
                                dataGridView1.Rows.RemoveAt(i);
                                i--;
                            }
                        }
                    MySqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "select * from product_fabric_consumption_view where product_code_id='"+product_code_id+"'";
                    cmd1.ExecuteNonQuery();
                    MySqlDataAdapter da1 = new MySqlDataAdapter(cmd1);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    foreach(DataRow dr1 in dt1.Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells[0].Value = listBox1.SelectedItem.ToString();
                        dataGridView1.Rows[n].Cells[1].Value = textBox2.Text;
                        dataGridView1.Rows[n].Cells[2].Value = dr1["component"].ToString();
                        dataGridView1.Rows[n].Cells[3].Value = dr1["fabric_code"].ToString();
                        dataGridView1.Rows[n].Cells[4].Value = dr1["fabric_name"].ToString();
                        dataGridView1.Rows[n].Cells[5].Value = dr1["unit"].ToString();
                        dataGridView1.Rows[n].Cells[6].Value = dr1["pending to request"].ToString();
                        dataGridView1.Rows[n].Cells[7].Value = dr1["pending to request"].ToString();
                        dataGridView1.Rows[n].Cells[8].Value = dr1["Product Consumption id"].ToString();

                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int i = 0;
            MySqlDataAdapter da = new MySqlDataAdapter("select * from batch_code_master where batchcode='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            i = System.Convert.ToInt32(dt.Rows.Count.ToString());
            if(i==0)
            {
                MessageBox.Show("Enter the correct Batchcode");
            }
            else
            {
                
                foreach (DataRow dr in dt.Rows)
                {
                    batch_id = dr["id"].ToString();
                    consumtion_require = dr["consumtion_require"].ToString();
                }
                if(consumtion_require=="YES")
                {
                    dataGridView1.AllowUserToAddRows = false;
                    MySqlDataAdapter da1 = new MySqlDataAdapter("select * from product_code_master where batcode_id='" + batch_id + "'", con);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    foreach(DataRow dr1 in dt1.Rows)
                    {
                        listBox1.Items.Add(dr1["product_code"]);
                    }
                    dataGridView1.Columns["product_code"].ReadOnly = true;
                    dataGridView1.Columns["batchcode"].ReadOnly = true;
                    dataGridView1.Columns["component"].ReadOnly = true;
                    dataGridView1.Columns["fabric_code"].ReadOnly = true;
                    dataGridView1.Columns["fabric_name"].ReadOnly = true;
                    dataGridView1.Columns["unit"].ReadOnly = true;
                }
                else
                {

                }
            }

        }
    }
}
