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

namespace Snap.costing
{
    public partial class garment_costing_cart : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public garment_costing_cart()
        {
            InitializeComponent();
        }

        private void garment_costing_cart_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            auto_complete_emb_name();
            add_style_amount();
        }

        public AutoCompleteStringCollection AutoComplete_item_Code()
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

        public AutoCompleteStringCollection AutoComplete_s_item_Code()
        {
            MySqlCommand cmd = new MySqlCommand("select item_code from item where item_type='S-FABRIC'", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection mycoll = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                mycoll.Add(dr["item_code"].ToString());
            }
            dr.Close();
            return mycoll;
        }

        public AutoCompleteStringCollection AutoComplete_mat_item_Code()
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

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int column = dataGridView1.CurrentCell.ColumnIndex;
            string g = dataGridView1.Columns[column].HeaderText;
            if (g.Equals("Fabric Code"))
            {
                TextBox auto_text = e.Control as TextBox;
                if (auto_text != null)
                {
                    auto_text.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    auto_text.AutoCompleteCustomSource = AutoComplete_item_Code();
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
                if(e.ColumnIndex==2)
                {
                    string newvalue;
                    newvalue = (dataGridView1[e.ColumnIndex, e.RowIndex].Value).ToString();
                    MySqlDataAdapter da = new MySqlDataAdapter("select uom,last_purchase_price from item where item_code='" + newvalue + "'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.Rows[e.RowIndex].Cells["uom"].Value = dt.Rows[0][0].ToString();
                    dataGridView1.Rows[e.RowIndex].Cells["rate"].Value = dt.Rows[0][1].ToString();                    
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Choose Correct Fabric code");
                dataGridView1.Rows[e.RowIndex].Cells["uom"].Value = "";
                dataGridView1.Rows[e.RowIndex].Cells["rate"].Value = "";
            }
            fabric_amount_calculation();
            add_style_amount();
        }

        public void fabric_amount_calculation()
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells[dataGridView1.Columns[7].Index].Value = System.Convert.ToDouble(row.Cells[dataGridView1.Columns[6].Index].Value) * System.Convert.ToDouble(row.Cells[dataGridView1.Columns[4].Index].Value);
                    row.Cells[dataGridView1.Columns[10].Index].Value = System.Convert.ToDouble(row.Cells[dataGridView1.Columns[8].Index].Value) * System.Convert.ToDouble(row.Cells[dataGridView1.Columns[9].Index].Value);
                    row.Cells[dataGridView1.Columns[13].Index].Value = System.Convert.ToDouble(row.Cells[dataGridView1.Columns[11].Index].Value) * System.Convert.ToDouble(row.Cells[dataGridView1.Columns[12].Index].Value);
                }
                double sum_of_fabric = 0, sum_of_dye = 0, sum_of_print = 0;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    sum_of_fabric += System.Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value);
                    sum_of_dye += System.Convert.ToDouble(dataGridView1.Rows[i].Cells[10].Value);
                    sum_of_print += System.Convert.ToDouble(dataGridView1.Rows[i].Cells[13].Value);
                }
                textBox11.Text = System.Convert.ToString(Math.Round(sum_of_fabric, 2));
                textBox4.Text = System.Convert.ToString(Math.Round(sum_of_fabric, 2));
                textBox12.Text = System.Convert.ToString(Math.Round(sum_of_dye, 2));                
                textBox13.Text = System.Convert.ToString(Math.Round(sum_of_print, 2));                
                textBox5.Text = System.Convert.ToString(System.Convert.ToInt32(textBox12.Text) + System.Convert.ToInt32(textBox31.Text));
                textBox6.Text = System.Convert.ToString(System.Convert.ToInt32(textBox13.Text) + System.Convert.ToInt32(textBox30.Text));
            }
            catch (Exception)
            {

            }
        }

        public void emb_amount_calculation()
        {
            double emb_amount = 0;
            try
            {
                for(int i=0;i<dataGridView2.Rows.Count;i++)
                {
                    emb_amount += System.Convert.ToDouble(dataGridView2.Rows[i].Cells[8].Value);
                }
                textBox24.Text = System.Convert.ToString(Math.Round(emb_amount, 2));
                textBox7.Text = System.Convert.ToString(Math.Round(emb_amount, 2));
            }
            catch
            {

            }
        }

        public void mat_amount_calculation()
        {
            double mat_amount = 0;
            try
            {
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    mat_amount += System.Convert.ToDouble(dataGridView3.Rows[i].Cells[10].Value);
                }
                textBox25.Text = System.Convert.ToString(Math.Round(mat_amount, 2));
                textBox8.Text = System.Convert.ToString(Math.Round(mat_amount, 2));
            }
            catch
            {

            }
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            fabric_amount_calculation();
            add_style_amount();
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            fabric_amount_calculation();
            add_style_amount();
        }

        public void auto_complete_emb_name()
        {
            MySqlCommand cmd = new MySqlCommand("select emb_name from emb_master", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection autocomplete = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                autocomplete.Add(dr.GetString(0));

            }
            textBox14.AutoCompleteCustomSource = autocomplete;
            dr.Close();
        }

        string costing_rate, fixed_rate, emb_id_string;
        private void textBox14_Leave(object sender, EventArgs e)
        {
            int i = 0;            
            MySqlDataAdapter da = new MySqlDataAdapter("select * from emb_master where emb_name='" + textBox14.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            i = System.Convert.ToInt32(dt.Rows.Count.ToString());
            if(i==0)
            {
                MessageBox.Show("Incorrect EMB Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    textBox23.Text = dr["emb_code"].ToString();
                    textBox15.Text = dr["uom"].ToString();
                    costing_rate = dr["costing_rate"].ToString();
                    fixed_rate = dr["fixed_rate"].ToString();
                    textBox21.Text = dr["mat_rate"].ToString();
                    textBox17.Text = dr["emb_type"].ToString();
                    textBox16.Text = dr["cmc_code"].ToString();
                    emb_id_string = dr["id"].ToString();
                }
                if(fixed_rate=="")
                {
                    textBox19.Text = costing_rate.ToString();
                    textBox20.Text = "Costing Rate";
                }
                else if(fixed_rate=="0")
                {
                    textBox19.Text = costing_rate.ToString();
                    textBox20.Text = "Costing Rate";
                }
                else
                {
                    textBox19.Text = fixed_rate.ToString();
                    textBox20.Text = "Fixed Rate";
                }
            }            
        }

        int max_number = 0, next_number;
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                if(max_number<int.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString()))
                {
                    max_number=int.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString());
                }
            }            
            next_number = max_number + 1;
            if(textBox26.Text=="")
            {
                MessageBox.Show("Amount Not Calculated", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            else if(textBox26.Text=="0")
            {
                MessageBox.Show("Amount Not Calculated","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                mat_consumption();
                emb_amount_calculation();
                mat_amount_calculation();
                add_style_amount();
                emb_clear();
            }
        }

        public void add_datagrid_view_emb()
        {
            dataGridView2.Rows.Add(next_number.ToString(),textBox28.Text, textBox22.Text, textBox14.Text, textBox23.Text, textBox18.Text, textBox15.Text, textBox19.Text, textBox26.Text, textBox20.Text, textBox16.Text, textBox17.Text, richTextBox2.Text);
        }

        int id_value_emb = 0;
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                id_value_emb = System.Convert.ToInt32(row.Cells["emb_id"].Value.ToString());
            }
        }

        public void mat_consumption()
        {
            int i = 0;
            MySqlDataAdapter da = new MySqlDataAdapter("select * from emb_consumption_line where emb_id='" + emb_id_string + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            i = System.Convert.ToInt32(dt.Rows.Count.ToString());
            if(i==0)
            {
                DialogResult result = MessageBox.Show("EMB Consumption Not Found Do You Want to Continue", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result==DialogResult.Yes)
                {
                    add_datagrid_view_emb();
                    foreach(DataRow dr in dt.Rows)
                    {
                        int j = dataGridView3.Rows.Add();
                        dataGridView3.Rows[j].Cells["emb_id1"].Value = next_number.ToString();
                        dataGridView3.Rows[j].Cells["erp_component2"].Value = textBox28.Text;
                        dataGridView3.Rows[j].Cells["componet"].Value = textBox22.Text;
                        dataGridView3.Rows[j].Cells["emb_name"].Value = textBox14.Text;
                        dataGridView3.Rows[j].Cells["mat_code"].Value = dr["item_code"].ToString();
                        dataGridView3.Rows[j].Cells["per_unit_qty"].Value = dr["final_qty"].ToString();
                        dataGridView3.Rows[j].Cells["total_qty"].Value = System.Convert.ToString(System.Convert.ToDouble(dataGridView3.Rows[j].Cells["per_unit_qty"].Value) * System.Convert.ToDouble(textBox18.Text));
                        dataGridView3.Rows[j].Cells["unit"].Value = dr["unit"].ToString();
                        dataGridView3.Rows[j].Cells["mat_rate"].Value = dr["rate"].ToString();
                        dataGridView3.Rows[j].Cells["per_unit_amt"].Value = System.Convert.ToString(System.Convert.ToDouble(dataGridView3.Rows[j].Cells["mat_rate"].Value) * System.Convert.ToDouble(dataGridView3.Rows[j].Cells["per_unit_qty"].Value));
                        dataGridView3.Rows[j].Cells["total_amt"].Value = System.Convert.ToString(System.Convert.ToDouble(dataGridView3.Rows[j].Cells["total_qty"].Value) * System.Convert.ToDouble(dataGridView3.Rows[j].Cells["mat_rate"].Value));
                    }
                }
                else
                {

                }
            }
            else
            {
                add_datagrid_view_emb();
                foreach (DataRow dr in dt.Rows)
                {
                    int j = dataGridView3.Rows.Add();
                    dataGridView3.Rows[j].Cells["emb_id1"].Value = next_number.ToString();
                    dataGridView3.Rows[j].Cells["erp_component2"].Value = textBox28.Text;
                    dataGridView3.Rows[j].Cells["componet"].Value = textBox22.Text;
                    dataGridView3.Rows[j].Cells["emb_name1"].Value = textBox14.Text;
                    dataGridView3.Rows[j].Cells["mat_code"].Value = dr["item_code"].ToString();
                    dataGridView3.Rows[j].Cells["per_unit_qty"].Value = dr["final_qty"].ToString();
                    dataGridView3.Rows[j].Cells["total_qty"].Value = System.Convert.ToString(System.Convert.ToDouble(dataGridView3.Rows[j].Cells["per_unit_qty"].Value) * System.Convert.ToDouble(textBox18.Text));
                    dataGridView3.Rows[j].Cells["unit"].Value = dr["unit"].ToString();
                    dataGridView3.Rows[j].Cells["mat_rate"].Value = dr["rate"].ToString();
                    dataGridView3.Rows[j].Cells["per_unit_amt"].Value = System.Convert.ToString(System.Convert.ToDouble(dataGridView3.Rows[j].Cells["mat_rate"].Value) * System.Convert.ToDouble(dataGridView3.Rows[j].Cells["per_unit_qty"].Value));
                    dataGridView3.Rows[j].Cells["total_amt"].Value = System.Convert.ToString(System.Convert.ToDouble(dataGridView3.Rows[j].Cells["total_qty"].Value) * System.Convert.ToDouble(dataGridView3.Rows[j].Cells["mat_rate"].Value));
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(id_value_emb==0)
            {
                MessageBox.Show("Please select the Row to Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach(DataGridViewRow item in this.dataGridView2.Rows)
                {
                    if (item.Cells["emb_id"].Value.ToString() == id_value_emb.ToString())
                    {
                        dataGridView2.Rows.RemoveAt(item.Index);
                    }
                }

                for (int v = 0; v < dataGridView3.Rows.Count; v++)
                {
                    if(string.Equals(dataGridView3[0,v].Value as string, id_value_emb.ToString()))
                    {
                        dataGridView3.Rows.RemoveAt(v);
                        v--;
                    }
                }
                emb_amount_calculation();
                mat_amount_calculation();
                add_style_amount();
            }
        }

        private void textBox18_Leave(object sender, EventArgs e)
        {
            emb_per_amt_cal();
        }

        public void emb_per_amt_cal()
        {
            try
            {
                textBox26.Text = System.Convert.ToString(System.Convert.ToDouble(textBox18.Text) * System.Convert.ToDouble(textBox19.Text));
            }
            catch(Exception)
            {

            }
        }

        private void textBox20_Leave(object sender, EventArgs e)
        {
            emb_per_amt_cal();
            add_style_amount();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do You Confirm to add the Style Consumption", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result==DialogResult.Yes)
            {
                MySqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "delete from style_fabric_dye_print where style_id='" + textBox27.Text + "'";
                cmd2.ExecuteNonQuery();

                MySqlCommand cmd6 = con.CreateCommand();
                cmd6.CommandType = CommandType.Text;
                cmd6.CommandText = "delete from style_s_fabric where style_id='" + textBox27.Text + "'";
                cmd6.ExecuteNonQuery();

                MySqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "delete from style_mat_consumption where style_id='" + textBox27.Text + "'";
                cmd3.ExecuteNonQuery();

                MySqlCommand cmd4 = con.CreateCommand();
                cmd4.CommandType = CommandType.Text;
                cmd4.CommandText = "delete from style_emb_consumption where style_id='" + textBox27.Text + "'";
                cmd4.ExecuteNonQuery();

                for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into style_fabric_dye_print (erp_component,component,fabric_code,phase,qty,uom,fabirc_rate,fabric_cost,dye_qty,dye_rate,dye_cost,print_qy,print_rate,print_cost,style_id) Values ('" + dataGridView1.Rows[j].Cells["erp_component"].Value + "','" + dataGridView1.Rows[j].Cells["sub_component"].Value + "','" + dataGridView1.Rows[j].Cells["fabric_code"].Value + "','" + dataGridView1.Rows[j].Cells["phase"].Value + "','" + dataGridView1.Rows[j].Cells["qty"].Value + "','" + dataGridView1.Rows[j].Cells["uom"].Value + "','" + dataGridView1.Rows[j].Cells["rate"].Value + "','" + dataGridView1.Rows[j].Cells["fabric_cost"].Value + "','" + dataGridView1.Rows[j].Cells["dye_qty"].Value + "','" + dataGridView1.Rows[j].Cells["dye_rate"].Value + "','" + dataGridView1.Rows[j].Cells["dye_cost"].Value + "','" + dataGridView1.Rows[j].Cells["print_qty"].Value + "','" + dataGridView1.Rows[j].Cells["print_rate"].Value + "','" + dataGridView1.Rows[j].Cells["print_cost"].Value + "','" + textBox27.Text + "')";
                    cmd.ExecuteNonQuery();
                }

                for (int j = 0; j < dataGridView2.Rows.Count; j++)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into style_emb_consumption (emb_id,component,emb_name,emb_code,emb_qty,emb_uom,emb_rate,amount,rate_type,cmc_code,emb_type,remarks,style_id,erp_component) Values ('" + dataGridView2.Rows[j].Cells["emb_id"].Value + "','" + dataGridView2.Rows[j].Cells["component"].Value + "','" + dataGridView2.Rows[j].Cells["emb_name"].Value + "','" + dataGridView2.Rows[j].Cells["emb_code"].Value + "','" + dataGridView2.Rows[j].Cells["emb_qty"].Value + "','" + dataGridView2.Rows[j].Cells["emb_uom"].Value + "','" + dataGridView2.Rows[j].Cells["emb_rate"].Value + "','" + dataGridView2.Rows[j].Cells["amount"].Value + "','" + dataGridView2.Rows[j].Cells["rate_type"].Value + "','" + dataGridView2.Rows[j].Cells["cmc_code"].Value + "','" + dataGridView2.Rows[j].Cells["emb_type"].Value + "','" + dataGridView2.Rows[j].Cells["remakrs"].Value + "','" + textBox27.Text + "','" + dataGridView2.Rows[j].Cells["erp_component1"].Value + "')";
                    cmd.ExecuteNonQuery();
                }

                for (int j = 0; j < dataGridView3.Rows.Count-1; j++)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into style_mat_consumption (emb_id,component,emb_name,mat_code,per_unit_qty,total_qty,unit,rate,per_unit_amount,total_amount,style_id,erp_component) Values ('" + dataGridView3.Rows[j].Cells["emb_id1"].Value + "','" + dataGridView3.Rows[j].Cells["componet"].Value + "','" + dataGridView3.Rows[j].Cells["emb_name1"].Value + "','" + dataGridView3.Rows[j].Cells["mat_code"].Value + "','" + dataGridView3.Rows[j].Cells["per_unit_qty"].Value + "','" + dataGridView3.Rows[j].Cells["total_qty"].Value + "','" + dataGridView3.Rows[j].Cells["unit"].Value + "','" + dataGridView3.Rows[j].Cells["mat_rate"].Value + "','" + dataGridView3.Rows[j].Cells["per_unit_amt"].Value + "','" + dataGridView3.Rows[j].Cells["total_amt"].Value + "','" + textBox27.Text + "','" + dataGridView3.Rows[j].Cells["erp_component2"].Value + "')";
                    cmd.ExecuteNonQuery();
                }

                for (int j = 0; j < dataGridView4.Rows.Count - 1; j++)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into style_s_fabric (erp_component,component,fabric_code,phase,qty,uom,fabirc_rate,fabric_cost,dye_qty,dye_rate,dye_cost,print_qy,print_rate,print_cost,style_id) Values ('" + dataGridView4.Rows[j].Cells["s_erp_component"].Value + "','" + dataGridView4.Rows[j].Cells["s_sub_component"].Value + "','" + dataGridView4.Rows[j].Cells["s_fabric_code"].Value + "','" + dataGridView4.Rows[j].Cells["s_phase"].Value + "','" + dataGridView4.Rows[j].Cells["s_qty"].Value + "','" + dataGridView4.Rows[j].Cells["s_uom"].Value + "','" + dataGridView4.Rows[j].Cells["s_rate"].Value + "','" + dataGridView4.Rows[j].Cells["s_cost"].Value + "','" + dataGridView4.Rows[j].Cells["s_dye_qty"].Value + "','" + dataGridView4.Rows[j].Cells["s_dye_rate"].Value + "','" + dataGridView4.Rows[j].Cells["s_dye_cost"].Value + "','" + dataGridView4.Rows[j].Cells["s_print_qty"].Value + "','" + dataGridView4.Rows[j].Cells["s_print_rate"].Value + "','" + dataGridView4.Rows[j].Cells["s_print_cost"].Value + "','" + textBox27.Text + "')";
                    cmd.ExecuteNonQuery();
                }

                MySqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "update style_master set fabric_cost='" + textBox4.Text + "',dye_cost='" + textBox5.Text + "',print_cost='" + textBox6.Text + "',mat_cost='" + textBox8.Text + "',emb_cost='" + textBox7.Text + "',stiching_cost='" + textBox9.Text + "',total_cost='" + textBox10.Text + "',s_fabric_cost='" + textBox33.Text + "',consumption_status='DONE' where id='" + textBox27.Text + "'";
                cmd1.ExecuteNonQuery();

                MessageBox.Show("Costing Inserted Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {

            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            add_style_amount();
        }

        public void add_style_amount()
        {
            try
            {
                textBox10.Text = System.Convert.ToString(System.Convert.ToDouble(textBox4.Text) + System.Convert.ToDouble(textBox5.Text) + System.Convert.ToDouble(textBox6.Text) + System.Convert.ToDouble(textBox7.Text) + System.Convert.ToDouble(textBox9.Text) + System.Convert.ToDouble(textBox33.Text));
            }
            catch 
            {

            }
        }

        public void emb_clear()
        {
            textBox14.Clear();
            textBox23.Clear();
            textBox15.Clear();
            textBox19.Clear();
            textBox18.Clear();
            textBox20.Clear();
            textBox21.Clear();
            textBox22.Clear();
            textBox17.Clear();
            textBox16.Clear();
            textBox26.Clear();
            richTextBox2.Clear();
        }

        public void fill_first_data()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from style_master where id='" + textBox27.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                textBox1.Text = dr["style_code"].ToString();
                textBox2.Text = dr["style_colour"].ToString();
                richTextBox1.Text = dr["description"].ToString();
                textBox3.Text = dr["mrp"].ToString();
                textBox4.Text = dr["fabric_cost"].ToString();
                textBox11.Text = dr["fabric_cost"].ToString();
                textBox33.Text = dr["s_fabric_cost"].ToString();
                textBox32.Text = dr["s_fabric_cost"].ToString();
                textBox5.Text = dr["dye_cost"].ToString();
                textBox12.Text = dr["dye_cost"].ToString();
                textBox6.Text = dr["print_cost"].ToString();
                textBox13.Text = dr["print_cost"].ToString();
                textBox7.Text = dr["emb_cost"].ToString();
                textBox24.Text = dr["emb_cost"].ToString();
                textBox8.Text = dr["mat_cost"].ToString();
                textBox25.Text = dr["mat_cost"].ToString();
                textBox9.Text = dr["stiching_cost"].ToString();
                textBox10.Text = dr["total_cost"].ToString();
            }

            MySqlDataAdapter da1 = new MySqlDataAdapter("select * from style_fabric_dye_print where style_id='" + textBox27.Text + "'", con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach(DataRow dr1 in dt1.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["erp_component"].Value = dr1["erp_component"].ToString();
                dataGridView1.Rows[i].Cells["sub_component"].Value = dr1["component"].ToString();
                dataGridView1.Rows[i].Cells["fabric_code"].Value = dr1["fabric_code"].ToString();
                dataGridView1.Rows[i].Cells["phase"].Value = dr1["phase"].ToString();
                dataGridView1.Rows[i].Cells["qty"].Value = dr1["qty"].ToString();
                dataGridView1.Rows[i].Cells["uom"].Value = dr1["uom"].ToString();
                dataGridView1.Rows[i].Cells["rate"].Value = dr1["fabirc_rate"].ToString();
                dataGridView1.Rows[i].Cells["fabric_cost"].Value = dr1["fabric_cost"].ToString();
                dataGridView1.Rows[i].Cells["dye_qty"].Value = dr1["dye_qty"].ToString();
                dataGridView1.Rows[i].Cells["dye_rate"].Value = dr1["dye_rate"].ToString();
                dataGridView1.Rows[i].Cells["dye_cost"].Value = dr1["dye_cost"].ToString();
                dataGridView1.Rows[i].Cells["print_qty"].Value = dr1["print_qy"].ToString();
                dataGridView1.Rows[i].Cells["print_rate"].Value = dr1["print_rate"].ToString();
                dataGridView1.Rows[i].Cells["print_cost"].Value = dr1["print_cost"].ToString();  
            }

            MySqlDataAdapter da2 = new MySqlDataAdapter("select * from style_emb_consumption where style_id='" + textBox27.Text + "'", con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            foreach(DataRow dr2 in dt2.Rows)
            {
                int j = dataGridView2.Rows.Add();
                dataGridView2.Rows[j].Cells["emb_id"].Value=dr2["emb_id"].ToString();
                dataGridView2.Rows[j].Cells["erp_component1"].Value = dr2["erp_component"].ToString();
                dataGridView2.Rows[j].Cells["component"].Value = dr2["component"].ToString();
                dataGridView2.Rows[j].Cells["emb_name"].Value = dr2["emb_name"].ToString();
                dataGridView2.Rows[j].Cells["emb_code"].Value = dr2["emb_code"].ToString();
                dataGridView2.Rows[j].Cells["emb_qty"].Value = dr2["emb_qty"].ToString();
                dataGridView2.Rows[j].Cells["emb_uom"].Value = dr2["emb_uom"].ToString();
                dataGridView2.Rows[j].Cells["emb_rate"].Value = dr2["emb_rate"].ToString();
                dataGridView2.Rows[j].Cells["amount"].Value = dr2["amount"].ToString();
                dataGridView2.Rows[j].Cells["rate_type"].Value = dr2["rate_type"].ToString();
                dataGridView2.Rows[j].Cells["cmc_code"].Value = dr2["cmc_code"].ToString();
                dataGridView2.Rows[j].Cells["emb_type"].Value = dr2["emb_type"].ToString();
                dataGridView2.Rows[j].Cells["remakrs"].Value = dr2["remarks"].ToString();
            }

            MySqlDataAdapter da3 = new MySqlDataAdapter("select * from style_mat_consumption where style_id='" + textBox27.Text + "'", con);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            foreach(DataRow dr3 in dt3.Rows)
            {
                int j = dataGridView3.Rows.Add();
                dataGridView3.Rows[j].Cells["emb_id1"].Value = dr3["emb_id"].ToString();
                dataGridView3.Rows[j].Cells["erp_component2"].Value = dr3["erp_component"].ToString();
                dataGridView3.Rows[j].Cells["componet"].Value = dr3["component"].ToString();
                dataGridView3.Rows[j].Cells["emb_name1"].Value = dr3["emb_name"].ToString();
                dataGridView3.Rows[j].Cells["mat_code"].Value = dr3["mat_code"].ToString();
                dataGridView3.Rows[j].Cells["per_unit_qty"].Value = dr3["per_unit_qty"].ToString();
                dataGridView3.Rows[j].Cells["total_qty"].Value = dr3["total_qty"].ToString();
                dataGridView3.Rows[j].Cells["unit"].Value = dr3["unit"].ToString();
                dataGridView3.Rows[j].Cells["mat_rate"].Value = dr3["rate"].ToString();
                dataGridView3.Rows[j].Cells["per_unit_amt"].Value = dr3["per_unit_amount"].ToString();
                dataGridView3.Rows[j].Cells["total_amt"].Value = dr3["total_amount"].ToString();
            }

            MySqlDataAdapter da4 = new MySqlDataAdapter("select * from style_s_fabric where style_id='" + textBox27.Text + "'", con);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            foreach (DataRow dr4 in dt4.Rows)
            {
                int i = dataGridView4.Rows.Add();
                dataGridView4.Rows[i].Cells["s_erp_component"].Value = dr4["erp_component"].ToString();
                dataGridView4.Rows[i].Cells["s_sub_component"].Value = dr4["component"].ToString();
                dataGridView4.Rows[i].Cells["s_fabric_code"].Value = dr4["fabric_code"].ToString();
                dataGridView4.Rows[i].Cells["s_phase"].Value = dr4["phase"].ToString();
                dataGridView4.Rows[i].Cells["s_qty"].Value = dr4["qty"].ToString();
                dataGridView4.Rows[i].Cells["s_uom"].Value = dr4["uom"].ToString();
                dataGridView4.Rows[i].Cells["s_rate"].Value = dr4["fabirc_rate"].ToString();
                dataGridView4.Rows[i].Cells["s_cost"].Value = dr4["fabric_cost"].ToString();
                dataGridView4.Rows[i].Cells["s_dye_qty"].Value = dr4["dye_qty"].ToString();
                dataGridView4.Rows[i].Cells["s_dye_rate"].Value = dr4["dye_rate"].ToString();
                dataGridView4.Rows[i].Cells["s_dye_cost"].Value = dr4["dye_cost"].ToString();
                dataGridView4.Rows[i].Cells["s_print_qty"].Value = dr4["print_qy"].ToString();
                dataGridView4.Rows[i].Cells["s_print_rate"].Value = dr4["print_rate"].ToString();
                dataGridView4.Rows[i].Cells["s_print_cost"].Value = dr4["print_cost"].ToString();
            }

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do You Confirm to Update the Style Consumption", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                MySqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "delete from style_fabric_dye_print where style_id='"+textBox27.Text+"'";
                cmd2.ExecuteNonQuery();

                MySqlCommand cmd6 = con.CreateCommand();
                cmd6.CommandType = CommandType.Text;
                cmd6.CommandText = "delete from style_s_fabric where style_id='" + textBox27.Text + "'";
                cmd6.ExecuteNonQuery();

                MySqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "delete from style_mat_consumption where style_id='" + textBox27.Text + "'";
                cmd3.ExecuteNonQuery();

                MySqlCommand cmd4 = con.CreateCommand();
                cmd4.CommandType = CommandType.Text;
                cmd4.CommandText = "delete from style_emb_consumption where style_id='" + textBox27.Text + "'";
                cmd4.ExecuteNonQuery();

                for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into style_fabric_dye_print (erp_component,component,fabric_code,phase,qty,uom,fabirc_rate,fabric_cost,dye_qty,dye_rate,dye_cost,print_qy,print_rate,print_cost,style_id) Values ('" + dataGridView1.Rows[j].Cells["erp_component"].Value + "','" + dataGridView1.Rows[j].Cells["sub_component"].Value + "','" + dataGridView1.Rows[j].Cells["fabric_code"].Value + "','" + dataGridView1.Rows[j].Cells["phase"].Value + "','" + dataGridView1.Rows[j].Cells["qty"].Value + "','" + dataGridView1.Rows[j].Cells["uom"].Value + "','" + dataGridView1.Rows[j].Cells["rate"].Value + "','" + dataGridView1.Rows[j].Cells["fabric_cost"].Value + "','" + dataGridView1.Rows[j].Cells["dye_qty"].Value + "','" + dataGridView1.Rows[j].Cells["dye_rate"].Value + "','" + dataGridView1.Rows[j].Cells["dye_cost"].Value + "','" + dataGridView1.Rows[j].Cells["print_qty"].Value + "','" + dataGridView1.Rows[j].Cells["print_rate"].Value + "','" + dataGridView1.Rows[j].Cells["print_cost"].Value + "','" + textBox27.Text + "')";
                    cmd.ExecuteNonQuery();
                }

                for (int j = 0; j < dataGridView2.Rows.Count; j++)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into style_emb_consumption (emb_id,component,emb_name,emb_code,emb_qty,emb_uom,emb_rate,amount,rate_type,cmc_code,emb_type,remarks,style_id,erp_component) Values ('" + dataGridView2.Rows[j].Cells["emb_id"].Value + "','" + dataGridView2.Rows[j].Cells["component"].Value + "','" + dataGridView2.Rows[j].Cells["emb_name"].Value + "','" + dataGridView2.Rows[j].Cells["emb_code"].Value + "','" + dataGridView2.Rows[j].Cells["emb_qty"].Value + "','" + dataGridView2.Rows[j].Cells["emb_uom"].Value + "','" + dataGridView2.Rows[j].Cells["emb_rate"].Value + "','" + dataGridView2.Rows[j].Cells["amount"].Value + "','" + dataGridView2.Rows[j].Cells["rate_type"].Value + "','" + dataGridView2.Rows[j].Cells["cmc_code"].Value + "','" + dataGridView2.Rows[j].Cells["emb_type"].Value + "','" + dataGridView2.Rows[j].Cells["remakrs"].Value + "','" + textBox27.Text + "','" + dataGridView2.Rows[j].Cells["erp_component1"].Value + "')";
                    cmd.ExecuteNonQuery();
                }

                for (int j = 0; j < dataGridView3.Rows.Count-1; j++)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into style_mat_consumption (emb_id,component,emb_name,mat_code,per_unit_qty,total_qty,unit,rate,per_unit_amount,total_amount,style_id,erp_component) Values ('" + dataGridView3.Rows[j].Cells["emb_id1"].Value + "','" + dataGridView3.Rows[j].Cells["componet"].Value + "','" + dataGridView3.Rows[j].Cells["emb_name1"].Value + "','" + dataGridView3.Rows[j].Cells["mat_code"].Value + "','" + dataGridView3.Rows[j].Cells["per_unit_qty"].Value + "','" + dataGridView3.Rows[j].Cells["total_qty"].Value + "','" + dataGridView3.Rows[j].Cells["unit"].Value + "','" + dataGridView3.Rows[j].Cells["mat_rate"].Value + "','" + dataGridView3.Rows[j].Cells["per_unit_amt"].Value + "','" + dataGridView3.Rows[j].Cells["total_amt"].Value + "','" + textBox27.Text + "','" + dataGridView3.Rows[j].Cells["erp_component2"].Value + "')";
                    cmd.ExecuteNonQuery();
                }

                for (int j = 0; j < dataGridView4.Rows.Count - 1; j++)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into style_s_fabric (erp_component,component,fabric_code,phase,qty,uom,fabirc_rate,fabric_cost,dye_qty,dye_rate,dye_cost,print_qy,print_rate,print_cost,style_id) Values ('" + dataGridView4.Rows[j].Cells["s_erp_component"].Value + "','" + dataGridView4.Rows[j].Cells["s_sub_component"].Value + "','" + dataGridView4.Rows[j].Cells["s_fabric_code"].Value + "','" + dataGridView4.Rows[j].Cells["s_phase"].Value + "','" + dataGridView4.Rows[j].Cells["s_qty"].Value + "','" + dataGridView4.Rows[j].Cells["s_uom"].Value + "','" + dataGridView4.Rows[j].Cells["s_rate"].Value + "','" + dataGridView4.Rows[j].Cells["s_cost"].Value + "','" + dataGridView4.Rows[j].Cells["s_dye_qty"].Value + "','" + dataGridView4.Rows[j].Cells["s_dye_rate"].Value + "','" + dataGridView4.Rows[j].Cells["s_dye_cost"].Value + "','" + dataGridView4.Rows[j].Cells["s_print_qty"].Value + "','" + dataGridView4.Rows[j].Cells["s_print_rate"].Value + "','" + dataGridView4.Rows[j].Cells["s_print_cost"].Value + "','" + textBox27.Text + "')";
                    cmd.ExecuteNonQuery();
                }

                MySqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "update style_master set fabric_cost='" + textBox4.Text + "',dye_cost='" + textBox5.Text + "',print_cost='" + textBox6.Text + "',mat_cost='" + textBox8.Text + "',stiching_cost='" + textBox9.Text + "',total_cost='" + textBox10.Text + "',s_fabric_cost='" + textBox33.Text + "' where id='" + textBox27.Text + "'";
                cmd1.ExecuteNonQuery();

                MessageBox.Show("Costing Updated Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {

            }
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            add_style_amount();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //fabric
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select * from item where item_code='" + dataGridView1.Rows[i].Cells["fabric_code"].Value + "'",con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    dataGridView1.Rows[i].Cells["rate"].Value = dr["last_purchase_price"].ToString();
                    dataGridView1.Rows[i].Cells["fabric_cost"].Value = System.Convert.ToDouble(dataGridView1.Rows[i].Cells["rate"].Value) * System.Convert.ToDouble(dataGridView1.Rows[i].Cells["qty"].Value);
                }
            }

            //emb

            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select * from emb_master where id='" + dataGridView2.Rows[i].Cells["emb_id"].Value + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    costing_rate = dr["costing_rate"].ToString();
                    fixed_rate = dr["fixed_rate"].ToString();
                }
                if (fixed_rate == "")
                {
                    dataGridView2.Rows[i].Cells["emb_rate"].Value = costing_rate.ToString();
                    dataGridView2.Rows[i].Cells["rate_type"].Value = "Costing Rate";
                    dataGridView2.Rows[i].Cells["amount"].Value = System.Convert.ToDouble(dataGridView2.Rows[i].Cells["emb_rate"].Value) * System.Convert.ToDouble(dataGridView2.Rows[i].Cells["emb_qty"].Value);
                }
                else if (fixed_rate == "0")
                {
                    dataGridView2.Rows[i].Cells["emb_rate"].Value = costing_rate.ToString();
                    dataGridView2.Rows[i].Cells["rate_type"].Value = "Costing Rate";
                    dataGridView2.Rows[i].Cells["amount"].Value = System.Convert.ToDouble(dataGridView2.Rows[i].Cells["emb_rate"].Value) * System.Convert.ToDouble(dataGridView2.Rows[i].Cells["emb_qty"].Value);
                }
                else
                {
                    dataGridView2.Rows[i].Cells["emb_rate"].Value = fixed_rate.ToString();
                    dataGridView2.Rows[i].Cells["rate_type"].Value = "Fixed Rate";
                    dataGridView2.Rows[i].Cells["amount"].Value = System.Convert.ToDouble(dataGridView2.Rows[i].Cells["emb_rate"].Value) * System.Convert.ToDouble(dataGridView2.Rows[i].Cells["emb_qty"].Value);
                }                
            }

            //NON-FABRIC

            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select * from item where item_code='" + dataGridView3.Rows[i].Cells["mat_code"].Value + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    dataGridView3.Rows[i].Cells["mat_rate"].Value = dr["last_purchase_price"].ToString();
                    dataGridView3.Rows[i].Cells["total_amt"].Value = System.Convert.ToDouble(dataGridView3.Rows[i].Cells["total_qty"].Value) * System.Convert.ToDouble(dataGridView3.Rows[i].Cells["mat_rate"].Value);
                    dataGridView3.Rows[i].Cells["per_unit_amt"].Value = System.Convert.ToDouble(dataGridView3.Rows[i].Cells["per_unit_qty"].Value) * System.Convert.ToDouble(dataGridView3.Rows[i].Cells["mat_rate"].Value);
                }
            }
            add_style_amount();
            emb_amount_calculation();
            mat_amount_calculation();
            fabric_amount_calculation();

            MessageBox.Show("All the rate Updated Sucessfully, Please click Update button", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dataGridView3_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int column = dataGridView3.CurrentCell.ColumnIndex;
            string g = dataGridView3.Columns[column].HeaderText;
            if (g.Equals("Mat Code"))
            {
                TextBox auto_text = e.Control as TextBox;
                if (auto_text != null)
                {
                    auto_text.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    auto_text.AutoCompleteCustomSource = AutoComplete_mat_item_Code();
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

        private void dataGridView3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 4)
                {
                    string newvalue;
                    newvalue = (dataGridView3[e.ColumnIndex, e.RowIndex].Value).ToString();
                    MySqlDataAdapter da = new MySqlDataAdapter("select uom,last_purchase_price from item where item_code='" + newvalue + "'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView3.Rows[e.RowIndex].Cells["unit"].Value = dt.Rows[0][0].ToString();
                    dataGridView3.Rows[e.RowIndex].Cells["mat_rate"].Value = dt.Rows[0][1].ToString();
                }
                mat_datagrid_cal();
                mat_amount_calculation();
                
            }
            catch (Exception)
            {
                MessageBox.Show("Choose Correct NON-Fabric code");
                dataGridView3.Rows[e.RowIndex].Cells["unit"].Value = "";
                dataGridView3.Rows[e.RowIndex].Cells["mat_rate"].Value = "";
            }
        }

        public void mat_datagrid_cal()
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    row.Cells[dataGridView3.Columns[9].Index].Value = System.Convert.ToDouble(row.Cells[dataGridView3.Columns[5].Index].Value) * System.Convert.ToDouble(row.Cells[dataGridView3.Columns[8].Index].Value);
                    row.Cells[dataGridView3.Columns[10].Index].Value = System.Convert.ToDouble(row.Cells[dataGridView3.Columns[6].Index].Value) * System.Convert.ToDouble(row.Cells[dataGridView3.Columns[8].Index].Value);
                }
            }
            catch (Exception)
            {

            }

        }

        private void dataGridView4_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            int column = dataGridView4.CurrentCell.ColumnIndex;
            string g = dataGridView4.Columns[column].HeaderText;
            if (g.Equals("Fabric Code"))
            {
                TextBox auto_text = e.Control as TextBox;
                if (auto_text != null)
                {
                    auto_text.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    auto_text.AutoCompleteCustomSource = AutoComplete_s_item_Code();
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

        private void dataGridView4_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            { 
                if (e.ColumnIndex == 2)
                {
                    string newvalue;
                    newvalue = (dataGridView4[e.ColumnIndex, e.RowIndex].Value).ToString();
                    MySqlDataAdapter da = new MySqlDataAdapter("select uom,last_purchase_price from item where item_code='" + newvalue + "'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView4.Rows[e.RowIndex].Cells["s_uom"].Value = dt.Rows[0][0].ToString();
                    dataGridView4.Rows[e.RowIndex].Cells["s_rate"].Value = dt.Rows[0][1].ToString();
                }
                S_fabric_amount_calculation();
                add_style_amount();
            }
            catch (Exception)
            {
                MessageBox.Show("Choose Correct Fabric code");
                dataGridView4.Rows[e.RowIndex].Cells["s_uom"].Value = "";
                dataGridView4.Rows[e.RowIndex].Cells["s_rate"].Value = "";
            }
        }

        public void S_fabric_amount_calculation()
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView4.Rows)
                {
                    row.Cells[dataGridView4.Columns[7].Index].Value = System.Convert.ToDouble(row.Cells[dataGridView4.Columns[6].Index].Value) * System.Convert.ToDouble(row.Cells[dataGridView4.Columns[4].Index].Value);
                    row.Cells[dataGridView4.Columns[10].Index].Value = System.Convert.ToDouble(row.Cells[dataGridView4.Columns[8].Index].Value) * System.Convert.ToDouble(row.Cells[dataGridView4.Columns[9].Index].Value);
                    row.Cells[dataGridView4.Columns[13].Index].Value = System.Convert.ToDouble(row.Cells[dataGridView4.Columns[11].Index].Value) * System.Convert.ToDouble(row.Cells[dataGridView4.Columns[12].Index].Value);
                }
                double sum_of_fabric = 0, sum_of_dye = 0, sum_of_print = 0;
                for (int i = 0; i < dataGridView4.Rows.Count - 1; i++)
                {
                    sum_of_fabric += System.Convert.ToDouble(dataGridView4.Rows[i].Cells[7].Value);
                    sum_of_dye += System.Convert.ToDouble(dataGridView4.Rows[i].Cells[10].Value);
                    sum_of_print += System.Convert.ToDouble(dataGridView4.Rows[i].Cells[13].Value);
                }
                textBox32.Text = System.Convert.ToString(Math.Round(sum_of_fabric, 2));                
                textBox31.Text = System.Convert.ToString(Math.Round(sum_of_dye, 2));                
                textBox30.Text = System.Convert.ToString(Math.Round(sum_of_print, 2));
                textBox33.Text = System.Convert.ToString(Math.Round(sum_of_fabric, 2));  
                textBox5.Text = System.Convert.ToString(System.Convert.ToInt32(textBox12.Text) + System.Convert.ToInt32(textBox31.Text));
                textBox6.Text = System.Convert.ToString(System.Convert.ToInt32(textBox13.Text) + System.Convert.ToInt32(textBox30.Text));
            }
            catch (Exception)
            {

            }
        }
    }
}
