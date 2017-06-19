using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            EFDbEntities entity = new EFDbEntities();
            t_customer customer = new t_customer()
            {
                Adress="东海五彩金轮",
                Age=23,
                UserName="小瀚"
            };
            //构造sql
            entity.t_customer.Add(customer);
            entity.SaveChanges();
            Console.WriteLine("ok");
            Console.ReadKey();
        }
    }
}
