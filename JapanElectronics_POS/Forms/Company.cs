using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JapanElectronics_POS.Forms
{
    public partial class Company : Form
    {

        SqlConnection conn = null;
        SqlCommand cmd = null;
        string ConString = Utility.Utility.GetConnectionString();
        public Company()
        {
            InitializeComponent();
        }

        private void Company_Load(object sender, EventArgs e)
        {
            GetAllCompanies();
        }
        public void GetAllCompanies()
        {
            dgvCompany.Rows.Clear();
            DataTable data = new DataTable();
            using (conn = new SqlConnection(ConString))
            {
                string query = "select CompanyName from tbl_Company";
                using (cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        // Assuming you have a DataGridView column named "CompanyName"
                        while (reader.Read())
                        {
                            int rowIndex = dgvCompany.Rows.Add();
                            dgvCompany.Rows[rowIndex].Cells["CompanyName"].Value = reader["companyname"];
                        }
                    }
                }
            }

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_companyname.Text == "")
                {
                    MessageBox.Show("Enter Company Name");
                }
                else
                {
                    using (conn = new SqlConnection(ConString))
                    {
                        string query = "Insert into tbl_Company(CompanyName) Values(@CompanyName)";
                        using (cmd = new SqlCommand(query, conn))
                        {
                            conn.Open();
                            cmd.Parameters.AddWithValue("@CompanyName", txt_companyname.Text);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    txt_companyname.Text = "";
                    GetAllCompanies();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
          //  Dashboard dashboard = new Dashboard();
         //   dashboard.Show();
        }

        private void Company_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }
    }
}
