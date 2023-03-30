using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LojaDeReparações.Data;
using LojaDeReparações.Models;

namespace LojaDeReparações.Controllers
{
    [Authorize]
    public class DispositivosController : Controller
    {
        private LojaDeReparacoesContext db = new LojaDeReparacoesContext();

        // GET: Dispositivos
        public ActionResult Index(int? id)
        {
            var dispositivos = db.Dispositivoes.Include(d => d.utilizador);
            if (User.IsInRole("Cliente") == true)
                dispositivos = db.Dispositivoes.Where(q => q.IdUtilizador == id);
            return View(dispositivos.ToList());
        }

        // GET: Dispositivos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dispositivo dispositivo = db.Dispositivoes.Where(d => d.Id == id).Include(d => d.utilizador).FirstOrDefault();
            if (dispositivo == null)
            {
                return HttpNotFound();
            }
            return View(dispositivo);
        }

        // GET: Dispositivos/Create
        public ActionResult Create(int? id)
        {
            ViewBag.IdUtilizador = new SelectList(db.Utilizadors, "Id", "Nome");
            if(id != null) 
            {
                ViewBag.IdUtilizador = new SelectList(db.Utilizadors.Where(q=>q.Id == id), "Id", "Nome");
            }

            return View();
        }

        // POST: Dispositivos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdUtilizador,Marca,Problema,Tipo,Estado")] Dispositivo dispositivo)
        {
            if (ModelState.IsValid)
            {
                db.Dispositivoes.Add(dispositivo);
                db.SaveChanges();
                if (User.IsInRole("Cliente") == true)
                    return RedirectToAction("Index/"+dispositivo.IdUtilizador);
                return RedirectToAction("Index");
            }

            ViewBag.IdUtilizador = new SelectList(db.Utilizadors, "Id", "Nome", dispositivo.IdUtilizador);
            return View(dispositivo);
        }

        // GET: Dispositivos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dispositivo dispositivo = db.Dispositivoes.Find(id);
            if (dispositivo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdUtilizador = new SelectList(db.Utilizadors, "Id", "Nome", dispositivo.IdUtilizador);
            return View(dispositivo);
        }

        // POST: Dispositivos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdUtilizador,Marca,Problema,Tipo,Estado")] Dispositivo dispositivo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dispositivo).State = EntityState.Modified;
                db.SaveChanges();
                if (User.IsInRole("Cliente"))
                {
                    return RedirectToAction("Index/"+dispositivo.IdUtilizador);
                }
                return RedirectToAction("Index");
            }
            ViewBag.IdUtilizador = new SelectList(db.Utilizadors, "Id", "Nome", dispositivo.IdUtilizador);
            return View(dispositivo);
        }

        // GET: Dispositivos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dispositivo dispositivo = db.Dispositivoes.Find(id);
            if (dispositivo == null)
            {
                return HttpNotFound();
            }
            return View(dispositivo);
        }

        [Authorize(Roles = "Administrador")]
        // POST: Dispositivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dispositivo dispositivo = db.Dispositivoes.Find(id);
            db.Dispositivoes.Remove(dispositivo);
            db.SaveChanges();
            if (User.IsInRole("Cliente"))
            {
                return RedirectToAction("Index/" + dispositivo.IdUtilizador);
            }
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
