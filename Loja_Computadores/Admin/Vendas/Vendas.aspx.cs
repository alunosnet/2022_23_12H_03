using Loja_Computadores.Classes;
using Loja_Computadores.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loja_Computadores.Admin.Vendas
{
    public partial class Vendas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserLogin.ValidarSessao(Session, Request, "0") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            AtualizaGrid();
            ConfigurarGrid();
        }

        private void ConfigurarGrid()
        {
            //paginação
            gv_Vendas.AllowPaging = true;
            gv_Vendas.PageSize = 5;
            gv_Vendas.PageIndexChanging += Gv_Vendas_PageIndexChanging;
            //botões de comando
            gv_Vendas.RowCommand += Gv_Vendas_RowCommand;
            gv_Vendas.RowDataBound += Gv_Vendas_RowDataBound;
        }

        private void Gv_Vendas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DateTime datadevolve = DateTime.Parse(e.Row.Cells[6].Text);
                int estado = int.Parse(e.Row.Cells[7].Text);
                if (estado != 0)
                {
                    e.Row.Cells[0].Controls[0].Visible = true;
                    if (datadevolve < DateTime.Now)
                        e.Row.Cells[1].Controls[0].Visible = true;
                    else
                        e.Row.Cells[1].Controls[0].Visible = false;

                }
                else
                {
                    e.Row.Cells[0].Controls[0].Visible = false;
                    e.Row.Cells[1].Controls[0].Visible = false;
                }
            }
        }

        private void Gv_Vendas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //mudar de página
            if (e.CommandName == "Page") return;
        }

        private void Gv_Vendas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_Vendas.PageIndex = e.NewPageIndex;
            AtualizaGrid();
        }

        private void AtualizaGrid()
        {
            Venda vendas = new Venda();
            gv_Vendas.DataSource = vendas.ListaVendas();
            gv_Vendas.DataBind();
        }
    }
}