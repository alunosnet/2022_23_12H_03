using Loja_Computadores.Admin.Vendas;
using Loja_Computadores.Classes;
using Loja_Computadores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loja_Computadores.User.Compras
{
    public partial class Historico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserLogin.ValidarSessao(Session, Request, "1") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            AtualizaGrid();
        }

        private void AtualizaGrid()
        {
            Venda vendas = new Venda();
            int idutilizador = int.Parse(Session["id"].ToString());
            gv_Historico.DataSource = vendas.DevolveComprasUser(idutilizador);
            gv_Historico.DataBind();
        }
    }
}