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

namespace ChampSupermarket.Controllers
{
    public class SuplierController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: /Suplier/
        public ActionResult Index()
        {
            return View(db.supliers.ToList());
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
