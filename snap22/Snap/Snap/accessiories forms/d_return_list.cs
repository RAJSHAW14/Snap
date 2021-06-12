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
    public partial class d_return_list : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public d_return_list()
        {
            InitializeComponent();
        }

        private void d_return_list_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            maskedTextBox1.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        public void view_stock()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select inventory from item where item_code='" + textBox6.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBox19.Text = dr["inventory"].ToString();
            }
        }
    }
}
