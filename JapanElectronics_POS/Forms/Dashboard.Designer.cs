
namespace JapanElectronics_POS.Forms
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.link_model = new System.Windows.Forms.LinkLabel();
            this.link_Cat = new System.Windows.Forms.LinkLabel();
            this.link_Campany = new System.Windows.Forms.LinkLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.link_add_qty = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.link_add_qty);
            this.panel1.Controls.Add(this.link_model);
            this.panel1.Controls.Add(this.link_Cat);
            this.panel1.Controls.Add(this.link_Campany);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(264, 450);
            this.panel1.TabIndex = 0;
            // 
            // link_model
            // 
            this.link_model.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.link_model.DisabledLinkColor = System.Drawing.Color.LightGray;
            this.link_model.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link_model.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.link_model.LinkColor = System.Drawing.Color.Black;
            this.link_model.Location = new System.Drawing.Point(37, 133);
            this.link_model.Name = "link_model";
            this.link_model.Size = new System.Drawing.Size(199, 34);
            this.link_model.TabIndex = 3;
            this.link_model.TabStop = true;
            this.link_model.Text = "Models";
            this.link_model.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_model_LinkClicked);
            // 
            // link_Cat
            // 
            this.link_Cat.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.link_Cat.DisabledLinkColor = System.Drawing.Color.LightGray;
            this.link_Cat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link_Cat.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.link_Cat.LinkColor = System.Drawing.Color.Black;
            this.link_Cat.Location = new System.Drawing.Point(37, 76);
            this.link_Cat.Name = "link_Cat";
            this.link_Cat.Size = new System.Drawing.Size(199, 34);
            this.link_Cat.TabIndex = 2;
            this.link_Cat.TabStop = true;
            this.link_Cat.Text = "Categories";
            this.link_Cat.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_Cat_LinkClicked);
            // 
            // link_Campany
            // 
            this.link_Campany.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.link_Campany.DisabledLinkColor = System.Drawing.Color.LightGray;
            this.link_Campany.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link_Campany.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.link_Campany.LinkColor = System.Drawing.Color.Black;
            this.link_Campany.Location = new System.Drawing.Point(37, 21);
            this.link_Campany.Name = "link_Campany";
            this.link_Campany.Size = new System.Drawing.Size(149, 34);
            this.link_Campany.TabIndex = 1;
            this.link_Campany.TabStop = true;
            this.link_Campany.Text = "Companies";
            this.link_Campany.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_Campany_LinkClicked);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(264, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(536, 450);
            this.panel2.TabIndex = 0;
            // 
            // link_add_qty
            // 
            this.link_add_qty.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.link_add_qty.DisabledLinkColor = System.Drawing.Color.LightGray;
            this.link_add_qty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link_add_qty.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.link_add_qty.LinkColor = System.Drawing.Color.Black;
            this.link_add_qty.Location = new System.Drawing.Point(26, 176);
            this.link_add_qty.Name = "link_add_qty";
            this.link_add_qty.Size = new System.Drawing.Size(199, 34);
            this.link_add_qty.TabIndex = 4;
            this.link_add_qty.TabStop = true;
            this.link_add_qty.Text = "Add Quantity";
            this.link_add_qty.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_add_qty_LinkClicked);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dashboard_FormClosing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel link_Cat;
        private System.Windows.Forms.LinkLabel link_Campany;
        private System.Windows.Forms.LinkLabel link_model;
        private System.Windows.Forms.LinkLabel link_add_qty;
    }
}