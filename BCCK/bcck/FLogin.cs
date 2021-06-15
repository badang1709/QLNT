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
    public partial class FLogin : Form
    {
        public FLogin()
        {
            InitializeComponent();
        }
        KetNoi kn = new KetNoi();
        DataTable DangNhap(string ten, string mk)
        {
            SqlCommand cmd = new SqlCommand("sp_NhanVienDangNhap", kn.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ten", ten);
            cmd.Parameters.AddWithValue("@matkhau", mk);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        private void FLogin_Load(object sender, EventArgs e)
        {
            txtTenDangNhap.Text = "";
            txtMatKhau.Text = "";
            txtTenDangNhap.Focus();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text == "" || txtMatKhau.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            DataTable dt = new DataTable();
            dt = DangNhap(txtTenDangNhap.Text, txtMatKhau.Text);
            if (int.Parse(dt.Rows[0]["errcode"].ToString()) == 1)
            {
                IsAdmin = Convert.ToBoolean(dt.Rows[0]["IsAdmin"].ToString());
                TenDN = txtTenDangNhap.Text;
                MKCu = txtMatKhau.Text;
                this.Hide();
                Fmain frm = new Fmain();
                frm.ShowDialog();
                this.Show();
                txtTenDangNhap.Text = "";
                txtMatKhau.Text = "";
                txtTenDangNhap.Focus();
            }
            else
                MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
                txtMatKhau.PasswordChar = '\0';
            else
                txtMatKhau.PasswordChar = '*';
        }
        public static bool IsAdmin;
        public static string TenDN = "";
        public static string MKCu = "";
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
