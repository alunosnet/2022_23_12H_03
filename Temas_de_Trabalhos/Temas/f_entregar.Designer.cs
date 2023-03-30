namespace Temas_de_Trabalhos.Temas
{
    partial class f_entregar
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
            this.lb_Temas = new System.Windows.Forms.ListBox();
            this.btn_Entregar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_Temas
            // 
            this.lb_Temas.FormattingEnabled = true;
            this.lb_Temas.Location = new System.Drawing.Point(21, 12);
            this.lb_Temas.Name = "lb_Temas";
            this.lb_Temas.Size = new System.Drawing.Size(242, 303);
            this.lb_Temas.TabIndex = 0;
            // 
            // btn_Entregar
            // 
            this.btn_Entregar.Location = new System.Drawing.Point(21, 321);
            this.btn_Entregar.Name = "btn_Entregar";
            this.btn_Entregar.Size = new System.Drawing.Size(242, 37);
            this.btn_Entregar.TabIndex = 1;
            this.btn_Entregar.Text = "Entregar";
            this.btn_Entregar.UseVisualStyleBackColor = true;
            this.btn_Entregar.Click += new System.EventHandler(this.btn_Entregar_Click);
            // 
            // Entregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 374);
            this.Controls.Add(this.btn_Entregar);
            this.Controls.Add(this.lb_Temas);
            this.Name = "Entregar";
            this.Text = "Entregar";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lb_Temas;
        private System.Windows.Forms.Button btn_Entregar;
    }
}