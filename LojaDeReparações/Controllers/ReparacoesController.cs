using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using LojaDeReparações.Data;
using LojaDeReparações.Migrations;
using LojaDeReparações.Models;

namespace LojaDeReparações.Controllers
{
    [Authorize]
    public class ReparacoesController : Controller
    {
        private LojaDeReparacoesContext db = new LojaDeReparacoesContext();

        // GET: Reparacoes
        public ActionResult Index(int? id)
        {
            var reparacaos = db.Reparacaos.Include(r => r.dispositivo).Include(r => r.u).Include(r => r.utilizador);
            if (User.IsInRole("Administrador") == true || User.IsInRole("Funcionário") == true)
            {
                return View(reparacaos.ToList());
            }
            else
            {
                reparacaos = db.Reparacaos.Where(q => q.IdCliente == id).Include(r => r.dispositivo).Include(r => r.u).Include(r => r.utilizador);
                return View(reparacaos.ToList());
            }
        }

        // GET: Reparacoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Reparacao reparacao = db.Reparacaos.Find(id);
            var reparacao = db.Reparacaos.Where(q => q.Id == id).Include(r => r.dispositivo).Include(r => r.u).Include(r => r.utilizador).FirstOrDefault();
            if (reparacao == null)
            {
                return HttpNotFound();
            }
            /*reparacao.Estados = new[]
            {
                new SelectListItem{Value="0", Text="Em Espera" },
                new SelectListItem{Value="1", Text="Em Reparação"},
                new SelectListItem{Value="2", Text="Finalizado"},
                new SelectListItem{Value="3", Text="Sem Concerto"},
            };*/

            return View(reparacao);
        }

        // GET: Reparacoes/Create
        public ActionResult Create()
        {
            if (User.IsInRole("Cliente"))
            {
                return HttpNotFound();
            }
            ViewBag.IdDispositivo = new SelectList(db.Dispositivoes.Where(q => q.Estado == false), "Id", "Marca");
            ViewBag.IdFuncionario = new SelectList(db.Utilizadors.Where(q => q.Perfil == 1 && q.Estado == true), "Id", "Nome");
            ViewBag.IdCliente = new SelectList(db.Utilizadors.Where(q => q.Perfil == 2 && q.Estado == true), "Id", "Nome");
            return View();
        }


        // POST: Reparacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdDispositivo,IdCliente,IdFuncionario,data_inicio,data_fim,Estado,preco")] Reparacao reparacao)
        {
            if (User.IsInRole("Cliente"))
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                var disp = db.Dispositivoes.Find(reparacao.IdDispositivo);
                reparacao.data_fim = reparacao.data_inicio;
                reparacao.IdCliente = disp.IdUtilizador;
                db.Reparacaos.Add(reparacao);
                disp.Estado = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDispositivo = new SelectList(db.Dispositivoes, "Id", "Marca", reparacao.IdDispositivo);
            ViewBag.IdFuncionario = new SelectList(db.Utilizadors.Where(q => q.Perfil == 1), "Id", "Nome", reparacao.IdFuncionario);
            ViewBag.IdCliente = new SelectList(db.Utilizadors.Where(q => q.Perfil == 2), "Id", "Nome", reparacao.IdCliente);
            return View(reparacao);
        }

        // GET: Reparacoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (User.IsInRole("Cliente"))
            {
                return HttpNotFound();
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reparacao reparacao = db.Reparacaos.Find(id);
            reparacao.Estados = new[]
            {
                new SelectListItem{Value="0", Text="Em Espera" },
                new SelectListItem{Value="1", Text="Em Reparação"},
                new SelectListItem{Value="2", Text="Finalizado"},
                new SelectListItem{Value="3", Text="Sem Concerto"},
            };
            if (reparacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDispositivo = new SelectList(db.Dispositivoes, "Id", "Marca", reparacao.IdDispositivo);
            ViewBag.IdFuncionario = new SelectList(db.Utilizadors.Where(q => q.Perfil == 1), "Id", "Nome", reparacao.IdFuncionario);
            ViewBag.IdCliente = new SelectList(db.Utilizadors.Where(q => q.Perfil == 2), "Id", "Nome", reparacao.IdCliente);
            return View(reparacao);
        }

        // POST: Reparacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdDispositivo,IdCliente,IdFuncionario,data_inicio,data_fim,Estado,preco")] Reparacao reparacao)
        {
            if (User.IsInRole("Cliente"))
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                db.Entry(reparacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            reparacao.Estados = new[]
            {
                new SelectListItem{Value="0", Text="Em Espera" },
                new SelectListItem{Value="1", Text="Em Reparação"},
                new SelectListItem{Value="2", Text="Finalizado"},
            };
            ViewBag.IdDispositivo = new SelectList(db.Dispositivoes, "Id", "Marca", reparacao.IdDispositivo);
            ViewBag.IdFuncionario = new SelectList(db.Utilizadors.Where(q => q.Perfil == 1), "Id", "Nome", reparacao.IdFuncionario);
            ViewBag.IdCliente = new SelectList(db.Utilizadors.Where(q => q.Perfil == 2), "Id", "Nome", reparacao.IdCliente);
            return View(reparacao);
        }
        [Authorize(Roles = "Administrador")]
        // GET: Reparacoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reparacao reparacao = db.Reparacaos.Find(id);
            if (reparacao == null || reparacao.Estado != 0)
            {
                return HttpNotFound();
            }

            return View(reparacao);
        }
        [Authorize(Roles = "Administrador")]
        // POST: Reparacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reparacao reparacao = db.Reparacaos.Find(id);
            db.Reparacaos.Remove(reparacao);
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

        public ActionResult ListaDispositivosEmEspera()
        {
            if (User.IsInRole("Cliente"))
            {
                return HttpNotFound();
            }
            var reparacoes = db.Reparacaos.Where(e => e.Estado == 0).Include(e => e.dispositivo).Include(e => e.utilizador).Include(e => e.u);
            return View(reparacoes.ToList());
        }

        public ActionResult IniciarReparacao(int? id)
        {
            if (User.IsInRole("Cliente"))
            {
                return HttpNotFound();
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var reparacao = db.Reparacaos.Where(r => r.Id == id).Include(e => e.dispositivo).Include(e => e.utilizador).Include(e => e.u).FirstOrDefault();
            if (reparacao.Estado != 0) return View(reparacao);
            if (reparacao == null)
            {
                return HttpNotFound();
            }

            return View(reparacao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IniciarReparacao(Reparacao reparacao)
        {
            if (User.IsInRole("Cliente"))
            {
                return HttpNotFound();
            }

            db.Entry(reparacao).State = EntityState.Modified;
            reparacao.Estado = 1;
            reparacao.data_inicio = DateTime.Now.Date;
            db.SaveChanges();
            return RedirectToAction("ListaDeReparacoesEmCurso");
        }

        public ActionResult ListaDeReparacoesEmCurso()
        {
            if (User.IsInRole("Cliente"))
            {
                return HttpNotFound();
            }

            var reparacoes = db.Reparacaos.Where(e => e.Estado == 1).Include(e => e.dispositivo).Include(e => e.utilizador).Include(e => e.u);
            return View(reparacoes.ToList());
        }

        public ActionResult ProcessaFimReparacao(int? id)
        {
            if (User.IsInRole("Cliente"))
            {
                return HttpNotFound();
            }

            var reparacao = db.Reparacaos.Where(r => r.Id == id).Include(e => e.dispositivo).Include(e => e.utilizador).Include(e => e.u).FirstOrDefault();

            if (reparacao == null)
            {
                return HttpNotFound();
            }
            if (reparacao.Estado != 1) return View(reparacao);

            reparacao.Estados = new[]
            {
                new SelectListItem{Value="2", Text="Finalizado"},
            };
            return View(reparacao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProcessaFimReparacao([Bind(Include = "Id,IdDispositivo,IdCliente,IdFuncionario,data_inicio,data_fim,Estado,preco")] Reparacao reparacao)
        {
            if (User.IsInRole("Cliente"))
            {
                return HttpNotFound();
            }

            db.Entry(reparacao).State = EntityState.Modified;
            reparacao.data_fim = DateTime.Now.Date;
            reparacao.Estado = 2;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Pagar(int? id)
        {
            var reparacao = db.Reparacaos.Where(r => r.Id == id).Include(e => e.dispositivo).Include(e => e.utilizador).Include(e => e.u).FirstOrDefault();
            if (reparacao == null)
            {
                return HttpNotFound();
            }
            if (reparacao.Estado != 2) return View(reparacao);
            return View(reparacao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Pagar([Bind(Include = "Id,IdDispositivo,IdCliente,IdFuncionario,data_inicio,data_fim,Estado,preco")] Reparacao reparacao)
        {
            db.Entry(reparacao).State = EntityState.Modified;
            reparacao.Estado = 3;
            db.SaveChanges();
            if (User.IsInRole("Cliente"))
            {
                return RedirectToAction("Index/"+reparacao.IdCliente);
            }
            return RedirectToAction("Index");
        }
    }
}