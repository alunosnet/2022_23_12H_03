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

namespace Temas_de_Trabalhos.Modulos
{
    public partial class f_modulos : Form
    {
        BaseDados bd;
        int id_modulo_escolhido;
        public f_modulos(BaseDados bd)
        {
            this.bd = bd;
            InitializeComponent();
            AtualizaGrelha();
            AtualizaCBAno();
            //AtualizaCBDisciplina();
            //AtualizaCBNModulo();
            btn_Apagar.Visible = false;
            btn_Atualizar.Visible = false;
            btn_Cancelar.Visible = false;
            btn_Guardar.Visible = true;
            
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

        private void AtualizaCBNModulo()
        {
            cb_Numero.Items.Clear();
            int i = 1;
            while (i < 20)
            {
                cb_Numero.Items.Add(i);
                i++;
            }
        }

        private void AtualizaCBDisciplina()
        {
            cb_Disciplina.Items.Clear();
            //erro
            int ano = int.Parse(cb_Ano.SelectedItem.ToString());
            DataTable dados = Disciplina.ListarTodosDoAno(bd, ano);
            foreach (DataRow dr in dados.Rows)
            {
                Disciplina disciplina = new Disciplina();
                disciplina.Id_disciplina = int.Parse(dr["id_disciplina"].ToString());
                disciplina.Nome = dr["nome"].ToString();
                cb_Disciplina.Items.Add(disciplina);

            }
            AtualizaCBNModulo();
        }

        private void AtualizaGrelha()
        {
            dg_Modulos.AllowUserToAddRows = false;
            dg_Modulos.AllowUserToDeleteRows = false;
            dg_Modulos.ReadOnly = true;
            dg_Modulos.DataSource = Modulo.ListarTodos(bd);
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            //validação
            int ano = 0;
            if (int.TryParse(cb_Ano.Text, out ano) == false)
            {
                MessageBox.Show("Escolha um ano");
                return;
            }
            MessageBox.Show("O ano é " + ano + " e o cb_Ano é " + cb_Ano.Text);
            string disciplina = cb_Disciplina.Text;
            if (cb_Disciplina.SelectedIndex == -1)
            {
                MessageBox.Show("O cb_Disciplina não está a funcionar lá muito bem" + cb_Disciplina.Text);
                cb_Disciplina.Focus();
            }
            int nmodulo = 0;
            if (cb_Numero.SelectedIndex == -1)
            {
                MessageBox.Show("Escolha um número de modulo");
                cb_Numero.Focus();
            }
            if (int.TryParse(cb_Numero.Text, out nmodulo) == false){
                cb_Numero.Focus();
            }
            string nome = tb_Nome.Text;
            if (nome == "" || nome.Length < 2)
            {
                MessageBox.Show("O nome tem de ter pelo menos duas letras");
                tb_Nome.Focus();
            }
            int hora = 0;
            if (int.TryParse(tb_NHoras.Text, out hora) == false)
            {
                MessageBox.Show("As horas têm de ser preenchidas por números maiores que 1");
                tb_NHoras.Focus();
            }
           
            Disciplina _disciplina = cb_Disciplina.SelectedItem as Disciplina;
            //criar objeto
            Modulo modulo = new Modulo(ano, _disciplina.Id_disciplina, nmodulo, nome, hora);
            //guardar objeto
            modulo.Guardar(bd);
            //atualizar grelha
            AtualizaGrelha();
        }

        private void cb_Ano_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Ano.SelectedIndex <= -1)
            {
                return;
            }
            else
            {
                AtualizaCBDisciplina();
            }
            
        }

        private void btn_Atualizar_Click(object sender, EventArgs e)
        {
            int ano = 0;
            if (int.TryParse(cb_Ano.Text, out ano) == false)
            {
                MessageBox.Show("Escolha um ano");
                return;
            }
            string disciplina = cb_Disciplina.Text;
            if (cb_Disciplina.SelectedIndex == -1)
            {
                cb_Disciplina.Focus();
            }
            int nmodulo = 0;
            if (cb_Numero.SelectedIndex == -1)
            {
                MessageBox.Show("Escolha um número de modulo");
                cb_Numero.Focus();
            }
            if (int.TryParse(cb_Numero.Text, out nmodulo) == false)
            {
                cb_Numero.Focus();
            }
            string nome = tb_Nome.Text;
            if (nome == "" || nome.Length < 2)
            {
                MessageBox.Show("O nome tem de ter pelo menos duas letras");
                tb_Nome.Focus();
            }
            int hora = 0;
            if (int.TryParse(tb_NHoras.Text, out hora) == false)
            {
                MessageBox.Show("As horas têm de ser preenchidas por números maiores que 1");
                tb_NHoras.Focus();
            }
            Disciplina _disciplina = cb_Disciplina.SelectedItem as Disciplina;
            Modulo modulo = new Modulo();
            modulo.Id_modulo = id_modulo_escolhido;
            modulo.Ano = ano;
            modulo.Id_disciplina = _disciplina.Id_disciplina;
            modulo.Nome = nome;
            modulo.Nmodulo = nmodulo;
            modulo.Nhoras = hora;

            modulo.Atualizar(bd);

            AtualizaGrelha();
            LimparForm();
            DesativarButtons();
        }

        private void LimparForm()
        {
            cb_Ano.SelectedIndex = -1;
            cb_Disciplina.SelectedIndex = -1;
            cb_Numero.SelectedIndex = -1;
            tb_Nome.Text = "";
            tb_NHoras.Text = "";
        }

        private void btn_Apagar_Click(object sender, EventArgs e)
        {
            if (id_modulo_escolhido < -1)
            {
                MessageBox.Show("Tem de selecionar um módulo primeiro. ");
                return;
            }

            if (MessageBox.Show("Tem a certeza que pretende eliminar o módulo selecionado?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Modulo.ApagarModulo(id_modulo_escolhido, bd);
            }

            AtualizaGrelha();
            LimparForm();
            DesativarButtons();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            LimparForm();
            DesativarButtons();
        }

        private void dg_Modulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AtivarButtons();
            AtualizaCBAno();

            int linha = dg_Modulos.CurrentCell.RowIndex;
            if (linha == -1)
            {
                return;
            }
            int id_modulo = int.Parse(dg_Modulos.Rows[linha].Cells[0].Value.ToString());
            Modulo escolhido = new Modulo();
            Disciplina disciplina = new Disciplina();
            escolhido.Procurar(id_modulo, bd);
            cb_Ano.SelectedItem = escolhido.Ano;
            disciplina.Procurar(escolhido.Id_disciplina, bd);
            cb_Disciplina.Text = disciplina.Nome;
            escolhido.ProcurarPorIdModulo(bd, escolhido.Id_modulo);
            cb_Numero.Text = escolhido.Nmodulo.ToString(); 
            tb_Nome.Text = escolhido.Nome;
            tb_NHoras.Text = escolhido.Nhoras.ToString();

            id_modulo_escolhido = escolhido.Id_modulo;
        }

        private void AtivarButtons()
        {
            btn_Apagar.Visible = true;
            btn_Atualizar.Visible = true;
            btn_Cancelar.Visible = true;
            btn_Guardar.Visible = false;
        }
    }
}
