using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class MessageDataContext : DbContext
    {
        public MessageDataContext() : base("MessageDataConnection")
            {}
        public DbSet<MessageData> messageDatas { get; set; }
    }
}
