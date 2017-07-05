using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAppPager.Models
{
    public class Order
    {
        public int ID { get; set; }
        public string OrderNo { get; set; }
        public decimal WayFee { get; set; }
        public string EMS { get; set; }
    }
}