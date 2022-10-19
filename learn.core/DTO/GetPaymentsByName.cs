using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.core.DTO
{
    public class GetPaymentsByName
    {
        public int Paymentid { get; set; }
        public DateTime Paymentdate { get; set; }
        public int? User_Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string userName { get; set; }
        public int? ServiceId { get; set; }
        public string Servicename { get; set; }
        public decimal Preprice { get; set; }
        public decimal Saleprice { get; set; }
        public double Revenue { get; set; }
    }
}
