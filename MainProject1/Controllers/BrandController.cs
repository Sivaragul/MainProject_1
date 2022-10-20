using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL_Library;
using Helper_Library;
using MainProject1.Models;

namespace MainProject1.Controllers
{
    public class BrandController : Controller
    {
        // GET: Brand
        brandmethods ms = null;

        public BrandController()
        {
            ms = new brandmethods();
        }
        public List<LapModel> ls()
        {
            List<LapModel> ls = new List<LapModel>();
            List<lapbrand> kl = ms.listallbrands();
            foreach (var item in kl)
            {
                ls.Add(new LapModel
                {
                    lapid = item.brandid,
                    lapname = item.brandname

                });
            }
            return ls;
        }
        public ActionResult Index()
        {
            List<LapModel> kt = ls();
            return View(kt);
        }

        public ActionResult Details(int id)
        {
            lapbrand ts = ms.findbrand(id);
            LapModel m = new LapModel();
            m.lapid = ts.brandid;
            m.lapname = ts.brandname;
            return View(m);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Brand/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                lapbrand m = new lapbrand();
                m.brandid = Convert.ToInt32(Request["lapid"]);
                m.brandname = Request["lapname"].ToString();
                bool k = ms.addbrand(m);
                if (k)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            lapbrand m = ms.findbrand(id);
            LapModel t = new LapModel();
            t.lapid = m.brandid;
            t.lapname = m.brandname;
            return View(t);
        }

        // POST: Brand/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                lapbrand m = new lapbrand();
                m.brandid = Convert.ToInt32(Request["lapid"]);
                m.brandname = Request["lapname"].ToString();
                bool k = ms.editbrand(id, m);
                if (k)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }

        }


        public ActionResult Delete(int id)
        {
            lapbrand m = ms.findbrand(id);
            LapModel t = new LapModel();
            t.lapid = m.brandid;
            t.lapname = m.brandname;
            return View(t);
        }

        // POST: Brand/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                int m = id;
                bool t = ms.removebrand(m);
                if (t)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

    }
}