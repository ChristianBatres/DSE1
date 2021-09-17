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
    public class cuentaBancariasController : Controller
    {
        private sistemabancario db = new sistemabancario();

        // GET: cuentaBancarias
        public ActionResult Index()
        {
            return View(db.cuentaBancaria.ToList());
        }

        // GET: cuentaBancarias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cuentaBancaria cuentaBancaria = db.cuentaBancaria.Find(id);
            if (cuentaBancaria == null)
            {
                return HttpNotFound();
            }
            return View(cuentaBancaria);
        }

        // GET: cuentaBancarias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cuentaBancarias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cliente_id,Moneda,tipo_id")] cuentaBancaria cuentaBancaria)
        {
            if (ModelState.IsValid)
            {
                db.cuentaBancaria.Add(cuentaBancaria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cuentaBancaria);
        }

        // GET: cuentaBancarias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cuentaBancaria cuentaBancaria = db.cuentaBancaria.Find(id);
            if (cuentaBancaria == null)
            {
                return HttpNotFound();
            }
            return View(cuentaBancaria);
        }

        // POST: cuentaBancarias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cliente_id,Moneda,tipo_id")] cuentaBancaria cuentaBancaria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuentaBancaria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cuentaBancaria);
        }

        // GET: cuentaBancarias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cuentaBancaria cuentaBancaria = db.cuentaBancaria.Find(id);
            if (cuentaBancaria == null)
            {
                return HttpNotFound();
            }
            return View(cuentaBancaria);
        }

        // POST: cuentaBancarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cuentaBancaria cuentaBancaria = db.cuentaBancaria.Find(id);
            db.cuentaBancaria.Remove(cuentaBancaria);
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
