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
    public partial class SalesForm : Form
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        string ConString = Utility.Utility.GetConnectionString();
        public SalesForm()
        {
            AutoScaleMode = AutoScaleMode.None;
            InitializeComponent();
            InitializeForm();
        }
        private void SalesForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }
        public void InitializeForm()
        {
            cmb_models.DisplayMember = "ModelName";
            cmb_models.ValueMember = "ModelID";
            FillItems();
        }
        public void FillItems()
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
                string query = "Select * from tbl_Model";

                using (cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    data.Load(cmd.ExecuteReader());
                }
            }

            cmb_models.DataSource = data;
            cmb_models.DisplayMember = "ModelName";
            cmb_models.ValueMember = "ModelID";
        }


        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_username.Text == "")
                {
                    MessageBox.Show("Enter Name Please");
                }
                else if (txt_cnic.Text == "")
                {
                    MessageBox.Show("Enter CNIC Please");
                }
                else if (cmb_models.SelectedValue != null && (int)cmb_models.SelectedValue==-1)
                {
                    MessageBox.Show("Please Select a Model");
                }
                else if (txt_unitprice.Text=="")
                {
                    MessageBox.Show("Please Enter Unit Price");
                }
                else if (txt_s_qty.Text == "")
                {
                    MessageBox.Show("Please Enter Quantity");
                }
                else
                {
                    using(conn = new SqlConnection(ConString))
                    {
                        string query = "Insert into tbl_Sales(UserName,CNIC,Model_ID,UnitPrice,Quantity," +
                                        "TotalPrice,SalesDate) " +
                                        " Values " +
                                        " (@UserName,@CNIC,@ItemModel,@UnitPrice,@Quantity,@TotalPrice,@SalesDate)";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@UserName",txt_username.Text);
                        cmd.Parameters.AddWithValue("@CNIC",txt_cnic.Text);
                        cmd.Parameters.AddWithValue("@ItemModel",cmb_models.SelectedValue);
                        cmd.Parameters.AddWithValue("@UnitPrice",txt_unitprice.Text);
                        cmd.Parameters.AddWithValue("@Quantity",txt_s_qty.Text);
                        cmd.Parameters.AddWithValue("@TotalPrice",txt_totalprice.Text);
                        if (DateTime.TryParse(txt_salesdate.Text, out DateTime salesDate))
                        {
                            cmd.Parameters.AddWithValue("@SalesDate", salesDate.ToString("yyyy-MM-dd"));
                        }
                        else
                        {
                            // Handle invalid date format
                            MessageBox.Show("Invalid date format");
                            return;
                        }
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        Clear();
                        MessageBox.Show("Record Saved Succesfully");
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
        public void Clear()
        {
            txt_username.Text = "";
            txt_cnic.Text = "";
            cmb_models.SelectedValue = "-1";
            txt_unitprice.Text = "";
            txt_totalprice.Text = "";
        }
        private void txt_s_qty_TextChanged(object sender, EventArgs e)
        {
            if (txt_s_qty.Text != "")
            {
                int uprice = Convert.ToInt32(txt_unitprice.Text);
                int qty = Convert.ToInt32(txt_s_qty.Text);
                txt_totalprice.Text = Convert.ToString(uprice * qty);
            }
            else
            {
                txt_totalprice.Text = txt_unitprice.Text;

            }

        }

      
    }
}
