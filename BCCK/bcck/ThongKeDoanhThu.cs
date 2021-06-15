using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bcck
{
    public partial class ThongKeDoanhThu : Form
    {
        public ThongKeDoanhThu()
        {
            InitializeComponent();
        }

        private void rpDoanhThu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.ChiTietHoaDon' table. You can move, or remove it, as needed.
            this.ChiTietHoaDonTableAdapter.Fill(this.DataSet1.ChiTietHoaDon);

            this.reportViewer1.RefreshReport();
        }
    }
}
