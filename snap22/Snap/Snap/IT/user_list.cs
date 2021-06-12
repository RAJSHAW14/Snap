using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Snap.IT
{
    public partial class user_list : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public user_list()
        {
            InitializeComponent();
        }

        private void user_list_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            fill_data();
            fill_dept();
        }

        public void fill_dept()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select department_name from department", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["department_name"].ToString());
            }
        }

        public void fill_data()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from it_user", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells["user_id"].Value = dr["user_id"].ToString();
                dataGridView1.Rows[i].Cells["name"].Value = dr["user_name"].ToString();
                dataGridView1.Rows[i].Cells["department"].Value = dr["department"].ToString();
                dataGridView1.Rows[i].Cells["ext_number"].Value = dr["ext_number"].ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter User ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(textBox2.Text=="")
            {
                MessageBox.Show("Enter User Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("Enter Department", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int i = 0;
                MySqlDataAdapter da = new MySqlDataAdapter("select * from it_user where user_id='" + textBox1.Text + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                i = System.Convert.ToInt32(dt.Rows.Count.ToString());
                if(i==0)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into it_user (user_id,user_name,department,ext_number) Values ('"+textBox1.Text+ "','" + textBox2.Text + "','" + comboBox1.Text + "','" + textBox4.Text + "')";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Inserted SUcessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                }
                else
                {
                    MessageBox.Show("User ID already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();            
            comboBox1.Text = "";
            dataGridView1.Rows.Clear();
            fill_data();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("Please retrive the data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Are You Sure want to Update", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update it_user set user_name='" + textBox2.Text + "', department='" + comboBox1.Text + "', ext_number='" + textBox4.Text + "' where user_id='" + textBox1.Text + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Updated Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                }
                else
                {

                }
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox3.Text = row.Cells["id"].Value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox3.Text=="")
            {
                MessageBox.Show("Select the cell first to retrive", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select * from it_user where id='"+textBox3.Text+"'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    textBox1.Text = dr["user_id"].ToString();
                    textBox2.Text = dr["user_name"].ToString();
                    comboBox1.Text = dr["department"].ToString();
                    textBox4.Text = dr["ext_number"].ToString();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please retrive the data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Are You Sure want to Delete", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "delete from it_user where user_id='" + textBox1.Text + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Deleted Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                }
                else
                {

                }
            }
        }
    }
}
