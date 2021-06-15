
namespace bcck
{
    partial class Fmain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.quảnLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnQLPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.btnQLHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnThongKeLuong = new System.Windows.Forms.ToolStripMenuItem();
            this.btnThongKeDT = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCaiDat = new System.Windows.Forms.ToolStripMenuItem();
            this.btnThongTinCaNhan = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCaiDatPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCaiDatNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýToolStripMenuItem,
            this.thốngKêToolStripMenuItem,
            this.btnCaiDat});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1301, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // quảnLýToolStripMenuItem
            // 
            this.quảnLýToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnQLPhong,
            this.btnQLHoaDon});
            this.quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            this.quảnLýToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.quảnLýToolStripMenuItem.Text = "Quản Lý";
            // 
            // btnQLPhong
            // 
            this.btnQLPhong.Name = "btnQLPhong";
            this.btnQLPhong.Size = new System.Drawing.Size(224, 26);
            this.btnQLPhong.Text = "Phòng";
            this.btnQLPhong.Click += new System.EventHandler(this.btnQLPhong_Click);
            // 
            // btnQLHoaDon
            // 
            this.btnQLHoaDon.Name = "btnQLHoaDon";
            this.btnQLHoaDon.Size = new System.Drawing.Size(224, 26);
            this.btnQLHoaDon.Text = "Hóa Đơn";
            this.btnQLHoaDon.Click += new System.EventHandler(this.btnQLHoaDon_Click);
            // 
            // thốngKêToolStripMenuItem
            // 
            this.thốngKêToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThongKeLuong,
            this.btnThongKeDT});
            this.thốngKêToolStripMenuItem.Name = "thốngKêToolStripMenuItem";
            this.thốngKêToolStripMenuItem.Size = new System.Drawing.Size(86, 24);
            this.thốngKêToolStripMenuItem.Text = "Thống Kê";
            // 
            // btnThongKeLuong
            // 
            this.btnThongKeLuong.Name = "btnThongKeLuong";
            this.btnThongKeLuong.Size = new System.Drawing.Size(204, 26);
            this.btnThongKeLuong.Text = "Lương Nhân viên";
            this.btnThongKeLuong.Click += new System.EventHandler(this.btnThongKeLuong_Click);
            // 
            // btnThongKeDT
            // 
            this.btnThongKeDT.Name = "btnThongKeDT";
            this.btnThongKeDT.Size = new System.Drawing.Size(224, 26);
            this.btnThongKeDT.Text = "Doanh Thu";
            this.btnThongKeDT.Click += new System.EventHandler(this.btnThongKeDT_Click);
            // 
            // btnCaiDat
            // 
            this.btnCaiDat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThongTinCaNhan,
            this.btnCaiDatPhong,
            this.btnCaiDatNhanVien});
            this.btnCaiDat.Name = "btnCaiDat";
            this.btnCaiDat.Size = new System.Drawing.Size(72, 24);
            this.btnCaiDat.Text = "Cài Đặt";
            // 
            // btnThongTinCaNhan
            // 
            this.btnThongTinCaNhan.Name = "btnThongTinCaNhan";
            this.btnThongTinCaNhan.Size = new System.Drawing.Size(226, 26);
            this.btnThongTinCaNhan.Text = "Thông Tin Tài Khoản";
            this.btnThongTinCaNhan.Click += new System.EventHandler(this.btnThongTinCaNhan_Click);
            // 
            // btnCaiDatPhong
            // 
            this.btnCaiDatPhong.Name = "btnCaiDatPhong";
            this.btnCaiDatPhong.Size = new System.Drawing.Size(226, 26);
            this.btnCaiDatPhong.Text = "Phòng";
            // 
            // btnCaiDatNhanVien
            // 
            this.btnCaiDatNhanVien.Name = "btnCaiDatNhanVien";
            this.btnCaiDatNhanVien.Size = new System.Drawing.Size(226, 26);
            this.btnCaiDatNhanVien.Text = "Nhân Viên";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1301, 618);
            this.panel1.TabIndex = 1;
            // 
            // Fmain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 646);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Fmain";
            this.Text = "Trang Chủ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Fmain_FormClosing);
            this.Load += new System.EventHandler(this.Fmain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quảnLýToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thốngKêToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem btnQLPhong;
        private System.Windows.Forms.ToolStripMenuItem btnThongKeLuong;
        private System.Windows.Forms.ToolStripMenuItem btnThongKeDT;
        private System.Windows.Forms.ToolStripMenuItem btnQLHoaDon;
        private System.Windows.Forms.ToolStripMenuItem btnCaiDat;
        private System.Windows.Forms.ToolStripMenuItem btnCaiDatPhong;
        private System.Windows.Forms.ToolStripMenuItem btnCaiDatNhanVien;
        private System.Windows.Forms.ToolStripMenuItem btnThongTinCaNhan;
    }
}