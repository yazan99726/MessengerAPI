using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.core.DTO
{
    public class SearchMessageBetweenDate
    {
        public int messageGroupId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
