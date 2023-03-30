using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Temas_de_Trabalhos.Disciplinas;
using Temas_de_Trabalhos.Modulos;

namespace Temas_de_Trabalhos.Temas
{
    public partial class f_temas : Form
    {
        string fotografia;
        int id_tema_escolhido;
        BaseDados bd;
        public f_temas(BaseDados bd)
        {
            this.bd = bd;
            InitializeComponent();
            AtualizarGrelha();
            AtualizaCBAno();
            DesativarButtons();
            
        }

        public void AtivarButtons()
        {
            btn_Apagar.Visible = true;
            btn_Atualizar.Visible = true;
            btn_Cancelar.Visible = true;
            btn_Guardar.Visible = false;
        }

        public void DesativarButtons()
        {
            btn_Apagar.Visible = false;
            btn_Atualizar.Visible = false;
            btn_Cancelar.Visible = false;
            btn_Guardar.Visible = true;
        }

        public void LimparForm()
        {
            cb_Ano.SelectedIndex = -1;
            cb_Disciplina.SelectedIndex = -1;
            cb_Modulo.SelectedIndex = -1;
            tb_Tema.Text = "";
            dt_Entrega.Value = DateTime.Now;
            pb_Fotografia.Image = null;
        }

        private void AtualizaCBModulo()
        {
            cb_Modulo.Items.Clear();
            Disciplina _disciplina = cb_Disciplina.SelectedItem as Disciplina;
            DataTable dados = Modulo.ListarModulos(bd, _disciplina.Id_disciplina);
            foreach (DataRow dr in dados.Rows)
            {
                Modulo modulo = new Modulo();
                modulo.Id_modulo = int.Parse(dr["id_modulo"].ToString());
                MessageBox.Show(modulo.Id_modulo.ToString());
                modulo.Nome = dr["nmodulo"].ToString();
                cb_Modulo.Items.Add(modulo);
            }
        }

        private void AtualizaCBAno()
        {
            cb_Ano.Items.Clear();
            cb_Ano.Items.Add(10);
            cb_Ano.Items.Add(11);
            cb_Ano.Items.Add(12);
            cb_Ano.SelectedIndex = -1;
        }

        private void AtualizarCBDisciplinas()
        {
            cb_Disciplina.Items.Clear();
            DataTable dados = Disciplina.ListarTodosDoAno(bd, int.Parse(cb_Ano.Text));
            foreach (DataRow dr in dados.Rows)
            {
                Disciplina disciplina = new Disciplina();
                disciplina.Id_disciplina = int.Parse(dr["id_disciplina"].ToString());
                disciplina.Nome = dr["nome"].ToString();
                cb_Disciplina.Items.Add(disciplina);
            }
        }

        private void AtualizarGrelha()
        {
            dg_Temas.AllowUserToAddRows = false;
            dg_Temas.AllowUserToDeleteRows = false;
            dg_Temas.ReadOnly = true;
            dg_Temas.DataSource = Tema.ListarTodos(bd);
        }



        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            //validar
            int ano = 0;
            if (cb_Ano.SelectedIndex == -1)
            {
                MessageBox.Show("Tem de selecionar um ano");
                cb_Ano.Focus();
            }
            if (int.TryParse(cb_Ano.Text, out ano) == false)
            {
                MessageBox.Show("Tem de selecionar um ano");
                cb_Ano.Focus();
            }
            if (cb_Disciplina.SelectedIndex == -1)
            {
                MessageBox.Show("Tem de selecionar uma disciplina");
                cb_Disciplina.Focus();
            }
            if (cb_Modulo.SelectedIndex == -1)
            {
                MessageBox.Show("Tem de selecionar um módulo");
                cb_Modulo.Focus();
            }

            string nome = tb_Tema.Text;
            if (nome == "" || nome.Length < 2)
            {
                MessageBox.Show("O tema tem de ter pelo menos 2 letras");
                tb_Tema.Focus();
            }

            DateTime entrega = dt_Entrega.Value;

            if (String.IsNullOrEmpty(fotografia))
            {
                MessageBox.Show("Tem de selecionar uma fotografia!");
                return;
            }
            //Fazer esta coisa
            Disciplina disciplina = cb_Disciplina.SelectedItem as Disciplina;
            Modulo modulo = cb_Modulo.SelectedItem as Modulo;
            MessageBox.Show(modulo.Id_modulo.ToString());
            //cria obj
            Tema tema = new Tema(disciplina.Id_disciplina, ano, modulo.Id_modulo, nome, entrega, Utils.ImagemParaVetor(fotografia));
            //guardar
            tema.Guardar(bd);
            //atualizar grelha
            AtualizarGrelha();
        }

        private void btn_Escolher_Click(object sender, EventArgs e)
        {
            OpenFileDialog ficheiro = new OpenFileDialog();
            ficheiro.InitialDirectory = "c:\\";
            ficheiro.Filter = "Imagens |*.jpg;*.png | Todos os ficheiros |*.*";
            ficheiro.Multiselect = false;
            if (ficheiro.ShowDialog() == DialogResult.OK)
            {
                string temp = ficheiro.FileName;
                if (System.IO.File.Exists(temp))
                {
                    pb_Fotografia.Image = Image.FromFile(temp);
                    fotografia = temp;
                }
            }
        }

        private void dg_Temas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int linha = dg_Temas.CurrentCell.RowIndex;
            if(linha == -1)
            {
                return;
            }
            int id_tema = int.Parse(dg_Temas.Rows[linha].Cells[0].Value.ToString());
            Tema escolhido = new Tema();
            Modulo modulo = new Modulo();
            Disciplina disciplina = new Disciplina();
            escolhido.Procurar(bd, id_tema);
            cb_Ano.SelectedItem = escolhido.Ano;
            disciplina.Procurar(escolhido.Id_disciplina, bd);
            cb_Disciplina.Text = disciplina.Nome;
            modulo.Procurar(escolhido.Id_modulo, bd);
            cb_Modulo.Text = modulo.Nmodulo.ToString();
            tb_Tema.Text = escolhido.Nome;
            dt_Entrega.Value = escolhido.Entrega;
            string ficheiro = System.IO.Path.GetTempPath() + @"\imagem.jpg";
            Utils.VetorParaImagem(escolhido.Fotografia, ficheiro);
            Image img;
            using (var bitmap = new Bitmap(ficheiro))
            {
                img = new Bitmap(bitmap);
                pb_Fotografia.Image = img;
            }

            id_tema_escolhido = id_tema;

            AtivarButtons();


        }

        private void btn_Atualizar_Click(object sender, EventArgs e)
        {
            //validar
            int ano = 0;
            if (cb_Ano.SelectedIndex == -1)
            {
                MessageBox.Show("Tem de selecionar um ano");
                cb_Ano.Focus();
            }
            if (int.TryParse(cb_Ano.Text, out ano) == false)
            {
                MessageBox.Show("Tem de selecionar um ano");
                cb_Ano.Focus();
            }
            if (cb_Disciplina.SelectedIndex == -1)
            {
                MessageBox.Show("Tem de selecionar uma disciplina");
                cb_Disciplina.Focus();
            }
            if (cb_Modulo.SelectedIndex == -1)
            {
                MessageBox.Show("Tem de selecionar um módulo");
                cb_Modulo.Focus();
            }

            string nome = tb_Tema.Text;
            if (nome == "" || nome.Length < 2)
            {
                MessageBox.Show("O tema tem de ter pelo menos 2 letras");
                tb_Tema.Focus();
            }

            DateTime entrega = dt_Entrega.Value;

            if (String.IsNullOrEmpty(fotografia))
            {
                MessageBox.Show("Tem de selecionar uma fotografia!");
                return;
            }

            Disciplina _disciplina = cb_Disciplina.SelectedItem as Disciplina;
            Modulo _modulo = cb_Modulo.SelectedItem as Modulo;
            Tema tema = new Tema();
            tema.Id_tema = id_tema_escolhido;
            tema.Id_disciplina = _disciplina.Id_disciplina;
            tema.Ano = ano;
            tema.Id_modulo = _modulo.Id_modulo;
            tema.Nome = nome;
            tema.Entrega = entrega;

            if (fotografia != null && fotografia != "")
            {
                tema.Fotografia = Utils.ImagemParaVetor(fotografia);
            }

            tema.Atualizar(bd);

            AtualizarGrelha();
            LimparForm();
            DesativarButtons();
        }

        private void cb_Ano_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Ano.SelectedIndex <= -1)
            {
                return;
            }
            else
            {
                AtualizarCBDisciplinas();
            }
        }

        private void cb_Disciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cb_Disciplina.SelectedIndex <= -1)
            {
                return;
            }
            else
            {
                AtualizaCBModulo();
            }
            
        }

        private void btn_Apagar_Click(object sender, EventArgs e)
        {
            if (id_tema_escolhido < -1)
            {
                MessageBox.Show("Tem de selecionar um tema primeiro. ");
                return;
            }
            if (MessageBox.Show("Tem a certeza que pretende eliminar o tema selecionado?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Tema.ApagarTema(id_tema_escolhido, bd);
            }

            AtualizarGrelha();
            LimparForm();
            DesativarButtons();

        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            LimparForm();
            DesativarButtons();
        }

        private void tb_Pesquisar_TextChanged(object sender, EventArgs e)
        {
            dg_Temas.DataSource = Tema.PesquisarNome(bd, tb_Pesquisar.Text);
        }
    }
}
