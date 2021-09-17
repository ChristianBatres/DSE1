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
    public class transaccionsController : Controller
    {
        private sistemabancario db = new sistemabancario();

        // GET: transaccions
        public ActionResult Index()
        {
            var transaccion = db.transaccion.Include(t => t.cuentaBancaria).Include(t => t.tipoTransaccion);
            return View(transaccion.ToList());
        }

        // GET: transaccions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transaccion transaccion = db.transaccion.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            return View(transaccion);
        }

        // GET: transaccions/Create
        public ActionResult Create()
        {
            ViewBag.cuentaBancaria_id = new SelectList(db.cuentaBancaria, "id", "Moneda");
            ViewBag.tipoTransaccion_id = new SelectList(db.tipoTransaccion, "id", "tipo");
            return View();
        }

        // POST: transaccions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cuentaBancaria_id,tipoTransaccion_id,monto,Estado,fechaTransaccion,fechaAplicacion")] transaccion transaccion)
        {
            if (ModelState.IsValid)
            {
                db.transaccion.Add(transaccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cuentaBancaria_id = new SelectList(db.cuentaBancaria, "id", "Moneda", transaccion.cuentaBancaria_id);
            ViewBag.tipoTransaccion_id = new SelectList(db.tipoTransaccion, "id", "tipo", transaccion.tipoTransaccion_id);
            return View(transaccion);
        }

        // GET: transaccions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transaccion transaccion = db.transaccion.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.cuentaBancaria_id = new SelectList(db.cuentaBancaria, "id", "Moneda", transaccion.cuentaBancaria_id);
            ViewBag.tipoTransaccion_id = new SelectList(db.tipoTransaccion, "id", "tipo", transaccion.tipoTransaccion_id);
            return View(transaccion);
        }

        // POST: transaccions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cuentaBancaria_id,tipoTransaccion_id,monto,Estado,fechaTransaccion,fechaAplicacion")] transaccion transaccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cuentaBancaria_id = new SelectList(db.cuentaBancaria, "id", "Moneda", transaccion.cuentaBancaria_id);
            ViewBag.tipoTransaccion_id = new SelectList(db.tipoTransaccion, "id", "tipo", transaccion.tipoTransaccion_id);
            return View(transaccion);
        }

        // GET: transaccions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transaccion transaccion = db.transaccion.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            return View(transaccion);
        }

        // POST: transaccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            transaccion transaccion = db.transaccion.Find(id);
            db.transaccion.Remove(transaccion);
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
