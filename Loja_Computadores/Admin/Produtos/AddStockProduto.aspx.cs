using Loja_Computadores.Classes;
using Loja_Computadores.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loja_Computadores.Admin.Produtos
{
    public partial class AddStockProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserLogin.ValidarSessao(Session, Request, "0") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            try
            {
                int id = int.Parse(Request.QueryString["id"].ToString());

                Produto produto = new Produto();
                DataTable dados = produto.devolveDadosProduto(id);

                if (dados == null || dados.Rows.Count == 0)
                {
                    throw new Exception("O Produto não existe");
                }
                //separa as tags
                string tags = dados.Rows[0]["tags"].ToString();
                string[] tag = tags.Split(',');
                //mostra o produto
                lbId.Text = dados.Rows[0]["id"].ToString();
                lbNome.Text = dados.Rows[0]["nome"].ToString();
                lbTipo.Text = tag[0];
                lbPreco.Text = dados.Rows[0]["preco"].ToString();
                lbAquisicao.Text = DateTime.Parse(dados.Rows[0]["data_aquisicao"].ToString()).ToString("yyyy-MM-dd");
                lbStock.Text = dados.Rows[0]["stock"].ToString();
                lbEstado.Text = dados.Rows[0]["estado"].ToString();

                string ficheiro = @"~\Public\Imagens\" + dados.Rows[0]["id"].ToString() + ".jpg";
                imgProduto.ImageUrl = ficheiro;
                imgProduto.Width = 200;

            }
            catch { }
        }

        protected void btnAddStock_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request["id"].ToString());
            int stock = int.Parse(tbAddStock.Text);
            Produto pd = new Produto();
            pd.AddStock(id, stock);

            //lbError.Text = "O produto foi atualizado com sucesso";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Redirecionar", "returnMain('produtos.aspx')", true);
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Produtos/Produtos.aspx");
        }
    }
}