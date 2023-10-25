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
    public partial class AddQuantity : Form
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        string ConString = Utility.Utility.GetConnectionString();
        public AddQuantity()
        {
            InitializeComponent();
            InitializeForm();
            
        }
        public void InitializeForm()
        {
            cmb_company.DisplayMember = "CompanyName";
            cmb_company.ValueMember = "CompanyID";
            cmb_category.DisplayMember = "CategoryName";
            cmb_category.ValueMember = "CategoryID";

            Fill_Companies();
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
                    cmd.Parameters.AddWithValue("@selectedValue", s);
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
        private void cmb_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_Models();
        }
        public void Fill_Models()
        {
            DataTable data = new DataTable();

            data.Columns.Add("ModelID", typeof(int));
            data.Columns.Add("ModelName", typeof(string));

            // Create a default row for 'Select' with a value of -1
            DataRow defaultRow = data.NewRow();
            defaultRow["ModelID"] = -1;
            defaultRow["ModelName"] = "Select Model";
            data.Rows.Add(defaultRow);

            using (conn = new SqlConnection(ConString))
            {
                string query = "Select * from tbl_Model where Category_ID = @selectedValue";

                using (cmd = new SqlCommand(query, conn))
                {
                    int s = (int)cmb_category.SelectedValue;
                    cmd.Parameters.AddWithValue("@selectedValue", s);
                    conn.Open();
                    data.Load(cmd.ExecuteReader());
                }
            }

            cmb_model.DataSource = data;
            cmb_model.DisplayMember = "ModelName";
            cmb_model.ValueMember = "ModelID";
        }
        private void AddQuantity_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_qty.Text == "")
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
                else if (cmb_model.SelectedValue != null && (int)cmb_model.SelectedValue == -1)
                {
                    MessageBox.Show("Please select a Model.");
                }
                else
                {
                    using (conn = new SqlConnection(ConString))
                    {
                        string query = "Insert into tbl_Quantity(TotalItems,Model_ID,Category_ID,Company_ID) " +
                                        "Values(@Item,@Model_ID,@Category_ID,@Company_ID)";
                        using (cmd = new SqlCommand(query, conn))
                        {
                            conn.Open();
                            cmd.Parameters.AddWithValue("@Item", txt_qty.Text);
                            cmd.Parameters.AddWithValue("@Model_ID", cmb_model.SelectedValue);
                            cmd.Parameters.AddWithValue("@Category_ID", cmb_category.SelectedValue);
                            cmd.Parameters.AddWithValue("@Company_ID", cmb_company.SelectedValue);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    txt_qty.Text = "";
                    //   GetAllCompanies();
                    Fill_Categories();
                    Fill_Companies();
                    Fill_Models();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally 
            {
                conn.Close();
            }
        }
    }
}
