﻿using System;
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
            AutoScaleMode = AutoScaleMode.None;
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
        private void AddQuantity_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
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
        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_unitprice.Text == "")
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
                        string query = "Insert into tbl_Quantity(UnitPrice,Quantity,TotalPrice,Model_ID,Category_ID,Company_ID,CreationDate) " +
                                        "Values(@UnitPrice,@Quantity,@TotalPrice,@Model_ID,@Category_ID,@Company_ID,@CreationDate)";
                        using (cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@UnitPrice", txt_unitprice.Text);
                            cmd.Parameters.AddWithValue("@Quantity", txt_quantity.Text);
                            cmd.Parameters.AddWithValue("@TotalPrice", txt_totalprice.Text);
                            cmd.Parameters.AddWithValue("@Model_ID", cmb_model.SelectedValue);
                            cmd.Parameters.AddWithValue("@Category_ID", cmb_category.SelectedValue);
                            cmd.Parameters.AddWithValue("@Company_ID", cmb_company.SelectedValue);
                            if (DateTime.TryParse(txt_creationdate.Text, out DateTime creationDate))
                            {
                                cmd.Parameters.AddWithValue("@CreationDate", creationDate.ToString("yyyy-MM-dd"));
                            }
                            else
                            {
                                MessageBox.Show("Invalid Date Format");
                                return;
                            }
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            Fill_Categories();
                            Fill_Companies();
                            Fill_Models();
                        }
                    }
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
        private void txt_quantity_TextChanged(object sender, EventArgs e)
        {
            if (txt_quantity.Text != "")
            {
                int uprice = Convert.ToInt32(txt_unitprice.Text);
                int qty = Convert.ToInt32(txt_quantity.Text);
                txt_totalprice.Text = Convert.ToString(uprice * qty);
            }
            else 
            {
                txt_totalprice.Text = txt_unitprice.Text;

            }
        }

       
    }
}
