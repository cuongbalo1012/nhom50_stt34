using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace QLSV
{
    class SinhVienDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public SinhVienDAL()
        {
            dc = new DataConnection();
        }

        public DataTable getAllSinhVien()
        {
            string sql = "SELECT * FROM tblSinhVien";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public bool InsertSinhVien(tblSinhVien sv)
        {
            string sql = "INSERT INTO tblSinhVien(MaSV, HoTen, DiaChi) VALUES(@MaSV, @HoTen, @DiaChi)";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaSV", SqlDbType.Int).Value = sv.MaSV;
                cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = sv.HoTen;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = sv.DiaChi;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        public bool UpdateSinhVien(tblSinhVien sv)
        {
            string sql = "UPDATE tblSinhVien SET MaSV=@MaSV, HoTen=@HoTen, DiaChi=@DiaChi WHERE id=@id";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = sv.id;
                cmd.Parameters.Add("@MaSV", SqlDbType.Int).Value = sv.MaSV;
                cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = sv.HoTen;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = sv.DiaChi;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception )
            {
                return false;
            }
            return true;
        }

        public bool DeleteSinhVien(tblSinhVien sv)
        {
            string sql = "DELETE tblSinhVien WHERE id=@id";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = sv.id;

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }


        public DataTable SeachSinhVien(string sv)
        {
            string sql = "SELECT * FROM tblSinhVien WHERE MaSV like '%" + sv + "%' OR HoTen like '%" + sv + "%'";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}
