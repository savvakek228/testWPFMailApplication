using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class MessageData
    {
        [Key]
        public int ID { get; set; }
        public string SenderLogin { get; set; }
        public string MessageText { get; set; }

        public MessageData(int Id, string sender, string message)
        {
            ID = Id;
            SenderLogin = sender;
            MessageText = message;
        }

        public MessageData()
        {}
    }
}
