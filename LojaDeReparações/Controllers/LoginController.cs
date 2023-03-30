using LojaDeReparações.Data;
using LojaDeReparações.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LojaDeReparações.Controllers
{
    public class LoginController : Controller
    {
        private LojaDeReparacoesContext db = new LojaDeReparacoesContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Utilizador utilizador)
        {
            if (utilizador.Email != null && utilizador.Password != null)
            {
                //hash password
                HMACSHA512 hMACSHA512 = new HMACSHA512(new byte[] { 16 });
                var password = hMACSHA512.ComputeHash(Encoding.UTF8.GetBytes(utilizador.Password));
                utilizador.Password = Convert.ToBase64String(password);
                foreach (var u in db.Utilizadors.ToList())
                {
                    if (u.Email.ToLower() == utilizador.Email.ToLower() && u.Password == utilizador.Password)
                    {
                        //iniciar sessão
                        FormsAuthentication.SetAuthCookie(utilizador.Email, false);
                        //redireconar
                        if (Request.QueryString["ReturnUrl"] == null)
                            return RedirectToAction("Index", "Home");
                        else
                            return Redirect(Request.QueryString["ReturnUrl"].ToString());
                    }
                }
            }
            ModelState.AddModelError("", "Login falhou. Tente novamente.");
            return View(utilizador);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Registar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registar([Bind(Include = "Id,Nome,Email,Password,Perfil,Estado")] Utilizador utilizador)
        {
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
                utilizador.Perfil = 2;
                db.Utilizadors.Add(utilizador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(utilizador);
        }
    }
}