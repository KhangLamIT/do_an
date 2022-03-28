using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;
namespace web.Controllers
{
    public class THANHTOANController : Controller
    {
        //
        // GET: /THANHTOAN/

        public ActionResult THANHTOAN()
        {
            if (Session["GH"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult THANHTOAN(string thanhtoan, string km, string txt_km, string hoten, string email, string sdt, string tp, string qh, string ph, string td)
        {
            if (!string.IsNullOrEmpty(km))
            {
                KHUYENMAI km1 = new KHUYENMAI();
                var menu = km1.getData(txt_km);
                int dem = 0;
                foreach (var item in menu)
                {
                    dem++;
                    if (DateTime.Parse(item.NGAYBD) <= DateTime.Now && DateTime.Parse(item.NGAYKT) >= DateTime.Now)
                    {
                        Session["HTKM"] = item.HINHTHUCKM;
                        Session["KM"] = item.ST;
                        ViewBag.TT = item.ST;
                        ViewBag.HTKM = item.HINHTHUCKM;
                    }
                    if (DateTime.Parse(item.NGAYBD) > DateTime.Now)
                    {
                        ViewBag.TB = "Mã khuyến mãi bắt đầu từ ngày " + item.NGAYBD + " đến " + item.NGAYKT;
                    }
                    if (DateTime.Parse(item.NGAYKT) < DateTime.Now)
                    {
                        ViewBag.TB = "Mã khuyến mãi đã kết thúc từ ngày " + item.NGAYKT;
                    }
                }
                if (dem == 0)
                {
                    ViewBag.TB = "Mã khuyến mãi không đúng";
                }
            }
            if (!string.IsNullOrEmpty(thanhtoan))
            {
                DONHANG hd = new DONHANG();
                if ((Boolean)Session["log"] == false)
                {
                    int kq = 0;
                    if (Session["KM"] != null)
                    {
                        kq = hd.them(hoten, email, sdt, td, ph, tp, qh, Session["KM"].ToString());
                    }
                    else
                    {
                        kq = hd.them2(hoten, email, sdt, td, ph, tp, qh);
                    }
                   
                    if (kq != 0)
                    {
                        var menu = Session["GH"] as List<GIOHANG>;
                        foreach (var item in menu)
                        {
                            SANPHAM sp = new SANPHAM();
                            var menu2 = sp.getDataCT(item.ID);
                            foreach (var item2 in menu2)
                            {
                                int tt = item.SL * int.Parse(item2.GIABAN);
                                int kq1 = hd.CT(item.ID, item.SL, tt);
                                if (kq1 != 0)
                                {
                                    int kq3 = hd.update(item.ID);
                                    if (kq3 != 0)
                                    {
                                        if (Session["KM"] != null)
                                        {
                                            int kq4 = hd.update2(int.Parse(Session["KM"].ToString()));
                                        }
                                        Session["KM"] = null;
                                        Session["GH"] = null;
                                        return RedirectToAction("HOADON", "HOADON");
                                    }
                                }
                            }
                        }

                    }
                }
                else
                {
                    KHACHHANG m = new KHACHHANG();
                    var kh = m.getData(Session["Email"].ToString());
                    int ma = 0;
                    foreach (var item in kh)
                    {
                        ma = item.ID;
                    }
                    int kq = 0;
                    if (Session["KM"] != null)
                    {
                        kq = hd.themKH(ma, hoten, email, sdt, td, ph, tp, qh, Session["KM"].ToString());
                    }
                    else
                    {
                        kq = hd.themKH2(ma, hoten, email, sdt, td, ph, tp, qh);
                    }
                    if (kq != 0)
                    {
                        var menu = Session["GH"] as List<GIOHANG>;
                        foreach (var item in menu)
                        {
                            SANPHAM sp = new SANPHAM();
                            var menu2 = sp.getDataCT(item.ID);
                            foreach (var item2 in menu2)
                            {
                                int tt = item.SL * int.Parse(item2.GIABAN);
                                int kq1 = hd.CT(item.ID, item.SL, tt);
                                if (kq1 != 0)
                                {
                                    int kq3 = hd.update(item.ID);
                                    if (kq3 != 0)
                                    {
                                        if (Session["KM"] != null)
                                        {
                                            int kq4 = hd.update2(int.Parse(Session["KM"].ToString()));
                                        }
                                        Session["KM"] = null;
                                        Session["GH"] = null;
                                        return RedirectToAction("HOADON", "HOADON");
                                    }
                                }
                            }
                        }

                    }
                }
            }
            return View();
        }

    }
}
