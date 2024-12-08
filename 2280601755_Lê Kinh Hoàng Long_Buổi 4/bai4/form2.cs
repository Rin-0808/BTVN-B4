using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai4
{
    public partial class form2 : Form
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Pay { get; set; }

        public form2()
        {
            InitializeComponent();
        }

        private void form2_Load(object sender, EventArgs e)
        {
            // Hiển thị thông tin hiện tại nếu có
            txtMSNV.Text = Id;
            txtTenNV.Text = Name;
            txtLuongCoBan.Text = Pay.ToString();
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các TextBox
            Id = txtMSNV.Text;
            Name = txtTenNV.Text;

            // Kiểm tra và chuyển đổi lương
            if (!decimal.TryParse(txtLuongCoBan.Text, out decimal pay))
            {
                MessageBox.Show("Lương cơ bản không hợp lệ!");
                return;
            }
            Pay = pay;

            // Đặt DialogResult và đóng form
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

}
