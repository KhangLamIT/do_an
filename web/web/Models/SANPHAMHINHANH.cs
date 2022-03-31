using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace web.Models
{
    public class SANPHAMHINHANH
    {
        public string conf = "Data Source=KID;Initial Catalog=QL_NhaSach;User ID=sa";
        public string ID { get; set; }
        public string HINH { get; set; }
        public List<SANPHAMHINHANH> getData(string masp)
        {
            List<SANPHAMHINHANH> listBH = new List<SANPHAMHINHANH>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select Top 1 * from SANPHAMHINHANH where disabled=0  and masp='" + masp + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SANPHAMHINHANH emp = new SANPHAMHINHANH();
                emp.ID = dr.GetValue(0).ToString();
                emp.HINH = dr.GetValue(2).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<SANPHAMHINHANH> getData2(string masp)
        {
            List<SANPHAMHINHANH> listBH = new List<SANPHAMHINHANH>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from SANPHAMHINHANH where disabled=0  and masp='" + masp + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SANPHAMHINHANH emp = new SANPHAMHINHANH();
                emp.ID = dr.GetValue(0).ToString();
                emp.HINH = dr.GetValue(2).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
    }
}