using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace MvcWep.Models
{
    //public class Data
    //{
    //    public Veriler Veri { get; set; }
    //}
    public class DataContext : DbContext
    {
        public DbSet<Veriler> VeriContext { get; set; }
    }
}