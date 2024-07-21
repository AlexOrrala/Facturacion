using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facturacion1{

    public partial class Form1 : Form{


        public static string connectionString = "Server=ALEX\\SQLEXPRESS;Database=facturacion;User Id=sa;Password=1234;";
        

        public Form1()
        {
            InitializeComponent();
            CargarNumFact();


            // Configurar el ReportViewer
            Report_Viewer.ProcessingMode = ProcessingMode.Local;
            Report_Viewer.LocalReport.ReportPath = @"C:\Users\alex_\Documents\GitHub\Facturacion\Facturacion1\Report1.rdlc";
        }

        private void Report_ViewerReportRefresh(object sender, CancelEventArgs e){
            cargarinforme();
        }

        private void cargarinforme(){

            try{
                Report_Viewer.LocalReport.DataSources.Clear();


                // Crear BindingSource
                //BindingSource productosBindingSource = new BindingSource();
                //productosBindingSource.DataSource = CrearFactura().getProductos();

                ReportDataSource rds = new ReportDataSource("DataSet_tabla", dtproductos());
                Report_Viewer.LocalReport.DataSources.Add(rds);

                // Agregar BindingSource al ReportViewer
                //Report_Viewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet_tabla", productosBindingSource));



                // Configurar el parámetro para el informe
                

                ReportParameter[] parametros = new ReportParameter[]{
                    new ReportParameter("ReportParameter_Cliente", CrearFactura().getCliente()),
                    new ReportParameter("ReportParameter_Fecha", Convert.ToString(CrearFactura().getfechafact())),
                    new ReportParameter("ReportParameter_NumFact", Convert.ToString(CrearFactura().getID_Factura())),
                    new ReportParameter("ReportParameter_Baseimponible12", Convert.ToString(CrearFactura().getBaseimponible12())),
                    new ReportParameter("ReportParameter_Baseimponible0", Convert.ToString(CrearFactura().getBaseimponible0())),
                    new ReportParameter("ReportParameter_iva12", Convert.ToString(CrearFactura().getiva())),
                    new ReportParameter("ReportParameter_Total", Convert.ToString(CrearFactura().getTotal()))
                    };

                


                Report_Viewer.LocalReport.SetParameters(parametros);

                // Refrescar el ReportViewer
                Report_Viewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el informe: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }

        }

        private DataTable dtproductos()
        {
            DataTable dtproductos = new DataTable();
            dtproductos.Columns.Add("Producto_nombre", typeof(string));
            dtproductos.Columns.Add("PrecioUnitario", typeof(double));
            dtproductos.Columns.Add("Cantidad", typeof(int));
            dtproductos.Columns.Add("iva", typeof(bool));
            dtproductos.Columns.Add("Subtotal", typeof(double));

            foreach (Producto producto in CrearFactura().getProductos())
            {
                dtproductos.Rows.Add(producto.getProducto_nombre(), producto.getPreciounitario(), producto.getCantidad(), producto.getIva(), producto.getsubtotal());
                Console.Write(producto.getProducto_nombre());
            }

            return dtproductos;
        }

        private void CargarNumFact(){
            try{
                using (SqlConnection connection = new SqlConnection(Form1.connectionString)){
                    connection.Open();
                    Console.WriteLine("Conexión establecida exitosamente.");
                    string query = "SELECT TOP (1) [ID_Factura] FROM [facturacion].[dbo].[FACTURA] ORDER BY [ID_Factura] DESC";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()){
                                txt_numfact.Text = Convert.ToString(reader.GetInt32(0) + 1);
                            }else{
                                txt_numfact.Text = "1";
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al conectar con la base de datos: {ex.Message}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.Report_Viewer.RefreshReport();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Table_productos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Table_productos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (Table_productos.IsCurrentCellDirty)
            {
                Table_productos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void Table_productos_CellValueChanged(object sender, DataGridViewCellEventArgs e){
            Double Preciounitario= 0;
            Double subtotal = 0;
            int Cantidad= 0;
            try{
                if (Table_productos.Columns["Table_iva12"] != null && e.ColumnIndex == Table_productos.Columns["Table_iva12"].Index){

                    
                    if (Table_productos.Rows[e.RowIndex].Cells[Table_productos.Columns["Table_nombreproducto"].Index].Value != null && Table_productos.Rows[e.RowIndex].Cells[Table_productos.Columns["Table_Preciounitario"].Index].Value != null && Table_productos.Rows[e.RowIndex].Cells[Table_productos.Columns["Table_Cantidad"].Index].Value != null){
                        Preciounitario = Convert.ToDouble(Table_productos.Rows[e.RowIndex].Cells[Table_productos.Columns["Table_Preciounitario"].Index].Value);
                        Cantidad = Convert.ToInt32(Table_productos.Rows[e.RowIndex].Cells[Table_productos.Columns["Table_Cantidad"].Index].Value);
                        subtotal = Preciounitario * Cantidad;
                        Table_productos.Rows[e.RowIndex].Cells[Table_productos.Columns["Table_Subtotal"].Index].Value = Convert.ToString(subtotal);
                        Actualizartotales();


                    }
                    else{
                        Table_productos.Rows[e.RowIndex].Cells[Table_productos.Columns["Table_Subtotal"].Index].Value = "0";
                        Actualizartotales();
                    }
                }
            }catch (Exception ex){
                    MessageBox.Show($"Los datos pueden estar vacios o no están en el formato adecuado: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);     
                }
            

        }

        private void Actualizartotales(){
            Double Baseimponible12 = 0;
            Double Baseimponible0 = 0;
            Double iva12 = 0;
            Double total= 0;
            foreach (DataGridViewRow fila in Table_productos.Rows){
                if (!fila.IsNewRow){
                    Boolean iva = true;
                    if (Convert.ToBoolean(fila.Cells[Table_productos.Columns["Table_iva12"].Index].Value)){
                        iva12 += (Convert.ToDouble(fila.Cells[Table_productos.Columns["Table_Subtotal"].Index].Value )* 0.12);
                        Baseimponible12 += Convert.ToDouble(fila.Cells[Table_productos.Columns["Table_Subtotal"].Index].Value);
                    }
                    else{
                        Baseimponible0 += Convert.ToDouble(fila.Cells[Table_productos.Columns["Table_Subtotal"].Index].Value);
                        iva = false;
                    }
                    
                }
                
            }
            total = Baseimponible12 +  Baseimponible0 + iva12;  
            txt_baseimponible12.Text = Convert.ToString(Baseimponible12);
            txt_baseimponible0.Text = Convert.ToString(Baseimponible0);
            txt_iva.Text = Convert.ToString(iva12);


            txt_Total.Text = Convert.ToString(total);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Butt_CargarDatos_Click(object sender, EventArgs e){

            
            Factura fact = CrearFactura();


            fact.cargarDBFactura();
            Table_productos.Rows.Clear();
            txt_baseimponible0.Text = "";
            txt_baseimponible12.Text = "";
            txt_cliente.Text = "";
            txt_iva.Text = "";
            txt_numfact.Text= "";
            txt_Total.Text = "";

            CargarNumFact();
            


        }

        private Factura CrearFactura(){
            Factura fact = new Factura(Convert.ToInt32(txt_numfact.Text), Convert.ToString(txt_cliente.Text), Convert.ToDateTime(DateTime_fechafact.Text), Convert.ToDouble(txt_baseimponible12.Text), Convert.ToDouble(txt_baseimponible0.Text), Convert.ToDouble(txt_iva.Text), Convert.ToDouble(txt_Total.Text));

            foreach (DataGridViewRow fila in Table_productos.Rows)
            {
                if (!fila.IsNewRow)
                {
                    Boolean iva = true;
                    if (!Convert.ToBoolean(fila.Cells[Table_productos.Columns["Table_iva12"].Index].Value))
                        iva = false;

                    fact.addProducto(new Producto((Convert.ToString(fila.Cells[Table_productos.Columns["Table_nombreproducto"].Index].Value)), (Convert.ToDouble(fila.Cells[Table_productos.Columns["Table_Preciounitario"].Index].Value)), Convert.ToInt32(fila.Cells[Table_productos.Columns["Table_Cantidad"].Index].Value), iva));

                }
            }
            return fact;
        }

        private void button1_Click(object sender, EventArgs e){
            
        }
    }
}
