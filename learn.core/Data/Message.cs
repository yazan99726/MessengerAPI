using Messenger.core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace learn.core.Data
{
    public class Message
    {
        public int MessageId { get; set; }
        public int SenderId { get; set; }
        public string Text { get; set; }
        public DateTime MessageDate { get; set; }
        public int MessageGroupId { get; set; }
        public string MessageType { get; set; }
        [ForeignKey("MessageGroupId")]
        public virtual MessageGroup MessageGroup { get; set; }

        public virtual Userr User { get; set; }
    }
}
