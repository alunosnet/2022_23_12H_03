using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Temas_de_Trabalhos.Temas
{
    public partial class f_entregar : Form
    {
        BaseDados bd;
        public f_entregar(BaseDados bd)
        {
            InitializeComponent();
            this.bd = bd;
            AtualizaLBEntregar();
        }

        private void AtualizaLBEntregar()
        {
            lb_Temas.Items.Clear();
            DataTable dados = Tema.ListarPorEntregar(bd);
            foreach (DataRow dr in dados.Rows)
            {
                Tema tema = new Tema();
                tema.Id_tema = int.Parse(dr["id_tema"].ToString());
                tema.Nome = dr["nome"].ToString();
                lb_Temas.Items.Add(tema);
            }
        }

        private void btn_Entregar_Click(object sender, EventArgs e)
        {
            if(lb_Temas.SelectedItem == null)
            {
                MessageBox.Show("Tem de escolher o tema a entregar");
                return;
            }
            Tema tema = lb_Temas.SelectedItem as Tema;
            Tema.Entregar(bd, tema.Id_tema);
            AtualizaLBEntregar();
        }
    }
}
