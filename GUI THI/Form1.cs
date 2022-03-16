using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_THI;
using System.Data;
namespace GUI_THI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        BUS bus = new BUS();
        private void Form1_Load(object sender, EventArgs e)
        {
            dgvHang.DataSource = bus.showBang();
            cboLoaiHang.Text = "Sam Sung";
            loadcb();
            txtMaHang.Focus();
        }
        private void loadcb()
        {
            cboLoaiHang.DataSource = bus.showcbo();
            cboLoaiHang.DisplayMember = "Tenloai";
            cboLoaiHang.ValueMember = "Maloai";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaHang.Text == "" || txtTenHang.Text == "" || txtDonGia.Text == "")
                MessageBox.Show("Nhập thiếu dữ liệu");
            else
            {
                try
                {
                    //lệnh insert
                    bus.Insert(int.Parse(txtMaHang.Text), txtTenHang.Text, float.Parse(txtDonGia.Text), int.Parse(cboLoaiHang.SelectedValue.ToString()));
                    MessageBox.Show("Thêm thành công");
                }
                catch
                {
                    MessageBox.Show("Lỗi nhập liệu", "Thông báo");
                }
                Form1_Load(sender, e);
            }


        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = bus.LookLop(int.Parse(cboLoaiHang.SelectedValue.ToString()));
            dgvHang.DataSource = dt;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?", "Exit this program", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void dgvHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int dong = e.RowIndex;
                txtMaHang.Text = dgvHang.Rows[dong].Cells[0].Value.ToString();
                txtTenHang.Text = dgvHang.Rows[dong].Cells[1].Value.ToString();
                txtDonGia.Text = dgvHang.Rows[dong].Cells[2].Value.ToString();
                cboLoaiHang.Text = dgvHang.Rows[dong].Cells[3].Value.ToString();
            }
            catch
            {

            }
        }
    }
}