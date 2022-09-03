using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AppWithRegistration
{
    class AppContext : DbContext            //подключение к субд
    {

        public DbSet<Registrater> Registraters { get; set; }                      //список элементов из таблицы

        public AppContext() : base("DefaultConnection") { }

    }
}
