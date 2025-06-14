namespace ApexAutos
{
    partial class Sales_Purchase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sales_Purchase));
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnRemoveSale = new System.Windows.Forms.Button();
            this.btnEditSale = new System.Windows.Forms.Button();
            this.btnAddSale = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridViewSP = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbViewType = new System.Windows.Forms.ComboBox();
            this.btnRemovePurchase = new System.Windows.Forms.Button();
            this.btnEditPurchase = new System.Windows.Forms.Button();
            this.btnAddPurchase = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSP)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRefresh.Location = new System.Drawing.Point(726, 575);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(176, 59);
            this.btnRefresh.TabIndex = 26;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnRemoveSale
            // 
            this.btnRemoveSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnRemoveSale.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemoveSale.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.btnRemoveSale.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRemoveSale.Location = new System.Drawing.Point(509, 539);
            this.btnRemoveSale.Name = "btnRemoveSale";
            this.btnRemoveSale.Size = new System.Drawing.Size(185, 59);
            this.btnRemoveSale.TabIndex = 25;
            this.btnRemoveSale.Text = "Remove Sale";
            this.btnRemoveSale.UseVisualStyleBackColor = false;
            this.btnRemoveSale.Click += new System.EventHandler(this.btnRemoveSale_Click);
            // 
            // btnEditSale
            // 
            this.btnEditSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnEditSale.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditSale.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.btnEditSale.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEditSale.Location = new System.Drawing.Point(293, 539);
            this.btnEditSale.Name = "btnEditSale";
            this.btnEditSale.Size = new System.Drawing.Size(185, 59);
            this.btnEditSale.TabIndex = 24;
            this.btnEditSale.Text = "Edit Sales";
            this.btnEditSale.UseVisualStyleBackColor = false;
            this.btnEditSale.Click += new System.EventHandler(this.btnEditSale_Click);
            // 
            // btnAddSale
            // 
            this.btnAddSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnAddSale.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddSale.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.btnAddSale.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddSale.Location = new System.Drawing.Point(78, 539);
            this.btnAddSale.Name = "btnAddSale";
            this.btnAddSale.Size = new System.Drawing.Size(185, 59);
            this.btnAddSale.TabIndex = 23;
            this.btnAddSale.Text = "Add Sale";
            this.btnAddSale.UseVisualStyleBackColor = false;
            this.btnAddSale.Click += new System.EventHandler(this.btnAddSale_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox1.Font = new System.Drawing.Font("Britannic Bold", 30F);
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.textBox1.Location = new System.Drawing.Point(27, 57);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(925, 67);
            this.textBox1.TabIndex = 22;
            this.textBox1.Text = "Apex Autos - Sales & Purchase";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataGridViewSP
            // 
            this.dataGridViewSP.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.dataGridViewSP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewSP.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridViewSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSP.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewSP.Location = new System.Drawing.Point(78, 216);
            this.dataGridViewSP.Name = "dataGridViewSP";
            this.dataGridViewSP.RowHeadersWidth = 62;
            this.dataGridViewSP.RowTemplate.Height = 28;
            this.dataGridViewSP.Size = new System.Drawing.Size(824, 302);
            this.dataGridViewSP.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(206, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 28);
            this.label1.TabIndex = 28;
            this.label1.Text = "Select an Option:";
            // 
            // cmbViewType
            // 
            this.cmbViewType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbViewType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.cmbViewType.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15F);
            this.cmbViewType.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cmbViewType.FormattingEnabled = true;
            this.cmbViewType.Location = new System.Drawing.Point(415, 155);
            this.cmbViewType.Name = "cmbViewType";
            this.cmbViewType.Size = new System.Drawing.Size(356, 42);
            this.cmbViewType.TabIndex = 27;
            // 
            // btnRemovePurchase
            // 
            this.btnRemovePurchase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnRemovePurchase.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemovePurchase.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.btnRemovePurchase.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRemovePurchase.Location = new System.Drawing.Point(509, 604);
            this.btnRemovePurchase.Name = "btnRemovePurchase";
            this.btnRemovePurchase.Size = new System.Drawing.Size(185, 59);
            this.btnRemovePurchase.TabIndex = 31;
            this.btnRemovePurchase.Text = "Remove Purchase";
            this.btnRemovePurchase.UseVisualStyleBackColor = false;
            this.btnRemovePurchase.Click += new System.EventHandler(this.btnRemovePurchase_Click);
            // 
            // btnEditPurchase
            // 
            this.btnEditPurchase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnEditPurchase.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditPurchase.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.btnEditPurchase.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEditPurchase.Location = new System.Drawing.Point(293, 604);
            this.btnEditPurchase.Name = "btnEditPurchase";
            this.btnEditPurchase.Size = new System.Drawing.Size(185, 59);
            this.btnEditPurchase.TabIndex = 30;
            this.btnEditPurchase.Text = "Edit Purchase";
            this.btnEditPurchase.UseVisualStyleBackColor = false;
            this.btnEditPurchase.Click += new System.EventHandler(this.btnEditPurchase_Click);
            // 
            // btnAddPurchase
            // 
            this.btnAddPurchase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnAddPurchase.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddPurchase.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.btnAddPurchase.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddPurchase.Location = new System.Drawing.Point(78, 604);
            this.btnAddPurchase.Name = "btnAddPurchase";
            this.btnAddPurchase.Size = new System.Drawing.Size(185, 59);
            this.btnAddPurchase.TabIndex = 29;
            this.btnAddPurchase.Text = "Add Purchase";
            this.btnAddPurchase.UseVisualStyleBackColor = false;
            this.btnAddPurchase.Click += new System.EventHandler(this.btnAddPurchase_Click);
            // 
            // Sales_Purchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(978, 694);
            this.Controls.Add(this.btnRemovePurchase);
            this.Controls.Add(this.btnEditPurchase);
            this.Controls.Add(this.btnAddPurchase);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbViewType);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnRemoveSale);
            this.Controls.Add(this.btnEditSale);
            this.Controls.Add(this.btnAddSale);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridViewSP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Sales_Purchase";
            this.Text = "Sales_Purchase";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnRemoveSale;
        private System.Windows.Forms.Button btnEditSale;
        private System.Windows.Forms.Button btnAddSale;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridViewSP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbViewType;
        private System.Windows.Forms.Button btnRemovePurchase;
        private System.Windows.Forms.Button btnEditPurchase;
        private System.Windows.Forms.Button btnAddPurchase;
    }
}