using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyProject.Core.Models;

namespace MyProject.Core
{
    public class ApplicationContext : DbContext
    {
        public DbSet<CategoryModel> Categorys { get; set; } = null!;
        public DbSet<GoodModel> Goods { get; set; } = null!;

        public ApplicationContext()
        {
            //Database.EnsureDeleted();   // удаляем бд со старой схемой
            //Database.EnsureCreated();   // создаем бд с новой схемой
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=helloapp.db");
        }
    }
}
