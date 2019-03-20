using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using MvcWep.Models;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

namespace MvcWep.Controllers
{
    
    public class HomeController : Controller
    {
        SqlDataReader oku;
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-V5FHF02\\SQLEXPRESS;Initial Catalog=Verilier;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlCommand komut = new SqlCommand();
        DataContext dataContext = new DataContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult UyeEkle(Veriler model)
        {
            if(model.Name==null&&model.Email==null&&model.Tel==null&&model.Password==null&&model.Password2==null)
            {
                ViewBag.Mesaj = "Tüm alanları doldurun";
                return View("UyeEkle");
            }
            if(ModelState.IsValid)
            {
                if(model.Password!=model.Password2)
                {
                    ViewBag.Uyari ="Şifreler Uyuşmuyor";
                }
                else
                {
                    baglan.Open();                  
                    komut = new SqlCommand("INSERT INTO Veriler(Name,Email,Tel,Password,Password2) VALUES('"+model.Name+ "','" + model.Email + "','" + model.Tel + "','" + model.Password + "','" + model.Password2 + "')", baglan);                  
                    komut.Parameters.AddWithValue("Name",model.Name);
                    komut.Parameters.AddWithValue("Email", model.Email);
                    komut.Parameters.AddWithValue("Tel", model.Tel);                  
                    komut.Parameters.AddWithValue("Password", model.Password);
                    komut.Parameters.AddWithValue("Password2", model.Password2);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    return View("Giris");
                }
            }
            return View();
        }
        public  ActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(Veriler model)
        {
            if (model.Email == null && model.Password == null)
            {
                return View("Index");
            }
            if(ModelState.IsValid)
            baglan.Open();
            komut.Connection=baglan;
            komut.CommandText= "SELECT*FROM Veriler WHERE Email='" + model.Email + "' AND Password='" + model.Password + "'";
            oku = komut.ExecuteReader();
            if(oku.Read())
            {
                return View("Giris");
            }
            baglan.Close();
            
            return View("Index");
        }
        [HttpPost]
        public ActionResult Contact(Veriler model)
        {
            if (model.Name == null && model.Email == null && model.Tel == null && model.Yorum == null)
            {
                ModelState.AddModelError("veriler", "Tüm Alanları Doldurun");
            }
            if (ModelState.IsValid)
                baglan.Open();

            string ekle = "INSERT INTO Veriler(Name,Email,Tel,Yorum) VALUES ('" + model.Name + "','" + model.Email + "','" + model.Tel + "','" + model.Yorum + "')";
            SqlCommand komut = new SqlCommand(ekle, baglan);
            komut.Parameters.AddWithValue("Name", model.Name);
            komut.Parameters.AddWithValue("Email", model.Email);
            komut.Parameters.AddWithValue("Tel", model.Tel);
            komut.Parameters.AddWithValue("Yorum", model.Yorum);
            komut.ExecuteNonQuery();
            baglan.Close();
            ViewBag.Mesaj = "Gönderme İşlemi Başarılı";
            return View();
        }                                         
        
        public ActionResult Hizmet()
        {
            return View();
        }
        public ActionResult Urun()
        {
            return View();
        }
    }
};