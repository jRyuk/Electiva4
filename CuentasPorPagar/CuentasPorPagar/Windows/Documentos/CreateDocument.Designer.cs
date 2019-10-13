namespace CuentasPorPagar.Windows.Documentos
{
    partial class CreateDocument
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtNoDocumento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtPickerFecha = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTipo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxProveedor = new System.Windows.Forms.ComboBox();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNumeroCuotas = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cbxPlazo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingreso de Documento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "No. Documento:";
            // 
            // txtNoDocumento
            // 
            this.txtNoDocumento.Location = new System.Drawing.Point(103, 51);
            this.txtNoDocumento.Name = "txtNoDocumento";
            this.txtNoDocumento.Size = new System.Drawing.Size(400, 20);
            this.txtNoDocumento.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Fecha: ";
            // 
            // dtPickerFecha
            // 
            this.dtPickerFecha.Location = new System.Drawing.Point(103, 128);
            this.dtPickerFecha.Name = "dtPickerFecha";
            this.dtPickerFecha.Size = new System.Drawing.Size(200, 20);
            this.dtPickerFecha.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tipo documento:";
            // 
            // txtTipo
            // 
            this.txtTipo.FormattingEnabled = true;
            this.txtTipo.Items.AddRange(new object[] {
            "Factura",
            "Credito Fiscal"});
            this.txtTipo.Location = new System.Drawing.Point(103, 86);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(148, 21);
            this.txtTipo.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Proveedor:";
            // 
            // cbxProveedor
            // 
            this.cbxProveedor.FormattingEnabled = true;
            this.cbxProveedor.Location = new System.Drawing.Point(103, 166);
            this.cbxProveedor.Name = "cbxProveedor";
            this.cbxProveedor.Size = new System.Drawing.Size(200, 21);
            this.cbxProveedor.TabIndex = 8;
            // 
            // txtConcepto
            // 
            this.txtConcepto.Location = new System.Drawing.Point(103, 217);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(400, 20);
            this.txtConcepto.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Concepto:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 319);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Plan:";
            // 
            // txtNumeroCuotas
            // 
            this.txtNumeroCuotas.Location = new System.Drawing.Point(122, 367);
            this.txtNumeroCuotas.Name = "txtNumeroCuotas";
            this.txtNumeroCuotas.Size = new System.Drawing.Size(150, 20);
            this.txtNumeroCuotas.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 370);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 13);
            this.label8.TabIndex = 14;
            this.label8.Tag = "Numero de cuotas programadas";
            this.label8.Text = "Cuotas programadas";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(428, 424);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(335, 424);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 272);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Monto total:";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(103, 269);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(169, 20);
            this.txtMonto.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(418, 272);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Incluye IVA:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(488, 271);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // cbxPlazo
            // 
            this.cbxPlazo.FormattingEnabled = true;
            this.cbxPlazo.Location = new System.Drawing.Point(103, 316);
            this.cbxPlazo.Name = "cbxPlazo";
            this.cbxPlazo.Size = new System.Drawing.Size(121, 21);
            this.cbxPlazo.TabIndex = 21;
            // 
            // CreateDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 459);
            this.Controls.Add(this.cbxPlazo);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNumeroCuotas);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtConcepto);
            this.Controls.Add(this.cbxProveedor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtPickerFecha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNoDocumento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CreateDocument";
            this.Text = "CreateDocument";
            this.Load += new System.EventHandler(this.CreateDocument_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNoDocumento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtPickerFecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox txtTipo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxProveedor;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNumeroCuotas;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox cbxPlazo;
    }
}