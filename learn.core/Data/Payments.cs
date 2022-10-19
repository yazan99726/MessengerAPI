using Messenger.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Data
{
    public class Payments
    {
        public int Paymentid { get; set; }
        public DateTime Paymentdate { get; set; }
        public int? UserId { get; set; }
        public int? ServiceId { get; set; }

        public virtual Services Service { get; set; }
        public virtual Userr User { get; set; }
    }
}
