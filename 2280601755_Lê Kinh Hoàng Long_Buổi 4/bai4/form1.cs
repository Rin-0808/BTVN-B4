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
    public partial class form1 : Form
    {
       
        public form1()
        {
            InitializeComponent();
        }
 
        List<employee> employeeinfo= new List<employee>();
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public class employee
        {
            public string MSNV { get; set; }
            public string Tên_Nhân_Viên { get; set; }
            public decimal Lương_Cơ_Bản { get; set; }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            form2 f2 = new form2();

            if (f2.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrWhiteSpace(f2.Id) || string.IsNullOrWhiteSpace(f2.Name) || f2.Pay <= 0)
                {
                    MessageBox.Show("Thông tin nhập không hợp lệ. Vui lòng kiểm tra lại!");
                    return;
                }

                employeeinfo.Add(new employee()
                {
                    MSNV = f2.Id,
                    Tên_Nhân_Viên = f2.Name,
                    Lương_Cơ_Bản = f2.Pay
                });               
                dgvNhanvien.DataSource = null; 
                dgvNhanvien.DataSource = employeeinfo;
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvNhanvien.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!");
                return;
            }

            int index = dgvNhanvien.CurrentRow.Index;

            employee selectedEmployee = employeeinfo[index];
            form2 f2 = new form2
            {
                Id = selectedEmployee.MSNV,
                Name = selectedEmployee.Tên_Nhân_Viên,
                Pay = selectedEmployee.Lương_Cơ_Bản
            };

            if (f2.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrWhiteSpace(f2.Id) || string.IsNullOrWhiteSpace(f2.Name) || f2.Pay <= 0)
                {
                    MessageBox.Show("Thông tin sửa không hợp lệ. Vui lòng kiểm tra lại!");
                    return;
                }

                employeeinfo[index] = new employee()
                {
                    MSNV = f2.Id,
                    Tên_Nhân_Viên = f2.Name,
                    Lương_Cơ_Bản = f2.Pay
                };

                dgvNhanvien.DataSource = null; 
                dgvNhanvien.DataSource = employeeinfo; 
            }
        }




        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = dgvNhanvien.CurrentCell.RowIndex;
            employeeinfo.RemoveAt(index);
            dgvNhanvien.DataSource = null;
            dgvNhanvien.DataSource = employeeinfo;
        }

        private void dgvNhanvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
