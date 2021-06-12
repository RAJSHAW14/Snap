namespace Snap.fabric
{
    partial class fabric_stock_summery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fabric_stock_summery));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.fabric_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.in_qc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.approved = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cutting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rejected = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RETURN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fabric_code,
            this.receive,
            this.in_qc,
            this.approved,
            this.cutting,
            this.rejected,
            this.total,
            this.RETURN});
            this.dataGridView1.Location = new System.Drawing.Point(6, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(956, 585);
            this.dataGridView1.TabIndex = 0;
            // 
            // fabric_code
            // 
            this.fabric_code.HeaderText = "FABRIC CODE";
            this.fabric_code.Name = "fabric_code";
            this.fabric_code.ReadOnly = true;
            this.fabric_code.Width = 200;
            // 
            // receive
            // 
            this.receive.HeaderText = "RECEIVE";
            this.receive.Name = "receive";
            this.receive.ReadOnly = true;
            // 
            // in_qc
            // 
            this.in_qc.HeaderText = "IN QC";
            this.in_qc.Name = "in_qc";
            this.in_qc.ReadOnly = true;
            // 
            // approved
            // 
            this.approved.HeaderText = "APPROVED";
            this.approved.Name = "approved";
            this.approved.ReadOnly = true;
            // 
            // cutting
            // 
            this.cutting.HeaderText = "CUTTING";
            this.cutting.Name = "cutting";
            this.cutting.ReadOnly = true;
            // 
            // rejected
            // 
            this.rejected.HeaderText = "REJECTED";
            this.rejected.Name = "rejected";
            this.rejected.ReadOnly = true;
            // 
            // total
            // 
            this.total.HeaderText = "TOTAL";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            // 
            // RETURN
            // 
            this.RETURN.HeaderText = "RETURN";
            this.RETURN.Name = "RETURN";
            this.RETURN.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(972, 634);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "FABRIC CODE";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(127, 9);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(298, 26);
            this.textBox1.TabIndex = 7;
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // fabric_stock_summery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 634);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fabric_stock_summery";
            this.Text = "FABRIC STOCK SUMMERY";
            this.Load += new System.EventHandler(this.fabric_stock_summery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fabric_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn receive;
        private System.Windows.Forms.DataGridViewTextBoxColumn in_qc;
        private System.Windows.Forms.DataGridViewTextBoxColumn approved;
        private System.Windows.Forms.DataGridViewTextBoxColumn cutting;
        private System.Windows.Forms.DataGridViewTextBoxColumn rejected;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn RETURN;
        private System.Windows.Forms.Label label1;
    }
}