using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Temas_de_Trabalhos.Disciplinas
{
    public partial class f_disciplina : Form
    {
        BaseDados bd;
        int id_disciplina_escolhida;
        public f_disciplina(BaseDados bd)
        {
            this.bd = bd;
            InitializeComponent();
            AtualizaCBAno();
            AtualizaGrelha();
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

        private void AtualizaCBAno()
        {
            cb_Ano.Items.Clear();
            cb_Ano.Items.Add(10);
            cb_Ano.Items.Add(11);
            cb_Ano.Items.Add(12);
        }

        private void AtualizaGrelha()
        {
            dg_Disciplinas.AllowUserToAddRows = false;
            dg_Disciplinas.AllowUserToDeleteRows = false;
            dg_Disciplinas.ReadOnly = true;
            dg_Disciplinas.DataSource = Disciplina.ListarTodos(bd);
        }

        

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            // Validações
            string nome = tb_Nome.Text;
            if (nome == "" || nome.Length < 2)
            {
                MessageBox.Show("Nome tem de ter pelo menos 2 letras.");
                tb_Nome.Focus();
                return;
            }

            int ano = 0;
            if (int.TryParse(cb_Ano.Text, out ano) == false)
            {
                MessageBox.Show("Escolha um ano");
                return;
            }

            Disciplina disciplina = new Disciplina(tb_Nome.Text, ano);

            disciplina.Guardar(bd);

            AtualizaGrelha();
        }

        private void btn_Atualizar_Click(object sender, EventArgs e)
        {
            // Validações
            string nome = tb_Nome.Text;
            if (nome == "" || nome.Length < 2)
            {
                MessageBox.Show("Nome tem de ter pelo menos 2 letras.");
                tb_Nome.Focus();
                return;
            }

            int ano = 0;
            if (int.TryParse(cb_Ano.Text, out ano) == false)
            {
                MessageBox.Show("Escolha um ano");
                return;
            }

            Disciplina disciplina = new Disciplina();
            disciplina.Id_disciplina = id_disciplina_escolhida;
            disciplina.Nome = nome;
            disciplina.Ano = ano;

            disciplina.Atualizar(bd);

            AtualizaGrelha();
            LimparForm();
            DesativarButtons();
        }

        private void dg_Disciplinas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AtivarButtons();

            int linha = dg_Disciplinas.CurrentCell.RowIndex;
            if (linha == -1)
            {
                return;
            }
            int id_disciplina = int.Parse(dg_Disciplinas.Rows[linha].Cells[0].Value.ToString());
            Disciplina escolhido = new Disciplina();
            escolhido.Procurar(id_disciplina, bd);
            cb_Ano.SelectedItem = escolhido.Ano;
            tb_Nome.Text = escolhido.Nome;

            id_disciplina_escolhida = escolhido.Id_disciplina;
        }

        private void btn_Apagar_Click(object sender, EventArgs e)
        {
            if (id_disciplina_escolhida < -1)
            {
                MessageBox.Show("Tem de selecionar uma disciplina primeiro.");
                return;
            }

            if(MessageBox.Show("Tem a certeza que pretende eliminar a disciplina selecionada?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Disciplina.ApagarDisciplina(id_disciplina_escolhida, bd);
            }

            LimparForm();
            DesativarButtons();
        }

        private void LimparForm()
        {
            tb_Nome.Text = "";
            cb_Ano.SelectedIndex = -1;
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            LimparForm();
            DesativarButtons();
        }
    }
}
