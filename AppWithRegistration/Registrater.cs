using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWithRegistration
{
    class Registrater
    {

        public int id { get; set; }                     //создание полей-столбцов из таблицы

        private string login, pass, email;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }

       public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public Registrater() { }                                //конструктор по умолчанию

        public Registrater(string login, string pass, string email) //конструктор для полей выше-столбцов
        {
            this.login = login;
            this.pass = pass;
            this.email = email;
        }

    }
}
