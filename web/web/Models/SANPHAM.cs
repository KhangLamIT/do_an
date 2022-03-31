using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PagedList;
namespace web.Models
{
    public class SANPHAM
    {
        string conf = "Data Source=KID;Initial Catalog=QL_NhaSach;User ID=sa";
        public string MASP { get; set; }
        public string TENSP { get; set; }
        public string NGAYDANG { get; set; }
        public string GIABAN { get; set; }
        public string GIANHAP { get; set; }
        public string MANCC { get; set; }
        public string MANXB { get; set; }
        public string XUATXU { get; set; }
        public string THUONGHIEU { get; set; }
        public string NGONNGU { get; set; }
        public string KICHTHUOC { get; set; }
        public string SOTRANG { get; set; }
        public string MOTA { get; set; }
        public string DOTUOI { get; set; }
        public string HSD { get; set; }
        public string SLTON { get; set; }
        public string TRONGLUONG { get; set; }
        public string MALOAIMH { get; set; }
        public string MACD { get; set; }
        public string MALCD { get; set; }
        public List<SANPHAM> getData(string sr)
        {
            List<SANPHAM> listBH = new List<SANPHAM>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select DISTINCT  SANPHAM.MASP,SANPHAM.TENSP,GIABAN from SANPHAM Inner join SACHTG on (SACHTG.MASP=SANPHAM.MASP)  Inner join TACGIA on (SACHTG.MATG=SACHTG.MATG)  where (TENSP like N'%" + sr + "%' or SANPHAM.MASP like N'%" + sr + "%' or TENTG like N'%" + sr + "%')  and SANPHAM.disabled=0 union  ALL  select DISTINCT  SANPHAM.MASP,SANPHAM.TENSP,GIABAN from SANPHAM LEFT join SACHTG on (SACHTG.MASP=SANPHAM.MASP) where (TENSP like N'%" + sr + "%' or SANPHAM.MASP like N'%" + sr + "%') and SANPHAM.disabled=0", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SANPHAM emp = new SANPHAM();
                emp.MASP = dr.GetValue(0).ToString();
                emp.TENSP = dr.GetValue(1).ToString();
                emp.GIABAN = dr.GetValue(2).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<SANPHAM> getDataSP(string malcd, int limit)
        {
            List<SANPHAM> listBH = new List<SANPHAM>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select top " + limit + " * from Sanpham,SANPHAMLOAICHUDE where Sanpham.disabled=0 and SANPHAMLOAICHUDE.masp=sanpham.masp and SANPHAMLOAICHUDE.MALOAICD= '" + malcd + "' order by ngaydang", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SANPHAM emp = new SANPHAM();
                emp.MASP = dr.GetValue(0).ToString();
                emp.TENSP = dr.GetValue(1).ToString();
                emp.GIABAN = dr.GetValue(3).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<SANPHAM> getDataSP2(string malcd, int limit, int limit2)
        {
            List<SANPHAM> listBH = new List<SANPHAM>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select* from Sanpham,SANPHAMLOAICHUDE where Sanpham.disabled=0 and SANPHAMLOAICHUDE.masp=sanpham.masp and SANPHAMLOAICHUDE.MALOAICD= '" + malcd + "'  order by ngaydang  OFFSET " + limit + " ROWS FETCH NEXT " + limit2 + " ROWS ONLY", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SANPHAM emp = new SANPHAM();
                emp.MASP = dr.GetValue(0).ToString();
                emp.TENSP = dr.GetValue(1).ToString();
                emp.GIABAN = dr.GetValue(3).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<SANPHAM> getDataCT(string masp)
        {
            List<SANPHAM> listBH = new List<SANPHAM>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from Sanpham where masp='" + masp + "' and disabled=0", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SANPHAM emp = new SANPHAM();
                emp.MASP = dr.GetValue(0).ToString();
                emp.TENSP = dr.GetValue(1).ToString();
                emp.GIABAN = dr.GetValue(3).ToString();
                emp.MANCC = dr.GetValue(5).ToString();
                emp.MANXB = dr.GetValue(6).ToString();
                emp.XUATXU = dr.GetValue(7).ToString();
                emp.THUONGHIEU = dr.GetValue(8).ToString();
                emp.NGONNGU = dr.GetValue(9).ToString();
                emp.KICHTHUOC = dr.GetValue(10).ToString();
                emp.SOTRANG = dr.GetValue(11).ToString();
                emp.MOTA = dr.GetValue(12).ToString();
                emp.DOTUOI = dr.GetValue(13).ToString();
                emp.SLTON = dr.GetValue(15).ToString();
                emp.TRONGLUONG = dr.GetValue(16).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<SANPHAM> getDataMuaN1()
        {
            List<SANPHAM> listBH = new List<SANPHAM>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select Top 4 SANPHAM.MASP,TenSp,GIABAN  from SanPham,DONHANGCT where SANPHAM.MASP=DONHANGCT.MASP and disabled=0  group by SANPHAM.MASP,TenSp,GIABAN having SUM(DONHANGCT.SL)>=10 order by SANPHAM.MASP,TenSp,GIABAN ", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SANPHAM emp = new SANPHAM();
                emp.MASP = dr.GetValue(0).ToString();
                emp.TENSP = dr.GetValue(1).ToString();
                emp.GIABAN = dr.GetValue(2).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<SANPHAM> getDataMuaN2()
        {
            List<SANPHAM> listBH = new List<SANPHAM>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select SANPHAM.MASP,TenSp,GIABAN  from SanPham,DONHANGCT where SANPHAM.MASP=DONHANGCT.MASP and disabled=0  group by SANPHAM.MASP,TenSp,GIABAN  having Sum(DONHANGCT.SL)>=10 order by SANPHAM.MASP,TenSp,GIABAN OFFSET 5 ROWS FETCH NEXT 4 ROWS ONLY", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SANPHAM emp = new SANPHAM();
                emp.MASP = dr.GetValue(0).ToString();
                emp.TENSP = dr.GetValue(1).ToString();
                emp.GIABAN = dr.GetValue(2).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<SANPHAM> getDataMuaLQ1(string listLoaiCD)
        {
            List<SANPHAM> listBH = new List<SANPHAM>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select Top 6 *  from SanPham,sanphamloaichude where sanpham.masp = sanphamloaichude.masp and maloaicd IN (" + listLoaiCD + ") and SanPham.disabled=0 ORDER BY RAND() ", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SANPHAM emp = new SANPHAM();
                emp.MASP = dr.GetValue(0).ToString();
                emp.TENSP = dr.GetValue(1).ToString();
                emp.GIABAN = dr.GetValue(3).ToString();
                listBH.Add(emp);
            }
            return listBH;
        }
        public IEnumerable<SANPHAM> getDataLMH(int page, int pagesize, string maloai)
        {
            List<SANPHAM> listBH = new List<SANPHAM>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select DISTINCT SANPHAM.MASP,SANPHAM.TENSP,GIABAN,LOAIMATHANG.MALOAI from SANPHAM Inner join SANPHAMLOAICHUDE on (SANPHAM.MASP=SANPHAMLOAICHUDE.MASP) Inner join LOAICHUDE on (LOAICHUDE.MALOAICD=SANPHAMLOAICHUDE.MALOAICD) Inner join CHUDE on (CHUDE.MACD=LOAICHUDE.MACD) Inner join LOAIMATHANG on (LOAIMATHANG.MALOAI=CHUDE.MALOAI)  where LOAIMATHANG.MALOAI='" + maloai + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SANPHAM emp = new SANPHAM();
                emp.MASP = dr.GetValue(0).ToString();
                emp.TENSP = dr.GetValue(1).ToString();
                emp.GIABAN = dr.GetValue(2).ToString();
                emp.MALOAIMH = dr.GetValue(3).ToString();
                listBH.Add(emp);
            }
            return listBH.OrderBy(x => x.MASP).ToPagedList(page, pagesize);
        }
        public IEnumerable<SANPHAM> getDataCD(int page, int pagesize, string MACD)
        {
            List<SANPHAM> listBH = new List<SANPHAM>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select DISTINCT SANPHAM.MASP,SANPHAM.TENSP,GIABAN,CHUDE.MACD from SANPHAM Inner join SANPHAMLOAICHUDE on (SANPHAM.MASP=SANPHAMLOAICHUDE.MASP) Inner join LOAICHUDE on (LOAICHUDE.MALOAICD=SANPHAMLOAICHUDE.MALOAICD) Inner join CHUDE on (CHUDE.MACD=LOAICHUDE.MACD) where CHUDE.MACD='" + MACD + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SANPHAM emp = new SANPHAM();
                emp.MASP = dr.GetValue(0).ToString();
                emp.TENSP = dr.GetValue(1).ToString();
                emp.GIABAN = dr.GetValue(2).ToString();
                emp.MACD = dr.GetValue(3).ToString();
                listBH.Add(emp);
            }
            return listBH.OrderBy(x => x.MASP).ToPagedList(page, pagesize);
        }
        public IEnumerable<SANPHAM> getDataLCD(int page, int pagesize, string MALCD)
        {
            List<SANPHAM> listBH = new List<SANPHAM>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select DISTINCT SANPHAM.MASP,SANPHAM.TENSP,GIABAN,LOAICHUDE.MALOAICD from SANPHAM Inner join SANPHAMLOAICHUDE on (SANPHAM.MASP=SANPHAMLOAICHUDE.MASP) Inner join LOAICHUDE on (LOAICHUDE.MALOAICD=SANPHAMLOAICHUDE.MALOAICD) where LOAICHUDE.MALOAICD='" + MALCD + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SANPHAM emp = new SANPHAM();
                emp.MASP = dr.GetValue(0).ToString();
                emp.TENSP = dr.GetValue(1).ToString();
                emp.GIABAN = dr.GetValue(2).ToString();
                emp.MALCD = dr.GetValue(3).ToString();
                listBH.Add(emp);
            }
            return listBH.OrderBy(x => x.MASP).ToPagedList(page, pagesize);
        }
    }
}