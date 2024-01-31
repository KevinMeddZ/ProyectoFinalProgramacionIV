namespace ProyectoFinalProgramacionIV.SubmenúComputadoras
{
    partial class FormAsignarCPU
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.cmb_CPU = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_Usuario = new System.Windows.Forms.ComboBox();
            this.cmb_Dep = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Desvincular = new System.Windows.Forms.Button();
            this.cmb_CPU2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_Usuario2 = new System.Windows.Forms.ComboBox();
            this.cmb_Dep2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAsignar);
            this.groupBox1.Controls.Add(this.cmb_CPU);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmb_Usuario);
            this.groupBox1.Controls.Add(this.cmb_Dep);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Location = new System.Drawing.Point(68, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(387, 473);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione el departamento:";
            // 
            // btnAsignar
            // 
            this.btnAsignar.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnAsignar.Location = new System.Drawing.Point(148, 384);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(142, 50);
            this.btnAsignar.TabIndex = 5;
            this.btnAsignar.Text = "Vincular";
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // cmb_CPU
            // 
            this.cmb_CPU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_CPU.Enabled = false;
            this.cmb_CPU.FormattingEnabled = true;
            this.cmb_CPU.Location = new System.Drawing.Point(7, 292);
            this.cmb_CPU.Name = "cmb_CPU";
            this.cmb_CPU.Size = new System.Drawing.Size(369, 39);
            this.cmb_CPU.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Seleccione un CPU:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seleccione el usuario:";
            // 
            // cmb_Usuario
            // 
            this.cmb_Usuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Usuario.Enabled = false;
            this.cmb_Usuario.FormattingEnabled = true;
            this.cmb_Usuario.Location = new System.Drawing.Point(6, 182);
            this.cmb_Usuario.Name = "cmb_Usuario";
            this.cmb_Usuario.Size = new System.Drawing.Size(369, 39);
            this.cmb_Usuario.TabIndex = 1;
            this.cmb_Usuario.SelectedIndexChanged += new System.EventHandler(this.cmb_Usuario_SelectedIndexChanged);
            // 
            // cmb_Dep
            // 
            this.cmb_Dep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Dep.FormattingEnabled = true;
            this.cmb_Dep.Location = new System.Drawing.Point(7, 80);
            this.cmb_Dep.Name = "cmb_Dep";
            this.cmb_Dep.Size = new System.Drawing.Size(369, 39);
            this.cmb_Dep.TabIndex = 0;
            this.cmb_Dep.SelectedIndexChanged += new System.EventHandler(this.cmb_Dep_SelectedIndexChanged);
            this.cmb_Dep.SelectedValueChanged += new System.EventHandler(this.cmb_Dep_SelectedValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Desvincular);
            this.groupBox2.Controls.Add(this.cmb_CPU2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cmb_Usuario2);
            this.groupBox2.Controls.Add(this.cmb_Dep2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Location = new System.Drawing.Point(494, 105);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(382, 473);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seleccione el departamento:";
            // 
            // btn_Desvincular
            // 
            this.btn_Desvincular.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Desvincular.Location = new System.Drawing.Point(102, 387);
            this.btn_Desvincular.Name = "btn_Desvincular";
            this.btn_Desvincular.Size = new System.Drawing.Size(165, 50);
            this.btn_Desvincular.TabIndex = 10;
            this.btn_Desvincular.Text = "Desvincular";
            this.btn_Desvincular.UseVisualStyleBackColor = true;
            this.btn_Desvincular.Click += new System.EventHandler(this.btn_Desvincular_Click);
            // 
            // cmb_CPU2
            // 
            this.cmb_CPU2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_CPU2.Enabled = false;
            this.cmb_CPU2.FormattingEnabled = true;
            this.cmb_CPU2.Location = new System.Drawing.Point(6, 292);
            this.cmb_CPU2.Name = "cmb_CPU2";
            this.cmb_CPU2.Size = new System.Drawing.Size(363, 38);
            this.cmb_CPU2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(223, 30);
            this.label3.TabIndex = 8;
            this.label3.Text = "Seleccione un CPU:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(251, 30);
            this.label4.TabIndex = 7;
            this.label4.Text = "Seleccione el usuario:";
            // 
            // cmb_Usuario2
            // 
            this.cmb_Usuario2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Usuario2.FormattingEnabled = true;
            this.cmb_Usuario2.Location = new System.Drawing.Point(6, 182);
            this.cmb_Usuario2.Name = "cmb_Usuario2";
            this.cmb_Usuario2.Size = new System.Drawing.Size(363, 38);
            this.cmb_Usuario2.TabIndex = 6;
            this.cmb_Usuario2.SelectedIndexChanged += new System.EventHandler(this.cmb_Usuario2_SelectedIndexChanged);
            // 
            // cmb_Dep2
            // 
            this.cmb_Dep2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Dep2.FormattingEnabled = true;
            this.cmb_Dep2.Location = new System.Drawing.Point(6, 81);
            this.cmb_Dep2.Name = "cmb_Dep2";
            this.cmb_Dep2.Size = new System.Drawing.Size(363, 38);
            this.cmb_Dep2.TabIndex = 5;
            this.cmb_Dep2.SelectedIndexChanged += new System.EventHandler(this.cmb_Dep2_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(111, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(284, 31);
            this.label5.TabIndex = 2;
            this.label5.Text = "Vincular usuario a CPU:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Location = new System.Drawing.Point(528, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(323, 31);
            this.label6.TabIndex = 3;
            this.label6.Text = "Desvincular usuario a CPU:";
            // 
            // FormAsignarCPU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(937, 682);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Name = "FormAsignarCPU";
            this.Text = "FormAsignarCPU";
            this.Load += new System.EventHandler(this.FormAsignarCPU_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_Usuario;
        private System.Windows.Forms.ComboBox cmb_Dep;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.ComboBox cmb_CPU;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_Desvincular;
        private System.Windows.Forms.ComboBox cmb_CPU2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_Usuario2;
        private System.Windows.Forms.ComboBox cmb_Dep2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}