using LojaDeReparações.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaDeReparações.Helper
{
    public static class Utils
    {
        public static string UserId(this HtmlHelper htmlHelper, System.Security.Principal.IPrincipal utilizador)
        {
            string iduser = "";
            using (var context = new LojaDeReparacoesContext())
            {
                var consulta = context.Database.SqlQuery<int>("SELECT Id FROM Utilizadors WHERE Email=@p0", utilizador.Identity.Name);
                if (consulta.ToList().Count > 0)
                {
                    iduser = consulta.ToList()[0].ToString();
                }
            }

            return iduser;
        }
    }
}