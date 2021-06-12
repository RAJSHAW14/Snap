namespace Snap.CMC
{
    partial class design_master_list
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(design_master_list));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.design_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.design_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.machine_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.design_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stitiches = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colors = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appx_mc_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emb_cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.digital = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1236, 604);
            this.panel1.TabIndex = 0;
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(1145, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(88, 36);
            this.button5.TabIndex = 7;
            this.button5.Text = "SEARCH";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(927, 9);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(213, 26);
            this.textBox1.TabIndex = 6;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "",
            "DESIGN CODE",
            "DESIGN TYPE",
            "MACHINE TYPE",
            "DESIGN DESCRIPTION"});
            this.comboBox1.Location = new System.Drawing.Point(725, 9);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(198, 26);
            this.comboBox1.TabIndex = 5;
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(286, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(91, 36);
            this.button4.TabIndex = 4;
            this.button4.Text = "REFRESH";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(191, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 36);
            this.button3.TabIndex = 3;
            this.button3.Text = "DELETE";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(97, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 36);
            this.button2.TabIndex = 2;
            this.button2.Text = "EDIT";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 36);
            this.button1.TabIndex = 1;
            this.button1.Text = "ADD NEW";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.design_code,
            this.design_type,
            this.machine_type,
            this.design_description,
            this.stitiches,
            this.colors,
            this.appx_mc_time,
            this.uom,
            this.emb_cost,
            this.digital,
            this.remarks});
            this.dataGridView1.Location = new System.Drawing.Point(1, 45);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1230, 550);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // design_code
            // 
            this.design_code.HeaderText = "Design code";
            this.design_code.Name = "design_code";
            this.design_code.ReadOnly = true;
            this.design_code.Width = 120;
            // 
            // design_type
            // 
            this.design_type.HeaderText = "Design Type";
            this.design_type.Name = "design_type";
            this.design_type.ReadOnly = true;
            this.design_type.Width = 120;
            // 
            // machine_type
            // 
            this.machine_type.HeaderText = "Machine Type";
            this.machine_type.Name = "machine_type";
            this.machine_type.ReadOnly = true;
            this.machine_type.Width = 120;
            // 
            // design_description
            // 
            this.design_description.HeaderText = "Design Description";
            this.design_description.Name = "design_description";
            this.design_description.ReadOnly = true;
            this.design_description.Width = 250;
            // 
            // stitiches
            // 
            this.stitiches.HeaderText = "Stitiches";
            this.stitiches.Name = "stitiches";
            this.stitiches.ReadOnly = true;
            // 
            // colors
            // 
            this.colors.HeaderText = "Colors";
            this.colors.Name = "colors";
            this.colors.ReadOnly = true;
            // 
            // appx_mc_time
            // 
            this.appx_mc_time.HeaderText = "Appx MC Time";
            this.appx_mc_time.Name = "appx_mc_time";
            this.appx_mc_time.ReadOnly = true;
            // 
            // uom
            // 
            this.uom.HeaderText = "UoM";
            this.uom.Name = "uom";
            this.uom.ReadOnly = true;
            // 
            // emb_cost
            // 
            this.emb_cost.HeaderText = "Embroidery Cost";
            this.emb_cost.Name = "emb_cost";
            this.emb_cost.ReadOnly = true;
            // 
            // digital
            // 
            this.digital.HeaderText = "Digital";
            this.digital.Name = "digital";
            this.digital.ReadOnly = true;
            // 
            // remarks
            // 
            this.remarks.HeaderText = "Remarks";
            this.remarks.Name = "remarks";
            this.remarks.ReadOnly = true;
            this.remarks.Width = 200;
            // 
            // design_master_list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 604);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "design_master_list";
            this.Text = "DESIGN MASTER LIST";
            this.Load += new System.EventHandler(this.design_master_list_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn design_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn design_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn machine_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn design_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn stitiches;
        private System.Windows.Forms.DataGridViewTextBoxColumn colors;
        private System.Windows.Forms.DataGridViewTextBoxColumn appx_mc_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn uom;
        private System.Windows.Forms.DataGridViewTextBoxColumn emb_cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn digital;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
    }
}