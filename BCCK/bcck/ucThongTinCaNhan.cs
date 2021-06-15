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
    public partial class ucThongTinCaNhan : UserControl
    {
        public ucThongTinCaNhan()
        {
            InitializeComponent();
        }
        KetNoi kn = new KetNoi();
        DataTable NhanVien()
        {
            SqlCommand cmd = new SqlCommand("sp_NhanVien", kn.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TenDN", FLogin.TenDN);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        DataTable DoiMatKhau()
        {
            SqlCommand cmd = new SqlCommand("sp_doimk", kn.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", txtID.Text);
            cmd.Parameters.AddWithValue("@mk", txtMatKhau.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        private void ucThongTinCaNhan_Load(object sender, EventArgs e)
        {
            DataTable dt = NhanVien();
            txtID.Text = dt.Rows[0][0].ToString();
            txtHoTen.Text = dt.Rows[0][1].ToString();
            txtSDT.Text = dt.Rows[0][2].ToString();
            txtCMND.Text = dt.Rows[0][3].ToString();
            txtChucVu.Text = dt.Rows[0][5].ToString();
            checkBox1.Checked = bool.Parse(dt.Rows[0][4].ToString());
            txtMucLuong.Text = dt.Rows[0][6].ToString();
            txtDN.Text = dt.Rows[0][7].ToString();
            txtMatKhau.Text = dt.Rows[0][8].ToString();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                txtMatKhau.PasswordChar = '\0';
            else
                txtMatKhau.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (FLogin.MKCu == txtMatKhau.Text)
            {
                MessageBox.Show("Mật Khẩu Chưa Thay Đổi");

            }
            else
            {
                DoiMatKhau();
                MessageBox.Show("Đã Đổi MK");
            }
        }
    }
}
