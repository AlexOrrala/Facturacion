namespace Facturacion1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Table_productos = new System.Windows.Forms.DataGridView();
            this.Table_nombreproducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Table_Preciounitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Table_Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Table_iva12 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Table_Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.DateTime_fechafact = new System.Windows.Forms.DateTimePicker();
            this.txt_cliente = new System.Windows.Forms.TextBox();
            this.txt_numfact = new System.Windows.Forms.TextBox();
            this.Butt_CargarDatos = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.txt_baseimponible12 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_iva = new System.Windows.Forms.TextBox();
            this.txt_Total = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_baseimponible0 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Table_productos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "CLIENTE:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(50, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "FECHA:";
            // 
            // Table_productos
            // 
            this.Table_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table_productos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Table_nombreproducto,
            this.Table_Preciounitario,
            this.Table_Cantidad,
            this.Table_iva12,
            this.Table_Subtotal});
            this.Table_productos.Location = new System.Drawing.Point(304, 168);
            this.Table_productos.Name = "Table_productos";
            this.Table_productos.Size = new System.Drawing.Size(541, 226);
            this.Table_productos.TabIndex = 2;
            this.Table_productos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Table_productos_CellContentClick);
            this.Table_productos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Table_productos_CellValueChanged);
            this.Table_productos.CurrentCellDirtyStateChanged += new System.EventHandler(this.Table_productos_CurrentCellDirtyStateChanged);
            // 
            // Table_nombreproducto
            // 
            this.Table_nombreproducto.HeaderText = "Nombre Producto";
            this.Table_nombreproducto.Name = "Table_nombreproducto";
            // 
            // Table_Preciounitario
            // 
            this.Table_Preciounitario.HeaderText = "Precio Unitario";
            this.Table_Preciounitario.Name = "Table_Preciounitario";
            // 
            // Table_Cantidad
            // 
            this.Table_Cantidad.HeaderText = "Cantidad";
            this.Table_Cantidad.Name = "Table_Cantidad";
            // 
            // Table_iva12
            // 
            this.Table_iva12.HeaderText = "IVA 12%";
            this.Table_iva12.Name = "Table_iva12";
            // 
            // Table_Subtotal
            // 
            this.Table_Subtotal.HeaderText = "Subtotal";
            this.Table_Subtotal.Name = "Table_Subtotal";
            this.Table_Subtotal.ReadOnly = true;
            this.Table_Subtotal.ToolTipText = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(50, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nº:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // DateTime_fechafact
            // 
            this.DateTime_fechafact.Location = new System.Drawing.Point(141, 128);
            this.DateTime_fechafact.Name = "DateTime_fechafact";
            this.DateTime_fechafact.Size = new System.Drawing.Size(200, 20);
            this.DateTime_fechafact.TabIndex = 4;
            // 
            // txt_cliente
            // 
            this.txt_cliente.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cliente.Location = new System.Drawing.Point(157, 81);
            this.txt_cliente.Name = "txt_cliente";
            this.txt_cliente.Size = new System.Drawing.Size(183, 35);
            this.txt_cliente.TabIndex = 5;
            // 
            // txt_numfact
            // 
            this.txt_numfact.Enabled = false;
            this.txt_numfact.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_numfact.Location = new System.Drawing.Point(94, 38);
            this.txt_numfact.Name = "txt_numfact";
            this.txt_numfact.Size = new System.Drawing.Size(57, 35);
            this.txt_numfact.TabIndex = 6;
            // 
            // Butt_CargarDatos
            // 
            this.Butt_CargarDatos.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Butt_CargarDatos.Location = new System.Drawing.Point(54, 531);
            this.Butt_CargarDatos.Name = "Butt_CargarDatos";
            this.Butt_CargarDatos.Size = new System.Drawing.Size(97, 38);
            this.Butt_CargarDatos.TabIndex = 7;
            this.Butt_CargarDatos.Text = "Cargar Datos";
            this.Butt_CargarDatos.UseVisualStyleBackColor = true;
            this.Butt_CargarDatos.Click += new System.EventHandler(this.Butt_CargarDatos_Click);
            // 
            // txt_baseimponible12
            // 
            this.txt_baseimponible12.Enabled = false;
            this.txt_baseimponible12.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_baseimponible12.Location = new System.Drawing.Point(764, 411);
            this.txt_baseimponible12.Name = "txt_baseimponible12";
            this.txt_baseimponible12.Size = new System.Drawing.Size(57, 35);
            this.txt_baseimponible12.TabIndex = 9;
            this.txt_baseimponible12.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(580, 417);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Base Imponible 12%:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(666, 493);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 23);
            this.label5.TabIndex = 10;
            this.label5.Text = "IVA 12%:";
            // 
            // txt_iva
            // 
            this.txt_iva.Enabled = false;
            this.txt_iva.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_iva.Location = new System.Drawing.Point(764, 487);
            this.txt_iva.Name = "txt_iva";
            this.txt_iva.Size = new System.Drawing.Size(57, 35);
            this.txt_iva.TabIndex = 11;
            this.txt_iva.Text = "0";
            // 
            // txt_Total
            // 
            this.txt_Total.Enabled = false;
            this.txt_Total.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Total.Location = new System.Drawing.Point(764, 529);
            this.txt_Total.Name = "txt_Total";
            this.txt_Total.Size = new System.Drawing.Size(57, 35);
            this.txt_Total.TabIndex = 13;
            this.txt_Total.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(699, 533);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 23);
            this.label7.TabIndex = 12;
            this.label7.Text = "Total:";
            // 
            // txt_baseimponible0
            // 
            this.txt_baseimponible0.Enabled = false;
            this.txt_baseimponible0.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_baseimponible0.Location = new System.Drawing.Point(764, 447);
            this.txt_baseimponible0.Name = "txt_baseimponible0";
            this.txt_baseimponible0.Size = new System.Drawing.Size(57, 35);
            this.txt_baseimponible0.TabIndex = 15;
            this.txt_baseimponible0.Text = "0";
            this.txt_baseimponible0.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(580, 453);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(184, 23);
            this.label6.TabIndex = 14;
            this.label6.Text = "Base Imponible 0 %:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(880, 611);
            this.Controls.Add(this.txt_baseimponible0);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_Total);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_iva);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_baseimponible12);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Butt_CargarDatos);
            this.Controls.Add(this.txt_numfact);
            this.Controls.Add(this.txt_cliente);
            this.Controls.Add(this.DateTime_fechafact);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Table_productos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Table_productos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView Table_productos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DateTime_fechafact;
        private System.Windows.Forms.TextBox txt_cliente;
        private System.Windows.Forms.TextBox txt_numfact;
        private System.Windows.Forms.Button Butt_CargarDatos;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox txt_baseimponible12;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_iva;
        private System.Windows.Forms.TextBox txt_Total;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_baseimponible0;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Table_nombreproducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Table_Preciounitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Table_Cantidad;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Table_iva12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Table_Subtotal;
    }
}

