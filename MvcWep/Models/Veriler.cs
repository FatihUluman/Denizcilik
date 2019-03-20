using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcWep.Models
{
    [Table("Veriler")]
    public class Veriler
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Yorum { get; set; }
        public string Password { get; set; }
        public string Password2 { get; set; }


    }
}