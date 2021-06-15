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
    public partial class Form1 : Form
    {
        public int IDNV;
        public string TenKh;
        public string Phong;
        public string sdt;
        public string cmnd;
        public string noicap;
        public DateTime ngaycap;
        public DateTime ngaysinh;
        public string noisinh;
        public Form1(int IDNV,string Ten,string Phong,string sdt,string cmnd,string noicap,DateTime ngaycap,DateTime ngaysinh,string noisinh)
        {
            this.IDNV = IDNV;
            this.Phong = Phong;
            TenKh = Ten;
            this.sdt = sdt;
            this.cmnd = cmnd;
            this.noicap = noicap;
            this.ngaycap = ngaycap;
            this.ngaysinh = ngaysinh;
            this.noisinh = noisinh;
            InitializeComponent();
        }
        KetNoi kn = new KetNoi();
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
        DataTable HoaDonMaxID()
        {
            SqlCommand cmd = new SqlCommand("sp_ChonHoaDon", kn.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public string autoidhd()
        {
            string _x = "";
            DataTable dt = new DataTable();
            dt = HoaDonMaxID();
            if (dt.Rows.Count == 0)
                _x = "HD001";
            else

                _x = dt.Rows[dt.Rows.Count-1]["IDHoaDon"].ToString();
            string kq = "";
            string left = _x.Substring(0, 2).ToString();
            string snew = _x.Substring(2, 3).ToString();
            int i = int.Parse(snew) + 1;
            if (i < 10)
                kq = "00" + i.ToString();
            if (i >= 10 && i < 100)
                kq = "0" + i.ToString();
            if (i >= 100)
                kq = i.ToString();
            return left + kq;
        }
        DataTable ThemHoaDon(DateTime tgvao)
        {
            SqlCommand cmd = new SqlCommand("sp_themhd", kn.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", autoidhd());
            cmd.Parameters.AddWithValue("@phong", Phong);
            cmd.Parameters.AddWithValue("@tgvao", tgvao);
            cmd.Parameters.AddWithValue("@idnv", IDNV);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        private void btnThue_Click(object sender, EventArgs e)
        {
            dtpThue.Value = DateTime.Now;
            ThemHoaDon(dtpThue.Value);
            ThemKhach(TenKh, Phong, sdt, cmnd, noicap, ngaycap, ngaysinh, noisinh);
            this.Close();
        }

        private void btnDat_Click(object sender, EventArgs e)
        {
            btnDat.Enabled = btnThue.Enabled = false;
            btnDat.Visible = btnThue.Visible = false;
            btnLuu.Visible = dtpThue.Visible = true;
            btnLuu.Enabled = dtpThue.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ThemHoaDon(dtpThue.Value);
            ThemKhach(TenKh, Phong, sdt, cmnd, noicap, ngaycap, ngaysinh, noisinh);
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
