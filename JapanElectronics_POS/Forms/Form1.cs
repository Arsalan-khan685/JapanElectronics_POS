using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JapanElectronics_POS.Forms
{
    public partial class Form1 : Form
    {
        Dashboard dashboard;
        Category category;
        Company company;
        Models models;
        AddQuantity addQuantity;
        SalesForm salesForm;
        public Form1()
        {
            InitializeComponent();
        }    
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            if(dashboard == null)
            {
                dashboard = new Dashboard();
                dashboard.FormClosed += Dashboard_FormClosed;
                dashboard.MdiParent = this;
                dashboard.Dock = DockStyle.Fill;
                dashboard.Show();
            }
            else
            {
                dashboard.Activate();
               
            }
            ResetButtonColors();

            // Change color for the clicked button
            btn_dashboard.BackColor = Color.Green;
        }
        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            dashboard = null;
        }
        private void btn_companies_Click(object sender, EventArgs e)
        {
            if(company == null)
            {
                company = new Company();
                company.FormClosed += Company_FormClosed;
                company.MdiParent = this;
                company.Dock = DockStyle.Fill;
                company.Show();
            }
            else
            {
                company.Activate();
            }
            ResetButtonColors();

            // Change color for the clicked button
            btn_companies.BackColor = Color.Green;
        }
        private void Company_FormClosed(object sender, FormClosedEventArgs e)
        {
            company = null;
        }
        private void btn_categories_Click(object sender, EventArgs e)
        {
            if (category == null)
            {
                category = new Category();
                category.FormClosed += Category_FormClosed;
                category.MdiParent = this;
                category.Dock = DockStyle.Fill;
                category.Show();
            }
            else
            {
                category.Activate();
            }
            ResetButtonColors();

            // Change color for the clicked button
            btn_categories.BackColor = Color.Green;
        }
        private void Category_FormClosed(object sender, FormClosedEventArgs e)
        {
            category = null;
        }
        private void btn_models_Click(object sender, EventArgs e)
        {
            if (models == null)
            {
                models = new Models();
                models.FormClosed += Models_FormClosed; 
                models.MdiParent = this;
                models.Dock = DockStyle.Fill;
                models.Show();
            }
            else
            {
                models.Activate();
            }
            ResetButtonColors();

            // Change color for the clicked button
            btn_models.BackColor = Color.Green;
        }
        private void Models_FormClosed(object sender, FormClosedEventArgs e)
        {
            models = null;
        }
        private void btn_add_qty_Click(object sender, EventArgs e)
        {
            if (addQuantity == null)
            {
                addQuantity = new AddQuantity();
                addQuantity.FormClosed += AddQuantity_FormClosed; 
                addQuantity.MdiParent = this;
                addQuantity.Dock = DockStyle.Fill;
                addQuantity.Show();
            }
            else
            {
                addQuantity.Activate();
            }
            ResetButtonColors();

            // Change color for the clicked button
            btn_add_qty.BackColor = Color.Green;
        }
        private void AddQuantity_FormClosed(object sender, FormClosedEventArgs e)
        {
            addQuantity = null;
        }
        private void btn_sales_form_Click(object sender, EventArgs e)
        {
            if (salesForm == null)
            {
                salesForm = new SalesForm();
                salesForm.FormClosed += SalesForm_FormClosed; 
                salesForm.MdiParent = this;
                salesForm.Dock = DockStyle.Fill;
                salesForm.Show();
            }
            else
            {
                salesForm.Activate();
            }
            ResetButtonColors();

            // Change color for the clicked button
            btn_sales_form.BackColor = Color.Green;
        }
        private void SalesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            salesForm = null;
        }
        private void ResetButtonColors()
        {
            // Reset color for all buttons
            btn_dashboard.BackColor = Color.FromArgb(23, 24, 29); // Change this to the default color
            btn_companies.BackColor = Color.FromArgb(23, 24, 29); // Change this to the default color
            btn_categories.BackColor = Color.FromArgb(23, 24, 29); // Change this to the default color
            btn_models.BackColor = Color.FromArgb(23, 24, 29); // Change this to the default color
            btn_add_qty.BackColor = Color.FromArgb(23, 24, 29); // Change this to the default color
            btn_sales_form.BackColor = Color.FromArgb(23, 24, 29); // Change this to the default color
        }

    }
}
