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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ordenar os produtos?
            int? ordenar = 0;
            try
            {
                ordenar = int.Parse(Request["ordena"].ToString());
            }
            catch
            {
                ordenar = null;
            }

                atualizaListaProdutos(null, ordenar, rbfiltra.SelectedIndex);
        }

        /*private void AtualizaGrid()
        {

            gv_Produtos.Columns.Clear();
            Produto pd = new Produto();
            DataTable dados = pd.ListarTodosProdutosDisponiveis();

            DataColumn dcComprar = new DataColumn();
            dcComprar.ColumnName = "Comprar";
            dcComprar.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcComprar);

            gv_Produtos.DataSource = dados;
            gv_Produtos.AutoGenerateColumns = false;

            //Comprar
            HyperLinkField hlComprar = new HyperLinkField();
            hlComprar.HeaderText = "Comprar";
            hlComprar.DataTextField = "Comprar";
            hlComprar.Text = "Comprar...";
            hlComprar.DataNavigateUrlFormatString = "Comprar.aspx?id={0}";
            hlComprar.DataNavigateUrlFields = new string[] { "id" };
            gv_Produtos.Columns.Add(hlComprar);
            //id
            BoundField bfid = new BoundField();
            bfid.HeaderText = "ID";
            bfid.DataField = "id";
            gv_Produtos.Columns.Add(bfid);
            //nome
            BoundField bfnome = new BoundField();
            bfnome.HeaderText = "Nome";
            bfnome.DataField = "nome";
            gv_Produtos.Columns.Add(bfnome);
            //tags
            BoundField bftags = new BoundField();
            bftags.HeaderText = "Tags";
            bftags.DataField = "tags";
            gv_Produtos.Columns.Add(bftags);
            //data aquisicao
            BoundField bfdata = new BoundField();
            bfdata.HeaderText = "Data Aquisição";
            bfdata.DataField = "data_aquisicao";
            bfdata.DataFormatString = "{0:dd-MM-yyyy}";
            gv_Produtos.Columns.Add(bfdata);
            //preço
            BoundField bfpreco = new BoundField();
            bfpreco.HeaderText = "Preço";
            bfpreco.DataField = "preco";
            bfpreco.DataFormatString = "{0:C}";
            gv_Produtos.Columns.Add(bfpreco);
            //stock
            BoundField bfstock = new BoundField();
            bfstock.HeaderText = "Stock";
            bfstock.DataField = "stock";
            gv_Produtos.Columns.Add(bfstock);

            gv_Produtos.DataBind();
        }*/

        protected void btPesquisar_Click(object sender, EventArgs e)
        {
            atualizaListaProdutos(tbPesquisa.Text);
        }

        private void atualizaListaProdutos(string pesquisa = null, int? ordena = null, int? filtro=null)
        {
            Produto produto = new Produto();
            DataTable dados;
            if (pesquisa == null)
            {
                //se existir o cookie ultimolivro listar os livros do mesmo autor
                HttpCookie httpCookie = Request.Cookies["ultimoproduto"];
                if (httpCookie == null)
                    dados = produto.ListarTodosProdutosDisponiveis(null,ordena, filtro);
                else
                {
                    dados = produto.ListarTodosProdutosDisponiveis(Server.UrlDecode(httpCookie.Value));
                    dados.Merge(produto.ListarTodosProdutosDisponiveis(null, ordena, filtro));
                }
            }
            else
            {
                dados = produto.ListarTodosProdutosDisponiveis(pesquisa, ordena, filtro);
            }
            gerarIndex(dados);
        }

        private void gerarIndex(DataTable dados)
        {
            if (dados == null || dados.Rows.Count == 0)
            {
                divProdutos.InnerHtml = "";
                return;
            }
            string grelha = "<div class='container-fluid'>";
            grelha += "<div class='row'>";
            foreach (DataRow produto in dados.Rows)
            {
                grelha += "<div class='col'>";
                grelha += "<img src='/Public/Imagens/" + produto[0].ToString() +
                    ".jpg' class='img-fluid'/>";
                grelha += "<p/><span class='stat-title'>" + produto[1].ToString()
                    + "</span>";
                grelha += "<span class='stat-title'>" +
                    String.Format(" | {0:C}", Decimal.Parse(produto[4].ToString()))
                    + "</span><br />";
                if (produto[5].ToString() == "Em Stock")
                {
                    grelha += "<span class='stat-title' style='color:green'>" +
                         produto[5].ToString()
                        + "</span>";
                }
                else if (produto[5].ToString() == "Sem Stock")
                {
                    grelha += "<span class='stat-title' style='color:red'>" +
                         produto[5].ToString()
                        + "</span>";
                }
                else
                {
                    grelha += "<span class='stat-title' style='color:orange'>" +
                         produto[5].ToString()
                        + "</span>";
                }
                    grelha += "<br/><a class='btn btn-primary' href='detalhesproduto.aspx?id=" + produto[0].ToString()
                    + "'>Detalhes</a>";
                grelha += "</div>";
            }
            grelha += "</div></div>";
            divProdutos.InnerHtml = grelha;
        }
    }
}