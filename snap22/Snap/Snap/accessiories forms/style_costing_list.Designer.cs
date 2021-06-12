namespace Snap.accessiories_forms
{
    partial class style_costing_list
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(style_costing_list));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.style_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.style_color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mrp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hardware = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hand_emb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.machine_emb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fabrication = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.digital_print = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lining_quilting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leather = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fabric = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dye = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emb_mat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.other = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hardware_polish = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.overhead = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1210, 602);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.style_code,
            this.style_color,
            this.description,
            this.mrp,
            this.hardware,
            this.hand_emb,
            this.machine_emb,
            this.fabrication,
            this.digital_print,
            this.lining_quilting,
            this.leather,
            this.fabric,
            this.dye,
            this.emb_mat,
            this.other,
            this.hardware_polish,
            this.packing,
            this.overhead,
            this.total});
            this.dataGridView1.Location = new System.Drawing.Point(3, 47);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1196, 543);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // style_code
            // 
            this.style_code.HeaderText = "Style Code";
            this.style_code.Name = "style_code";
            this.style_code.ReadOnly = true;
            // 
            // style_color
            // 
            this.style_color.HeaderText = "Style Color";
            this.style_color.Name = "style_color";
            this.style_color.ReadOnly = true;
            // 
            // description
            // 
            this.description.HeaderText = "Description";
            this.description.Name = "description";
            this.description.ReadOnly = true;
            // 
            // mrp
            // 
            this.mrp.HeaderText = "MRP";
            this.mrp.Name = "mrp";
            this.mrp.ReadOnly = true;
            // 
            // hardware
            // 
            this.hardware.HeaderText = "Hardware";
            this.hardware.Name = "hardware";
            this.hardware.ReadOnly = true;
            // 
            // hand_emb
            // 
            this.hand_emb.HeaderText = "Hand EMB";
            this.hand_emb.Name = "hand_emb";
            this.hand_emb.ReadOnly = true;
            // 
            // machine_emb
            // 
            this.machine_emb.HeaderText = "Machine EMB";
            this.machine_emb.Name = "machine_emb";
            this.machine_emb.ReadOnly = true;
            // 
            // fabrication
            // 
            this.fabrication.HeaderText = "Fabrication";
            this.fabrication.Name = "fabrication";
            this.fabrication.ReadOnly = true;
            // 
            // digital_print
            // 
            this.digital_print.HeaderText = "Digital Print";
            this.digital_print.Name = "digital_print";
            this.digital_print.ReadOnly = true;
            // 
            // lining_quilting
            // 
            this.lining_quilting.HeaderText = "Lining Quilting";
            this.lining_quilting.Name = "lining_quilting";
            this.lining_quilting.ReadOnly = true;
            // 
            // leather
            // 
            this.leather.HeaderText = "Leather";
            this.leather.Name = "leather";
            this.leather.ReadOnly = true;
            // 
            // fabric
            // 
            this.fabric.HeaderText = "Fabric";
            this.fabric.Name = "fabric";
            this.fabric.ReadOnly = true;
            // 
            // dye
            // 
            this.dye.HeaderText = "Dye";
            this.dye.Name = "dye";
            this.dye.ReadOnly = true;
            // 
            // emb_mat
            // 
            this.emb_mat.HeaderText = "EMB Material";
            this.emb_mat.Name = "emb_mat";
            this.emb_mat.ReadOnly = true;
            // 
            // other
            // 
            this.other.HeaderText = "Others";
            this.other.Name = "other";
            this.other.ReadOnly = true;
            // 
            // hardware_polish
            // 
            this.hardware_polish.HeaderText = "Hardware Polish";
            this.hardware_polish.Name = "hardware_polish";
            this.hardware_polish.ReadOnly = true;
            // 
            // packing
            // 
            this.packing.HeaderText = "Packing";
            this.packing.Name = "packing";
            this.packing.ReadOnly = true;
            // 
            // overhead
            // 
            this.overhead.HeaderText = "Overhead";
            this.overhead.Name = "overhead";
            this.overhead.ReadOnly = true;
            // 
            // total
            // 
            this.total.HeaderText = "Grand Total";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Location = new System.Drawing.Point(3, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1196, 40);
            this.panel2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(849, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Style Code Search";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(990, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(177, 26);
            this.textBox1.TabIndex = 7;
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(159, 3);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(123, 34);
            this.button5.TabIndex = 6;
            this.button5.Text = "REFRESH";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(82, 2);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(73, 34);
            this.button3.TabIndex = 2;
            this.button3.Text = "DELETE";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(5, 2);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(73, 34);
            this.button2.TabIndex = 1;
            this.button2.Text = "UPDATE";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // style_costing_list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 602);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "style_costing_list";
            this.Text = "STYLE COSTING LIST";
            this.Load += new System.EventHandler(this.style_costing_list_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn style_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn style_color;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn mrp;
        private System.Windows.Forms.DataGridViewTextBoxColumn hardware;
        private System.Windows.Forms.DataGridViewTextBoxColumn hand_emb;
        private System.Windows.Forms.DataGridViewTextBoxColumn machine_emb;
        private System.Windows.Forms.DataGridViewTextBoxColumn fabrication;
        private System.Windows.Forms.DataGridViewTextBoxColumn digital_print;
        private System.Windows.Forms.DataGridViewTextBoxColumn lining_quilting;
        private System.Windows.Forms.DataGridViewTextBoxColumn leather;
        private System.Windows.Forms.DataGridViewTextBoxColumn fabric;
        private System.Windows.Forms.DataGridViewTextBoxColumn dye;
        private System.Windows.Forms.DataGridViewTextBoxColumn emb_mat;
        private System.Windows.Forms.DataGridViewTextBoxColumn other;
        private System.Windows.Forms.DataGridViewTextBoxColumn hardware_polish;
        private System.Windows.Forms.DataGridViewTextBoxColumn packing;
        private System.Windows.Forms.DataGridViewTextBoxColumn overhead;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}