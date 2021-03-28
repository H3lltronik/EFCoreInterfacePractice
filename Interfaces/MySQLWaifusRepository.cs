using ConsoleApp1.Db;
using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interfaces {
    class MySQLWaifusRepository : IWaifusRepository {
        //docker run --name waifus-mysql -e MYSQL_ROOT_PASSWORD = secret - d - p 3307:3306 mysql
        public MysqlDbContext MysqlDbContext;

        public MySQLWaifusRepository() {
            MysqlDbContext = new();
        }

        public void CreateWaifu(Waifu waifu) {
            this.MysqlDbContext.Add(waifu);
            this.MysqlDbContext.SaveChanges();
        }

        public List<Waifu> GetWaifus() {
            IQueryable<Waifu> rtn = from temp in this.MysqlDbContext.Waifus select temp;
            return rtn.ToList();
        }
    }
}
