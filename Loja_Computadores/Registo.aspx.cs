using Loja_Computadores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loja_Computadores
{
    public partial class Registo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btRegistar_Click(object sender, EventArgs e)
        {
            try
            {
                //validar os dados do form
                if (tbNome.Text.Length < 3)
                {
                    throw new Exception("O nome tem de ter pelo menos 3 caracteres");
                }
                string nome = tbNome.Text;
                string email = tbEmail.Text;
                string morada = tbMorada.Text;
                string nif = tbNif.Text;
                string palavra_passe = tbPassword.Text;
                int perfil = 1;

                //Validar rcaptcha
                var respostaRecaptcha = Request.Form["g-Recaptcha-Response"];
                var valido = ReCaptcha.Validate(respostaRecaptcha);
                if (valido == false)
                {
                    throw new Exception("Tem de provar que não é um robot");
                }

                //Inserir o utilizador na bd
                Models.User utilizador = new Models.User();
                utilizador.nome = nome;
                utilizador.email = email;
                utilizador.morada = morada;
                utilizador.nif = nif;
                utilizador.password = palavra_passe;
                utilizador.perfil = perfil;
                Random rnd = new Random();
                utilizador.sal = rnd.Next(9999);
                utilizador.Adicionar();
                lbErro.Text = "Registado com sucesso";

                //Redirecionar para index
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Redirecionar", "returnMain('/index.aspx')", true);
            }
            catch (Exception erro)
            {
                lbErro.Text = erro.Message;
            }
        }
    }
}