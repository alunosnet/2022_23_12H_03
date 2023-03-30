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
    public partial class PcPartPicker : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Produto pd = new Produto();
            DataTable dd;
            lbTotal.Text = "0";
            if (!IsPostBack)
                AtualizaDPs();
            else
            {
                if (dpCPU.SelectedIndex != 0)
                {
                    dd = pd.ListarTodosProdutosDisponiveis(dpCPU.SelectedItem.Text, null);
                    lbTotal.Text = (double.Parse(dd.Rows[0]["preco"].ToString()) + double.Parse(lbTotal.Text)).ToString();
                }
                if (dpMotherboard.SelectedIndex != 0)
                {
                    dd = pd.ListarTodosProdutosDisponiveis(dpMotherboard.SelectedItem.Text, null);
                    lbTotal.Text = (double.Parse(dd.Rows[0]["preco"].ToString()) + double.Parse(lbTotal.Text)).ToString();
                }
                if (dpRam.SelectedIndex != 0)
                {
                    dd = pd.ListarTodosProdutosDisponiveis(dpRam.SelectedItem.Text, null);
                    lbTotal.Text = (double.Parse(dd.Rows[0]["preco"].ToString()) + double.Parse(lbTotal.Text)).ToString();
                }
                if (dpGrafica.SelectedIndex != 0)
                {
                    dd = pd.ListarTodosProdutosDisponiveis(dpGrafica.SelectedItem.Text, null);
                    lbTotal.Text = (double.Parse(dd.Rows[0]["preco"].ToString()) + double.Parse(lbTotal.Text)).ToString();
                }
                if (dpCaixa.SelectedIndex != 0)
                {
                    dd = pd.ListarTodosProdutosDisponiveis(dpCaixa.SelectedItem.Text, null);
                    lbTotal.Text = (double.Parse(dd.Rows[0]["preco"].ToString()) + double.Parse(lbTotal.Text)).ToString();
                }
                if (dpPSU.SelectedIndex != 0)
                {
                    dd = pd.ListarTodosProdutosDisponiveis(dpPSU.SelectedItem.Text, null);
                    lbTotal.Text = (double.Parse(dd.Rows[0]["preco"].ToString()) + double.Parse(lbTotal.Text)).ToString();
                }
                if (dpArmazenamento.SelectedIndex != 0)
                {
                    dd = pd.ListarTodosProdutosDisponiveis(dpArmazenamento.SelectedItem.Text, null);
                    lbTotal.Text = (double.Parse(dd.Rows[0]["preco"].ToString()) + double.Parse(lbTotal.Text)).ToString();
                }
            }
            lbTotal.Text = " " + lbTotal.Text + "€";
        }

        private void AtualizaDPs()
        {
            Produto produto = new Produto();
            DataTable dados = produto.ListarTodosProdutosDisponiveis("",null,1);
            dpCPU.Items.Add("Selecione um produto");
            foreach (DataRow linha in dados.Rows)
                dpCPU.Items.Add(
                    new ListItem(linha["nome"].ToString(), linha["id"].ToString())
                );
            dados = produto.ListarTodosProdutosDisponiveis("", null, 2);
            dpMotherboard.Items.Add("Selecione um produto");
            foreach (DataRow linha in dados.Rows)
                dpMotherboard.Items.Add(
                    new ListItem(linha["nome"].ToString(), linha["id"].ToString())
                );
            dados = produto.ListarTodosProdutosDisponiveis("", null, 3);
            dpRam.Items.Add("Selecione um produto");
            foreach (DataRow linha in dados.Rows)
                dpRam.Items.Add(
                    new ListItem(linha["nome"].ToString(), linha["id"].ToString())
                );
            dados = produto.ListarTodosProdutosDisponiveis("", null, 4);
            dpGrafica.Items.Add("Selecione um produto");
            foreach (DataRow linha in dados.Rows)
                dpGrafica.Items.Add(
                    new ListItem(linha["nome"].ToString(), linha["id"].ToString())
                );
            dados = produto.ListarTodosProdutosDisponiveis("", null, 5);
            dpPSU.Items.Add("Selecione um produto");
            foreach (DataRow linha in dados.Rows)
                dpPSU.Items.Add(
                    new ListItem(linha["nome"].ToString(), linha["id"].ToString())
                );
            dados = produto.ListarTodosProdutosDisponiveis("", null, 6);
            dpArmazenamento.Items.Add("Selecione um produto");
            foreach (DataRow linha in dados.Rows)
                dpArmazenamento.Items.Add(
                    new ListItem(linha["nome"].ToString(), linha["id"].ToString())
                );
            dados = produto.ListarTodosProdutosDisponiveis("", null, 7);
            dpCaixa.Items.Add("Selecione um produto");
            foreach (DataRow linha in dados.Rows)
                dpCaixa.Items.Add(
                    new ListItem(linha["nome"].ToString(), linha["id"].ToString())
                );
        }

        protected void dpCPU_SelectedIndexChanged(object sender, EventArgs e)
        {
            Produto produto = new Produto();
            DataTable dados = produto.devolveDadosProduto(int.Parse(dpCPU.Text.ToString()));

            string tags = dados.Rows[0]["tags"].ToString();
            string[] tag = tags.Split(',');

            dados = produto.ListarTodosProdutosDisponiveis("", null, 2, tag[1]);
            dpMotherboard.Items.Clear();
            dpMotherboard.Items.Add("Selecione um produto");
            foreach (DataRow linha in dados.Rows)
                dpMotherboard.Items.Add(
                    new ListItem(linha["nome"].ToString(), linha["id"].ToString())
                );
        }

        protected void dpMotherboard_SelectedIndexChanged(object sender, EventArgs e)
        {
            Produto produto = new Produto();
            DataTable dados = produto.devolveDadosProduto(int.Parse(dpMotherboard.Text.ToString()));

            string tags = dados.Rows[0]["tags"].ToString();
            string[] tag = tags.Split(',');

            if (dpCPU.SelectedIndex == 0)
            {
                dados = produto.ListarTodosProdutosDisponiveis("", null, 1, tag[2]);
                dpCPU.Items.Clear();
                dpCPU.Items.Add("Selecione um produto");
                foreach (DataRow linha in dados.Rows)
                    dpCPU.Items.Add(
                        new ListItem(linha["nome"].ToString(), linha["id"].ToString())
                    );
            }
            if (dpRam.SelectedIndex == 0)
            {
                dados = produto.ListarTodosProdutosDisponiveis("", null, 3, tag[5]);
                dpRam.Items.Clear();
                dpRam.Items.Add("Selecione um produto");
                foreach (DataRow linha in dados.Rows)
                    dpRam.Items.Add(
                        new ListItem(linha["nome"].ToString(), linha["id"].ToString())
                    );
            }
        }

        protected void dpRam_SelectedIndexChanged(object sender, EventArgs e)
        {
            Produto produto = new Produto();
            DataTable dados = produto.devolveDadosProduto(int.Parse(dpRam.Text.ToString()));

            string tags = dados.Rows[0]["tags"].ToString();
            string[] tag = tags.Split(',');
            string[] vel = tag[3].Split(' ');

            if (dpMotherboard.SelectedIndex == 0)
            {
                dados = produto.ListarTodosProdutosDisponiveis("", null, 2, vel[0]);
                dpMotherboard.Items.Clear();
                dpMotherboard.Items.Add("Selecione um produto");
                foreach (DataRow linha in dados.Rows)
                    dpMotherboard.Items.Add(
                        new ListItem(linha["nome"].ToString(), linha["id"].ToString())
                    );
            }
        }
    }
}