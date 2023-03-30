namespace Temas_de_Trabalhos.Disciplinas
{
    partial class f_disciplina
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.tb_Nome = new System.Windows.Forms.TextBox();
            this.dg_Disciplinas = new System.Windows.Forms.DataGridView();
            this.btn_Atualizar = new System.Windows.Forms.Button();
            this.btn_Apagar = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.cb_Ano = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Disciplinas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ano de Escolaridade";
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.Location = new System.Drawing.Point(127, 265);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(162, 67);
            this.btn_Guardar.TabIndex = 4;
            this.btn_Guardar.Text = "Guardar";
            this.btn_Guardar.UseVisualStyleBackColor = true;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // tb_Nome
            // 
            this.tb_Nome.Location = new System.Drawing.Point(127, 35);
            this.tb_Nome.Name = "tb_Nome";
            this.tb_Nome.Size = new System.Drawing.Size(162, 20);
            this.tb_Nome.TabIndex = 5;
            // 
            // dg_Disciplinas
            // 
            this.dg_Disciplinas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Disciplinas.Location = new System.Drawing.Point(335, 35);
            this.dg_Disciplinas.Name = "dg_Disciplinas";
            this.dg_Disciplinas.Size = new System.Drawing.Size(354, 264);
            this.dg_Disciplinas.TabIndex = 7;
            this.dg_Disciplinas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_Disciplinas_CellClick);
            // 
            // btn_Atualizar
            // 
            this.btn_Atualizar.Location = new System.Drawing.Point(335, 309);
            this.btn_Atualizar.Name = "btn_Atualizar";
            this.btn_Atualizar.Size = new System.Drawing.Size(75, 23);
            this.btn_Atualizar.TabIndex = 8;
            this.btn_Atualizar.Text = "Atualizar";
            this.btn_Atualizar.UseVisualStyleBackColor = true;
            this.btn_Atualizar.Click += new System.EventHandler(this.btn_Atualizar_Click);
            // 
            // btn_Apagar
            // 
            this.btn_Apagar.Location = new System.Drawing.Point(416, 309);
            this.btn_Apagar.Name = "btn_Apagar";
            this.btn_Apagar.Size = new System.Drawing.Size(75, 23);
            this.btn_Apagar.TabIndex = 9;
            this.btn_Apagar.Text = "Apagar";
            this.btn_Apagar.UseVisualStyleBackColor = true;
            this.btn_Apagar.Click += new System.EventHandler(this.btn_Apagar_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Location = new System.Drawing.Point(614, 309);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancelar.TabIndex = 10;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // cb_Ano
            // 
            this.cb_Ano.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Ano.FormattingEnabled = true;
            this.cb_Ano.Location = new System.Drawing.Point(127, 76);
            this.cb_Ano.Name = "cb_Ano";
            this.cb_Ano.Size = new System.Drawing.Size(47, 21);
            this.cb_Ano.TabIndex = 11;
            // 
            // f_disciplina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 376);
            this.Controls.Add(this.cb_Ano);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Apagar);
            this.Controls.Add(this.btn_Atualizar);
            this.Controls.Add(this.dg_Disciplinas);
            this.Controls.Add(this.tb_Nome);
            this.Controls.Add(this.btn_Guardar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "f_disciplina";
            this.Text = "f_disciplina";
            ((System.ComponentModel.ISupportInitialize)(this.dg_Disciplinas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.TextBox tb_Nome;
        private System.Windows.Forms.DataGridView dg_Disciplinas;
        private System.Windows.Forms.Button btn_Atualizar;
        private System.Windows.Forms.Button btn_Apagar;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.ComboBox cb_Ano;
    }
}