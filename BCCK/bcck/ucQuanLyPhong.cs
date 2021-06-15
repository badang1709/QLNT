using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bcck
{
    public partial class ucQuanLyPhong : UserControl
    {
        public ucQuanLyPhong()
        {
            InitializeComponent();
        }
        KetNoi kn = new KetNoi();
        DataTable Phong()
        {
            SqlCommand cmd = new SqlCommand("SLPhong", kn.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        DataTable KhachHangHienTai(string s)
        {
            SqlCommand cmd = new SqlCommand("SLKhachHang", kn.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idphong", s);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        private void ucQuanLyPhong_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Phong();
            DataTable dt = NhanVien(FLogin.TenDN);
            txtNV.Text = dt.Rows[0][0].ToString();
        }
        public void luuthongtin()
        {
            txtTenKH.Enabled = false;
            txtSDT.Enabled = false;
            txtCMND.Enabled = false;
            txtNoiCap.Enabled = false;
            dtpNgayCap.Enabled = false;
            txtNoiSinh.Enabled = false;
            dtpNgaySinh.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuuKhach.Enabled = false;
            btnThemKhach.Enabled = true;
        }
        public void themthongtin()
        {
            txtTenKH.Enabled = true;
            txtSDT.Enabled = true;
            txtCMND.Enabled = true;
            txtNoiCap.Enabled = true;
            dtpNgayCap.Enabled = true;
            txtNoiSinh.Enabled = true;
            dtpNgaySinh.Enabled = true;
            btnLuuKhach.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThemKhach.Enabled = false;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (txtTenKH.Enabled)
            {
                MessageBox.Show("Thông Tin Chưa Được Lưu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            luuthongtin();
            DataGridViewRow dr = dataGridView1.CurrentRow;
            txtIDPhong.Text = dr.Cells[0].Value.ToString();
            txtTenPhong.Text = dr.Cells[1].Value.ToString();
            txtSLCP.Text = dr.Cells[2].Value.ToString();
            txtSLHT.Text = dr.Cells[3].Value.ToString();
            chktrangthai.Checked = bool.Parse(dr.Cells[4].Value.ToString());
            cbbDanhSachKhachHang.DataSource = null;
            try
            {
                cbbDanhSachKhachHang.DisplayMember = "TenKhachHang";
                cbbDanhSachKhachHang.ValueMember = "IDKhachHang";
                cbbDanhSachKhachHang.DataSource = KhachHangHienTai(txtIDPhong.Text);
                cbbDanhSachKhachHang.SelectedIndex = 0;
            }
            catch
            {
            }
        }
        public void resetttphong()
        {
            txtIDPhong.Text = "";
            txtTenPhong.Text = "";
            txtSLCP.Text = "";
            txtSLHT.Text = "";
        }
        DataTable ThongTinKhachHang(int s)
        {
            SqlCommand cmd = new SqlCommand("ThongTinKhachHang", kn.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idkhachhang", s);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        private void cbbDanhSachKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbDanhSachKhachHang.DataSource != null)
            {
                if (cbbDanhSachKhachHang.SelectedValue != null)
                {
                    DataTable dt = ThongTinKhachHang(int.Parse(cbbDanhSachKhachHang.SelectedValue.ToString()));
                    txtIDKH.Text = dt.Rows[0][0].ToString();
                    txtTenKH.Text = dt.Rows[0][2].ToString();
                    txtSDT.Text = dt.Rows[0][3].ToString();
                    txtCMND.Text = dt.Rows[0][4].ToString();
                    txtNoiCap.Text = dt.Rows[0][5].ToString();
                    dtpNgayCap.Value = DateTime.Parse(dt.Rows[0][6].ToString());
                    txtNoiSinh.Text = dt.Rows[0][8].ToString();
                    dtpNgaySinh.Value = DateTime.Parse(dt.Rows[0][7].ToString());
                }
                else
                {
                    rongttkh();
                }
            }
            else
            {
                rongttkh();
            }
        }
        public void rongttkh()
        {
            txtIDKH.Text = "";
            txtTenKH.Text = "";
            txtSDT.Text = "";
            txtCMND.Text = "";
            txtNoiCap.Text = "";
            dtpNgayCap.Value = DateTime.Now;
            txtNoiSinh.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
        }
        private void btnTraPhong_Click(object sender, EventArgs e)
        {
            string id = txtIDPhong.Text;
            string soluonghientai = txtSLHT.Text;
            if (!chktrangthai.Checked)
            {
                MessageBox.Show("Phòng Này Đang Trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                for (int i = 0; i < int.Parse(soluonghientai); i++)
                {
                    cbbDanhSachKhachHang.SelectedIndex = i;
                    XoaKH(int.Parse(txtIDKH.Text), id);
                }
                traphong(id, DateTime.Now);

            }
            dataGridView1.DataSource = Phong();
            resetttphong();
            rongttkh();
        }

        private void btnThemKhach_Click(object sender, EventArgs e)
        {
            if(int.Parse(txtSLHT.Text) == int.Parse(txtSLCP.Text))
            {
                MessageBox.Show("Phòng Đã Đầy");
            }
            else
            {
                cbbDanhSachKhachHang.SelectedValue = 0;
                status = 0;
                themthongtin();
            }
           
        }
        DataTable ThemKhach(string ten, string phong, string sdt, string cmnd, string noicap, DateTime ngaycap, DateTime ngaysinh, string noisinh)
        {
            SqlCommand cmd = new SqlCommand("sp_ThemKhachHang", kn.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ten", ten);
            cmd.Parameters.AddWithValue("@phong", phong);
            cmd.Parameters.AddWithValue("@sdt", sdt);
            cmd.Parameters.AddWithValue("@cmnd", cmnd);
            cmd.Parameters.AddWithValue("@noicap", noicap);
            cmd.Parameters.AddWithValue("@ngaycap", ngaycap);
            cmd.Parameters.AddWithValue("@ngaysinh", ngaysinh);
            cmd.Parameters.AddWithValue("@noisinh", noisinh);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        DataTable XoaKH(int s, string p)
        {
            SqlCommand cmd = new SqlCommand("sp_xoakh", kn.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", s);
            cmd.Parameters.AddWithValue("@phong", p);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        DataTable traphong(string p,DateTime tgr)
        {
            SqlCommand cmd = new SqlCommand("sp_traphong", kn.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", p);
            cmd.Parameters.AddWithValue("@tgr", tgr);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        DataTable NhanVien(string p)
        {
            SqlCommand cmd = new SqlCommand("sp_NhanVien", kn.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TenDN", p);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        private void btnLuuKhach_Click(object sender, EventArgs e)
        {
            if (status == 1)
            {
                suakh(int.Parse(txtIDKH.Text), txtTenKH.Text, txtSDT.Text, txtCMND.Text, txtNoiCap.Text, dtpNgayCap.Value, dtpNgaySinh.Value, txtNoiSinh.Text);
            }
            else
            {
                if (!chktrangthai.Checked)
                {
                    Form1 a = new Form1(int.Parse(txtNV.Text),txtTenKH.Text, txtIDPhong.Text, txtSDT.Text, txtCMND.Text, txtNoiCap.Text, dtpNgayCap.Value, dtpNgaySinh.Value, txtNoiSinh.Text);
                    a.ShowDialog();
                }
                else ThemKhach(txtTenKH.Text, txtIDPhong.Text, txtSDT.Text, txtCMND.Text, txtNoiCap.Text, dtpNgayCap.Value, dtpNgaySinh.Value, txtNoiSinh.Text);
            }

            luuthongtin();
            dataGridView1.DataSource = Phong();
            resetttphong();
        }
        int status = 0;
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Có Muốn Xóa Người Này ??", "Xóa Khách", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string id = txtIDPhong.Text;
                string soluonghientai = txtSLHT.Text;
                XoaKH(int.Parse(txtIDKH.Text), id);
                dataGridView1.DataSource = Phong();
                resetttphong();
                rongttkh();
                if (soluonghientai == "1")
                {
                    traphong(id,DateTime.Now);
                }
            }
        }
        DataTable suakh(int id, string ten, string sdt, string cmnd, string noicap, DateTime ngaycap, DateTime ngaysinh, string noisinh)
        {
            SqlCommand cmd = new SqlCommand("sp_ThemKhachHang", kn.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@ten", ten);
            cmd.Parameters.AddWithValue("@sdt", sdt);
            cmd.Parameters.AddWithValue("@cmnd", cmnd);
            cmd.Parameters.AddWithValue("@noicap", noicap);
            cmd.Parameters.AddWithValue("@ngaycap", ngaycap);
            cmd.Parameters.AddWithValue("@ngaysinh", ngaysinh);
            cmd.Parameters.AddWithValue("@noisinh", noisinh);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = btnThemKhach.Enabled = false;
            btnLuuKhach.Enabled = true;
            status = 1;

        }
    }
}
