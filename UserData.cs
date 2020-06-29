using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class UserData
    {
        [Key]
        public int ID { get; set; }
        public string Login { get; set; }
        public int PasswordHashCode { get; set; }   

        public UserData(int Id, string login, int passwordHash)
        {
            ID = Id;
            Login = login;
            PasswordHashCode = passwordHash;
        }
    }
}
