namespace Temas_de_Trabalhos.Modulos
{
    partial class f_modulos
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
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.btn_Apagar = new System.Windows.Forms.Button();
            this.btn_Atualizar = new System.Windows.Forms.Button();
            this.dg_Modulos = new System.Windows.Forms.DataGridView();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_Disciplina = new System.Windows.Forms.ComboBox();
            this.cb_Numero = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_NHoras = new System.Windows.Forms.TextBox();
            this.tb_Nome = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_Ano = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Modulos)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Location = new System.Drawing.Point(607, 303);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancelar.TabIndex = 19;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // btn_Apagar
            // 
            this.btn_Apagar.Location = new System.Drawing.Point(409, 303);
            this.btn_Apagar.Name = "btn_Apagar";
            this.btn_Apagar.Size = new System.Drawing.Size(75, 23);
            this.btn_Apagar.TabIndex = 18;
            this.btn_Apagar.Text = "Apagar";
            this.btn_Apagar.UseVisualStyleBackColor = true;
            this.btn_Apagar.Click += new System.EventHandler(this.btn_Apagar_Click);
            // 
            // btn_Atualizar
            // 
            this.btn_Atualizar.Location = new System.Drawing.Point(328, 303);
            this.btn_Atualizar.Name = "btn_Atualizar";
            this.btn_Atualizar.Size = new System.Drawing.Size(75, 23);
            this.btn_Atualizar.TabIndex = 17;
            this.btn_Atualizar.Text = "Atualizar";
            this.btn_Atualizar.UseVisualStyleBackColor = true;
            this.btn_Atualizar.Click += new System.EventHandler(this.btn_Atualizar_Click);
            // 
            // dg_Modulos
            // 
            this.dg_Modulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Modulos.Location = new System.Drawing.Point(328, 29);
            this.dg_Modulos.Name = "dg_Modulos";
            this.dg_Modulos.Size = new System.Drawing.Size(354, 264);
            this.dg_Modulos.TabIndex = 16;
            this.dg_Modulos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_Modulos_CellClick);
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.Location = new System.Drawing.Point(120, 259);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(162, 67);
            this.btn_Guardar.TabIndex = 13;
            this.btn_Guardar.Text = "Guardar";
            this.btn_Guardar.UseVisualStyleBackColor = true;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Número";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Disciplina";
            // 
            // cb_Disciplina
            // 
            this.cb_Disciplina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Disciplina.FormattingEnabled = true;
            this.cb_Disciplina.Location = new System.Drawing.Point(120, 73);
            this.cb_Disciplina.Name = "cb_Disciplina";
            this.cb_Disciplina.Size = new System.Drawing.Size(162, 21);
            this.cb_Disciplina.TabIndex = 20;
            // 
            // cb_Numero
            // 
            this.cb_Numero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Numero.FormattingEnabled = true;
            this.cb_Numero.Location = new System.Drawing.Point(120, 120);
            this.cb_Numero.Name = "cb_Numero";
            this.cb_Numero.Size = new System.Drawing.Size(162, 21);
            this.cb_Numero.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Número de Horas";
            // 
            // tb_NHoras
            // 
            this.tb_NHoras.Location = new System.Drawing.Point(120, 215);
            this.tb_NHoras.Name = "tb_NHoras";
            this.tb_NHoras.Size = new System.Drawing.Size(162, 20);
            this.tb_NHoras.TabIndex = 23;
            // 
            // tb_Nome
            // 
            this.tb_Nome.Location = new System.Drawing.Point(120, 169);
            this.tb_Nome.Name = "tb_Nome";
            this.tb_Nome.Size = new System.Drawing.Size(162, 20);
            this.tb_Nome.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Nome";
            // 
            // cb_Ano
            // 
            this.cb_Ano.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Ano.FormattingEnabled = true;
            this.cb_Ano.Location = new System.Drawing.Point(120, 29);
            this.cb_Ano.Name = "cb_Ano";
            this.cb_Ano.Size = new System.Drawing.Size(162, 21);
            this.cb_Ano.TabIndex = 26;
            this.cb_Ano.SelectedIndexChanged += new System.EventHandler(this.cb_Ano_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(67, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Ano";
            // 
            // f_modulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 348);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cb_Ano);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_Nome);
            this.Controls.Add(this.tb_NHoras);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_Numero);
            this.Controls.Add(this.cb_Disciplina);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Apagar);
            this.Controls.Add(this.btn_Atualizar);
            this.Controls.Add(this.dg_Modulos);
            this.Controls.Add(this.btn_Guardar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "f_modulos";
            this.Text = "f_modulos";
            ((System.ComponentModel.ISupportInitialize)(this.dg_Modulos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button btn_Apagar;
        private System.Windows.Forms.Button btn_Atualizar;
        private System.Windows.Forms.DataGridView dg_Modulos;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_Disciplina;
        private System.Windows.Forms.ComboBox cb_Numero;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_NHoras;
        private System.Windows.Forms.TextBox tb_Nome;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_Ano;
        private System.Windows.Forms.Label label5;
    }
}