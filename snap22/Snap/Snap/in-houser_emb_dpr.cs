using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace Snap
{
    public partial class in_houser_emb_dpr : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public in_houser_emb_dpr()
        {
            InitializeComponent();
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Select Unit");
            }
            else
            {
                textBox1.ReadOnly = false;
                //fetch_time();
            }
        }


        public void fetch_time()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from unit_time_slot where unit_name='" + comboBox1.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                maskedTextBox2.Text = dr["start_1"].ToString();
                maskedTextBox3.Text = dr["end_1"].ToString();
                maskedTextBox4.Text = dr["start_2"].ToString();
                maskedTextBox5.Text = dr["end_2"].ToString();
                maskedTextBox6.Text = dr["start_3"].ToString();
                maskedTextBox7.Text = dr["end_3"].ToString();
                maskedTextBox8.Text = dr["start_4"].ToString();
                maskedTextBox9.Text = dr["end_4"].ToString();
            }
        }

        MaskedTextBox starttime, endtime;

        private void in_houser_emb_dpr_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            fill_combobox();
            //auto_complete_order_number();
            maskedTextBox1.Text = DateTime.Now.ToString("dd-MM-yyyy");
            //fetch_time();

        }


        public void masked_textbox()
        {
            starttime = new MaskedTextBox();
            endtime = new MaskedTextBox();
            dataGridView1.Controls.Add(starttime);
            dataGridView1.Controls.Add(endtime);
        }

        public void fill_combobox()
        {
            comboBox1.Items.Clear();
            MySqlDataAdapter da = new MySqlDataAdapter("select unit_name from emb_unit where type='IN-HOUSE' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["unit_name"].ToString());
            }
        }

        public void auto_complete_order_number()
        {
            MySqlCommand cmd = new MySqlCommand("select order_number from emb_order where order_number like '%" + textBox1.Text + "%'", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection mycollection = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                mycollection.Add(dr.GetString(0));
            }
            textBox1.AutoCompleteCustomSource = mycollection;
            dr.Close();
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int column = dataGridView1.CurrentCell.ColumnIndex;
            string g = dataGridView1.Columns[column].HeaderText;
            if (g.Equals("Gate Number"))
            {
                TextBox auto_text = e.Control as TextBox;
                if (auto_text != null)
                {
                    auto_text.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    auto_text.AutoCompleteCustomSource = AutoComplete_gate_number();
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

        public AutoCompleteStringCollection AutoComplete_gate_number()
        {
            MySqlCommand cmd = new MySqlCommand("select gate_number from karigar_master ", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection mycoll = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                mycoll.Add(dr["gate_number"].ToString());
            }
            dr.Close();
            return mycoll;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.ColumnIndex == 0)
                {
                    string newvalue;
                    newvalue = (dataGridView1[e.ColumnIndex, e.RowIndex].Value).ToString();
                    MySqlDataAdapter da = new MySqlDataAdapter("select name from karigar_master where gate_number='" + newvalue + "' AND unit='" + comboBox1.Text + "'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.Rows[e.RowIndex].Cells[1].Value = dt.Rows[0][0].ToString();
                    dataGridView1.Rows[e.RowIndex].Cells[3].Value = maskedTextBox2.Text;
                    dataGridView1.Rows[e.RowIndex].Cells[4].Value = maskedTextBox9.Text;
                    dataGridView1.Rows[e.RowIndex].Cells[5].Value = maskedTextBox2.Text;
                    dataGridView1.Rows[e.RowIndex].Cells[6].Value = maskedTextBox3.Text;
                    dataGridView1.Rows[e.RowIndex].Cells[7].Value = maskedTextBox4.Text;
                    dataGridView1.Rows[e.RowIndex].Cells[8].Value = maskedTextBox5.Text;
                    dataGridView1.Rows[e.RowIndex].Cells[9].Value = maskedTextBox6.Text;
                    dataGridView1.Rows[e.RowIndex].Cells[10].Value = maskedTextBox7.Text;
                    dataGridView1.Rows[e.RowIndex].Cells[11].Value = maskedTextBox8.Text;
                    dataGridView1.Rows[e.RowIndex].Cells[12].Value = maskedTextBox9.Text;
                    time_calculation();
                }
                
                 if(e.ColumnIndex == 3)
                 {
                    dataGridView1.Rows[e.RowIndex].Cells[5].Value = maskedTextBox2.Text;
                    dataGridView1.Rows[e.RowIndex].Cells[6].Value = maskedTextBox3.Text;
                    dataGridView1.Rows[e.RowIndex].Cells[7].Value = maskedTextBox4.Text;
                    dataGridView1.Rows[e.RowIndex].Cells[8].Value = maskedTextBox5.Text;
                    dataGridView1.Rows[e.RowIndex].Cells[9].Value = maskedTextBox6.Text;
                    dataGridView1.Rows[e.RowIndex].Cells[10].Value = maskedTextBox7.Text;
                    dataGridView1.Rows[e.RowIndex].Cells[11].Value = maskedTextBox8.Text;
                    dataGridView1.Rows[e.RowIndex].Cells[12].Value = maskedTextBox9.Text;
                    string start;
                    start = (dataGridView1[e.ColumnIndex, e.RowIndex].Value).ToString();
                    TimeSpan start_time = TimeSpan.Parse(start);
                    dataGridView1.Rows[e.RowIndex].Cells[4].ReadOnly = false;
                    if (start_time > TimeSpan.Parse(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString()))
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[5].Value = "00:00";
                        dataGridView1.Rows[e.RowIndex].Cells[6].Value = "00:00";
                        dataGridView1.Rows[e.RowIndex].Cells[7].Value = start;
                        
                    }
                    
                    if (start_time > TimeSpan.Parse(dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString()))
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[7].Value = "00:00";
                        dataGridView1.Rows[e.RowIndex].Cells[8].Value = "00:00";
                        dataGridView1.Rows[e.RowIndex].Cells[9].Value = start;
                        
                    }
                    
                    if (start_time > TimeSpan.Parse(dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString()))
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[9].Value = "00:00";
                        dataGridView1.Rows[e.RowIndex].Cells[10].Value = "00:00";
                        dataGridView1.Rows[e.RowIndex].Cells[11].Value = start;
                        
                    }
                    if (start_time < TimeSpan.Parse(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString()))
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[5].Value = start;
                        
                    }
                    time_calculation();

                    
                }

                if(e.ColumnIndex==4)
                {
                    string end;
                    end = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString(); 
                    TimeSpan end_time = TimeSpan.Parse(end);
                    dataGridView1.Rows[e.RowIndex].Cells[4].ReadOnly = true;
                    if (end_time< TimeSpan.Parse(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString())&& dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString()!="00:00")
                    {
                        
                        dataGridView1.Rows[e.RowIndex].Cells[6].Value = end;
                        dataGridView1.Rows[e.RowIndex].Cells[7].Value = "00:00";
                        dataGridView1.Rows[e.RowIndex].Cells[8].Value = "00:00";
                        dataGridView1.Rows[e.RowIndex].Cells[9].Value = "00:00";
                        dataGridView1.Rows[e.RowIndex].Cells[10].Value = "00:00";
                        dataGridView1.Rows[e.RowIndex].Cells[11].Value = "00:00";
                        dataGridView1.Rows[e.RowIndex].Cells[12].Value = "00:00";
                        
                    }
                   else if (end_time < TimeSpan.Parse(dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString()) && dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString() != "00:00")
                    {
                        
                        dataGridView1.Rows[e.RowIndex].Cells[8].Value = end;
                        dataGridView1.Rows[e.RowIndex].Cells[9].Value = "00:00";
                        dataGridView1.Rows[e.RowIndex].Cells[10].Value = "00:00";
                        dataGridView1.Rows[e.RowIndex].Cells[11].Value = "00:00";
                        dataGridView1.Rows[e.RowIndex].Cells[12].Value = "00:00";
                        
                    }
                    else if (end_time < TimeSpan.Parse(dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString()) && dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString() != "00:00")
                    {

                        dataGridView1.Rows[e.RowIndex].Cells[10].Value = end;
                        dataGridView1.Rows[e.RowIndex].Cells[11].Value = "00:00";
                        dataGridView1.Rows[e.RowIndex].Cells[12].Value = "00:00";
                        
                    }
                    else
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[12].Value = end;
                       
                    }
                    time_calculation();
                }

            }
            catch (Exception)
            {
              //  MessageBox.Show(ex.Message);
            }
        }

        

        public void time_calculation()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                
                TimeSpan start1 = TimeSpan.Parse(row.Cells[dataGridView1.Columns[5].Index].Value.ToString());
                TimeSpan end1 = TimeSpan.Parse(row.Cells[dataGridView1.Columns[6].Index].Value.ToString());                
                TimeSpan slot1 = end1.Subtract(start1);
                TimeSpan start2 = TimeSpan.Parse(row.Cells[dataGridView1.Columns[7].Index].Value.ToString());
                TimeSpan end2 = TimeSpan.Parse(row.Cells[dataGridView1.Columns[8].Index].Value.ToString());
                TimeSpan slot2 = end2.Subtract(start2);
                TimeSpan start3 = TimeSpan.Parse(row.Cells[dataGridView1.Columns[9].Index].Value.ToString());
                TimeSpan end3 = TimeSpan.Parse(row.Cells[dataGridView1.Columns[10].Index].Value.ToString());
                TimeSpan slot3 = end3.Subtract(start3);
                TimeSpan start4 = TimeSpan.Parse(row.Cells[dataGridView1.Columns[11].Index].Value.ToString());
                TimeSpan end4 = TimeSpan.Parse(row.Cells[dataGridView1.Columns[12].Index].Value.ToString());
                TimeSpan slot4 = end4.Subtract(start4);
                TimeSpan final_time = slot1 + slot2 + slot3 + slot4;
                string diff = final_time.Hours.ToString("00") + ":" + final_time.Minutes.ToString("00");
                row.Cells[dataGridView1.Columns[13].Index].Value = diff.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into dpr_entry (order_number,date,gate_number,karigar_name,unit,component,start1,end1,start2,end2,start3,end3,start4,end4,total_time) Values ('" + textBox1.Text + "','" + maskedTextBox1.Text + "','" + dataGridView1.Rows[i].Cells[0].Value + "','" + dataGridView1.Rows[i].Cells[1].Value + "','" + comboBox1.Text + "','" + dataGridView1.Rows[i].Cells[2].Value + "','" + dataGridView1.Rows[i].Cells[5].Value + "','" + dataGridView1.Rows[i].Cells[6].Value + "','" + dataGridView1.Rows[i].Cells[7].Value + "','" + dataGridView1.Rows[i].Cells[8].Value + "','" + dataGridView1.Rows[i].Cells[9].Value + "','" + dataGridView1.Rows[i].Cells[10].Value + "','" + dataGridView1.Rows[i].Cells[11].Value + "','" + dataGridView1.Rows[i].Cells[12].Value + "','" + dataGridView1.Rows[i].Cells[13].Value + "')";
                cmd.ExecuteNonQuery();
            }
            textBox1.Clear();
            textBox5.Clear();
            textBox3.Clear();
            textBox6.Clear();
            textBox2.Clear();
            richTextBox1.Clear();
            textBox7.Clear();
            dataGridView1.Rows.Clear();
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime date = System.Convert.ToDateTime(this.maskedTextBox1.Text.Trim(), new CultureInfo("en-GB"));
            textBox8.Text = date.AddDays(-1).ToString("dd-MM-yyyy");

            if (maskedTextBox1.Text == "")
            {
                MessageBox.Show("enter date");
            }

            else if (comboBox1.Text == "")
            {
                MessageBox.Show("Select Unit");
            }
               
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Enter Order Number");
            }

            else
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select * from dpr_entry where date='" + textBox8.Text + "' AND unit='" + comboBox1.Text + "' AND order_number='" + textBox1.Text + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr["gate_number"].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dr["karigar_name"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dr["component"].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = dr["start1"].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = dr["end1"].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = dr["start2"].ToString();
                    dataGridView1.Rows[i].Cells[8].Value = dr["end2"].ToString();
                    dataGridView1.Rows[i].Cells[9].Value = dr["start3"].ToString();
                    dataGridView1.Rows[i].Cells[10].Value = dr["end3"].ToString();
                    dataGridView1.Rows[i].Cells[11].Value = dr["start4"].ToString();
                    dataGridView1.Rows[i].Cells[12].Value = dr["end4"].ToString();
                    dataGridView1.Rows[i].Cells[13].Value = dr["total_time"].ToString();
                }
            }            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            /*try
            {
                auto_complete_order_number();
            }
            catch(Exception)
            { }*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fetch_time();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            listBox1.Visible = true;
            listBox1.Items.Clear();
            MySqlDataAdapter da = new MySqlDataAdapter("select order_number from emb_order where order_number like '%" + textBox1.Text + "%'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                listBox1.Items.Add(dr["order_number"].ToString());
            }
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Down)
            {
                listBox1.Focus();
                listBox1.SelectedIndex = 0;
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode==Keys.Down)
                {
                    this.listBox1.SelectedIndex = this.listBox1.SelectedIndex;
                }
                if(e.KeyCode==Keys.Up)
                {
                    this.listBox1.SelectedIndex = this.listBox1.SelectedIndex;
                }
                if(e.KeyCode==Keys.Enter)
                {
                    textBox1.Text = listBox1.SelectedItem.ToString();
                    listBox1.Visible = false;
                    button3.Focus();
                    fetch_order_details();
                }
            }
            catch
            {

            }
        }

        public void fetch_order_details()
        {
            int i = 0;
            MySqlDataAdapter da = new MySqlDataAdapter("select * from emb_order where order_number='" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            i = System.Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 0)
            {
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    textBox6.Text = dr["qty"].ToString();
                    textBox5.Text = dr["emb_code"].ToString();
                    textBox3.Text = dr["fab_qty_detail"].ToString();
                    textBox4.Text = dr["uom"].ToString();
                    textBox2.Text = dr["batchcode"].ToString();
                    richTextBox1.Text = dr["emb_name"].ToString();
                    textBox7.Text = dr["no._of_p_code"].ToString();
                }
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            try
            {
                fetch_order_details();
                //listBox1.Visible = false;
            }
            catch(Exception)
            {

            }
        }
    }
}
