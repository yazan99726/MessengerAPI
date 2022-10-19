using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.core.DTO
{
    public class GetTestimonialByUserName
    {
        public int TestId { get; set; }
        public string Message { get; set; }
        public int status { get; set; }
        public DateTime publishDate { get; set; }
        public int userId { get; set; }
        public string UserName { get; set; }
    }
}
