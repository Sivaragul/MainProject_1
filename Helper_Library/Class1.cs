using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Library;

namespace Helper_Library
{
        public class brandmethods
        {
            LaptopStoresEntities context = null;
            public brandmethods()
            {
                context = new LaptopStoresEntities();
            }
            public bool addbrand(lapbrand q)
            {
                try
                {
                    context.lapbrands.Add(q);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    return false;
                }
            }
            public bool removebrand(int id)
            {
                try
                {
                    lapbrand k = context.lapbrands.Find(id);
                    context.lapbrands.Remove(k);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    return false;
                }
            }
            public lapbrand findbrand(int id)
            {
                return context.lapbrands.Find(id);
            }
            public List<lapbrand> listallbrands()
            {
                return context.lapbrands.ToList();
            }
            public bool editbrand(int id, lapbrand p)
            {
                try
                {
                    lapbrand p1 = context.lapbrands.Find(id);
                    p1.brandid = p.brandid;
                    p1.brandname = p.brandname;
                    context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public class loginmethods
        {
            LaptopStoresEntities context = null;
            public loginmethods()
            {
                context = new LaptopStoresEntities();
            }
            public bool addlogin(logintable t)
            {
                try
                {
                    context.logintables.Add(t);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    return false;
                }
            }
            public bool checklogin(logintable t)
            {

                List<logintable> list = context.logintables.ToList();
                bool k = false;
                foreach (var item in list)
                {
                    if (t.customerid == item.customerid && t.customername == item.customername)
                    {
                        k = true;
                    }
                }
                return k;

            }

        }
        public class ordermethods
        {
            LaptopStoresEntities context = null;
            public ordermethods()
            {
                context = new LaptopStoresEntities();
            }
            public bool addorder(placedorder p)
            {
                try
                {
                    context.placedorders.Add(p);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    return false;
                }

            }
            public bool removeorder(int id)
            {
                try
                {
                    placedorder pt = context.placedorders.Find(id);
                    context.placedorders.Remove(pt);
                    context.SaveChanges();
                    return true;

                }
                catch
                {
                    return false;
                }
            }
            public List<placedorder> listbycustid(int id)
            {
                List<placedorder> m = context.placedorders.ToList();
                m = m.Where(p => p.customerid == id).ToList();
                return m;
            }


        }
    }

