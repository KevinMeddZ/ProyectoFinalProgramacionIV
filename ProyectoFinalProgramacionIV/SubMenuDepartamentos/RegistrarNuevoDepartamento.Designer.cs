namespace ProyectoFinalProgramacionIV
{
    partial class RegistrarNuevoDepartamento
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
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodigoDepartamento = new System.Windows.Forms.TextBox();
            this.txtNombreDepartamento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRegistrarDep = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Yu Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(126, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(676, 43);
            this.label5.TabIndex = 17;
            this.label5.Text = "REGISTRO DE  NUEVO DEPARTAMENTO";
            // 
            // txtCodigoDepartamento
            // 
            this.txtCodigoDepartamento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.txtCodigoDepartamento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCodigoDepartamento.Enabled = false;
            this.txtCodigoDepartamento.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoDepartamento.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtCodigoDepartamento.Location = new System.Drawing.Point(279, 213);
            this.txtCodigoDepartamento.Name = "txtCodigoDepartamento";
            this.txtCodigoDepartamento.Size = new System.Drawing.Size(370, 21);
            this.txtCodigoDepartamento.TabIndex = 13;
            this.txtCodigoDepartamento.Text = "Codigo";
            // 
            // txtNombreDepartamento
            // 
            this.txtNombreDepartamento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.txtNombreDepartamento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombreDepartamento.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreDepartamento.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtNombreDepartamento.Location = new System.Drawing.Point(279, 164);
            this.txtNombreDepartamento.Name = "txtNombreDepartamento";
            this.txtNombreDepartamento.Size = new System.Drawing.Size(370, 21);
            this.txtNombreDepartamento.TabIndex = 15;
            this.txtNombreDepartamento.Text = "Nombre del departamento";
            this.txtNombreDepartamento.Enter += new System.EventHandler(this.txtNombreDepartamento_Enter);
            this.txtNombreDepartamento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreDepartamento_KeyPress);
            this.txtNombreDepartamento.Leave += new System.EventHandler(this.txtNombreDepartamento_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(274, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(375, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "______________________________________________";
            // 
            // btnRegistrarDep
            // 
            this.btnRegistrarDep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnRegistrarDep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarDep.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRegistrarDep.Location = new System.Drawing.Point(320, 286);
            this.btnRegistrarDep.Name = "btnRegistrarDep";
            this.btnRegistrarDep.Size = new System.Drawing.Size(251, 44);
            this.btnRegistrarDep.TabIndex = 19;
            this.btnRegistrarDep.Text = "Registrar";
            this.btnRegistrarDep.UseVisualStyleBackColor = false;
            this.btnRegistrarDep.Click += new System.EventHandler(this.btnRegistrarDep_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(276, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(375, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "______________________________________________";
            // 
            // RegistrarNuevoDepartamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(916, 471);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRegistrarDep);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCodigoDepartamento);
            this.Controls.Add(this.txtNombreDepartamento);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegistrarNuevoDepartamento";
            this.Text = "RegistrarNuevoDepartamento";
    
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCodigoDepartamento;
        private System.Windows.Forms.TextBox txtNombreDepartamento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRegistrarDep;
        private System.Windows.Forms.Label label1;
    }
}