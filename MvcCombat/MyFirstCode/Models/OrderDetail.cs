using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyFirstCode.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }

        public decimal Price { get; set; }

        public int Count { get; set; }

        /// <summary>
        /// 外键，当属性名和Order主键名称一样，默认会当成外键
        /// </summary>
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}