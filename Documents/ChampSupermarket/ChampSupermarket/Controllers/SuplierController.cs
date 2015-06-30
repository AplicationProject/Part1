using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ChampSupermarket.Models;
using ChampSupermarket.DAL;
using PagedList;

namespace ChampSupermarket.Controllers
{
    public class SuplierController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: /Suplier/
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.IDSortParm = String.IsNullOrEmpty(sortOrder) ? "Phone_desc" : "";
            //ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var supliers = from s in db.supliers
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                supliers = supliers.Where(s => s.SuplierName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    supliers = supliers.OrderByDescending(s => s.SuplierName);
                    break;
                case "Phone_desc":
                    supliers = supliers.OrderBy(s => s.Phone);
                    break;
               /* case "date_desc":
                    supliers = supliers.OrderByDescending(s => s.);
                    break;*/
                default:
                    supliers = supliers.OrderBy(s => s.SuplierID);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(supliers.ToPagedList(pageNumber, pageSize));
        }

        // GET: /Suplier/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suplier suplier = db.supliers.Find(id);
            if (suplier == null)
            {
                return HttpNotFound();
            }
            return View(suplier);
        }

        // GET: /Suplier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Suplier/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="SuplierID,SuplierName,Adress,Phone")] Suplier suplier)
        {
            if (ModelState.IsValid)
            {
                db.supliers.Add(suplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(suplier);
        }

        // GET: /Suplier/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suplier suplier = db.supliers.Find(id);
            if (suplier == null)
            {
                return HttpNotFound();
            }
            return View(suplier);
        }

        // POST: /Suplier/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="SuplierID,SuplierName,Adress,Phone")] Suplier suplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suplier);
        }

        // GET: /Suplier/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suplier suplier = db.supliers.Find(id);
            if (suplier == null)
            {
                return HttpNotFound();
            }
            return View(suplier);
        }

        // POST: /Suplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Suplier suplier = db.supliers.Find(id);
            db.supliers.Remove(suplier);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
