using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Data
{
    public class Services
    {
        public int Serviceid { get; set; }
        public string Servicename { get; set; }
        public decimal Preprice { get; set; }
        public decimal Saleprice { get; set; }

        public virtual ICollection<Payments> Payments { get; set; }
    }
}
