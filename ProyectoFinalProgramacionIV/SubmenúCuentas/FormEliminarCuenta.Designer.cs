namespace ProyectoFinalProgramacionIV.SubmenúCuentas
{
    partial class FormEliminarCuenta
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewEliminarCuenta = new System.Windows.Forms.DataGridView();
            this.btnEliminarCuenta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEliminarCuenta)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(386, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 37);
            this.label3.TabIndex = 6;
            this.label3.Text = "CUENTAS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(281, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(365, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "SELECCIONA LA CUENTA A ELIMINAR";
            // 
            // dataGridViewEliminarCuenta
            // 
            this.dataGridViewEliminarCuenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEliminarCuenta.Location = new System.Drawing.Point(146, 131);
            this.dataGridViewEliminarCuenta.Name = "dataGridViewEliminarCuenta";
            this.dataGridViewEliminarCuenta.RowHeadersWidth = 51;
            this.dataGridViewEliminarCuenta.RowTemplate.Height = 24;
            this.dataGridViewEliminarCuenta.Size = new System.Drawing.Size(649, 252);
            this.dataGridViewEliminarCuenta.TabIndex = 8;
            // 
            // btnEliminarCuenta
            // 
            this.btnEliminarCuenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnEliminarCuenta.FlatAppearance.BorderSize = 0;
            this.btnEliminarCuenta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnEliminarCuenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEliminarCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarCuenta.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnEliminarCuenta.Location = new System.Drawing.Point(146, 389);
            this.btnEliminarCuenta.Name = "btnEliminarCuenta";
            this.btnEliminarCuenta.Size = new System.Drawing.Size(649, 40);
            this.btnEliminarCuenta.TabIndex = 17;
            this.btnEliminarCuenta.Text = "ELIMINAR CUENTA";
            this.btnEliminarCuenta.UseVisualStyleBackColor = false;
            this.btnEliminarCuenta.Click += new System.EventHandler(this.btnEliminarCuenta_Click);
            // 
            // FormEliminarCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.ClientSize = new System.Drawing.Size(955, 606);
            this.Controls.Add(this.btnEliminarCuenta);
            this.Controls.Add(this.dataGridViewEliminarCuenta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormEliminarCuenta";
            this.Text = "FormEliminarCuenta";
            this.Load += new System.EventHandler(this.FormEliminarCuenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEliminarCuenta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewEliminarCuenta;
        private System.Windows.Forms.Button btnEliminarCuenta;
    }
}