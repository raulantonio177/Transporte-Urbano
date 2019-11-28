namespace PIA_Programacion_2
{
    partial class ReportePuestoEmpleado
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
            this.label1 = new System.Windows.Forms.Label();
            this.rdbMatutino = new System.Windows.Forms.RadioButton();
            this.rdbVespertino = new System.Windows.Forms.RadioButton();
            this.rdbNocturno = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPuesto = new System.Windows.Forms.ComboBox();
            this.dgvEmpleados = new System.Windows.Forms.DataGridView();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Turno";
            // 
            // rdbMatutino
            // 
            this.rdbMatutino.AutoSize = true;
            this.rdbMatutino.Location = new System.Drawing.Point(111, 56);
            this.rdbMatutino.Name = "rdbMatutino";
            this.rdbMatutino.Size = new System.Drawing.Size(34, 17);
            this.rdbMatutino.TabIndex = 1;
            this.rdbMatutino.TabStop = true;
            this.rdbMatutino.Text = "M";
            this.rdbMatutino.UseVisualStyleBackColor = true;
            // 
            // rdbVespertino
            // 
            this.rdbVespertino.AutoSize = true;
            this.rdbVespertino.Location = new System.Drawing.Point(149, 56);
            this.rdbVespertino.Name = "rdbVespertino";
            this.rdbVespertino.Size = new System.Drawing.Size(32, 17);
            this.rdbVespertino.TabIndex = 2;
            this.rdbVespertino.TabStop = true;
            this.rdbVespertino.Text = "V";
            this.rdbVespertino.UseVisualStyleBackColor = true;
            // 
            // rdbNocturno
            // 
            this.rdbNocturno.AutoSize = true;
            this.rdbNocturno.Location = new System.Drawing.Point(187, 56);
            this.rdbNocturno.Name = "rdbNocturno";
            this.rdbNocturno.Size = new System.Drawing.Size(33, 17);
            this.rdbNocturno.TabIndex = 3;
            this.rdbNocturno.TabStop = true;
            this.rdbNocturno.Text = "N";
            this.rdbNocturno.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Puesto";
            // 
            // cmbPuesto
            // 
            this.cmbPuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPuesto.FormattingEnabled = true;
            this.cmbPuesto.Location = new System.Drawing.Point(111, 89);
            this.cmbPuesto.Name = "cmbPuesto";
            this.cmbPuesto.Size = new System.Drawing.Size(121, 21);
            this.cmbPuesto.TabIndex = 5;
            // 
            // dgvEmpleados
            // 
            this.dgvEmpleados.AllowUserToAddRows = false;
            this.dgvEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpleados.Location = new System.Drawing.Point(53, 159);
            this.dgvEmpleados.Name = "dgvEmpleados";
            this.dgvEmpleados.Size = new System.Drawing.Size(381, 233);
            this.dgvEmpleados.TabIndex = 7;
            // 
            // btnMostrar
            // 
            this.btnMostrar.Location = new System.Drawing.Point(298, 87);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(75, 23);
            this.btnMostrar.TabIndex = 6;
            this.btnMostrar.Text = "Mostrar";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.Location = new System.Drawing.Point(314, 425);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(120, 36);
            this.btnRegresar.TabIndex = 69;
            this.btnRegresar.Text = "Regresar al Menu";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // ReportePuestoEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 505);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.dgvEmpleados);
            this.Controls.Add(this.btnMostrar);
            this.Controls.Add(this.cmbPuesto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rdbNocturno);
            this.Controls.Add(this.rdbVespertino);
            this.Controls.Add(this.rdbMatutino);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportePuestoEmpleado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportePuestoEmpleado";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReportePuestoEmpleado_FormClosing);
            this.Load += new System.EventHandler(this.ReportePuestoEmpleado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbMatutino;
        private System.Windows.Forms.RadioButton rdbVespertino;
        private System.Windows.Forms.RadioButton rdbNocturno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPuesto;
        private System.Windows.Forms.DataGridView dgvEmpleados;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.Button btnRegresar;
    }
}