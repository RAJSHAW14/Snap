namespace Snap.CMC
{
    partial class cmc_production_list
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.order_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batch_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.designer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.order_receive_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.design_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.design_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.design_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.machine_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.component = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fab_qty_details = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fabric = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.start_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.start_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.end_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.end_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.non_working_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.non_w_remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actual_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.per_hr_rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1683, 821);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.order_number,
            this.batch_code,
            this.department,
            this.designer,
            this.order_receive_date,
            this.design_code,
            this.design_description,
            this.design_type,
            this.machine_type,
            this.component,
            this.fab_qty_details,
            this.fabric,
            this.color,
            this.start_date,
            this.start_time,
            this.end_date,
            this.end_time,
            this.total_time,
            this.non_working_time,
            this.non_w_remarks,
            this.actual_time,
            this.per_hr_rate,
            this.cost});
            this.dataGridView1.Location = new System.Drawing.Point(3, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1668, 761);
            this.dataGridView1.TabIndex = 0;
            // 
            // id
            // 
            this.id.Frozen = true;
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // order_number
            // 
            this.order_number.Frozen = true;
            this.order_number.HeaderText = "ORDER NUMBER";
            this.order_number.Name = "order_number";
            this.order_number.ReadOnly = true;
            this.order_number.Width = 200;
            // 
            // batch_code
            // 
            this.batch_code.HeaderText = "BATCHCODE";
            this.batch_code.Name = "batch_code";
            this.batch_code.ReadOnly = true;
            this.batch_code.Width = 200;
            // 
            // department
            // 
            this.department.HeaderText = "DEPARTMENT";
            this.department.Name = "department";
            this.department.ReadOnly = true;
            this.department.Width = 200;
            // 
            // designer
            // 
            this.designer.HeaderText = "DESIGNER";
            this.designer.Name = "designer";
            this.designer.ReadOnly = true;
            this.designer.Width = 150;
            // 
            // order_receive_date
            // 
            this.order_receive_date.HeaderText = "RECEIVE DATE";
            this.order_receive_date.Name = "order_receive_date";
            this.order_receive_date.ReadOnly = true;
            this.order_receive_date.Width = 150;
            // 
            // design_code
            // 
            this.design_code.HeaderText = "DESIGN CODE";
            this.design_code.Name = "design_code";
            this.design_code.ReadOnly = true;
            this.design_code.Width = 150;
            // 
            // design_description
            // 
            this.design_description.HeaderText = "DESIGN DESCRIPTION";
            this.design_description.Name = "design_description";
            this.design_description.ReadOnly = true;
            this.design_description.Width = 250;
            // 
            // design_type
            // 
            this.design_type.HeaderText = "DESIGN TYPE";
            this.design_type.Name = "design_type";
            this.design_type.ReadOnly = true;
            this.design_type.Width = 150;
            // 
            // machine_type
            // 
            this.machine_type.HeaderText = "MACHINE TYPE";
            this.machine_type.Name = "machine_type";
            this.machine_type.ReadOnly = true;
            this.machine_type.Width = 150;
            // 
            // component
            // 
            this.component.HeaderText = "COMPONENT";
            this.component.Name = "component";
            this.component.ReadOnly = true;
            this.component.Width = 200;
            // 
            // fab_qty_details
            // 
            this.fab_qty_details.HeaderText = "FAB QTY DESIGN";
            this.fab_qty_details.Name = "fab_qty_details";
            this.fab_qty_details.ReadOnly = true;
            this.fab_qty_details.Width = 200;
            // 
            // fabric
            // 
            this.fabric.HeaderText = "FABRIC";
            this.fabric.Name = "fabric";
            this.fabric.ReadOnly = true;
            this.fabric.Width = 200;
            // 
            // color
            // 
            this.color.HeaderText = "COLOR";
            this.color.Name = "color";
            this.color.ReadOnly = true;
            this.color.Width = 150;
            // 
            // start_date
            // 
            this.start_date.HeaderText = "START DATE";
            this.start_date.Name = "start_date";
            this.start_date.ReadOnly = true;
            this.start_date.Width = 150;
            // 
            // start_time
            // 
            this.start_time.HeaderText = "START TIME";
            this.start_time.Name = "start_time";
            this.start_time.ReadOnly = true;
            this.start_time.Width = 150;
            // 
            // end_date
            // 
            this.end_date.HeaderText = "END DATE";
            this.end_date.Name = "end_date";
            this.end_date.ReadOnly = true;
            this.end_date.Width = 150;
            // 
            // end_time
            // 
            this.end_time.HeaderText = "END TIME";
            this.end_time.Name = "end_time";
            this.end_time.ReadOnly = true;
            this.end_time.Width = 150;
            // 
            // total_time
            // 
            this.total_time.HeaderText = "TOTAL TIME";
            this.total_time.Name = "total_time";
            this.total_time.ReadOnly = true;
            this.total_time.Width = 150;
            // 
            // non_working_time
            // 
            this.non_working_time.HeaderText = "NON-WORKING TIME";
            this.non_working_time.Name = "non_working_time";
            this.non_working_time.ReadOnly = true;
            this.non_working_time.Width = 150;
            // 
            // non_w_remarks
            // 
            this.non_w_remarks.HeaderText = "NON-WORK REMARKS";
            this.non_w_remarks.Name = "non_w_remarks";
            this.non_w_remarks.ReadOnly = true;
            this.non_w_remarks.Width = 250;
            // 
            // actual_time
            // 
            this.actual_time.HeaderText = "ACTUAL TIME (HRs)";
            this.actual_time.Name = "actual_time";
            this.actual_time.ReadOnly = true;
            this.actual_time.Width = 150;
            // 
            // per_hr_rate
            // 
            this.per_hr_rate.HeaderText = "PER HR RATE";
            this.per_hr_rate.Name = "per_hr_rate";
            this.per_hr_rate.ReadOnly = true;
            this.per_hr_rate.Width = 150;
            // 
            // cost
            // 
            this.cost.HeaderText = "COST";
            this.cost.Name = "cost";
            this.cost.ReadOnly = true;
            this.cost.Width = 150;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "ORDER NUMBER",
            "DESIGN NUMBER",
            "DESIGN DESCRIPTION",
            "DESIGN TYPE",
            "MACHINE TYPE",
            "BATCHCODE",
            "DEPARTMENT"});
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(323, 30);
            this.comboBox1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(360, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(355, 29);
            this.textBox1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(721, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 29);
            this.button1.TabIndex = 3;
            this.button1.Text = "SEARCH";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmc_production_list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1683, 821);
            this.Controls.Add(this.panel1);
            this.Name = "cmc_production_list";
            this.Text = "CMC PRODUCTION TIME";
            this.Load += new System.EventHandler(this.cmc_production_list_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn order_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn batch_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn department;
        private System.Windows.Forms.DataGridViewTextBoxColumn designer;
        private System.Windows.Forms.DataGridViewTextBoxColumn order_receive_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn design_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn design_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn design_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn machine_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn component;
        private System.Windows.Forms.DataGridViewTextBoxColumn fab_qty_details;
        private System.Windows.Forms.DataGridViewTextBoxColumn fabric;
        private System.Windows.Forms.DataGridViewTextBoxColumn color;
        private System.Windows.Forms.DataGridViewTextBoxColumn start_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn start_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn end_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn end_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn non_working_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn non_w_remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn actual_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn per_hr_rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
    }
}