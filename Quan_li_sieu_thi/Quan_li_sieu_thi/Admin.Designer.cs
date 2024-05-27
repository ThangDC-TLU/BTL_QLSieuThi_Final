namespace Quan_li_sieu_thi
{
    partial class Admin
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.quảnLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_item_QLTK = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_item_QLNCC = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_item_QLSP = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_item_QLHD = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_item_BanHang = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_item_Info = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_item_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.menuStrip1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýToolStripMenuItem,
            this.menu_item_BanHang,
            this.menu_item_Info,
            this.menu_item_Exit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(15);
            this.menuStrip1.Size = new System.Drawing.Size(956, 67);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // quảnLýToolStripMenuItem
            // 
            this.quảnLýToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_item_QLTK,
            this.menu_item_QLNCC,
            this.menu_item_QLSP,
            this.menu_item_QLHD});
            this.quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            this.quảnLýToolStripMenuItem.Size = new System.Drawing.Size(120, 37);
            this.quảnLýToolStripMenuItem.Text = "Quản lý";
            // 
            // menu_item_QLTK
            // 
            this.menu_item_QLTK.Name = "menu_item_QLTK";
            this.menu_item_QLTK.Size = new System.Drawing.Size(361, 42);
            this.menu_item_QLTK.Text = "Quản lý tài khoản";
            this.menu_item_QLTK.Click += new System.EventHandler(this.menu_item_QLTK_Click);
            // 
            // menu_item_QLNCC
            // 
            this.menu_item_QLNCC.Name = "menu_item_QLNCC";
            this.menu_item_QLNCC.Size = new System.Drawing.Size(361, 42);
            this.menu_item_QLNCC.Text = "Quản lý nhà cung cấp";
            this.menu_item_QLNCC.Click += new System.EventHandler(this.menu_item_QLNCC_Click);
            // 
            // menu_item_QLSP
            // 
            this.menu_item_QLSP.Name = "menu_item_QLSP";
            this.menu_item_QLSP.Size = new System.Drawing.Size(361, 42);
            this.menu_item_QLSP.Text = "Quản lý sản phẩm";
            this.menu_item_QLSP.Click += new System.EventHandler(this.menu_item_QLSP_Click);
            // 
            // menu_item_QLHD
            // 
            this.menu_item_QLHD.Name = "menu_item_QLHD";
            this.menu_item_QLHD.Size = new System.Drawing.Size(361, 42);
            this.menu_item_QLHD.Text = "Quản lý hóa đơn";
            this.menu_item_QLHD.Click += new System.EventHandler(this.menu_item_QLHD_Click);
            // 
            // menu_item_BanHang
            // 
            this.menu_item_BanHang.Name = "menu_item_BanHang";
            this.menu_item_BanHang.Size = new System.Drawing.Size(136, 37);
            this.menu_item_BanHang.Text = "Bán hàng";
            this.menu_item_BanHang.Click += new System.EventHandler(this.menu_item_BanHang_Click);
            // 
            // menu_item_Info
            // 
            this.menu_item_Info.Name = "menu_item_Info";
            this.menu_item_Info.Size = new System.Drawing.Size(139, 37);
            this.menu_item_Info.Text = "Thông tin";
            this.menu_item_Info.Click += new System.EventHandler(this.menu_item_Info_Click);
            // 
            // menu_item_Exit
            // 
            this.menu_item_Exit.Name = "menu_item_Exit";
            this.menu_item_Exit.Size = new System.Drawing.Size(145, 37);
            this.menu_item_Exit.Text = "Đăng xuất";
            this.menu_item_Exit.Click += new System.EventHandler(this.menu_item_Exit_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Quan_li_sieu_thi.Properties.Resources.Screenshot_2024_05_16_132723;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(0, 54);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(956, 537);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Admin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(956, 587);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý siêu thị";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quảnLýToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_item_QLTK;
        private System.Windows.Forms.ToolStripMenuItem menu_item_QLNCC;
        private System.Windows.Forms.ToolStripMenuItem menu_item_QLSP;
        private System.Windows.Forms.ToolStripMenuItem menu_item_QLHD;
        private System.Windows.Forms.ToolStripMenuItem menu_item_BanHang;
        private System.Windows.Forms.ToolStripMenuItem menu_item_Info;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu_item_Exit;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}