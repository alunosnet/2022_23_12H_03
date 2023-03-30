using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Deployment.Internal;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using LojaDeReparações.Data;
using LojaDeReparações.Migrations;
using LojaDeReparações.Models;

namespace LojaDeReparações.Controllers
{
    [Authorize]
    public class UtilizadoresController : Controller
    {
        private LojaDeReparacoesContext db = new LojaDeReparacoesContext();

        // GET: Utilizadores
        public ActionResult Index()
        {
            if (User.IsInRole("Cliente"))
            {
                return HttpNotFound();
            }
            return View(db.Utilizadors.ToList());
        }

        // GET: Utilizadores/Details/5
        public ActionResult Details(int? id)
        {

            if (User.IsInRole("Cliente"))
            {
                return HttpNotFound();
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizador utilizador = db.Utilizadors.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }
            

            return View(utilizador);
        }

        // GET: Utilizadores/Create
        public ActionResult Create()
        {
            if (User.IsInRole("Cliente"))
            {
                return HttpNotFound();
            }
            var utilizador = new Utilizador();
            utilizador.Perfis = new[]
            {
                new SelectListItem{Value="0", Text="Administrator" },
                new SelectListItem{Value="1", Text="Funcionário"},
                new SelectListItem{Value="2", Text="Cliente"},
            };
            return View(utilizador);
        }

        // POST: Utilizadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Email,Password,Perfil,Estado")] Utilizador utilizador)
        {
            if (User.IsInRole("Cliente"))
            {
                return HttpNotFound();
            }
            utilizador.Perfis = new[]
            {
                new SelectListItem{Value="0", Text="Administrator" },
                new SelectListItem{Value="1", Text="Funcionário"},
                new SelectListItem{Value="2", Text="Cliente"},
            };
            if (ModelState.IsValid)
            {
                var temp = db.Utilizadors.Where(u => u.Email == utilizador.Email).ToList();
                //se o user ja existe
                if (temp != null && temp.Count > 0)
                {
                    ModelState.AddModelError("Email", "Já existe um utilizador com esse email");
                    return View(utilizador);
                }
                //se tem password
                if (utilizador.Password == null || utilizador.Password == "")
                {
                    ModelState.AddModelError("Password", "Tem de indicar uma password");
                    return View(utilizador);
                }
                //validar a password
                if (utilizador.Password.Trim().Length < 5)
                {
                    ModelState.AddModelError("Password", "A palavra passe deve ter pelo menos 5 letras");
                    return View(utilizador);
                }
                //hash password
                HMACSHA512 hMACSHA512 = new HMACSHA512(new byte[] { 16 });
                var password = hMACSHA512.ComputeHash(Encoding.UTF8.GetBytes(utilizador.Password));
                utilizador.Password = Convert.ToBase64String(password);
                db.Utilizadors.Add(utilizador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(utilizador);
        }

        // GET: Utilizadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizador utilizador = db.Utilizadors.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }

            if (User.IsInRole("Administrador"))
            {
                utilizador.Perfis = new[]
                {
                    new SelectListItem{Value="0", Text="Administrator"},
                    new SelectListItem{Value="1", Text="Funcionário"},
                    new SelectListItem{Value="2", Text="Cliente"},
                };
            }
            else if (User.IsInRole("Funcionário"))
            {
                var temp = db.Utilizadors.Where(u => u.Email == User.Identity.Name).FirstOrDefault();
                utilizador = temp;
                utilizador.Perfis = new[]
                {
                    new SelectListItem{Value="1", Text="Funcionário"}
                };
            }
            else
            {
                var temp = db.Utilizadors.Where(u => u.Email == User.Identity.Name).FirstOrDefault();
                utilizador = temp;
                utilizador.Perfis = new[]
                {
                    new SelectListItem{Value="2", Text="Cliente"}
                };
            }
            return View(utilizador);
        }

        // POST: Utilizadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Email,Password,Perfil,Estado")] Utilizador utilizador)
        {

            if (User.IsInRole("Funcionário") == true)
            {
                utilizador.Perfis = new[]
                {
                    new SelectListItem{Value="1", Text="Funcionário"}
                };
            }
            if (User.IsInRole("Cliente") == true)
            {
                utilizador.Perfis = new[]
                {
                    new SelectListItem{Value="2", Text="Cliente"}
                };
            }

            if (ModelState.IsValid)
            {
                var t = db.Utilizadors.Find(utilizador.Id);
                utilizador.Password = t.Password;
                t.Nome = utilizador.Nome;
                t.Email = utilizador.Email;
                t.Perfil = utilizador.Perfil;
                t.Estado = utilizador.Estado;
                db.Entry(t).CurrentValues.SetValues(t);
                db.SaveChanges();
                if (User.IsInRole("Cliente"))
                {
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Index");
            }
            return View(utilizador);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        [Authorize(Roles = "Administrador")]
        public ActionResult MudarEstado(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizador utilizador = db.Utilizadors.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }
            return View(utilizador);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MudarEstado([Bind(Include = "Id,Nome,Email,Password,Perfil,Estado")] Utilizador utilizador)
        {
            if (utilizador.Estado == false)
                utilizador.Estado = true;
            else
                utilizador.Estado = false;
            db.SaveChanges();
            return View(utilizador);
        }
    }
}
