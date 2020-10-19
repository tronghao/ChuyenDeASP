using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppMVCStudy.Models;

namespace AppMVCStudy.Controllers
{
    public class CategoryOfProductController : Controller
    {
        private ProductDBContext db = new ProductDBContext();

        // GET: /CategoryOfProduct/
        public ActionResult Index()
        {
            return View(db.CategoryOfProduct.ToList());
        }

        // GET: /CategoryOfProduct/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryOfProduct categoryofproduct = db.CategoryOfProduct.Find(id);
            if (categoryofproduct == null)
            {
                return HttpNotFound();
            }
            return View(categoryofproduct);
        }

        // GET: /CategoryOfProduct/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /CategoryOfProduct/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CategoryOfProductId,Description")] CategoryOfProduct categoryofproduct)
        {
            if (ModelState.IsValid)
            {
                db.CategoryOfProduct.Add(categoryofproduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoryofproduct);
        }

        // GET: /CategoryOfProduct/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryOfProduct categoryofproduct = db.CategoryOfProduct.Find(id);
            if (categoryofproduct == null)
            {
                return HttpNotFound();
            }
            return View(categoryofproduct);
        }

        // POST: /CategoryOfProduct/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CategoryOfProductId,Description")] CategoryOfProduct categoryofproduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoryofproduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoryofproduct);
        }

        // GET: /CategoryOfProduct/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryOfProduct categoryofproduct = db.CategoryOfProduct.Find(id);
            if (categoryofproduct == null)
            {
                return HttpNotFound();
            }
            return View(categoryofproduct);
        }

        // POST: /CategoryOfProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoryOfProduct categoryofproduct = db.CategoryOfProduct.Find(id);
            db.CategoryOfProduct.Remove(categoryofproduct);
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
