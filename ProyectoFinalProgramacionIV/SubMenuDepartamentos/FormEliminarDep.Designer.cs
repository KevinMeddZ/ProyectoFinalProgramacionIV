namespace ProyectoFinalProgramacionIV
{
    partial class FormEliminarDep
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
            this.cmb_Departamentos = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEliminarDep = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmb_Departamentos
            // 
            this.cmb_Departamentos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.cmb_Departamentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Departamentos.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.cmb_Departamentos.FormattingEnabled = true;
            this.cmb_Departamentos.Location = new System.Drawing.Point(271, 137);
            this.cmb_Departamentos.Name = "cmb_Departamentos";
            this.cmb_Departamentos.Size = new System.Drawing.Size(372, 28);
            this.cmb_Departamentos.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label4.Location = new System.Drawing.Point(178, 320);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(570, 22);
            this.label4.TabIndex = 36;
            this.label4.Text = "SOLO SE MOSTRARAN LOS DEPARTAMENTOS EN ESTADO INACTIVO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Yu Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(314, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(294, 23);
            this.label3.TabIndex = 35;
            this.label3.Text = "NOMBRE DEL DEPARTAMENTO";
            // 
            // btnEliminarDep
            // 
            this.btnEliminarDep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnEliminarDep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarDep.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEliminarDep.Location = new System.Drawing.Point(332, 187);
            this.btnEliminarDep.Name = "btnEliminarDep";
            this.btnEliminarDep.Size = new System.Drawing.Size(251, 44);
            this.btnEliminarDep.TabIndex = 34;
            this.btnEliminarDep.Text = "Eliminar";
            this.btnEliminarDep.UseVisualStyleBackColor = false;
            this.btnEliminarDep.Click += new System.EventHandler(this.btnEliminarDep_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Yu Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(228, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(478, 43);
            this.label5.TabIndex = 32;
            this.label5.Text = "ELIMINAR DEPARTAMENTO";
            // 
            // FormEliminarDep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(898, 565);
            this.Controls.Add(this.cmb_Departamentos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnEliminarDep);
            this.Controls.Add(this.label5);
            this.Name = "FormEliminarDep";
            this.Text = "FormEliminarDep";
            this.Load += new System.EventHandler(this.FormEliminarDep_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_Departamentos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEliminarDep;
        private System.Windows.Forms.Label label5;
    }
}