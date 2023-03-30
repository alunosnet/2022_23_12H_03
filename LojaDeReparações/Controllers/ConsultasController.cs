using LojaDeReparações.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LojaDeReparações.Controllers
{
    [Authorize(Roles = "Administrador")] 
    
    public class ConsultasController : Controller
    {
        private LojaDeReparacoesContext db = new LojaDeReparacoesContext();
        // GET: Consultas
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult PesquisaNome(string nome)
        { 
            var clientes = db.Utilizadors.Where( c => c.Nome.Contains(nome) && c.Perfil == 2).ToList();
            var lista = new List<Campos>();
            foreach (var c in clientes)
                lista.Add(new Campos() { nome = c.Nome });
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ClienteProb()
        {
            string sql = @"SELECT count(Reparacaos.Id) as id,nome 
                        FROM Reparacaos INNER JOIN Utilizadors 
                        ON Reparacaos.IdCliente = Utilizadors.Id 
                        GROUP BY Reparacaos.IdCliente ,nome
                        ORDER BY id DESC";
            var prob = db.Database.SqlQuery<Campos>(sql);

            if (prob != null && prob.ToList().Count > 0)
                ViewBag.prob = prob.ToList()[0];
            else
            {
                Campos temp = new Campos();
                temp.nome = "Não foram encontrados registos";
                ViewBag.prob = temp;
            }
            return View();
        }

        public class Campos
        {
            public string nome { get; set; }
            public decimal valor { get; set; }
            public int Id { get; set; }
        }
    }
}