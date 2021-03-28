using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Db {
    public class MysqlDbContext : DbContext {
        public DbSet<Waifu> Waifus;

        public MysqlDbContext() : base() {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseMySQL("server=localhost;database=library;user=user;password=password");
        }
    }
}
