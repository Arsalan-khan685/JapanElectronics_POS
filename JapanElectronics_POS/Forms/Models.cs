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
    public partial class Models : Form
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        string ConString = Utility.Utility.GetConnectionString();
        public Models()
        {
            InitializeComponent();
            InitializeForm();
            dgv_models.AutoGenerateColumns = false;
        }
        public void InitializeForm()
        {
            cmb_company.DisplayMember = "CompanyName";
            cmb_company.ValueMember = "CompanyID";
            cmb_category.DisplayMember = "CategoryName";
            cmb_category.ValueMember = "CategoryID";

            Fill_Companies();
            GetAllModels();
        }

        public void Fill_Companies()
        {
            DataTable data = new DataTable();

            data.Columns.Add("CompanyID", typeof(int));
            data.Columns.Add("CompanyName", typeof(string));

            // Create a default row for 'Select' with a value of -1
            DataRow defaultRow = data.NewRow();
            defaultRow["CompanyID"] = -1;
            defaultRow["CompanyName"] = "Select Company";
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
        public void Fill_Categories()
        {
            DataTable data = new DataTable();

            data.Columns.Add("CategoryID", typeof(int));
            data.Columns.Add("CategoryName", typeof(string));

            // Create a default row for 'Select' with a value of -1
            DataRow defaultRow = data.NewRow();
            defaultRow["CategoryID"] = -1;
            defaultRow["CategoryName"] = "Select Category";
            data.Rows.Add(defaultRow);

            using (conn = new SqlConnection(ConString))
            {
                string query = "Select * from tbl_Category where Company_ID = @selectedValue";

                using (cmd = new SqlCommand(query, conn))
                {
                    int s = (int)cmb_company.SelectedValue;
                    cmd.Parameters.AddWithValue("@selectedValue",s);
                    conn.Open();
                    data.Load(cmd.ExecuteReader());
                }
            }

            cmb_category.DataSource = data;
            cmb_category.DisplayMember = "CategoryName";
            cmb_category.ValueMember = "CategoryID";
        }
        private void cmb_company_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_Categories();
        }
        public void GetAllModels()
        {
            dgv_models.Rows.Clear();
            DataTable data = new DataTable();
            using (conn = new SqlConnection(ConString))
            {
                string query = "select tm.ModelName,tc.CategoryName,tco.CompanyName from tbl_Model tm" +
                                " inner join tbl_Category tc on tm.Category_ID=tc.CategoryID" +
                                " inner join tbl_Company tco on tm.Company_ID = tco.CompanyID";
                using (cmd = new SqlCommand(query, conn))
                    conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    // Assuming you have a DataGridView column named "CompanyName"
                    while (reader.Read())
                    {
                        int rowIndex = dgv_models.Rows.Add();
                        dgv_models.Rows[rowIndex].Cells["ModelName"].Value = reader["ModelName"];
                        dgv_models.Rows[rowIndex].Cells["CategoryName"].Value = reader["CategoryName"];
                        dgv_models.Rows[rowIndex].Cells["CompanyName"].Value = reader["CompanyName"];
                    }
                }
            }
        }
        private void Models_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }
        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_model.Text == "")
                {
                    MessageBox.Show("Enter Model Name");
                }
                else if (cmb_company.SelectedValue != null && (int)cmb_company.SelectedValue == -1)
                {
                    MessageBox.Show("Please select a company.");
                }
                else if (cmb_category.SelectedValue != null && (int)cmb_category.SelectedValue == -1)
                {
                    MessageBox.Show("Please select a category.");
                }
                else
                {
                    using (conn = new SqlConnection(ConString))
                    {
                        string query = "Insert into tbl_Model(ModelName,Category_ID,Company_ID) " +
                                        "Values(@ModelName,@Category_ID,@Company_ID)";
                        using (cmd = new SqlCommand(query, conn))
                        {
                            conn.Open();
                            cmd.Parameters.AddWithValue("@ModelName", txt_model.Text);
                            cmd.Parameters.AddWithValue("@Category_ID", cmb_category.SelectedValue);
                            cmd.Parameters.AddWithValue("@Company_ID", cmb_company.SelectedValue);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    txt_model.Text = "";
                    //   GetAllCompanies();
                    GetAllModels();
                    Fill_Categories();
                    Fill_Companies();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

       
    }
}
