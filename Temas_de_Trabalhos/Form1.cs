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
using Temas_de_Trabalhos.Temas;

namespace Temas_de_Trabalhos
{
    public partial class Form1 : Form
    {
        BaseDados bd = new BaseDados("M15_BD_Projeto");
        public Form1()
        {
            InitializeComponent();
        }

        private void disciplinasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_disciplina f_Disciplina = new f_disciplina(bd);
            f_Disciplina.Show();
        }

        private void módulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_modulos f_Modulos = new f_modulos(bd);
            f_Modulos.Show();
        }

        private void temasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_temas f_Temas = new f_temas(bd);
            f_Temas.Show();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void entregarTrabalhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_entregar f_Entregar = new f_entregar(bd);
            f_Entregar.Show();
        }
    }
}
