using Loja_Computadores.Classes;
using Loja_Computadores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loja_Computadores.Admin.Users
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserLogin.ValidarSessao(Session, Request, "0") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            AtualizaGrid();
        }

        private void AtualizaGrid()
        {
            Models.User user = new Models.User();
            gvUsers.DataSource = user.ListaTodosUsers();
            gvUsers.DataBind();
        }

        protected void btAdicionar_Click(object sender, EventArgs e)
        {
            //validar form
            string nome = tbNome.Text;
            string email = tbEmail.Text;
            string morada = tbMorada.Text;
            string nif = tbNif.Text;
            string password = tbPassword.Text;
            int perfil = int.Parse(dpPerfil.SelectedValue);
            Random rnd = new Random();
            int sal = rnd.Next(1000);

            Models.User utilizador = new Models.User();
            utilizador.nome = nome;
            utilizador.email = email;
            utilizador.sal = sal;
            utilizador.nif = nif;
            utilizador.morada = morada;
            utilizador.password = password;
            utilizador.perfil = perfil;

            utilizador.Adicionar();

            //limpar form
            tbEmail.Text = "";
            tbMorada.Text = "";
            tbNif.Text = "";
            tbNome.Text = "";

            //atualizar grid
            AtualizaGrid();
        }
    }
}