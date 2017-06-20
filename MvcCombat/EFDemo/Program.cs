using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Add();
            //QueryDelay1();
            //QueryDelay2();
            //List<Customers> list=GetListBy<string>(o => o.CompanyName == "深圳市XXX软件技术有限公司", o => o.CustomerID);
            //List<Customers> list=GetPageList<string>(1, 10, o => o.CompanyName == "深圳市XXX软件技术有限公司", o => o.CustomerID);
            //Edit();
            //Delete();
            Query1();
            Console.WriteLine("ok");
            Console.ReadKey();

        }
        static int Add()
        {
            int res = 0;
            try
            {
                using (NorthwindEntities db = new NorthwindEntities())
                {

                    Customers customers = new Customers()
                    {
                        CustomerID = "aouqx",
                        Address = "广东省潮州",
                        City = "潮州",
                        Phone = "13168084732",
                        CompanyName = "深圳市XXX软件技术有限公司",
                        ContactName = "小明"
                    };
                    //方法一
                    db.Customers.Add(customers);

                    //方法二
                    DbEntityEntry<Customers> entry = db.Entry<Customers>(customers);
                    entry.State = EntityState.Added;
                     res = db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
 
            }
            return res;
         
        }
        static void Query1()
        {
            using (var edm = new NorthwindEntities())
            {
                var query=from d in edm.Order_Details
                          join order in edm.Orders
                          on d.OrderID equals order.OrderID
                          select new
                          {
                              OrderId=order.OrderID,
                              ProdcutId=d.ProductID,
                              UnitPrice=d.UnitPrice
                          };
                foreach (var q in query)
                {
                    Console.WriteLine("{0}-{1}-{2}",q.OrderId,q.ProdcutId,q.UnitPrice);
                }
            }
        }
        static void QueryDelay1()
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                DbQuery<Customers> dbQuery = db.Customers.Where(u => u.ContactName.Equals("小明")).OrderBy(u => u.ContactName).Take(1)
                    as DbQuery<Customers>;
                Customers customers = dbQuery.FirstOrDefault();
                Console.WriteLine(customers.ContactName);
            }
        }

        static void QueryDelay2()
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                //真实返回的DbQuery接口
                IQueryable<Orders> order = db.Orders.Where(a => a.CustomerID == "VINET");
                Orders orders = order.FirstOrDefault();
                //当访问订单表的外键实体时,EF会查询订单对应的用户表，查到之后再将数据装入到这个外键实体
                Console.WriteLine(orders.Customers.ContactName);
                IQueryable<Orders> orderList = db.Orders;
                foreach (var o in orderList)
                {
                    Console.WriteLine(o.OrderID+"           "+o.Customers.ContactName);
                }
            }
        }
        /// <summary>
        /// 根据条件排序和查询
        /// </summary>
        /// <typeparam name="TKey">排序字段类型</typeparam>
        /// <param name="whereLambda">查询条件 lambda表达式</param>
        /// <param name="orderLambda">排序条件 lambda表达式</param>
        /// <returns></returns>
        static List<Customers> GetListBy<TKey>(Expression<Func<Customers, bool>> whereLambda, Expression<Func<Customers, TKey>> orderLambda)
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                return db.Customers.Where(whereLambda).OrderBy(orderLambda).ToList();
            }
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="whereLambda">条件Lamdba表达式</param>
        /// <param name="orderBy">排序Lambda表达式</param>
        /// <returns></returns>
        static List<Customers> GetPageList<TKey>(int pageIndex, int pageSize, Expression<Func<Customers, bool>> whereLambda, Expression<Func<Customers, TKey>> orderBy)
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                //db.Customers.Select(o => o).OrderBy(p=>p.CustomerID);
                return db.Customers.Where(whereLambda).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        static void Edit()
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                Customers customers = db.Customers.Where(u => u.CustomerID == "aouqj").FirstOrDefault();
                Console.WriteLine(string.Format("修改前的值:{0}",customers.CompanyName));
                customers.CompanyName = "深圳市JJJ软件技术有限公司";
                db.SaveChanges();
                Console.WriteLine("修改成功");
                Console.WriteLine(customers.CompanyName);
            }
        }
        static void Delete()
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                Customers customers = new Customers() { CustomerID = "aouqj" };
                //附加到EF中
                db.Customers.Attach(customers);
                db.Customers.Remove(customers);
                db.SaveChanges();
                Console.WriteLine("删除成功");
            }
        }
    }
}
