using Loja_Computadores.Admin.Vendas;
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
    public partial class detalhesproduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request["id"].ToString());
                Produto produto = new Produto();
                DataTable dados = produto.devolveDadosProduto(id);

                string tags = dados.Rows[0]["tags"].ToString();
                string[] tag = tags.Split(',');
                lbDescricao.Text = "<h3>Descrição</h3>";
                int tamanho = tag.Length;

                int i = 0;
                while (i < tamanho)
                {
                    lbDescricao.Text += "-" + tag[i] + "<br />";
                    i++;
                }

                lbNome.Text = "<h1>" + dados.Rows[0]["nome"].ToString() + "</h1>";
                lbPreco.Text = String.Format("{0:c}", Decimal.Parse(dados.Rows[0]["preco"].ToString()));
                if (int.Parse(dados.Rows[0]["stock"].ToString()) == 0) 
                { 
                    lbStock.Text = "Sem Stock";
                    btComprar.Enabled = false;
                }
                else if (int.Parse(dados.Rows[0]["stock"].ToString()) >= 10)
                {
                    lbStock.Text = "Em Stock";
                    btComprar.Enabled = true;
                }
                else
                {
                    lbStock.Text = "Poucas Unidades";
                    btComprar.Enabled = true;
                }
                string ficheiro = @"~\Public\Imagens\" + dados.Rows[0]["id"].ToString() + ".jpg";
                imgProduto.ImageUrl = ficheiro;
                imgProduto.Width = 200;
            }
            catch
            {
                Response.Redirect("~/index.aspx");
            }
        }
        protected void btComprar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Comprar.aspx?id=" + Request["id"].ToString());
        }
    }
}