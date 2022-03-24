using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

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
        public List<SANPHAM> getData(string sr)
        {
            List<SANPHAM> listBH = new List<SANPHAM>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from Sanpham where tensp like N'%" + sr + "%' and trangthai=N'Chưa xóa'", con);
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
        public List<SANPHAM> getDataSP(string malcd,int limit)
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
        public List<SANPHAM> getDataSP2(string malcd, int limit,int limit2)
        {
            List<SANPHAM> listBH = new List<SANPHAM>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select* from Sanpham,SANPHAMLOAICHUDE where Sanpham.disabled=0 and SANPHAMLOAICHUDE.masp=sanpham.masp and SANPHAMLOAICHUDE.MALOAICD= '" + malcd + "'  order by ngaydang  OFFSET "+limit+" ROWS FETCH NEXT "+limit2+" ROWS ONLY", con);
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
         public List<SANPHAM> getDataCT(string masp)
        {
            List<SANPHAM> listBH = new List<SANPHAM>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from Sanpham where masp='"+masp+"' and disabled=0", con);
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
    }
}