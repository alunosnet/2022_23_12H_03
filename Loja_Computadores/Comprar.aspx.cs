using Loja_Computadores.Classes;
using Loja_Computadores.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loja_Computadores
{
    public partial class Comprar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserLogin.ValidarSessao(Session, Request, "1") == false)
            {
                Response.Redirect("~/login.aspx");
            }
            if (IsPostBack == true) return;
            divNovaMorada.Visible = false;
            tbQuatidade.Text = "1";
            int id = int.Parse(Request.QueryString["id"].ToString());

            Produto produto = new Produto();
            DataTable dados = produto.devolveDadosProduto(id);

            if (dados == null || dados.Rows.Count == 0)
            {
                throw new Exception("O Produto não existe");
            }
            try
            {
                int id_utilizador = int.Parse(Session["id"].ToString());
                Models.User utilizador = new Models.User();
                DataTable dd = utilizador.devolveDadosUser(id_utilizador);

                //separa as tags
                string tags = dados.Rows[0]["tags"].ToString();
                string[] tag = tags.Split(',');
                //mostra o produto
                string ficheiro = @"~\Public\Imagens\" + dados.Rows[0]["id"].ToString() + ".jpg";
                imgProduto.ImageUrl = ficheiro;
                imgProduto.Width = 200;

                lbNome.Text = dados.Rows[0]["nome"].ToString();

                lbDescricao.Text = tag[0];

                lbMorada.Text = dd.Rows[0]["morada"].ToString();


                lbPreco.Text = dados.Rows[0]["preco"].ToString() + "€";

                AtualizaLBTotal();
            }
            catch
            {
                throw new Exception("Algo correu mal");
            }
            
        }

        private void AtualizaLBTotal()
        {
            int id = int.Parse(Request.QueryString["id"].ToString());
            Produto produto = new Produto();
            DataTable dados = produto.devolveDadosProduto(id);

            if (dados == null || dados.Rows.Count == 0)
            {
                throw new Exception("O Produto não existe");
            }
            double total = double.Parse(dados.Rows[0]["preco"].ToString()) * int.Parse(tbQuatidade.Text);
            lbTotal.Text = "<h1>" + total.ToString() + "€</h1>";
        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            try
            {
                int idproduto = int.Parse(Request.QueryString["id"].ToString());
                int idutilizador = int.Parse(Session["id"].ToString());
                int quantidade = int.Parse(tbQuatidade.Text);
                string morada = lbMorada.Text;
                Venda venda = new Venda();
                venda.AdicionarVenda(idproduto, idutilizador, quantidade, DateTime.Now, morada);
                lbErro.Text = "Produto foi comprado com sucesso";
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('/index.aspx')", true);
            }
            catch
            {
                Response.Redirect("/index.aspx");
            }
        }

        protected void AddMorada_Click(object sender, EventArgs e)
        {
            divNovaMorada.Visible = false;
            string Morada = tbMorada.Text;
            lbMorada.Text = Morada;
        }

        protected void btnMudaMorada_Click(object sender, EventArgs e)
        {
            divNovaMorada.Visible = true;
            btnMudaMorada.Visible = false;
        }

        protected void btCancelAddMorada_Click(object sender, EventArgs e)
        {
            divNovaMorada.Visible = false;
            btnMudaMorada.Visible = true;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/detalhesproduto.aspx?id=" + Request.QueryString["id"].ToString());
        }

        protected void tbQuatidade_TextChanged(object sender, EventArgs e)
        {
            AtualizaLBTotal();
        }
    }
}