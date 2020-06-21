using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class UserDataContext : DbContext
    {
        public UserDataContext() : base("UserDataConnection")
        { }
        public DbSet<UserData> userDatas { get;set; }
    }
}
