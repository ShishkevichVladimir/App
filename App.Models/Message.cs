using System;

namespace App.Models
{
    public class Message
    {
        public Message()
        {
            CreatedDate = DateTime.Now;
        }

        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
