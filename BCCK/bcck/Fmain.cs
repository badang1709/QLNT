using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace bcck
{
    public partial class Fmain : Form
    {
        public Fmain()
        {
            InitializeComponent();
        }
        KetNoi kn = new KetNoi();
        private void Fmain_Load(object sender, EventArgs e)
        {
            if(FLogin.IsAdmin == false)
            {
                btnCaiDatPhong.Visible = false;
                btnCaiDatNhanVien.Visible = false;
                btnThongKeLuong.Visible = false;
            }    else
            {
                btnCaiDatPhong.Visible = true;
                btnCaiDatNhanVien.Visible = true;
                btnThongKeLuong.Visible = true;
            }
            kn.ThemUserControl(panel1, new ucQuanLyPhong());
        }

        private void Fmain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn Muốn Đăng Xuất ??","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }    
        }

        private void btnQLKhachHang_Click(object sender, EventArgs e)
        {

        }

        private void btnQLHoaDon_Click(object sender, EventArgs e)
        {
            kn.ThemUserControl(panel1, new ucQLHoaDon());
        }

        private void btnThongTinCaNhan_Click(object sender, EventArgs e)
        {
            kn.ThemUserControl(panel1, new ucThongTinCaNhan());
        }

        private void btnThongKeLuong_Click(object sender, EventArgs e)
        {
            ThongKeNV a = new ThongKeNV();
            a.ShowDialog();
        }

        private void btnQLPhong_Click(object sender, EventArgs e)
        {
            kn.ThemUserControl(panel1, new ucQuanLyPhong());
        }

        private void btnThongKeDT_Click(object sender, EventArgs e)
        {
            ThongKeDoanhThu a = new ThongKeDoanhThu();
            a.ShowDialog();
        }
    }
}
