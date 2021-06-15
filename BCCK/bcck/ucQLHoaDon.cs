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
    public partial class ucQLHoaDon : UserControl
    {
        public ucQLHoaDon()
        {
            InitializeComponent();
        }
        KetNoi kn = new KetNoi();
        DataTable HoaDon()
        {
            SqlCommand cmd = new SqlCommand("sp_HoaDon", kn.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        private void ucQLHoaDon_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = HoaDon();
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dataGridView1.CurrentRow;
            txtID.Text = dr.Cells[0].Value.ToString();
            txtNV.Text = dr.Cells[4].Value.ToString();
            dateTimePicker1.Value = DateTime.Parse(dr.Cells[2].Value.ToString());
            checkBox1.Checked = bool.Parse(dr.Cells[5].Value.ToString());
            if (dr.Cells[3].Value.ToString() != "")
            {
                dateTimePicker2.Value = DateTime.Parse(dr.Cells[3].Value.ToString());
                txtDonGia.Text = dr.Cells[6].Value.ToString();
                int SoThang = dateTimePicker2.Value.Month - dateTimePicker1.Value.Month;
                int SoNgay = dateTimePicker2.Value.Day - dateTimePicker1.Value.Day;
                int SoGio = dateTimePicker2.Value.Hour - dateTimePicker1.Value.Hour;
                int Tong = SoThang * 30 * 24 + SoNgay * 24 + SoGio;
                txttong.Text = Tong.ToString();
                int ThanhTien = Tong * int.Parse(txtDonGia.Text);
                txtThanhTien.Text = ThanhTien.ToString();
            }
        }
        DataTable ThanhToanHoaDon(string id, float sogio, int sotien)
        {
            SqlCommand cmd = new SqlCommand("sp_ThanhToan", kn.connection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idhd", id);
            cmd.Parameters.AddWithValue("@sogio", sogio);
            cmd.Parameters.AddWithValue("@sotien", sotien);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                ThanhToanHoaDon(txtID.Text, float.Parse(txttong.Text), int.Parse(txtThanhTien.Text));
                MessageBox.Show("Thanh Toán Thành Công");
            }
            else
            {
                MessageBox.Show("Đã Thanh Toán");
            }
        }
    }
}
