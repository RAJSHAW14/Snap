namespace Snap
{
    partial class product_status_view
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(product_status_view));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Component = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.designer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.starting_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fabric_receive_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actual_receive_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fabric_remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dye_receive_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actual_dye_receive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dye_remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dye_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.print_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actual_print_receive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.print_remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.print_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.over_dye_receive_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actual_overdye_recevei = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.overdye_remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.over_dye_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmc_machine_receive_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actual_cmc_machine_receive_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmc_remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmc_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.highlight_req_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actual_highlight_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.highlight_remaks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.highlight_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stitiching_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actual_stitching = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ststiching_remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stitiching_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.maskedTextBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1692, 801);
            this.panel1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(878, 15);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(180, 34);
            this.button2.TabIndex = 7;
            this.button2.Text = "SEARCH";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "FABRIC",
            "DYE",
            "PRINT",
            "OVER DYE",
            "CMC",
            "HIGHLIGHT",
            "STITICHING"});
            this.comboBox1.Location = new System.Drawing.Point(686, 15);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(183, 28);
            this.comboBox1.TabIndex = 6;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(571, 15);
            this.maskedTextBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.maskedTextBox1.Mask = "00-00-0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(94, 26);
            this.maskedTextBox1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(492, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "DATE";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(1491, 10);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 39);
            this.button1.TabIndex = 3;
            this.button1.Text = "REFRESH";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Product Code";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(155, 15);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(329, 26);
            this.textBox1.TabIndex = 1;
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.PaleGoldenrod;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.product_code,
            this.Component,
            this.designer,
            this.starting_date,
            this.fabric_receive_date,
            this.actual_receive_date,
            this.fabric_remarks,
            this.status,
            this.dye_receive_date,
            this.actual_dye_receive,
            this.dye_remarks,
            this.dye_status,
            this.print_date,
            this.actual_print_receive,
            this.print_remarks,
            this.print_status,
            this.over_dye_receive_date,
            this.actual_overdye_recevei,
            this.overdye_remarks,
            this.over_dye_status,
            this.cmc_machine_receive_date,
            this.actual_cmc_machine_receive_date,
            this.cmc_remarks,
            this.cmc_status,
            this.highlight_req_date,
            this.actual_highlight_date,
            this.highlight_remaks,
            this.highlight_status,
            this.stitiching_date,
            this.actual_stitching,
            this.ststiching_remarks,
            this.stitiching_status});
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleGoldenrod;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.SaddleBrown;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(2, 55);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1690, 746);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 125;
            // 
            // product_code
            // 
            this.product_code.HeaderText = "Product Code";
            this.product_code.MinimumWidth = 6;
            this.product_code.Name = "product_code";
            this.product_code.ReadOnly = true;
            this.product_code.Width = 180;
            // 
            // Component
            // 
            this.Component.HeaderText = "Component";
            this.Component.MinimumWidth = 6;
            this.Component.Name = "Component";
            this.Component.ReadOnly = true;
            this.Component.Width = 150;
            // 
            // designer
            // 
            this.designer.HeaderText = "Designer";
            this.designer.MinimumWidth = 6;
            this.designer.Name = "designer";
            this.designer.ReadOnly = true;
            this.designer.Width = 120;
            // 
            // starting_date
            // 
            this.starting_date.HeaderText = "Starting Date";
            this.starting_date.MinimumWidth = 6;
            this.starting_date.Name = "starting_date";
            this.starting_date.ReadOnly = true;
            this.starting_date.Width = 125;
            // 
            // fabric_receive_date
            // 
            this.fabric_receive_date.HeaderText = "Fabric Req Date";
            this.fabric_receive_date.MinimumWidth = 6;
            this.fabric_receive_date.Name = "fabric_receive_date";
            this.fabric_receive_date.ReadOnly = true;
            this.fabric_receive_date.Width = 125;
            // 
            // actual_receive_date
            // 
            this.actual_receive_date.HeaderText = "Actual Fabric Request";
            this.actual_receive_date.MinimumWidth = 6;
            this.actual_receive_date.Name = "actual_receive_date";
            this.actual_receive_date.ReadOnly = true;
            this.actual_receive_date.Width = 125;
            // 
            // fabric_remarks
            // 
            this.fabric_remarks.HeaderText = "Fabric Remarks";
            this.fabric_remarks.MinimumWidth = 6;
            this.fabric_remarks.Name = "fabric_remarks";
            this.fabric_remarks.ReadOnly = true;
            this.fabric_remarks.Width = 125;
            // 
            // status
            // 
            this.status.HeaderText = "Fabric Status";
            this.status.MinimumWidth = 6;
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 125;
            // 
            // dye_receive_date
            // 
            this.dye_receive_date.HeaderText = "Dye Req Date";
            this.dye_receive_date.MinimumWidth = 6;
            this.dye_receive_date.Name = "dye_receive_date";
            this.dye_receive_date.ReadOnly = true;
            this.dye_receive_date.Width = 125;
            // 
            // actual_dye_receive
            // 
            this.actual_dye_receive.HeaderText = "Actual Dye Request";
            this.actual_dye_receive.MinimumWidth = 6;
            this.actual_dye_receive.Name = "actual_dye_receive";
            this.actual_dye_receive.ReadOnly = true;
            this.actual_dye_receive.Width = 125;
            // 
            // dye_remarks
            // 
            this.dye_remarks.HeaderText = "Dye Remarks";
            this.dye_remarks.MinimumWidth = 6;
            this.dye_remarks.Name = "dye_remarks";
            this.dye_remarks.ReadOnly = true;
            this.dye_remarks.Width = 125;
            // 
            // dye_status
            // 
            this.dye_status.HeaderText = "Dye Status";
            this.dye_status.MinimumWidth = 6;
            this.dye_status.Name = "dye_status";
            this.dye_status.ReadOnly = true;
            this.dye_status.Width = 125;
            // 
            // print_date
            // 
            this.print_date.HeaderText = "Print Req Date";
            this.print_date.MinimumWidth = 6;
            this.print_date.Name = "print_date";
            this.print_date.ReadOnly = true;
            this.print_date.Width = 125;
            // 
            // actual_print_receive
            // 
            this.actual_print_receive.HeaderText = "Actual Print Request";
            this.actual_print_receive.MinimumWidth = 6;
            this.actual_print_receive.Name = "actual_print_receive";
            this.actual_print_receive.ReadOnly = true;
            this.actual_print_receive.Width = 125;
            // 
            // print_remarks
            // 
            this.print_remarks.HeaderText = "Print Remarks";
            this.print_remarks.MinimumWidth = 6;
            this.print_remarks.Name = "print_remarks";
            this.print_remarks.ReadOnly = true;
            this.print_remarks.Width = 125;
            // 
            // print_status
            // 
            this.print_status.HeaderText = "Print Status";
            this.print_status.MinimumWidth = 6;
            this.print_status.Name = "print_status";
            this.print_status.ReadOnly = true;
            this.print_status.Width = 125;
            // 
            // over_dye_receive_date
            // 
            this.over_dye_receive_date.HeaderText = "Over-Dye Req Date";
            this.over_dye_receive_date.MinimumWidth = 6;
            this.over_dye_receive_date.Name = "over_dye_receive_date";
            this.over_dye_receive_date.ReadOnly = true;
            this.over_dye_receive_date.Width = 125;
            // 
            // actual_overdye_recevei
            // 
            this.actual_overdye_recevei.HeaderText = "Actual Over-Dye Request";
            this.actual_overdye_recevei.MinimumWidth = 6;
            this.actual_overdye_recevei.Name = "actual_overdye_recevei";
            this.actual_overdye_recevei.ReadOnly = true;
            this.actual_overdye_recevei.Width = 125;
            // 
            // overdye_remarks
            // 
            this.overdye_remarks.HeaderText = "Over Dye Remaks";
            this.overdye_remarks.MinimumWidth = 6;
            this.overdye_remarks.Name = "overdye_remarks";
            this.overdye_remarks.ReadOnly = true;
            this.overdye_remarks.Width = 125;
            // 
            // over_dye_status
            // 
            this.over_dye_status.HeaderText = "Over Dye Status";
            this.over_dye_status.MinimumWidth = 6;
            this.over_dye_status.Name = "over_dye_status";
            this.over_dye_status.ReadOnly = true;
            this.over_dye_status.Width = 125;
            // 
            // cmc_machine_receive_date
            // 
            this.cmc_machine_receive_date.HeaderText = "CMC / Machine Req Date";
            this.cmc_machine_receive_date.MinimumWidth = 6;
            this.cmc_machine_receive_date.Name = "cmc_machine_receive_date";
            this.cmc_machine_receive_date.ReadOnly = true;
            this.cmc_machine_receive_date.Width = 125;
            // 
            // actual_cmc_machine_receive_date
            // 
            this.actual_cmc_machine_receive_date.HeaderText = "Actual CMC/ Machine Request Date";
            this.actual_cmc_machine_receive_date.MinimumWidth = 6;
            this.actual_cmc_machine_receive_date.Name = "actual_cmc_machine_receive_date";
            this.actual_cmc_machine_receive_date.ReadOnly = true;
            this.actual_cmc_machine_receive_date.Width = 125;
            // 
            // cmc_remarks
            // 
            this.cmc_remarks.HeaderText = "CMC / Machine Remarks";
            this.cmc_remarks.MinimumWidth = 6;
            this.cmc_remarks.Name = "cmc_remarks";
            this.cmc_remarks.ReadOnly = true;
            this.cmc_remarks.Width = 125;
            // 
            // cmc_status
            // 
            this.cmc_status.HeaderText = "CMC / Machine Status";
            this.cmc_status.MinimumWidth = 6;
            this.cmc_status.Name = "cmc_status";
            this.cmc_status.ReadOnly = true;
            this.cmc_status.Width = 125;
            // 
            // highlight_req_date
            // 
            this.highlight_req_date.HeaderText = "Highlight Req Date";
            this.highlight_req_date.MinimumWidth = 6;
            this.highlight_req_date.Name = "highlight_req_date";
            this.highlight_req_date.ReadOnly = true;
            this.highlight_req_date.Width = 125;
            // 
            // actual_highlight_date
            // 
            this.actual_highlight_date.HeaderText = "Actual Highlight Request";
            this.actual_highlight_date.MinimumWidth = 6;
            this.actual_highlight_date.Name = "actual_highlight_date";
            this.actual_highlight_date.ReadOnly = true;
            this.actual_highlight_date.Width = 125;
            // 
            // highlight_remaks
            // 
            this.highlight_remaks.HeaderText = "Highlight Remarks";
            this.highlight_remaks.MinimumWidth = 6;
            this.highlight_remaks.Name = "highlight_remaks";
            this.highlight_remaks.ReadOnly = true;
            this.highlight_remaks.Width = 125;
            // 
            // highlight_status
            // 
            this.highlight_status.HeaderText = "Highlight Status";
            this.highlight_status.MinimumWidth = 6;
            this.highlight_status.Name = "highlight_status";
            this.highlight_status.ReadOnly = true;
            this.highlight_status.Width = 125;
            // 
            // stitiching_date
            // 
            this.stitiching_date.HeaderText = "Stitiching Req date";
            this.stitiching_date.MinimumWidth = 6;
            this.stitiching_date.Name = "stitiching_date";
            this.stitiching_date.ReadOnly = true;
            this.stitiching_date.Width = 125;
            // 
            // actual_stitching
            // 
            this.actual_stitching.HeaderText = "Actual Stitiching Request";
            this.actual_stitching.MinimumWidth = 6;
            this.actual_stitching.Name = "actual_stitching";
            this.actual_stitching.ReadOnly = true;
            this.actual_stitching.Width = 125;
            // 
            // ststiching_remarks
            // 
            this.ststiching_remarks.HeaderText = "Stitiching Remarks";
            this.ststiching_remarks.MinimumWidth = 6;
            this.ststiching_remarks.Name = "ststiching_remarks";
            this.ststiching_remarks.ReadOnly = true;
            this.ststiching_remarks.Width = 125;
            // 
            // stitiching_status
            // 
            this.stitiching_status.HeaderText = "Stitiching Status";
            this.stitiching_status.MinimumWidth = 6;
            this.stitiching_status.Name = "stitiching_status";
            this.stitiching_status.ReadOnly = true;
            this.stitiching_status.Width = 125;
            // 
            // product_status_view
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1692, 801);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "product_status_view";
            this.Text = "Product Code Status";
            this.Load += new System.EventHandler(this.product_status_view_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Component;
        private System.Windows.Forms.DataGridViewTextBoxColumn designer;
        private System.Windows.Forms.DataGridViewTextBoxColumn starting_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn fabric_receive_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn actual_receive_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn fabric_remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn dye_receive_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn actual_dye_receive;
        private System.Windows.Forms.DataGridViewTextBoxColumn dye_remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn dye_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn print_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn actual_print_receive;
        private System.Windows.Forms.DataGridViewTextBoxColumn print_remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn print_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn over_dye_receive_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn actual_overdye_recevei;
        private System.Windows.Forms.DataGridViewTextBoxColumn overdye_remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn over_dye_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmc_machine_receive_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn actual_cmc_machine_receive_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmc_remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmc_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn highlight_req_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn actual_highlight_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn highlight_remaks;
        private System.Windows.Forms.DataGridViewTextBoxColumn highlight_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn stitiching_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn actual_stitching;
        private System.Windows.Forms.DataGridViewTextBoxColumn ststiching_remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn stitiching_status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
    }
}