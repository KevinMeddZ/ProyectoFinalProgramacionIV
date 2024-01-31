namespace ProyectoFinalProgramacionIV.SubmenúInstalaciones
{
    partial class FormInstalarSoftware
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
            this.label1 = new System.Windows.Forms.Label();
            this.comBoxComputadora = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comBoxSoftware = new System.Windows.Forms.ComboBox();
            this.btnInstalar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLicenciasDisp = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(251, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(414, 37);
            this.label5.TabIndex = 12;
            this.label5.Text = "INSTALACIÓN DE SOFTWARE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(21, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 23);
            this.label1.TabIndex = 13;
            this.label1.Text = "Selecciona la computadora:";
            // 
            // comBoxComputadora
            // 
            this.comBoxComputadora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comBoxComputadora.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comBoxComputadora.FormattingEnabled = true;
            this.comBoxComputadora.Location = new System.Drawing.Point(25, 114);
            this.comBoxComputadora.Name = "comBoxComputadora";
            this.comBoxComputadora.Size = new System.Drawing.Size(854, 31);
            this.comBoxComputadora.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(21, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(332, 23);
            this.label2.TabIndex = 15;
            this.label2.Text = "Selecciona el software a instalar:";
            // 
            // comBoxSoftware
            // 
            this.comBoxSoftware.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comBoxSoftware.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comBoxSoftware.FormattingEnabled = true;
            this.comBoxSoftware.Location = new System.Drawing.Point(393, 181);
            this.comBoxSoftware.Name = "comBoxSoftware";
            this.comBoxSoftware.Size = new System.Drawing.Size(486, 31);
            this.comBoxSoftware.TabIndex = 16;
            this.comBoxSoftware.SelectedIndexChanged += new System.EventHandler(this.comBoxSoftware_SelectedIndexChanged);
            // 
            // btnInstalar
            // 
            this.btnInstalar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstalar.Location = new System.Drawing.Point(591, 320);
            this.btnInstalar.Name = "btnInstalar";
            this.btnInstalar.Size = new System.Drawing.Size(125, 35);
            this.btnInstalar.TabIndex = 17;
            this.btnInstalar.Text = "Instalar";
            this.btnInstalar.UseVisualStyleBackColor = true;
            this.btnInstalar.Click += new System.EventHandler(this.btnInstalar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(21, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(224, 23);
            this.label3.TabIndex = 18;
            this.label3.Text = "Licencias disponibles:";
            // 
            // txtLicenciasDisp
            // 
            this.txtLicenciasDisp.Enabled = false;
            this.txtLicenciasDisp.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLicenciasDisp.Location = new System.Drawing.Point(393, 244);
            this.txtLicenciasDisp.Name = "txtLicenciasDisp";
            this.txtLicenciasDisp.Size = new System.Drawing.Size(486, 32);
            this.txtLicenciasDisp.TabIndex = 19;
            // 
            // FormInstalarSoftware
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(970, 617);
            this.Controls.Add(this.txtLicenciasDisp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnInstalar);
            this.Controls.Add(this.comBoxSoftware);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comBoxComputadora);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormInstalarSoftware";
            this.Text = "FormInstalarSoftware";
            this.Load += new System.EventHandler(this.FormInstalarSoftware_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comBoxComputadora;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comBoxSoftware;
        private System.Windows.Forms.Button btnInstalar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLicenciasDisp;
    }
}