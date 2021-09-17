using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using banco.Models;

namespace banco.Controllers
{
    public class tipoTransaccionsController : Controller
    {
        private sistemabancario db = new sistemabancario();

        // GET: tipoTransaccions
        public ActionResult Index()
        {
            return View(db.tipoTransaccion.ToList());
        }

        // GET: tipoTransaccions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoTransaccion tipoTransaccion = db.tipoTransaccion.Find(id);
            if (tipoTransaccion == null)
            {
                return HttpNotFound();
            }
            return View(tipoTransaccion);
        }

        // GET: tipoTransaccions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipoTransaccions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,tipo")] tipoTransaccion tipoTransaccion)
        {
            if (ModelState.IsValid)
            {
                db.tipoTransaccion.Add(tipoTransaccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoTransaccion);
        }

        // GET: tipoTransaccions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoTransaccion tipoTransaccion = db.tipoTransaccion.Find(id);
            if (tipoTransaccion == null)
            {
                return HttpNotFound();
            }
            return View(tipoTransaccion);
        }

        // POST: tipoTransaccions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,tipo")] tipoTransaccion tipoTransaccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoTransaccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoTransaccion);
        }

        // GET: tipoTransaccions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoTransaccion tipoTransaccion = db.tipoTransaccion.Find(id);
            if (tipoTransaccion == null)
            {
                return HttpNotFound();
            }
            return View(tipoTransaccion);
        }

        // POST: tipoTransaccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipoTransaccion tipoTransaccion = db.tipoTransaccion.Find(id);
            db.tipoTransaccion.Remove(tipoTransaccion);
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
