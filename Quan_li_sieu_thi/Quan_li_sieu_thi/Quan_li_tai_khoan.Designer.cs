namespace Quan_li_sieu_thi
{
    partial class Quan_li_tai_khoan
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
            this.Date = new System.Windows.Forms.DateTimePicker();
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_Del = new System.Windows.Forms.Button();
            this.button_Edit = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
            this.ChV = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_MK = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_TK = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Date
            // 
            this.Date.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Date.Location = new System.Drawing.Point(1002, 358);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(310, 33);
            this.Date.TabIndex = 27;
            this.Date.ValueChanged += new System.EventHandler(this.Date_ValueChanged);
            // 
            // button_Exit
            // 
            this.button_Exit.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_Exit.Location = new System.Drawing.Point(236, 98);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(155, 48);
            this.button_Exit.TabIndex = 3;
            this.button_Exit.Text = "Thoát";
            this.button_Exit.UseVisualStyleBackColor = false;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // button_Del
            // 
            this.button_Del.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_Del.Location = new System.Drawing.Point(236, 45);
            this.button_Del.Name = "button_Del";
            this.button_Del.Size = new System.Drawing.Size(155, 47);
            this.button_Del.TabIndex = 2;
            this.button_Del.Text = "Xóa";
            this.button_Del.UseVisualStyleBackColor = false;
            this.button_Del.Click += new System.EventHandler(this.button_Del_Click);
            // 
            // button_Edit
            // 
            this.button_Edit.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_Edit.Location = new System.Drawing.Point(44, 98);
            this.button_Edit.Name = "button_Edit";
            this.button_Edit.Size = new System.Drawing.Size(148, 48);
            this.button_Edit.TabIndex = 1;
            this.button_Edit.Text = "Sửa";
            this.button_Edit.UseVisualStyleBackColor = false;
            this.button_Edit.Click += new System.EventHandler(this.button_Edit_Click);
            // 
            // button_Add
            // 
            this.button_Add.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_Add.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Add.Location = new System.Drawing.Point(44, 45);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(148, 47);
            this.button_Add.TabIndex = 0;
            this.button_Add.Text = "Thêm";
            this.button_Add.UseVisualStyleBackColor = false;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // ChV
            // 
            this.ChV.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ChV.FormattingEnabled = true;
            this.ChV.Location = new System.Drawing.Point(1002, 430);
            this.ChV.Name = "ChV";
            this.ChV.Size = new System.Drawing.Size(310, 33);
            this.ChV.TabIndex = 26;
            this.ChV.SelectedIndexChanged += new System.EventHandler(this.ChV_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_Exit);
            this.groupBox1.Controls.Add(this.button_Del);
            this.groupBox1.Controls.Add(this.button_Edit);
            this.groupBox1.Controls.Add(this.button_Add);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(882, 487);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 177);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức năng";
            // 
            // label6
            // 
            this.label6.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(871, 427);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 32);
            this.label6.TabIndex = 24;
            this.label6.Text = "Chức vụ";
            // 
            // textBox_Name
            // 
            this.textBox_Name.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBox_Name.Location = new System.Drawing.Point(1002, 285);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(310, 33);
            this.textBox_Name.TabIndex = 23;
            this.textBox_Name.TextChanged += new System.EventHandler(this.textBox_Name_TextChanged);
            // 
            // label5
            // 
            this.label5.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(871, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 32);
            this.label5.TabIndex = 22;
            this.label5.Text = "Họ và tên";
            // 
            // label4
            // 
            this.label4.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(871, 358);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 32);
            this.label4.TabIndex = 21;
            this.label4.Text = "Ngày tạo";
            // 
            // textBox_MK
            // 
            this.textBox_MK.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBox_MK.Location = new System.Drawing.Point(1002, 202);
            this.textBox_MK.Name = "textBox_MK";
            this.textBox_MK.Size = new System.Drawing.Size(310, 33);
            this.textBox_MK.TabIndex = 20;
            this.textBox_MK.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(871, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 32);
            this.label3.TabIndex = 19;
            this.label3.Text = "Mật khẩu";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBox_TK
            // 
            this.textBox_TK.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBox_TK.Location = new System.Drawing.Point(1002, 118);
            this.textBox_TK.Name = "textBox_TK";
            this.textBox_TK.Size = new System.Drawing.Size(310, 33);
            this.textBox_TK.TabIndex = 18;
            this.textBox_TK.TextChanged += new System.EventHandler(this.textBox_TK_TextChanged);
            // 
            // label2
            // 
            this.label2.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(866, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 32);
            this.label2.TabIndex = 17;
            this.label2.Text = "Tài khoản";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(273, -66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 41);
            this.label1.TabIndex = 16;
            this.label1.Text = "Quản lý Tài khoản";
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 102);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.RowTemplate.Height = 28;
            this.dataGridView.Size = new System.Drawing.Size(848, 562);
            this.dataGridView.TabIndex = 15;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_CellFormatting);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(569, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(355, 51);
            this.label7.TabIndex = 28;
            this.label7.Text = "Quản lý tài khoản";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // Quan_li_tai_khoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1328, 676);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Date);
            this.Controls.Add(this.ChV);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_Name);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_MK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_TK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Quan_li_tai_khoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quan_li_tai_khoan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Quan_li_tai_khoan_FormClosing);
            this.Load += new System.EventHandler(this.Quan_li_tai_khoan_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker Date;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_Del;
        private System.Windows.Forms.Button button_Edit;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.ComboBox ChV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_MK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_TK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label7;
    }
}