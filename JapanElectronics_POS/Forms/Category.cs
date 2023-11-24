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
    public partial class Category : Form
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        string ConString = Utility.Utility.GetConnectionString();
        public Category()
        {
            InitializeComponent();
            dgv_category.AutoGenerateColumns = false;
        }
        private void Category_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            FillCompanies();
            GetAllCategories();
        }
        public void FillCompanies()
        {
            DataTable data = new DataTable();

            data.Columns.Add("CompanyID", typeof(int));
            data.Columns.Add("CompanyName", typeof(string));

            // Create a default row for 'Select' with a value of -1
            DataRow defaultRow = data.NewRow();
            defaultRow["CompanyID"] = -1;
            defaultRow["CompanyName"] = "Select";
            data.Rows.Add(defaultRow);

            using (conn = new SqlConnection(ConString))
            {
                string query = "Select * from tbl_Company";
                using (cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    data.Load(cmd.ExecuteReader());
                }
            }
            cmb_company.DataSource = data;
            cmb_company.DisplayMember = "CompanyName";
            cmb_company.ValueMember = "CompanyID";
        }
        public void GetAllCategories()
        {
            dgv_category.Rows.Clear();
            DataTable data = new DataTable();
            using (conn = new SqlConnection(ConString))
            {
                string query = "select tco.CompanyName,tc.CategoryName from tbl_category tc" +
                                " join tbl_Company tco on tc.Company_ID = tco.CompanyID";
                using (cmd = new SqlCommand(query, conn))
                    conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    // Assuming you have a DataGridView column named "CompanyName"
                    while (reader.Read())
                    {
                        int rowIndex = dgv_category.Rows.Add();
                        dgv_category.Rows[rowIndex].Cells["CategoryName"].Value = reader["CategoryName"];
                        dgv_category.Rows[rowIndex].Cells["CompanyName"].Value = reader["CompanyName"];
                    }
                }
            }
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_category.Text == "")
                {
                    MessageBox.Show("Enter Category Name");
                }
                else if (cmb_company.SelectedValue != null && (int)cmb_company.SelectedValue == -1)
                {
                    MessageBox.Show("Please select a company.");
                }
                else
                {
                    using (conn = new SqlConnection(ConString))
                    {
                        string query = "Insert into tbl_Category(CategoryName,Company_ID) Values(@CatName,@Company_ID)";
                        using (cmd = new SqlCommand(query, conn))
                        {
                            conn.Open();
                            cmd.Parameters.AddWithValue("@CatName", txt_category.Text);
                            cmd.Parameters.AddWithValue("@Company_ID", cmb_company.SelectedValue);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    txt_category.Text = "";
                    cmb_company.SelectedIndex = -1;
                    GetAllCategories();
                    FillCompanies();
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
         //   Dashboard dashboard = new Dashboard();
         //   dashboard.Show();
        }

       
    }
}
