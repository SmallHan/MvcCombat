using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace MvcModelApp
{
    public class EmailAttribute:RegularExpressionAttribute
    {
        public EmailAttribute():base(@"^\w+([-=.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")
        {
 
        }
    }
    [MetadataType(typeof(UserMetadate))]
    public partial class tb_User
    {
        public string RePwd { get; set; }
    }
    public class UserMetadate
    {
        [DisplayName("用户名")]
        [Remote("NotExitesUserName", "Home")]
        public string UserName { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayName("备注")]
        public string Remark { get; set; }
        [DisplayName("年龄")]
        [Range(1, 120)]
        public int Age { get; set; }
        [PasswordPropertyText]
        [DisplayName("密码")]
        public string Pwd { get; set; }
        [PasswordPropertyText]
        [DisplayName("重输密码")]
        [System.Web.Mvc.Compare("Pwd")]
        public string RePwd { get; set; }
        [Email]
        public string Email { get; set; }
    }
}