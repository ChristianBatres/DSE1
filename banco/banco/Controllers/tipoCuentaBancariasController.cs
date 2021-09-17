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
    public class tipoCuentaBancariasController : Controller
    {
        private sistemabancario db = new sistemabancario();

        // GET: tipoCuentaBancarias
        public ActionResult Index()
        {
            return View(db.tipoCuentaBancaria.ToList());
        }

        // GET: tipoCuentaBancarias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoCuentaBancaria tipoCuentaBancaria = db.tipoCuentaBancaria.Find(id);
            if (tipoCuentaBancaria == null)
            {
                return HttpNotFound();
            }
            return View(tipoCuentaBancaria);
        }

        // GET: tipoCuentaBancarias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipoCuentaBancarias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,tipo,Activo")] tipoCuentaBancaria tipoCuentaBancaria)
        {
            if (ModelState.IsValid)
            {
                db.tipoCuentaBancaria.Add(tipoCuentaBancaria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoCuentaBancaria);
        }

        // GET: tipoCuentaBancarias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoCuentaBancaria tipoCuentaBancaria = db.tipoCuentaBancaria.Find(id);
            if (tipoCuentaBancaria == null)
            {
                return HttpNotFound();
            }
            return View(tipoCuentaBancaria);
        }

        // POST: tipoCuentaBancarias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,tipo,Activo")] tipoCuentaBancaria tipoCuentaBancaria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoCuentaBancaria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoCuentaBancaria);
        }

        // GET: tipoCuentaBancarias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoCuentaBancaria tipoCuentaBancaria = db.tipoCuentaBancaria.Find(id);
            if (tipoCuentaBancaria == null)
            {
                return HttpNotFound();
            }
            return View(tipoCuentaBancaria);
        }

        // POST: tipoCuentaBancarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipoCuentaBancaria tipoCuentaBancaria = db.tipoCuentaBancaria.Find(id);
            db.tipoCuentaBancaria.Remove(tipoCuentaBancaria);
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
