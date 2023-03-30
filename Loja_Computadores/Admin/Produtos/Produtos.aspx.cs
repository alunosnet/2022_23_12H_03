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
    public partial class Produtos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (UserLogin.ValidarSessao(Session, Request, "0") == false)
            {
                Response.Redirect("~/index.aspx");
            }*/
            AtualizaGrid();
            if (!IsPostBack)
            {
                AtualizaDPs();

                divCPU.Visible = false;
                divMotherboard.Visible = false;
                divGrafica.Visible = false;
                divArmazenamento.Visible = false;
                divCaixa.Visible = false;
                divPSU.Visible = false;
                divRam.Visible = false;
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
            if(dpCPUMotherboard.Text == "Intel")
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
            if(dpMarcaCPU.Text == "AMD")
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

        private void AtualizaGrid()
        {

            gv_Produtos.Columns.Clear();
            Produto pd = new Produto();
            DataTable dados;
            if(rbfiltra.SelectedIndex == 1)
            {
                dados = pd.ListarTodosProdutos(1);
            }
            else if (rbfiltra.SelectedIndex == 2)
            {
                dados = pd.ListarTodosProdutos(2);
            }
            else
            {
                dados = pd.ListarTodosProdutos();
            }
            //DataTable dados = pd.ListarTodosProdutos();

            DataColumn dcEditar = new DataColumn();
            dcEditar.ColumnName = "Editar";
            dcEditar.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcEditar);

            DataColumn dcMudarEstado = new DataColumn();
            dcMudarEstado.ColumnName = "Mudar Estado";
            dcMudarEstado.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcMudarEstado);

            DataColumn dcAddStock = new DataColumn();
            dcAddStock.ColumnName = "Adicionar Stock";
            dcAddStock.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcAddStock);

            gv_Produtos.DataSource = dados;
            gv_Produtos.AutoGenerateColumns = false;

            //Editar
            HyperLinkField hlEditar = new HyperLinkField();
            hlEditar.HeaderText = "Editar";
            hlEditar.DataTextField = "Editar";
            hlEditar.Text = "Editar...";
            hlEditar.DataNavigateUrlFormatString = "EditarProduto.aspx?id={0}";
            hlEditar.DataNavigateUrlFields = new string[] { "id" };
            gv_Produtos.Columns.Add(hlEditar);
            //Descontinuar
            HyperLinkField hlMudarEstado = new HyperLinkField();
            hlMudarEstado.HeaderText = "Mudar Estado";
            hlMudarEstado.DataTextField = "Mudar Estado";
            hlMudarEstado.Text = "Mudar Estado";
            hlMudarEstado.DataNavigateUrlFormatString = "MudarEstadoProduto.aspx?id={0}";
            hlMudarEstado.DataNavigateUrlFields = new string[] { "id" };
            gv_Produtos.Columns.Add(hlMudarEstado);
            //Descontinuar
            HyperLinkField hlAddStock = new HyperLinkField();
            hlAddStock.HeaderText = "Adicionar Stock";
            hlMudarEstado.DataTextField = "Adicionar Stock";
            hlAddStock.Text = "Adicionar Stock...";
            hlAddStock.DataNavigateUrlFormatString = "AddStockProduto.aspx?id={0}";
            hlAddStock.DataNavigateUrlFields = new string[] { "id" };
            gv_Produtos.Columns.Add(hlAddStock);
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
            //estado
            BoundField bfestado = new BoundField();
            bfestado.HeaderText = "Estado";
            bfestado.DataField = "estado";
            gv_Produtos.Columns.Add(bfestado);
            //imagem
            ImageField ifImg = new ImageField();
            ifImg.HeaderText = "Imagem";
            int aleatorio = new Random().Next(99999);
            ifImg.DataImageUrlFormatString = "~/Public/Imagens/{0}.jpg?" + aleatorio;
            ifImg.DataImageUrlField = "id";
            ifImg.ControlStyle.Width = 200;
            gv_Produtos.Columns.Add(ifImg);

            gv_Produtos.DataBind();
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

        protected void btAdicionar_Click(object sender, EventArgs e)
        {
            string nome = tbNome.Text;
            if (tbNome.Text.Trim().Length < 3)
            {
                throw new Exception("O produto tem de ter um nome com um mínimo de 3 caracteres");
            }

            string tags = dpTipo.Text + ",";
            if(dpTipo.SelectedIndex == 0)
            {
                throw new Exception("Escolha um tipo de produto");
            }
            else if(dpTipo.SelectedIndex == 1)
            {
                tags += dpMarcaCPU.Text + ",";
                tags += dpSocketCPU.Text + ",";
                tags += dpModeloCPU.Text + ",";
                tags += dpGeracaoCPU.Text;
            }
            else if(dpTipo.SelectedIndex == 2)
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
            else if(dpTipo.SelectedIndex == 3)
            {
                tags += dpMarcaRam.Text + ",";
                tags += dpTipoRam.Text + ",";
                tags += dpVelocidadeRam.Text + ",";
            }
            else if(dpTipo.SelectedIndex == 4)
            {
                tags += dpMarcaGrafica.Text + ",";
                tags += dpModeloGrafica.Text;
            }
            else if(dpTipo.SelectedIndex == 5)
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
            int id = produto.Adicionar();

            if (fuImg.HasFile)
            {
                string ficheiro = Server.MapPath(@"~\Public\imagens\");
                ficheiro = ficheiro + id + ".jpg";
                fuImg.SaveAs(ficheiro);
            }

            AtualizaGrid();
        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            LimpaForm();
        }

        private void LimpaForm()
        {
            tbNome.Text = "";
            tbPreco.Text = "";
            tbStock.Text = "0";
            tbAquisicao.Text = "";
            dpTipo.SelectedIndex = 0;
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
        }

        protected void dpTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            EscondeDivs();
        }

        protected void dpMarcaCPU_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarDPSocketCPU();
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

        protected void dpTipoRam_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarDPVelocidadeRam();
        }

        protected void dpSocketCPU_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarDPModeloCPU();
            AtualizarDPGeracaoCPU();
        }

        protected void dpTipoRamMotherboard_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarDPVelocidadeMax();
        }

        protected void rbfiltra_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizaGrid();
        }
    }
}