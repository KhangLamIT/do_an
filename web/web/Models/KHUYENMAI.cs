using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace web.Models
{
    public class KHUYENMAI
    {
        string conf = "Data Source=KID;Initial Catalog=QL_NhaSach;User ID=sa";
        public string ID { get; set; }
        public string ST { get; set; }
        public string NGAYBD { get; set; }
        public string NGAYKT { get; set; }
        public string HINHTHUCKM { get; set; }
        public List<KHUYENMAI> getData(string sr)
        {
            List<KHUYENMAI> listBH = new List<KHUYENMAI>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from KHUYENMAI where makm='" + sr + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                KHUYENMAI emp = new KHUYENMAI();
                emp.ID = dr.GetValue(0).ToString();
                emp.ST = dr.GetValue(1).ToString();
                emp.NGAYBD = dr.GetValue(2).ToString();
                emp.NGAYKT = dr.GetValue(3).ToString();
                emp.HINHTHUCKM = dr.GetValue(9).ToString();
                listBH.Add(emp);
            }
            return listBH;
        }
    }
}