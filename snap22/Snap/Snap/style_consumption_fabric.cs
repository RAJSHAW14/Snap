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
    public partial class style_consumption_fabric : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        int delete_id_fabric;

        public style_consumption_fabric()
        {
            InitializeComponent();
        }

        private void style_consumption_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            fill_datagride();
        }

       
        

        public AutoCompleteStringCollection AutoComplete_component()
        {
            MySqlCommand cmd = new MySqlCommand("select * from component_master ", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection mycoll = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                mycoll.Add(dr["component"].ToString());
            }
            dr.Close();
            return mycoll;
        }

        public AutoCompleteStringCollection AutoComplete_fabric_code()
        {
            MySqlCommand cmd = new MySqlCommand("select item_code from item ", con);
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
            if (g.Equals("Component"))
            {
                TextBox auto_text = e.Control as TextBox;
                if (auto_text != null)
                {
                    auto_text.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    auto_text.AutoCompleteCustomSource = AutoComplete_component();
                    auto_text.AutoCompleteSource = AutoCompleteSource.CustomSource;

                }
            }

            else if(g.Equals("Fabric Code"))
            {
                TextBox auto_text = e.Control as TextBox;
                if (auto_text != null)
                {
                    auto_text.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    auto_text.AutoCompleteCustomSource = AutoComplete_fabric_code();
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
                    MySqlDataAdapter da = new MySqlDataAdapter("select item_name,uom from item where item_code='" + newvalue + "'",con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.Rows[e.RowIndex].Cells[3].Value = dt.Rows[0][0].ToString();
                    dataGridView1.Rows[e.RowIndex].Cells[4].Value = dt.Rows[0][1].ToString();
                }
                else if(e.ColumnIndex==1)
                {

                    int newvalue1 = 0;
                    newvalue1 = System.Convert.ToInt32((dataGridView1[e.ColumnIndex, e.RowIndex].Value).ToString());
                    MySqlDataAdapter da1 = new MySqlDataAdapter("select component from component_master where component='" + newvalue1 + "'", con);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    newvalue1 = System.Convert.ToInt32(dt1.Rows.Count.ToString());
                    if(newvalue1==0)
                    {
                        MessageBox.Show("enter conrrect component");
                        dataGridView1.Rows[e.RowIndex].Cells[1].Value = "";
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Choose Correct Fabric code");
                dataGridView1.Rows[e.RowIndex].Cells[2].Value = "";
                dataGridView1.Rows[e.RowIndex].Cells[3].Value = "";
                dataGridView1.Rows[e.RowIndex].Cells[4].Value = "";
            }
        }

      

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int i = 0;
            MySqlDataAdapter da = new MySqlDataAdapter("select * from style_consumption_fabric wehre style_code='"+textBox2.Text+ "' and style_colour='" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            i = System.Convert.ToInt32(dt.Rows.Count.ToString());
            if(i==0)
            {
                button3.Enabled = false;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Style Already added, Do you want to edit the consumption", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    MySqlDataAdapter da1 = new MySqlDataAdapter("select * from style_consumption_fabric where style_code='" + textBox2.Text + "' and style_colour='" + textBox1.Text + "'", con);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    foreach (DataRow dr in dt.Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells[0].Value = dr["id"].ToString();
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            int j = 0;
            MySqlDataAdapter da = new MySqlDataAdapter("select * from style_master where style_code='"+textBox2.Text+ "' and style_colour='"+textBox1.Text+"'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            i = System.Convert.ToInt32(dt.Rows.Count.ToString());
            if(i==0)
            {
                MessageBox.Show("Style Code not found");
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    richTextBox1.Text = dr["description"].ToString();
                    textBox4.Text = dr["catagory"].ToString();
                }
            }

            MySqlDataAdapter da1 = new MySqlDataAdapter("select * from style_consumption_fabric where style_code='" + textBox2.Text + "' and style_colour='" + textBox1.Text + "'", con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            j = System.Convert.ToInt32(dt1.Rows.Count);
            if(j==0)
            {
                button3.Enabled = false;
            }
            else
            {
                fill_datagride();
                button2.Enabled = false;
            }

        }

        public void fill_datagride()
        {
            MySqlDataAdapter da1 = new MySqlDataAdapter("select * from style_consumption_fabric where style_code='" + textBox2.Text + "' and  style_colour='" + textBox1.Text + "'", con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = dr1["id"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = dr1["component"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = dr1["fabric_code"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = dr1["fabric_name"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = dr1["unit"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = dr1["qty"].ToString();
            }
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            try {
                if (e.Button == MouseButtons.Right)
                {
                    delete_id_fabric = System.Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    this.contextMenuStrip1.Show(this.dataGridView1, e.Location);
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
            catch(Exception)
            { }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from style_consumption_fabric where id='"+delete_id_fabric.ToString()+"'";
            cmd.ExecuteNonQuery();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you want to add the data", "confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into style_consumption_fabric (style_code,style_colour,component,fabric_code,fabric_name,unit,qty) Values ('"+textBox2.Text+ "','" + textBox1.Text + "','"+dataGridView1.Rows[i].Cells[1].Value+ "','" + dataGridView1.Rows[i].Cells[2].Value + "','" + dataGridView1.Rows[i].Cells[3].Value + "','" + dataGridView1.Rows[i].Cells[4].Value + "','" + dataGridView1.Rows[i].Cells[5].Value + "')";
                    cmd.ExecuteNonQuery();
                }
                MySqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "Update style_master set fabric_status='DONE'";
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Data Inserted");
                this.Close();
            }
            else
            { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you want to update the style consumption", "Confirm", MessageBoxButtons.YesNo);
            if(dialog==DialogResult.Yes)
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from style_consumption_fabric where style_code='" + textBox2.Text + "' and style_colour='" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    MySqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "insert into style_consumption_fabric (style_code,style_colour,component,fabric_code,fabric_name,unit,qty) Values ('" + textBox2.Text + "','" + textBox1.Text + "','" + dataGridView1.Rows[i].Cells[1].Value + "','" + dataGridView1.Rows[i].Cells[2].Value + "','" + dataGridView1.Rows[i].Cells[3].Value + "','" + dataGridView1.Rows[i].Cells[4].Value + "','" + dataGridView1.Rows[i].Cells[5].Value + "')";
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Data updated");
                }
            }
        }
    }
}
