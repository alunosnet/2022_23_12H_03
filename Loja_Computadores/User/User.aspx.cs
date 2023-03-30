using System;
using Loja_Computadores.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loja_Computadores.Classes;

namespace Loja_Computadores.User
{
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserLogin.ValidarSessao(Session, Request, "1") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            if (!IsPostBack)
            {
                divEditar.Visible = false;
                MostrarPerfil();
            }
        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            divPerfil.Visible = true;
            divEditar.Visible = false;
            MostrarPerfil();
        }

        protected void btAtualizar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Session["id"].ToString());
            string nome = tbNome.Text;
            string morada = tbMorada.Text;
            string nif = tbNif.Text;
            //TODO: validar os dados
            Models.User utilizador = new Models.User();
            utilizador.nome = nome;
            utilizador.morada = morada;
            utilizador.nif = nif;
            utilizador.id = id;
            utilizador.atualizarUtilizador();
            btCancelar_Click(sender, e);
        }

        protected void Editar_Click(object sender, EventArgs e)
        {
            divPerfil.Visible = false;
            divEditar.Visible = true;
            MostrarPerfil();
        }

        private void MostrarPerfil()
        {
            int id = int.Parse(Session["id"].ToString());
            Models.User utilizador = new Models.User();
            DataTable dados = utilizador.devolveDadosUser(id);
            if (divPerfil.Visible == true)
            {
                lbNome.Text = dados.Rows[0]["nome"].ToString();
                lbMorada.Text = dados.Rows[0]["morada"].ToString();
                lbNif.Text = dados.Rows[0]["nif"].ToString();
            }
            else
            {
                tbNome.Text = dados.Rows[0]["nome"].ToString();
                tbMorada.Text = dados.Rows[0]["morada"].ToString();
                tbNif.Text = dados.Rows[0]["nif"].ToString();
            }
        }

        
    }
}