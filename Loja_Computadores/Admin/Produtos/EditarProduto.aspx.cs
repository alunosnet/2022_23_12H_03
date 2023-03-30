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
    public partial class EditarProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserLogin.ValidarSessao(Session, Request, "0") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            if (IsPostBack) return;
            try
            {
                AtualizaDPs();

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
                tbNome.Text = dados.Rows[0]["nome"].ToString();
                string a = tag[0];
                dpTipo.Text = a;

                EscondeDivs();

                if (dpTipo.SelectedIndex == 1)
                {
                    dpMarcaCPU.Text = tag[1];
                    dpSocketCPU.Text = tag[2];
                    dpModeloCPU.Text = tag[3];
                    dpGeracaoCPU.Text = tag[4];
                }
                else if (dpTipo.SelectedIndex == 2)
                {
                    dpMarcaMotherBoard.Text = tag[1];
                    dpCPUMotherboard.Text = tag[2];
                    dpSocketMotherboard.Text = tag[3];
                    dpChipset.Text = tag[4];
                    dpTipoRamMotherboard.Text = tag[5];
                    dpRamSlots.Text = tag[6];
                    dpVelocidadeMax.Text = tag[7];
                    dpSlotsM2.Text = tag[8];
                    if (tag[9] == "Wifi")
                    {
                        chkWifi.Checked = true;
                    }
                }
                else if (dpTipo.SelectedIndex == 3)
                {
                    dpMarcaRam.Text = tag[1];
                    dpTipoRam.Text = tag[2];
                    dpCapacidadeRam.Text = tag[3];
                    dpVelocidadeRam.Text = tag[4];
                }
                else if (dpTipo.SelectedIndex == 4)
                {
                    dpMarcaGrafica.Text = tag[1];
                    dpModeloGrafica.Text = tag[2];
                }
                else if (dpTipo.SelectedIndex == 5)
                {
                    dpMarcaPSU.Text = tag[1];
                    tbWatts.Text = tag[2];
                    if (tag[3] == "Modular")
                    {
                        chkModular.Checked = true;
                    }
                }//TODO
                else if (dpTipo.SelectedIndex == 6)
                {
                    dpMarcaArmazenamento.Text = tag[1];
                    dpTipoArmazenamento.Text = tag[2];
                    tbTamanho.Text = tag[3];
                }
                else if (dpTipo.SelectedIndex == 7)
                {
                    dpMarcaCaixa.Text = tag[1];
                    dpFormatoCaixa.Text = tag[2];
                }
                else
                {
                    throw new Exception("Algo correu mal");
                }

                tbPreco.Text = dados.Rows[0]["preco"].ToString();
                tbAquisicao.Text = DateTime.Parse(dados.Rows[0]["data_aquisicao"].ToString()).ToString("yyyy-MM-dd");
                tbStock.Text = dados.Rows[0]["stock"].ToString();

                //imagem
                Random rnd = new Random();
                imgProduto.ImageUrl = @"~\Public\imagens\" + id + ".jpg?" + rnd.Next(9999);
                imgProduto.Width = 300;
            }
            catch
            {
                Response.Redirect("~/Admin/Produtos/Produtos.aspx");
            }
        }

        public void AtualizaDPs()
        {
            AtualizarDPTipo();
            //Atualiza as DPs do CPU
            AtualizarDPMarcaCPU();
            AtualizarDPSocketCPU();
            AtualizarDPGeracaoCPU();
            AtualizarDPModeloCPU();
            //Atualiza as DPs da MotherBoard
            AtualizarDPMarcaMotherboard();
            AtualizarDPSocketMotherboard();
            AtualizarDPFormato();
            AtualizarDPCPUMotherboard();
            AtualizarDPChipset();
            AtualizarDPTipoRamMotherboard();
            AtualizarDPRamSlots();
            AtualizarDPVelocidadeMax();
            AtualizarDPSlotsM2();
            //Atualiza as DPs da Ram
            AtualizarMarcaRam();
            AtualizarDPTipoRam();
            AtualizarDPCapacidadeRam();
            AtualizarDPVelocidadeRam();
            //Atualiza as DPs da Grafica
            AtualizarDPMarcaGrafica();
            AtualizarDPModeloGrafica();
            //Atualiza a DP da PSU
            AtualizaDPMarcaPSU();
            //Atualiza as DPs do Armazenamento
            AtualizarDPMarcaArmazanamento();
            AtualizarDPTipoArmazenamento();
            //Atualiza as DPs da Caixa
            AtualizarDPMarcaCaixa();
            AtualizarDPFormatoCaixa();
        }

        private void AtualizarDPTipo()
        {
            dpTipo.Items.Clear();
            dpTipo.Items.Add(new ListItem("Selecione uma opção"));
            dpTipo.Items.Add(new ListItem("Processador"));
            dpTipo.Items.Add(new ListItem("Motherboard"));
            dpTipo.Items.Add(new ListItem("Ram"));
            dpTipo.Items.Add(new ListItem("Grafica"));
            dpTipo.Items.Add(new ListItem("PSU"));
            dpTipo.Items.Add(new ListItem("Armazenamento"));
            dpTipo.Items.Add(new ListItem("Caixa"));
        }

        private void AtualizaDPMarcaPSU()
        {
            dpMarcaPSU.Items.Clear();
            dpMarcaPSU.Items.Add(new ListItem("Seasonic"));
            dpMarcaPSU.Items.Add(new ListItem("Corsair"));
        }

        private void AtualizarDPFormatoCaixa()
        {
            dpFormatoCaixa.Items.Clear();
            dpFormatoCaixa.Items.Add(new ListItem("ATX"));
            dpFormatoCaixa.Items.Add(new ListItem("Micro-ATX"));
            dpFormatoCaixa.Items.Add(new ListItem("ITX"));
        }

        private void AtualizarDPMarcaCaixa()
        {
            dpMarcaCaixa.Items.Clear();
            dpMarcaCaixa.Items.Add(new ListItem("Corsair"));
            dpMarcaCaixa.Items.Add(new ListItem("Factal"));
            dpMarcaCaixa.Items.Add(new ListItem("Cooler Master"));
        }

        private void AtualizarDPTipoArmazenamento()
        {
            dpTipoArmazenamento.Items.Clear();
            dpTipoArmazenamento.Items.Add(new ListItem("SSD M.2"));
            dpTipoArmazenamento.Items.Add(new ListItem("SSD SATA"));
            dpTipoArmazenamento.Items.Add(new ListItem("HDD"));
        }

        private void AtualizarDPMarcaArmazanamento()
        {
            dpMarcaArmazenamento.Items.Clear();
            dpMarcaArmazenamento.Items.Add(new ListItem("Kingstom"));
            dpMarcaArmazenamento.Items.Add(new ListItem("Samsung"));
        }

        private void AtualizarDPModeloGrafica()
        {
            dpModeloGrafica.Items.Clear();
            dpModeloGrafica.Items.Add(new ListItem("AMD Radeon 7900XT"));
            dpModeloGrafica.Items.Add(new ListItem("AMD Radeon 6800XT"));
            dpModeloGrafica.Items.Add(new ListItem("Nvidia RTX 4090"));
            dpModeloGrafica.Items.Add(new ListItem("Nvidia RTX 3080TI"));
        }

        private void AtualizarDPMarcaGrafica()
        {
            dpMarcaGrafica.Items.Clear();
            dpMarcaGrafica.Items.Add(new ListItem("Asus"));
            dpMarcaGrafica.Items.Add(new ListItem("Gigabyte"));
        }

        private void AtualizarDPVelocidadeRam()
        {
            dpVelocidadeRam.Items.Clear();
            if (dpTipoRam.Text == "DDR4")
            {
                dpVelocidadeRam.Items.Add(new ListItem("3200mhz CL16"));
                dpVelocidadeRam.Items.Add(new ListItem("3600mhz CL17"));
            }
            else if (dpTipoRam.Text == "DDR5")
            {
                dpVelocidadeRam.Items.Add(new ListItem("5600mhz CL36"));
                dpVelocidadeRam.Items.Add(new ListItem("6000mhz CL38"));
            }
            else
            {
                dpVelocidadeRam.Items.Add(new ListItem("3200mhz CL16"));
                dpVelocidadeRam.Items.Add(new ListItem("3600mhz CL17"));
                dpVelocidadeRam.Items.Add(new ListItem("5600mhz CL36"));
                dpVelocidadeRam.Items.Add(new ListItem("6000mhz CL38"));
            }
        }

        private void AtualizarDPTipoRam()
        {
            dpTipoRam.Items.Clear();
            dpTipoRam.Items.Add(new ListItem("DDR4"));
            dpTipoRam.Items.Add(new ListItem("DDR5"));
        }

        private void AtualizarDPCapacidadeRam()
        {
            dpCapacidadeRam.Items.Clear();
            dpCapacidadeRam.Items.Add(new ListItem("2x8gb"));
            dpCapacidadeRam.Items.Add(new ListItem("2x16gb"));
        }

        private void AtualizarMarcaRam()
        {
            dpMarcaRam.Items.Clear();
            dpMarcaRam.Items.Add(new ListItem("Team Group"));
            dpMarcaRam.Items.Add(new ListItem("G.SKILL"));
        }

        private void AtualizarDPSlotsM2()
        {
            dpSlotsM2.Items.Clear();
            dpSlotsM2.Items.Add(new ListItem("1 M2 Slot"));
            dpSlotsM2.Items.Add(new ListItem("2 M2 Slots"));
        }

        private void AtualizarDPVelocidadeMax()
        {
            dpVelocidadeMax.Items.Clear();
            if (dpTipoRamMotherboard.Text == "DDR4")
            {
                dpVelocidadeMax.Items.Add(new ListItem("3200mhz"));
                dpVelocidadeMax.Items.Add(new ListItem("3600mhz"));
            }
            else if (dpTipoRamMotherboard.Text == "DDR5")
            {
                dpVelocidadeMax.Items.Add(new ListItem("6000mhz"));
                dpVelocidadeMax.Items.Add(new ListItem("5600mhz"));
            }
            else
            {
                dpVelocidadeMax.Items.Add(new ListItem("3200mhz"));
                dpVelocidadeMax.Items.Add(new ListItem("3600mhz"));
                dpVelocidadeMax.Items.Add(new ListItem("6000mhz"));
                dpVelocidadeMax.Items.Add(new ListItem("5600mhz"));
            }

        }

        private void AtualizarDPRamSlots()
        {
            dpRamSlots.Items.Clear();
            dpRamSlots.Items.Add(new ListItem("2 slots"));
            dpRamSlots.Items.Add(new ListItem("4 slots"));
        }

        private void AtualizarDPTipoRamMotherboard()
        {
            dpTipoRamMotherboard.Items.Clear();
            dpTipoRamMotherboard.Items.Add(new ListItem("DDR4"));
            dpTipoRamMotherboard.Items.Add(new ListItem("DDR5"));
        }

        private void AtualizarDPChipset()
        {
            dpChipset.Items.Clear();
            if (dpCPUMotherboard.Text == "AMD")
            {
                dpChipset.Items.Add(new ListItem("B560"));
                dpChipset.Items.Add(new ListItem("X570"));
            }
            else if (dpCPUMotherboard.Text == "Intel")
            {
                dpChipset.Items.Add(new ListItem("B660"));
                dpChipset.Items.Add(new ListItem("Z690"));
            }
            else
            {
                dpChipset.Items.Add(new ListItem("B660"));
                dpChipset.Items.Add(new ListItem("Z690"));
                dpChipset.Items.Add(new ListItem("B560"));
                dpChipset.Items.Add(new ListItem("X570"));
            }
        }

        private void AtualizarDPCPUMotherboard()
        {
            dpCPUMotherboard.Items.Clear();
            dpCPUMotherboard.Items.Add(new ListItem("Intel"));
            dpCPUMotherboard.Items.Add(new ListItem("AMD"));
        }

        private void AtualizarDPFormato()
        {
            dpFormatoMotherboard.Items.Clear();
            dpFormatoMotherboard.Items.Add(new ListItem("ATX"));
            dpFormatoMotherboard.Items.Add(new ListItem("Micro-ATX"));
            dpFormatoMotherboard.Items.Add(new ListItem("Mini-ITX"));
        }

        private void AtualizarDPSocketMotherboard()
        {
            dpSocketMotherboard.Items.Clear();
            if (dpCPUMotherboard.Text == "Intel")
                dpSocketMotherboard.Items.Add(new ListItem("LGA1700"));
            else
                dpSocketMotherboard.Items.Add(new ListItem("AM5"));
        }

        private void AtualizarDPMarcaMotherboard()
        {
            dpMarcaMotherBoard.Items.Clear();
            dpMarcaMotherBoard.Items.Add(new ListItem("Asus"));
            dpMarcaMotherBoard.Items.Add(new ListItem("Gigabyte"));
            dpMarcaMotherBoard.Items.Add(new ListItem("AsRock"));
        }

        private void AtualizarDPModeloCPU()
        {
            dpModeloCPU.Items.Clear();
            if (dpMarcaCPU.Text == "AMD")
            {
                dpModeloCPU.Items.Add(new ListItem("Ryzen 7"));
                dpModeloCPU.Items.Add(new ListItem("Ryzen 5"));
            }
            else if (dpMarcaCPU.Text == "Intel")
            {
                dpModeloCPU.Items.Add(new ListItem("i5"));
                dpModeloCPU.Items.Add(new ListItem("i7"));
            }
            else
            {
                dpModeloCPU.Items.Add(new ListItem("Ryzen 7"));
                dpModeloCPU.Items.Add(new ListItem("Ryzen 5"));
                dpModeloCPU.Items.Add(new ListItem("i5"));
                dpModeloCPU.Items.Add(new ListItem("i7"));
            }
        }

        private void AtualizarDPGeracaoCPU()
        {
            dpGeracaoCPU.Items.Clear();
            if (dpMarcaCPU.Text == "AMD")
            {
                dpGeracaoCPU.Items.Add(new ListItem("Ryzen 7000 series"));

            }
            else if (dpMarcaCPU.Text == "Intel")
            {
                dpGeracaoCPU.Items.Add(new ListItem("Intel 13 gen"));
            }
            else
            {
                dpGeracaoCPU.Items.Add(new ListItem("Ryzen 7000 series"));
                dpGeracaoCPU.Items.Add(new ListItem("Intel 13 gen"));
            }

        }

        private void AtualizarDPSocketCPU()
        {
            dpSocketCPU.Items.Clear();
            if (dpMarcaCPU.Text == "AMD")
            {
                dpSocketCPU.Items.Add(new ListItem("AM5"));

            }
            else if (dpMarcaCPU.Text == "Intel")
            {
                dpSocketCPU.Items.Add(new ListItem("LGA1700"));
            }
            else
            {
                dpSocketCPU.Items.Add(new ListItem("AM5"));
                dpSocketCPU.Items.Add(new ListItem("LGA1700"));
            }

        }

        private void AtualizarDPMarcaCPU()
        {
            dpMarcaCPU.Items.Clear();
            dpMarcaCPU.Items.Add(new ListItem("AMD"));
            dpMarcaCPU.Items.Add(new ListItem("Intel"));
        }

        protected void btEditar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = tbNome.Text;
                if (tbNome.Text.Trim().Length < 3)
                {
                    throw new Exception("O produto tem de ter um nome com um mínimo de 3 caracteres");
                }

                string tags = dpTipo.Text + ",";
                if (dpTipo.SelectedIndex == 0)
                {
                    throw new Exception("Escolha um tipo de produto");
                }
                else if (dpTipo.SelectedIndex == 1)
                {
                    tags += dpMarcaCPU.Text + ",";
                    tags += dpSocketCPU.Text + ",";
                    tags += dpModeloCPU.Text + ",";
                    tags += dpGeracaoCPU.Text;
                }
                else if (dpTipo.SelectedIndex == 2)
                {
                    tags += dpMarcaMotherBoard.Text + ",";
                    tags += dpCPUMotherboard.Text + ",";
                    tags += dpSocketMotherboard.Text + ",";
                    tags += dpChipset.Text + ",";
                    tags += dpTipoRamMotherboard.Text + ",";
                    tags += dpRamSlots.Text + ",";
                    tags += dpVelocidadeMax.Text + ",";
                    tags += dpSlotsM2.Text + ",";
                    if (chkWifi.Checked == true)
                    {
                        tags += "Wifi";
                    }
                    else
                    {
                        tags += "SemWifi";
                    }
                }
                else if (dpTipo.SelectedIndex == 3)
                {
                    tags += dpMarcaRam.Text + ",";
                    tags += dpTipoRam.Text + ",";
                    tags += dpVelocidadeRam.Text + ",";
                }
                else if (dpTipo.SelectedIndex == 4)
                {
                    tags += dpMarcaGrafica.Text + ",";
                    tags += dpModeloGrafica.Text;
                }
                else if (dpTipo.SelectedIndex == 5)
                {
                    tags += dpMarcaPSU.Text + ",";
                    tags += tbWatts.Text + ",";
                    if (chkModular.Checked == true)
                    {
                        tags += "Modular";
                    }
                    else
                    {
                        tags += "NaoModular";
                    }
                }
                else if (dpTipo.SelectedIndex == 6)
                {
                    tags += dpMarcaArmazenamento.Text + ",";
                    tags += dpTipoArmazenamento.Text + ",";
                    tags += tbTamanho.Text;
                }
                if (dpTipo.SelectedIndex == 7)
                {
                    tags += dpMarcaCaixa.Text + ",";
                    tags += dpFormatoCaixa.Text;
                }

                Decimal preco = Decimal.Parse(tbPreco.Text);
                if (preco < 0 || preco > 10000)
                {
                    throw new Exception("O preço não é válido");
                }
                DateTime data = DateTime.Parse(tbAquisicao.Text);
                if (data > DateTime.Now)
                {
                    throw new Exception("A data tem de ser inferior à data atual");
                }
                int stock = int.Parse(tbStock.Text);
                if (stock < 0)
                {
                    throw new Exception("O stock não é válido");
                }

                Produto produto = new Produto();
                produto.nome = nome;
                produto.tags = tags;
                produto.preco = preco;
                produto.data_aquisicao = data;
                produto.stock = stock;
                produto.estado = 1;
                produto.id = int.Parse(Request.QueryString["id"].ToString());
                produto.AtualizaProduto();

                if (fuProduto.HasFile)
                {
                    string ficheiro = Server.MapPath(@"~\Public\imagens\");
                    ficheiro = ficheiro + produto.id + ".jpg";
                    fuProduto.SaveAs(ficheiro);
                }

                lbErro.Text = "Produto Atualizado com sucesso!";
                Response.Redirect("~/Admin/Produtos/Produtos.aspx");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Redirecionar", "returnMain('produtos.aspx')", true);

            }
            catch (Exception ex)
            {
                lbErro.Text = "Ocorreu o seguinte erro: " + ex.Message;
                return;
            }
        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            
        }

        protected void dpTipo_SelectedIndexChanged1(object sender, EventArgs e)
        {
            EscondeDivs();
        }
        private void EscondeDivs()
        {
            if (dpTipo.SelectedIndex == 0)
            {
                divCPU.Visible = false;
                divMotherboard.Visible = false;
                divGrafica.Visible = false;
                divArmazenamento.Visible = false;
                divCaixa.Visible = false;
                divPSU.Visible = false;
                divRam.Visible = false;
            }
            else if (dpTipo.SelectedIndex == 1)
            {
                divCPU.Visible = true;
                divMotherboard.Visible = false;
                divGrafica.Visible = false;
                divArmazenamento.Visible = false;
                divCaixa.Visible = false;
                divPSU.Visible = false;
                divRam.Visible = false;
            }
            else if (dpTipo.SelectedIndex == 2)
            {
                divCPU.Visible = false;
                divMotherboard.Visible = true;
                divGrafica.Visible = false;
                divArmazenamento.Visible = false;
                divCaixa.Visible = false;
                divPSU.Visible = false;
                divRam.Visible = false;
            }
            else if (dpTipo.SelectedIndex == 3)
            {
                divCPU.Visible = false;
                divMotherboard.Visible = false;
                divGrafica.Visible = false;
                divArmazenamento.Visible = false;
                divCaixa.Visible = false;
                divPSU.Visible = false;
                divRam.Visible = true;
            }
            else if (dpTipo.SelectedIndex == 4)
            {
                divCPU.Visible = false;
                divMotherboard.Visible = false;
                divGrafica.Visible = true;
                divArmazenamento.Visible = false;
                divCaixa.Visible = false;
                divPSU.Visible = false;
                divRam.Visible = false;
            }
            else if (dpTipo.SelectedIndex == 5)
            {
                divCPU.Visible = false;
                divMotherboard.Visible = false;
                divGrafica.Visible = false;
                divArmazenamento.Visible = true;
                divCaixa.Visible = false;
                divPSU.Visible = false;
                divRam.Visible = false;
            }
            else if (dpTipo.SelectedIndex == 6)
            {
                divCPU.Visible = false;
                divMotherboard.Visible = false;
                divGrafica.Visible = false;
                divArmazenamento.Visible = false;
                divCaixa.Visible = true;
                divPSU.Visible = false;
                divRam.Visible = false;
            }
            else if (dpTipo.SelectedIndex == 7)
            {
                divCPU.Visible = false;
                divMotherboard.Visible = false;
                divGrafica.Visible = false;
                divArmazenamento.Visible = false;
                divCaixa.Visible = false;
                divPSU.Visible = true;
                divRam.Visible = false;
            }
            else
            {
                divCPU.Visible = false;
                divMotherboard.Visible = false;
                divGrafica.Visible = false;
                divArmazenamento.Visible = false;
                divCaixa.Visible = false;
                divPSU.Visible = false;
                divRam.Visible = false;
            }
        }

        protected void dpMarcaCPU_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarDPSocketCPU();
            AtualizarDPGeracaoCPU();
        }

        protected void dpSocketCPU_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarDPModeloCPU();
            AtualizarDPGeracaoCPU();
        }

        protected void dpCPUMotherboard_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarDPSocketMotherboard();
            AtualizarDPChipset();
        }

        protected void dpSocketMotherboard_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarDPChipset();
        }

        protected void dpTipoRamMotherboard_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarDPVelocidadeMax();
        }

        protected void dpTipoRam_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarDPVelocidadeRam();
        }
    }
}