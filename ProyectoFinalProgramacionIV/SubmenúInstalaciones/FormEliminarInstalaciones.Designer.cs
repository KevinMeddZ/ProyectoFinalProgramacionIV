namespace ProyectoFinalProgramacionIV.SubmenúInstalaciones
{
    partial class FormEliminarInstalaciones
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxComputadora = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDesinstalar = new System.Windows.Forms.Button();
            this.dataGridViewSoftware = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSoftware)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(204, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(361, 37);
            this.label5.TabIndex = 14;
            this.label5.Text = "DESINSTALAR SOFTWARE";
            // 
            // comboBoxComputadora
            // 
            this.comboBoxComputadora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxComputadora.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxComputadora.FormattingEnabled = true;
            this.comboBoxComputadora.Location = new System.Drawing.Point(326, 93);
            this.comboBoxComputadora.Name = "comboBoxComputadora";
            this.comboBoxComputadora.Size = new System.Drawing.Size(301, 31);
            this.comboBoxComputadora.TabIndex = 18;
            this.comboBoxComputadora.SelectedIndexChanged += new System.EventHandler(this.comboBoxComputadora_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(12, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 23);
            this.label1.TabIndex = 17;
            this.label1.Text = "Selecciona la computadora:";
            // 
            // btnDesinstalar
            // 
            this.btnDesinstalar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesinstalar.Location = new System.Drawing.Point(751, 339);
            this.btnDesinstalar.Name = "btnDesinstalar";
            this.btnDesinstalar.Size = new System.Drawing.Size(136, 33);
            this.btnDesinstalar.TabIndex = 20;
            this.btnDesinstalar.Text = "Desinstalar";
            this.btnDesinstalar.UseVisualStyleBackColor = true;
            this.btnDesinstalar.Click += new System.EventHandler(this.btnDesinstalar_Click);
            // 
            // dataGridViewSoftware
            // 
            this.dataGridViewSoftware.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewSoftware.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewSoftware.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.dataGridViewSoftware.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewSoftware.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewSoftware.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSoftware.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewSoftware.ColumnHeadersHeight = 25;
            this.dataGridViewSoftware.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewSoftware.EnableHeadersVisualStyles = false;
            this.dataGridViewSoftware.GridColor = System.Drawing.Color.SteelBlue;
            this.dataGridViewSoftware.Location = new System.Drawing.Point(25, 142);
            this.dataGridViewSoftware.Name = "dataGridViewSoftware";
            this.dataGridViewSoftware.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSoftware.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewSoftware.RowHeadersWidth = 51;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewSoftware.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewSoftware.RowTemplate.Height = 24;
            this.dataGridViewSoftware.Size = new System.Drawing.Size(862, 191);
            this.dataGridViewSoftware.TabIndex = 21;
            // 
            // FormEliminarInstalaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(916, 450);
            this.Controls.Add(this.dataGridViewSoftware);
            this.Controls.Add(this.btnDesinstalar);
            this.Controls.Add(this.comboBoxComputadora);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormEliminarInstalaciones";
            this.Text = "FormEliminarInstalaciones";
            this.Load += new System.EventHandler(this.FormEliminarInstalaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSoftware)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxComputadora;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDesinstalar;
        private System.Windows.Forms.DataGridView dataGridViewSoftware;
    }
}