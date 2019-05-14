using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string NameProduct { get; set; }
        public int Qty { get; set; }
        public int Amount { get; set; }
        public string Img { get; set; }

        //[ForeignKey("CreatedBy")]
        //public string CreatedById { get; set; }

        //public ApplicationUser CreatedBy { get; set; }

       
    }
}
