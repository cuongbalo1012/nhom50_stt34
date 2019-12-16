using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV
{
    public partial class frmMain : Form
    {
        SinhVienBLL bllSV;
        int ID;
        DataTable dtSV;
        string A;
        int index;
        public frmMain()
        {
            InitializeComponent();
            bllSV = new SinhVienBLL();
        }

        public void ShowAllSinhVien()
        {
            DataTable dt = bllSV.getAllSinhVien();
            dataGridSinhVien.DataSource = dt;
        }


        

        public DataTable Table()
        {
            DataTable dt = new DataTable();
            
            dt.Columns.Add("MaSV");
            dt.Columns.Add("HoTen");
            dt.Columns.Add("DiaChi");
            return dt;
        }

        public void LockControl()
        {
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
            btnExit.Enabled = false;


            txtMaSV.ReadOnly = true;
            txtHoTen.ReadOnly = true;
            txtDiaChi.ReadOnly = true;

           
        }

        public void UnlockControl()
        {
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnExit.Enabled = true;


            txtMaSV.ReadOnly = false;
            txtHoTen.ReadOnly = false;
            txtDiaChi.ReadOnly = false;

            txtMaSV.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LockControl();
            dtSV = Table();
            ShowAllSinhVien();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UnlockControl();
            A = "add";
            txtMaSV.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            UnlockControl();
            A = "edit";
        }

        public bool check()
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Chua nhap MSV", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSV.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Chua nhap TenSV", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHoTen.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Chua nhap Dia Chi", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return false;
            }
            return true;
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (A == "add")
            {
                if (check())
                {
                    tblSinhVien sv = new tblSinhVien();
                    sv.MaSV = int.Parse(txtMaSV.Text);
                    sv.HoTen = txtHoTen.Text;
                    sv.DiaChi = txtDiaChi.Text;

                    if (bllSV.InsertSinhVien(sv))
                    {
                        ShowAllSinhVien();
                    }
                    else { MessageBox.Show("Loi", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
                }
                
            }
            else if (A == "edit")
            {
                if (check())
                {
                    tblSinhVien sv = new tblSinhVien();
                    sv.id = ID;
                    sv.MaSV = int.Parse(txtMaSV.Text);
                    sv.HoTen = txtHoTen.Text;
                    sv.DiaChi = txtDiaChi.Text;

                    if (bllSV.UpdateSinhVien(sv))
                    {
                        ShowAllSinhVien();
                    }
                    else { MessageBox.Show("Loi", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
                }
            }
            LockControl();
        }

        //private void datagridsinhvien_selectionchanged(object sender, eventargs e)
        //{
        //    index = datagridsinhvien.currentcell == null ? -1 : datagridsinhvien.currentcell.rowindex;
        //    datatable dt = (datatable)datagridsinhvien.datasource;
        //    if (index != -1)
        //    {
        //        id = int32.parse(datagridsinhvien.rows[index].cells["id"].value.tostring());
        //        txtmasv.text = datagridsinhvien.rows[index].cells["masv"].value.tostring();
        //        txthoten.text = datagridsinhvien.rows[index].cells["hoten"].value.tostring();
        //        txtdiachi.text = datagridsinhvien.rows[index].cells["diachi"].value.tostring();
        //    }
        //}

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Ban co muon xoa SV nay?","Canh Bao", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tblSinhVien sv = new tblSinhVien();
                sv.id = ID;
                if (bllSV.DeleteSinhVien(sv))
                {
                    ShowAllSinhVien();
                }
                else { MessageBox.Show("Loi", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
            }
        }

        private void dataGridSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if(index >= 0)
            {
                ID = Int32.Parse(dataGridSinhVien.Rows[index].Cells["id"].Value.ToString());
                txtMaSV.Text = dataGridSinhVien.Rows[index].Cells["colMaSV"].Value.ToString();
                txtHoTen.Text = dataGridSinhVien.Rows[index].Cells["colHoTen"].Value.ToString();
                txtDiaChi.Text = dataGridSinhVien.Rows[index].Cells["colDiaChi"].Value.ToString();
            }
        }

        private void txtSeach_TextChanged(object sender, EventArgs e)
        {
            string value = txtSeach.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllSV.SeachSinhVien(value);
                dataGridSinhVien.DataSource = dt;

            }
            else
                ShowAllSinhVien();
        }
    }
}
