using MyFirstCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace MyFirstCode.Controllers
{
    public class BaseController : Controller
    {
        public MvcFirstCodeContext db
        {
            get
            {
                MvcFirstCodeContext db = CallContext.GetData("DB") as MvcFirstCodeContext;
                if (db == null)
                {
                    db = new MvcFirstCodeContext();
                    CallContext.SetData("DB", db);
                }
                return db;
            }
        }
    }
}
