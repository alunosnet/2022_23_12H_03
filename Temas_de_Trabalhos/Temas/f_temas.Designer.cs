namespace Temas_de_Trabalhos.Temas
{
    partial class f_temas
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
            this.cb_Disciplina = new System.Windows.Forms.ComboBox();
            this.cb_Modulo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Tema = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dt_Entrega = new System.Windows.Forms.DateTimePicker();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.dg_Temas = new System.Windows.Forms.DataGridView();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.btn_Apagar = new System.Windows.Forms.Button();
            this.btn_Atualizar = new System.Windows.Forms.Button();
            this.cb_Ano = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Escolher = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.pb_Fotografia = new System.Windows.Forms.PictureBox();
            this.tb_Pesquisar = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Temas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Fotografia)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_Disciplina
            // 
            this.cb_Disciplina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Disciplina.FormattingEnabled = true;
            this.cb_Disciplina.Location = new System.Drawing.Point(128, 70);
            this.cb_Disciplina.Name = "cb_Disciplina";
            this.cb_Disciplina.Size = new System.Drawing.Size(200, 21);
            this.cb_Disciplina.TabIndex = 0;
            this.cb_Disciplina.SelectedIndexChanged += new System.EventHandler(this.cb_Disciplina_SelectedIndexChanged);
            // 
            // cb_Modulo
            // 
            this.cb_Modulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Modulo.FormattingEnabled = true;
            this.cb_Modulo.Location = new System.Drawing.Point(128, 107);
            this.cb_Modulo.Name = "cb_Modulo";
            this.cb_Modulo.Size = new System.Drawing.Size(59, 21);
            this.cb_Modulo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Disciplina";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Módulo";
            // 
            // tb_Tema
            // 
            this.tb_Tema.Location = new System.Drawing.Point(128, 146);
            this.tb_Tema.Name = "tb_Tema";
            this.tb_Tema.Size = new System.Drawing.Size(200, 20);
            this.tb_Tema.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tema";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Data de Entrega";
            // 
            // dt_Entrega
            // 
            this.dt_Entrega.Location = new System.Drawing.Point(128, 184);
            this.dt_Entrega.Name = "dt_Entrega";
            this.dt_Entrega.Size = new System.Drawing.Size(200, 20);
            this.dt_Entrega.TabIndex = 8;
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.Location = new System.Drawing.Point(128, 354);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(108, 38);
            this.btn_Guardar.TabIndex = 9;
            this.btn_Guardar.Text = "Guardar";
            this.btn_Guardar.UseVisualStyleBackColor = true;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // dg_Temas
            // 
            this.dg_Temas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Temas.Location = new System.Drawing.Point(392, 70);
            this.dg_Temas.Name = "dg_Temas";
            this.dg_Temas.Size = new System.Drawing.Size(356, 272);
            this.dg_Temas.TabIndex = 10;
            this.dg_Temas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_Temas_CellClick);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Location = new System.Drawing.Point(673, 362);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancelar.TabIndex = 13;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // btn_Apagar
            // 
            this.btn_Apagar.Location = new System.Drawing.Point(473, 362);
            this.btn_Apagar.Name = "btn_Apagar";
            this.btn_Apagar.Size = new System.Drawing.Size(75, 23);
            this.btn_Apagar.TabIndex = 12;
            this.btn_Apagar.Text = "Apagar";
            this.btn_Apagar.UseVisualStyleBackColor = true;
            this.btn_Apagar.Click += new System.EventHandler(this.btn_Apagar_Click);
            // 
            // btn_Atualizar
            // 
            this.btn_Atualizar.Location = new System.Drawing.Point(392, 362);
            this.btn_Atualizar.Name = "btn_Atualizar";
            this.btn_Atualizar.Size = new System.Drawing.Size(75, 23);
            this.btn_Atualizar.TabIndex = 11;
            this.btn_Atualizar.Text = "Atualizar";
            this.btn_Atualizar.UseVisualStyleBackColor = true;
            this.btn_Atualizar.Click += new System.EventHandler(this.btn_Atualizar_Click);
            // 
            // cb_Ano
            // 
            this.cb_Ano.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Ano.FormattingEnabled = true;
            this.cb_Ano.Location = new System.Drawing.Point(128, 33);
            this.cb_Ano.Name = "cb_Ano";
            this.cb_Ano.Size = new System.Drawing.Size(59, 21);
            this.cb_Ano.TabIndex = 27;
            this.cb_Ano.SelectedIndexChanged += new System.EventHandler(this.cb_Ano_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Ano";
            // 
            // btn_Escolher
            // 
            this.btn_Escolher.Location = new System.Drawing.Point(128, 219);
            this.btn_Escolher.Name = "btn_Escolher";
            this.btn_Escolher.Size = new System.Drawing.Size(75, 23);
            this.btn_Escolher.TabIndex = 29;
            this.btn_Escolher.Text = "Escolher..";
            this.btn_Escolher.UseVisualStyleBackColor = true;
            this.btn_Escolher.Click += new System.EventHandler(this.btn_Escolher_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(57, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Fotografia";
            // 
            // pb_Fotografia
            // 
            this.pb_Fotografia.Location = new System.Drawing.Point(128, 248);
            this.pb_Fotografia.Name = "pb_Fotografia";
            this.pb_Fotografia.Size = new System.Drawing.Size(108, 100);
            this.pb_Fotografia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Fotografia.TabIndex = 31;
            this.pb_Fotografia.TabStop = false;
            // 
            // tb_Pesquisar
            // 
            this.tb_Pesquisar.Location = new System.Drawing.Point(392, 44);
            this.tb_Pesquisar.Name = "tb_Pesquisar";
            this.tb_Pesquisar.Size = new System.Drawing.Size(356, 20);
            this.tb_Pesquisar.TabIndex = 32;
            this.tb_Pesquisar.TextChanged += new System.EventHandler(this.tb_Pesquisar_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(392, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Pesquisar pelo Nome";
            // 
            // f_temas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 416);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tb_Pesquisar);
            this.Controls.Add(this.pb_Fotografia);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_Escolher);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cb_Ano);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Apagar);
            this.Controls.Add(this.btn_Atualizar);
            this.Controls.Add(this.dg_Temas);
            this.Controls.Add(this.btn_Guardar);
            this.Controls.Add(this.dt_Entrega);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_Tema);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_Modulo);
            this.Controls.Add(this.cb_Disciplina);
            this.Name = "f_temas";
            this.Text = "f_temas";
            ((System.ComponentModel.ISupportInitialize)(this.dg_Temas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Fotografia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_Disciplina;
        private System.Windows.Forms.ComboBox cb_Modulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_Tema;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dt_Entrega;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.DataGridView dg_Temas;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button btn_Apagar;
        private System.Windows.Forms.Button btn_Atualizar;
        private System.Windows.Forms.ComboBox cb_Ano;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Escolher;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pb_Fotografia;
        private System.Windows.Forms.TextBox tb_Pesquisar;
        private System.Windows.Forms.Label label7;
    }
}