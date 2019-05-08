using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Model;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class MyContext: IdentityDbContext<ApplicationUser>
    {
        public MyContext(DbContextOptions<MyContext> options)
           : base(options)
        {
        }
        public DbSet<Product> Product { get; set; }
    }
}
