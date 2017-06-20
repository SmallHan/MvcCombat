using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFirstCode.Models
{

    public class Order
    {
        /// <summary>
        /// 如果属性名后面包含Id，则默认会当成主键，可以不用加[KEY]属性
        /// </summary>
        [Key]
        public int OrderId { get; set; }

        [StringLength(50)]
        public string OrderCode { get; set; }

        public decimal OrderAmouunt { get; set; }

        public virtual List<OrderDetail> OrderDetail { get; set; }

    }
}