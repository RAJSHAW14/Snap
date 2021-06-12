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

namespace Snap.accessiories_forms
{
    public partial class costing : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public costing()
        {
            InitializeComponent();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void costing_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        public void amount_calculation()
        {
            try
            {
                double overhead,sum_for_overhead;
                sum_for_overhead = System.Convert.ToDouble(textBox1.Text) + System.Convert.ToDouble(textBox2.Text) + System.Convert.ToDouble(textBox3.Text) + System.Convert.ToDouble(textBox4.Text) + System.Convert.ToDouble(textBox5.Text) + System.Convert.ToDouble(textBox6.Text) + System.Convert.ToDouble(textBox7.Text) + System.Convert.ToDouble(textBox8.Text) + System.Convert.ToDouble(textBox9.Text) + System.Convert.ToDouble(textBox10.Text) + System.Convert.ToDouble(textBox11.Text) + System.Convert.ToDouble(textBox12.Text);
                overhead = (sum_for_overhead * System.Convert.ToDouble(textBox15.Text)) / 100;
                textBox14.Text = overhead.ToString();
                textBox16.Text = System.Convert.ToString(System.Convert.ToDouble(textBox1.Text) + System.Convert.ToDouble(textBox2.Text) + System.Convert.ToDouble(textBox3.Text) + System.Convert.ToDouble(textBox4.Text) + System.Convert.ToDouble(textBox5.Text) + System.Convert.ToDouble(textBox6.Text) + System.Convert.ToDouble(textBox7.Text) + System.Convert.ToDouble(textBox8.Text) + System.Convert.ToDouble(textBox9.Text) + System.Convert.ToDouble(textBox10.Text) + System.Convert.ToDouble(textBox11.Text) + System.Convert.ToDouble(textBox12.Text) + System.Convert.ToDouble(textBox14.Text));
            }
            catch(Exception)
            {
                
            }
        }

        public AutoCompleteStringCollection AutoComplete__fabric_item_Code()
        {
            MySqlCommand cmd = new MySqlCommand("select item_code from item where item_type='FABRIC'", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection mycoll = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                mycoll.Add(dr["item_code"].ToString());
            }
            dr.Close();
            return mycoll;
        }

        private void dataGridView3_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int column = dataGridView3.CurrentCell.ColumnIndex;
            string g = dataGridView3.Columns[column].HeaderText;
            if (g.Equals("Fabric Code"))
            {
                TextBox auto_text = e.Control as TextBox;
                if (auto_text != null)
                {
                    auto_text.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    auto_text.AutoCompleteCustomSource = AutoComplete__fabric_item_Code();
                    auto_text.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
            else
            {
                TextBox auto_text = e.Control as TextBox;
                if (auto_text != null)
                {
                    auto_text.AutoCompleteMode = AutoCompleteMode.None;
                }
            }
        }

        public AutoCompleteStringCollection AutoComplete__hardware_item_Code()
        {
            MySqlCommand cmd = new MySqlCommand("select item_code from item where item_type='ACC'", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection mycoll = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                mycoll.Add(dr["item_code"].ToString());
            }
            dr.Close();
            return mycoll;
        }

        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int column = dataGridView2.CurrentCell.ColumnIndex;
            string g = dataGridView2.Columns[column].HeaderText;
            if (g.Equals("Item Code"))
            {
                TextBox auto_text = e.Control as TextBox;
                if (auto_text != null)
                {
                    auto_text.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    auto_text.AutoCompleteCustomSource = AutoComplete__hardware_item_Code();
                    auto_text.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
            else
            {
                TextBox auto_text = e.Control as TextBox;
                if (auto_text != null)
                {
                    auto_text.AutoCompleteMode = AutoCompleteMode.None;
                }
            }
        }

        public AutoCompleteStringCollection AutoComplete__leather_item_Code()
        {
            MySqlCommand cmd = new MySqlCommand("select item_code from item where item_type='ACC'", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection mycoll = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                mycoll.Add(dr["item_code"].ToString());
            }
            dr.Close();
            return mycoll;
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int column = dataGridView1.CurrentCell.ColumnIndex;
            string g = dataGridView1.Columns[column].HeaderText;
            if (g.Equals("Item Code"))
            {
                TextBox auto_text = e.Control as TextBox;
                if (auto_text != null)
                {
                    auto_text.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    auto_text.AutoCompleteCustomSource = AutoComplete__leather_item_Code();
                    auto_text.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
            else
            {
                TextBox auto_text = e.Control as TextBox;
                if (auto_text != null)
                {
                    auto_text.AutoCompleteMode = AutoCompleteMode.None;
                }
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 1)
                {
                    string newvalue;
                    double las_purchase_rate;
                    newvalue = (dataGridView1[e.ColumnIndex, e.RowIndex].Value).ToString();
                    MySqlDataAdapter da = new MySqlDataAdapter("select last_purchase_price,gst from item where item_code='" + newvalue + "'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);     
                    las_purchase_rate=System.Convert.ToDouble(dt.Rows[0][0].ToString());
                   // gst=System.Convert.ToDouble(dt.Rows[0][1].ToString());
                    //actual_amount = (las_purchase_rate * gst) / 100 + las_purchase_rate;
                    dataGridView1.Rows[e.RowIndex].Cells["rate"].Value = las_purchase_rate;
                }
                leather_calculation();
            }
            catch (Exception)
            {
                MessageBox.Show("Choose Correct Item code");                
                dataGridView1.Rows[e.RowIndex].Cells["rate"].Value = "";
            }
        }

        public void leather_calculation()
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    double width, height, qty, area, total, wastage,grand_total;
                    width = System.Convert.ToDouble(row.Cells[dataGridView3.Columns[2].Index].Value);
                    height = System.Convert.ToDouble(row.Cells[dataGridView3.Columns[3].Index].Value);
                    qty = System.Convert.ToDouble(row.Cells[dataGridView3.Columns[4].Index].Value);
                    wastage = System.Convert.ToDouble(row.Cells[dataGridView3.Columns[7].Index].Value);
                    area = (width * height * qty) / 144;
                    row.Cells[dataGridView3.Columns[5].Index].Value = Math.Round(area, 2);
                    total = System.Convert.ToDouble(row.Cells[dataGridView3.Columns[6].Index].Value) * area;
                    grand_total = (total * wastage) / 100 + total;
                    row.Cells[dataGridView3.Columns[8].Index].Value = Math.Round(grand_total, 2);
                }

                double sum_of_leather = 0;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    sum_of_leather += System.Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value);
                }
                textBox17.Text = System.Convert.ToString(Math.Round(sum_of_leather, 2));
                textBox1.Text = textBox17.Text;
            }
            catch(Exception)
            {
                
            }
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 1)
                {
                    string newvalue;
                    double last_purchase, gst, actual_amount;
                    newvalue = (dataGridView2[e.ColumnIndex, e.RowIndex].Value).ToString();
                    MySqlDataAdapter da = new MySqlDataAdapter("select last_purchase_price,uom,gst from item where item_code='" + newvalue + "'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    last_purchase = System.Convert.ToDouble(dt.Rows[0][0].ToString());
                    //gst = System.Convert.ToDouble(dt.Rows[0][2].ToString());
                    dataGridView2.Rows[e.RowIndex].Cells["hardware_uom"].Value = dt.Rows[0][1].ToString();
                    //actual_amount = (last_purchase * gst) / 100 + last_purchase;
                    dataGridView2.Rows[e.RowIndex].Cells["hardware_rate"].Value = last_purchase;                 
                }
                hardware_calculation();
            }
            catch (Exception)
            {
                MessageBox.Show("Choose Correct Item code");
                dataGridView2.Rows[e.RowIndex].Cells["hardware_rate"].Value = "";
                dataGridView2.Rows[e.RowIndex].Cells["hardware_uom"].Value = "";
            }
        }

        public void hardware_calculation()
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    row.Cells[dataGridView3.Columns[5].Index].Value = System.Convert.ToDouble(row.Cells[dataGridView3.Columns[2].Index].Value) * System.Convert.ToDouble(row.Cells[dataGridView3.Columns[3].Index].Value);
                }

                double sum_of_hardware = 0;
                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    sum_of_hardware += System.Convert.ToDouble(dataGridView2.Rows[i].Cells[5].Value);                    
                }
                textBox19.Text = System.Convert.ToString(Math.Round(sum_of_hardware, 2));
                textBox3.Text = textBox19.Text;
            }
            catch(Exception)
            {

            }
        }

        private void dataGridView3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 1)
                {
                    string newvalue;
                    double last_purchase_price, gst, actual_rate;
                    newvalue = (dataGridView3[e.ColumnIndex, e.RowIndex].Value).ToString();
                    MySqlDataAdapter da = new MySqlDataAdapter("select last_purchase_price,gst from item where item_code='" + newvalue + "'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    last_purchase_price=System.Convert.ToDouble(dt.Rows[0][0].ToString());
                    //gst = System.Convert.ToDouble(dt.Rows[0][1].ToString());
                    //actual_rate = (last_purchase_price * gst) / 100 + last_purchase_price;
                    dataGridView3.Rows[e.RowIndex].Cells["fabric_rate"].Value = last_purchase_price;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Choose Correct Item code");
                dataGridView3.Rows[e.RowIndex].Cells["fabric_rate"].Value = "";
            }
            fabric_amount_calculation();
        }

        public void fabric_amount_calculation()
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    double fabric_amount, wastage, total_amount;
                    row.Cells[dataGridView3.Columns[5].Index].Value = Math.Round((System.Convert.ToDouble(row.Cells[dataGridView3.Columns[2].Index].Value) * System.Convert.ToDouble(row.Cells[dataGridView3.Columns[3].Index].Value) * System.Convert.ToDouble(row.Cells[dataGridView3.Columns[4].Index].Value)) / 1550, 2);
                    fabric_amount = System.Convert.ToDouble(row.Cells[dataGridView3.Columns[5].Index].Value) * System.Convert.ToDouble(row.Cells[dataGridView3.Columns[6].Index].Value);
                    wastage = System.Convert.ToDouble(row.Cells[dataGridView3.Columns[7].Index].Value);
                    total_amount = (fabric_amount * wastage) / 100 + fabric_amount;
                    row.Cells[dataGridView3.Columns[8].Index].Value = Math.Round(total_amount, 2);
                }

                double sum_of_fabric = 0;
                for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
                {
                    sum_of_fabric += System.Convert.ToDouble(dataGridView3.Rows[i].Cells[8].Value);                    
                }
                textBox18.Text = System.Convert.ToString(Math.Round(sum_of_fabric, 2));
                textBox2.Text = textBox18.Text;
            }
            catch(Exception)
            {

            }
        }

        private void dataGridView4_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int column = dataGridView4.CurrentCell.ColumnIndex;
            string g = dataGridView4.Columns[column].HeaderText;
            if (g.Equals("Non-Fabric Item Code"))
            {
                TextBox auto_text = e.Control as TextBox;
                if (auto_text != null)
                {
                    auto_text.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    auto_text.AutoCompleteCustomSource = AutoComplete__mat_item_Code();
                    auto_text.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
            else
            {
                TextBox auto_text = e.Control as TextBox;
                if (auto_text != null)
                {
                    auto_text.AutoCompleteMode = AutoCompleteMode.None;
                }
            }
        }

        public AutoCompleteStringCollection AutoComplete__mat_item_Code()
        {
            MySqlCommand cmd = new MySqlCommand("select item_code from item where item_type='NON-FABRIC'", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection mycoll = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                mycoll.Add(dr["item_code"].ToString());
            }
            dr.Close();
            return mycoll;
        }

        private void dataGridView4_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 1)
                {
                    string newvalue;
                    double last_purchase_price, gst, actual_rate;
                    newvalue = (dataGridView4[e.ColumnIndex, e.RowIndex].Value).ToString();
                    MySqlDataAdapter da = new MySqlDataAdapter("select last_purchase_price,gst,uom from item where item_code='" + newvalue + "'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    last_purchase_price = System.Convert.ToDouble(dt.Rows[0][0].ToString());
                    //gst = System.Convert.ToDouble(dt.Rows[0][1].ToString());
                    //actual_rate = (last_purchase_price * gst) / 100 + last_purchase_price;
                    dataGridView4.Rows[e.RowIndex].Cells["mat_rate"].Value = last_purchase_price;
                    dataGridView4.Rows[e.RowIndex].Cells["mat_uom"].Value =dt.Rows[0][2].ToString();
                }
                mat_cal();
            }
            catch (Exception)
            {
                MessageBox.Show("Choose Correct Item code");
                dataGridView4.Rows[e.RowIndex].Cells["mat_rate"].Value = "";
                dataGridView4.Rows[e.RowIndex].Cells["mat_uom"].Value = "";
            }
        }

        public void mat_cal()
        {
            foreach (DataGridViewRow row in dataGridView4.Rows)
            {
                row.Cells[dataGridView4.Columns[5].Index].Value = System.Convert.ToDouble(row.Cells[dataGridView4.Columns[2].Index].Value) * System.Convert.ToDouble(row.Cells[dataGridView4.Columns[4].Index].Value);
            }

            double sum_of_mat = 0;
            for (int i = 0; i < dataGridView4.Rows.Count - 1; i++)
            {
                sum_of_mat += System.Convert.ToDouble(dataGridView4.Rows[i].Cells[5].Value);
            }
            textBox20.Text = System.Convert.ToString(Math.Round(sum_of_mat, 2));
            textBox10.Text = textBox20.Text;
        }

        private void textBox15_Leave(object sender, EventArgs e)
        {
            amount_calculation();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            amount_calculation();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox16.Text==""|textBox16.Text=="0")
            {
                MessageBox.Show("Calculate the Amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MySqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "insert into acc_style_summery (style_id,hardware,hand_emb,machine_emb,fabrication,digital_print,lining_quilting,leather,fabric,dye,emb_mat,others,hardware_polish,packing,overhead_PER,overhead,grand_total) Values ('" + textBox24.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "','" + textBox13.Text + "','" + textBox15.Text + "','" + textBox14.Text + "','" + textBox16.Text + "')";
                cmd1.ExecuteNonQuery();

                MySqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "update style_master set consumption_status='DONE' where id='" + textBox24.Text + "'";
                cmd2.ExecuteNonQuery();

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into acc_style_leather_details (style_id,part,item_code,width,height,qty,area,rate,wastage,total) Values ('" + textBox24.Text + "','" + dataGridView1.Rows[i].Cells["part"].Value + "','" + dataGridView1.Rows[i].Cells["item_code"].Value + "','" + dataGridView1.Rows[i].Cells["width"].Value + "','" + dataGridView1.Rows[i].Cells["height"].Value + "','" + dataGridView1.Rows[i].Cells["qty"].Value + "','" + dataGridView1.Rows[i].Cells["area"].Value + "','" + dataGridView1.Rows[i].Cells["rate"].Value + "','" + dataGridView1.Rows[i].Cells["wastage"].Value + "','" + dataGridView1.Rows[i].Cells["leather_total"].Value + "')";
                    cmd.ExecuteNonQuery();
                }

                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into acc_style_hardware_details (style_id,component,item_code,rate,qty,uom,total) Values ('" + textBox24.Text + "','" + dataGridView2.Rows[i].Cells["component"].Value + "','" + dataGridView2.Rows[i].Cells["hardware_item_code"].Value + "','" + dataGridView2.Rows[i].Cells["hardware_rate"].Value + "','" + dataGridView2.Rows[i].Cells["hardware_qty"].Value + "','" + dataGridView2.Rows[i].Cells["hardware_uom"].Value + "','" + dataGridView2.Rows[i].Cells["total"].Value + "')";
                    cmd.ExecuteNonQuery();
                }

                for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into acc_style_fabric_details (style_id,part,fabric_code,width,height,qty,area,fabric_rate,wastage,total) Values ('" + textBox24.Text + "','" + dataGridView3.Rows[i].Cells["fabric_part"].Value + "','" + dataGridView3.Rows[i].Cells["fabric_code"].Value + "','" + dataGridView3.Rows[i].Cells["fabric_width"].Value + "','" + dataGridView3.Rows[i].Cells["fabric_height"].Value + "','" + dataGridView3.Rows[i].Cells["fabric_qty"].Value + "','" + dataGridView3.Rows[i].Cells["fabric_area"].Value + "','" + dataGridView3.Rows[i].Cells["fabric_rate"].Value + "','" + dataGridView3.Rows[i].Cells["fabric_wastage"].Value + "','" + dataGridView3.Rows[i].Cells["fabric_total"].Value + "') ";
                    cmd.ExecuteNonQuery();
                }

                for(int i=0;i<dataGridView4.Rows.Count-1;i++)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into acc_style_emb_mat_details (style_id,component,non_fabric_code,rate,uom,qty,total) Values ('" + textBox24.Text + "','" + dataGridView4.Rows[i].Cells["mat_component"].Value + "','" + dataGridView4.Rows[i].Cells["mat_code"].Value + "','" + dataGridView4.Rows[i].Cells["mat_rate"].Value + "','" + dataGridView4.Rows[i].Cells["mat_uom"].Value + "','" + dataGridView4.Rows[i].Cells["mat_qty"].Value + "','" + dataGridView4.Rows[i].Cells["mat_total"].Value + "')";
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Style Costing Details Inserted Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd6 = con.CreateCommand();
            cmd6.CommandType = CommandType.Text;
            cmd6.CommandText = "delete from acc_style_summery where style_id='" + textBox24.Text + "'";
            cmd6.ExecuteNonQuery();

            MySqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "delete from acc_style_leather_details where style_id='" + textBox24.Text + "'";
            cmd1.ExecuteNonQuery();

            MySqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "delete from acc_style_hardware_details where style_id='" + textBox24.Text + "'";
            cmd2.ExecuteNonQuery();

            MySqlCommand cmd3 = con.CreateCommand();
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "delete from acc_style_fabric_details where style_id='" + textBox24.Text + "'";
            cmd3.ExecuteNonQuery();

            MySqlCommand cmd4 = con.CreateCommand();
            cmd4.CommandType = CommandType.Text;
            cmd4.CommandText = "delete from acc_style_emb_mat_details where style_id='" + textBox24.Text + "'";
            cmd4.ExecuteNonQuery();

            MySqlCommand cmd5 = con.CreateCommand();
            cmd5.CommandType = CommandType.Text;
            cmd5.CommandText = "insert into acc_style_summery (style_id,hardware,hand_emb,machine_emb,fabrication,digital_print,lining_quilting,leather,fabric,dye,emb_mat,others,hardware_polish,packing,overhead_PER,overhead,grand_total) Values ('" + textBox24.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "','" + textBox13.Text + "','" + textBox15.Text + "','" + textBox14.Text + "','" + textBox16.Text + "')";
            cmd5.ExecuteNonQuery();

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into acc_style_leather_details (style_id,part,item_code,width,height,qty,area,rate,wastage,total) Values ('" + textBox24.Text + "','" + dataGridView1.Rows[i].Cells["part"].Value + "','" + dataGridView1.Rows[i].Cells["item_code"].Value + "','" + dataGridView1.Rows[i].Cells["width"].Value + "','" + dataGridView1.Rows[i].Cells["height"].Value + "','" + dataGridView1.Rows[i].Cells["qty"].Value + "','" + dataGridView1.Rows[i].Cells["area"].Value + "','" + dataGridView1.Rows[i].Cells["rate"].Value + "','" + dataGridView1.Rows[i].Cells["wastage"].Value + "','" + dataGridView1.Rows[i].Cells["leather_total"].Value + "')";
                cmd.ExecuteNonQuery();
            }

            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into acc_style_hardware_details (style_id,component,item_code,rate,qty,uom,total) Values ('" + textBox24.Text + "','" + dataGridView2.Rows[i].Cells["component"].Value + "','" + dataGridView2.Rows[i].Cells["hardware_item_code"].Value + "','" + dataGridView2.Rows[i].Cells["hardware_rate"].Value + "','" + dataGridView2.Rows[i].Cells["hardware_qty"].Value + "','" + dataGridView2.Rows[i].Cells["hardware_uom"].Value + "','" + dataGridView2.Rows[i].Cells["total"].Value + "')";
                cmd.ExecuteNonQuery();
            }

            for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into acc_style_fabric_details (style_id,part,fabric_code,width,height,qty,area,fabric_rate,wastage,total) Values ('" + textBox24.Text + "','" + dataGridView3.Rows[i].Cells["fabric_part"].Value + "','" + dataGridView3.Rows[i].Cells["fabric_code"].Value + "','" + dataGridView3.Rows[i].Cells["fabric_width"].Value + "','" + dataGridView3.Rows[i].Cells["fabric_height"].Value + "','" + dataGridView3.Rows[i].Cells["fabric_qty"].Value + "','" + dataGridView3.Rows[i].Cells["fabric_area"].Value + "','" + dataGridView3.Rows[i].Cells["fabric_rate"].Value + "','" + dataGridView3.Rows[i].Cells["fabric_wastage"].Value + "','" + dataGridView3.Rows[i].Cells["fabric_total"].Value + "') ";
                cmd.ExecuteNonQuery();
            }

            for (int i = 0; i < dataGridView4.Rows.Count - 1; i++)
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into acc_style_emb_mat_details (style_id,component,non_fabric_code,rate,uom,qty,total) Values ('" + textBox24.Text + "','" + dataGridView4.Rows[i].Cells["mat_component"].Value + "','" + dataGridView4.Rows[i].Cells["mat_code"].Value + "','" + dataGridView4.Rows[i].Cells["mat_rate"].Value + "','" + dataGridView4.Rows[i].Cells["mat_uom"].Value + "','" + dataGridView4.Rows[i].Cells["mat_qty"].Value + "','" + dataGridView4.Rows[i].Cells["mat_total"].Value + "')";
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Costing Updated Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        public void fill_data()
        {
            
            MySqlDataAdapter da = new MySqlDataAdapter("select * from acc_style_summery where style_id='" + textBox24.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                textBox3.Text = dr["hardware"].ToString();
                textBox19.Text = dr["hardware"].ToString();
                textBox4.Text = dr["hand_emb"].ToString();
                textBox5.Text = dr["machine_emb"].ToString();
                textBox6.Text = dr["fabrication"].ToString();
                textBox7.Text = dr["digital_print"].ToString();
                textBox8.Text = dr["lining_quilting"].ToString();
                textBox1.Text = dr["leather"].ToString();
                textBox17.Text = dr["leather"].ToString();
                textBox2.Text = dr["fabric"].ToString();
                textBox18.Text = dr["fabric"].ToString();
                textBox9.Text = dr["dye"].ToString();
                textBox10.Text = dr["emb_mat"].ToString();
                textBox20.Text = dr["emb_mat"].ToString();
                textBox11.Text = dr["others"].ToString();
                textBox12.Text = dr["hardware_polish"].ToString();
                textBox13.Text = dr["packing"].ToString();
                textBox15.Text = dr["overhead_PER"].ToString();
                textBox14.Text = dr["overhead"].ToString();
                textBox16.Text = dr["grand_total"].ToString();
            }

            MySqlDataAdapter da1 = new MySqlDataAdapter("select * from acc_style_leather_details where style_id='"+textBox24.Text+"'",con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach(DataRow dr in dt1.Rows)
            {
                int i = dataGridView1.Rows.Add();               
                dataGridView1.Rows[i].Cells["part"].Value = dr["part"].ToString();
                dataGridView1.Rows[i].Cells["item_code"].Value = dr["item_code"].ToString();
                dataGridView1.Rows[i].Cells["width"].Value = dr["width"].ToString();
                dataGridView1.Rows[i].Cells["height"].Value = dr["height"].ToString();
                dataGridView1.Rows[i].Cells["qty"].Value = dr["qty"].ToString();
                dataGridView1.Rows[i].Cells["area"].Value = dr["area"].ToString();
                dataGridView1.Rows[i].Cells["rate"].Value = dr["rate"].ToString();
                dataGridView1.Rows[i].Cells["wastage"].Value = dr["wastage"].ToString();
                dataGridView1.Rows[i].Cells["leather_total"].Value = dr["total"].ToString();
            }

            MySqlDataAdapter da2 = new MySqlDataAdapter("select * from acc_style_hardware_details where style_id='" + textBox24.Text + "'", con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            foreach(DataRow dr in dt2.Rows)
            {
                int i = dataGridView2.Rows.Add();
                dataGridView2.Rows[i].Cells["component"].Value = dr["component"].ToString();
                dataGridView2.Rows[i].Cells["hardware_item_code"].Value = dr["item_code"].ToString();
                dataGridView2.Rows[i].Cells["hardware_rate"].Value = dr["rate"].ToString();
                dataGridView2.Rows[i].Cells["hardware_qty"].Value = dr["qty"].ToString();
                dataGridView2.Rows[i].Cells["hardware_uom"].Value = dr["uom"].ToString();
                dataGridView2.Rows[i].Cells["total"].Value = dr["total"].ToString();

            }

            MySqlDataAdapter da3 = new MySqlDataAdapter("select * from acc_style_fabric_details where style_id='" + textBox24.Text + "'", con);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            foreach(DataRow dr in dt3.Rows)
            {
                int i = dataGridView3.Rows.Add();                
                dataGridView3.Rows[i].Cells["fabric_part"].Value = dr["part"].ToString();
                dataGridView3.Rows[i].Cells["fabric_code"].Value = dr["fabric_code"].ToString();
                dataGridView3.Rows[i].Cells["fabric_width"].Value = dr["width"].ToString();
                dataGridView3.Rows[i].Cells["fabric_height"].Value = dr["height"].ToString();
                dataGridView3.Rows[i].Cells["fabric_qty"].Value = dr["qty"].ToString();
                dataGridView3.Rows[i].Cells["fabric_area"].Value = dr["area"].ToString();
                dataGridView3.Rows[i].Cells["fabric_rate"].Value = dr["fabric_rate"].ToString();
                dataGridView3.Rows[i].Cells["fabric_wastage"].Value = dr["wastage"].ToString();
                dataGridView3.Rows[i].Cells["fabric_total"].Value = dr["total"].ToString();
            }

            MySqlDataAdapter da4 = new MySqlDataAdapter("select * from acc_style_emb_mat_details where style_id='" + textBox24.Text + "'", con);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            foreach(DataRow dr in dt4.Rows)
            {
                int i = dataGridView4.Rows.Add();
                textBox24.Text = dr["style_id"].ToString();
                dataGridView4.Rows[i].Cells["mat_component"].Value = dr["component"].ToString();
                dataGridView4.Rows[i].Cells["mat_code"].Value = dr["non_fabric_code"].ToString();
                dataGridView4.Rows[i].Cells["mat_rate"].Value = dr["rate"].ToString();
                dataGridView4.Rows[i].Cells["mat_uom"].Value = dr["uom"].ToString();
                dataGridView4.Rows[i].Cells["mat_qty"].Value = dr["qty"].ToString();
                dataGridView4.Rows[i].Cells["mat_total"].Value = dr["total"].ToString();
            }
        }

        public void fill_style_details()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from style_master where id='" + textBox24.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                textBox21.Text = dr["style_code"].ToString();
                richTextBox1.Text = dr["description"].ToString();
                textBox22.Text = dr["style_colour"].ToString();
                textBox23.Text = dr["mrp"].ToString();
            }
        }
    }
}
