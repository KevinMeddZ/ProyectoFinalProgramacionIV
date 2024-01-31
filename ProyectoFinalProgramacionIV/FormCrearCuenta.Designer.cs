namespace ProyectoFinalProgramacionIV
{
    partial class FormCrearCuenta
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtContraNueva = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtContraNueva1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCrearUsuario = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrimerApellido = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSegundoApellido = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbID_Departamento = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.radioEmpleadoAdmin = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(360, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(288, 44);
            this.label3.TabIndex = 6;
            this.label3.Text = "CREAR CUENTA";
            // 
            // txtCedula
            // 
            this.txtCedula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.txtCedula.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCedula.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCedula.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.txtCedula.Location = new System.Drawing.Point(181, 65);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(504, 23);
            this.txtCedula.TabIndex = 7;
            this.txtCedula.Text = "CÉDULA";
            this.txtCedula.Enter += new System.EventHandler(this.txtUsuario_Enter);
            this.txtCedula.Leave += new System.EventHandler(this.txtUsuario_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(178, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(588, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "_________________________________________________________________________________" +
    "__";
            // 
            // txtContraNueva
            // 
            this.txtContraNueva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.txtContraNueva.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContraNueva.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraNueva.ForeColor = System.Drawing.Color.White;
            this.txtContraNueva.Location = new System.Drawing.Point(181, 315);
            this.txtContraNueva.Name = "txtContraNueva";
            this.txtContraNueva.Size = new System.Drawing.Size(504, 23);
            this.txtContraNueva.TabIndex = 9;
            this.txtContraNueva.Text = "CREAR CONTRASEÑA";
            this.txtContraNueva.Enter += new System.EventHandler(this.txtContraNueva_Enter);
            this.txtContraNueva.Leave += new System.EventHandler(this.txtContraNueva_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(178, 332);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(588, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "_________________________________________________________________________________" +
    "__";
            // 
            // txtContraNueva1
            // 
            this.txtContraNueva1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.txtContraNueva1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContraNueva1.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraNueva1.ForeColor = System.Drawing.Color.White;
            this.txtContraNueva1.Location = new System.Drawing.Point(181, 370);
            this.txtContraNueva1.Name = "txtContraNueva1";
            this.txtContraNueva1.Size = new System.Drawing.Size(504, 23);
            this.txtContraNueva1.TabIndex = 11;
            this.txtContraNueva1.Text = "REPETIR CONTRASEÑA";
            this.txtContraNueva1.Enter += new System.EventHandler(this.txtContraNueva1_Enter);
            this.txtContraNueva1.Leave += new System.EventHandler(this.txtContraNueva1_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(178, 387);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(588, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "_________________________________________________________________________________" +
    "__";
            // 
            // btnCrearUsuario
            // 
            this.btnCrearUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnCrearUsuario.FlatAppearance.BorderSize = 0;
            this.btnCrearUsuario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnCrearUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCrearUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearUsuario.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCrearUsuario.Location = new System.Drawing.Point(181, 493);
            this.btnCrearUsuario.Name = "btnCrearUsuario";
            this.btnCrearUsuario.Size = new System.Drawing.Size(585, 40);
            this.btnCrearUsuario.TabIndex = 16;
            this.btnCrearUsuario.Text = "CREAR USUARIO";
            this.btnCrearUsuario.UseVisualStyleBackColor = false;
            this.btnCrearUsuario.Click += new System.EventHandler(this.btnCrearUsuario_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombre.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.Color.White;
            this.txtNombre.Location = new System.Drawing.Point(181, 115);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(504, 23);
            this.txtNombre.TabIndex = 18;
            this.txtNombre.Text = "NOMBRE";
            this.txtNombre.Enter += new System.EventHandler(this.txtNombre_Enter);
            this.txtNombre.Leave += new System.EventHandler(this.txtNombre_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(178, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(588, 16);
            this.label5.TabIndex = 19;
            this.label5.Text = "_________________________________________________________________________________" +
    "__";
            // 
            // txtPrimerApellido
            // 
            this.txtPrimerApellido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.txtPrimerApellido.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrimerApellido.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrimerApellido.ForeColor = System.Drawing.Color.White;
            this.txtPrimerApellido.Location = new System.Drawing.Point(181, 163);
            this.txtPrimerApellido.Name = "txtPrimerApellido";
            this.txtPrimerApellido.Size = new System.Drawing.Size(504, 23);
            this.txtPrimerApellido.TabIndex = 20;
            this.txtPrimerApellido.Text = "PRIMER APELLIDO";
            this.txtPrimerApellido.Enter += new System.EventHandler(this.txtPrimerApellido_Enter);
            this.txtPrimerApellido.Leave += new System.EventHandler(this.txtPrimerApellido_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(178, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(588, 16);
            this.label6.TabIndex = 21;
            this.label6.Text = "_________________________________________________________________________________" +
    "__";
            // 
            // txtSegundoApellido
            // 
            this.txtSegundoApellido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.txtSegundoApellido.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSegundoApellido.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSegundoApellido.ForeColor = System.Drawing.Color.White;
            this.txtSegundoApellido.Location = new System.Drawing.Point(181, 211);
            this.txtSegundoApellido.Name = "txtSegundoApellido";
            this.txtSegundoApellido.Size = new System.Drawing.Size(504, 23);
            this.txtSegundoApellido.TabIndex = 22;
            this.txtSegundoApellido.Text = "SEGUNDO APELLIDO";
            this.txtSegundoApellido.Enter += new System.EventHandler(this.txtSegundoApellido_Enter);
            this.txtSegundoApellido.Leave += new System.EventHandler(this.txtSegundoApellido_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(178, 228);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(588, 16);
            this.label7.TabIndex = 23;
            this.label7.Text = "_________________________________________________________________________________" +
    "__";
            // 
            // cmbID_Departamento
            // 
            this.cmbID_Departamento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.cmbID_Departamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbID_Departamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbID_Departamento.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbID_Departamento.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cmbID_Departamento.FormattingEnabled = true;
            this.cmbID_Departamento.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbID_Departamento.Location = new System.Drawing.Point(398, 260);
            this.cmbID_Departamento.Name = "cmbID_Departamento";
            this.cmbID_Departamento.Size = new System.Drawing.Size(359, 29);
            this.cmbID_Departamento.TabIndex = 26;
            this.cmbID_Departamento.SelectedIndexChanged += new System.EventHandler(this.cmbID_Departamento_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(177, 268);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(157, 21);
            this.label9.TabIndex = 27;
            this.label9.Text = "DEPARTAMENTO";
            // 
            // radioEmpleadoAdmin
            // 
            this.radioEmpleadoAdmin.AutoSize = true;
            this.radioEmpleadoAdmin.ForeColor = System.Drawing.Color.White;
            this.radioEmpleadoAdmin.Location = new System.Drawing.Point(398, 418);
            this.radioEmpleadoAdmin.Name = "radioEmpleadoAdmin";
            this.radioEmpleadoAdmin.Size = new System.Drawing.Size(137, 20);
            this.radioEmpleadoAdmin.TabIndex = 28;
            this.radioEmpleadoAdmin.Text = "Es administrador?";
            this.radioEmpleadoAdmin.UseVisualStyleBackColor = true;
            // 
            // FormCrearCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.ClientSize = new System.Drawing.Size(955, 606);
            this.Controls.Add(this.radioEmpleadoAdmin);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbID_Departamento);
            this.Controls.Add(this.txtSegundoApellido);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPrimerApellido);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCrearUsuario);
            this.Controls.Add(this.txtContraNueva1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtContraNueva);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCedula);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCrearCuenta";
            this.Text = "FormCrearCuenta";
            this.Load += new System.EventHandler(this.FormCrearCuenta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContraNueva;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtContraNueva1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCrearUsuario;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrimerApellido;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSegundoApellido;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbID_Departamento;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox radioEmpleadoAdmin;
    }
}