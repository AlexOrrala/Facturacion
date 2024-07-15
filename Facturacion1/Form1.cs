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
                            if (reader.Read())
                            {
                                Console.WriteLine("mal");
                                txt_numfact.Text = Convert.ToString(reader.GetInt32(0) + 1);
                            }
                            else
                            {
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
                }
            }catch (Exception ex){
                    MessageBox.Show($"Los datos pueden estar vacios o no están en el formato adecuado: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);     
                }
            

        }

        private void Actualizartotales(){
            Double Subtotal=0;
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

            Factura fact = new Factura(Convert.ToInt32(txt_numfact.Text), Convert.ToString(txt_cliente.Text), Convert.ToDateTime(DateTime_fechafact.Text), Convert.ToDouble(txt_baseimponible12.Text), Convert.ToDouble(txt_baseimponible0.Text), Convert.ToDouble(txt_iva.Text), Convert.ToDouble(txt_Total.Text)); 

            foreach (DataGridViewRow fila in Table_productos.Rows){
                if (!fila.IsNewRow){
                    Boolean iva = true;
                    if (!Convert.ToBoolean(fila.Cells[Table_productos.Columns["Table_iva12"].Index].Value))
                        iva = false;
                    
                    fact.addProducto(new Producto((Convert.ToString(fila.Cells[Table_productos.Columns["Table_nombreproducto"].Index].Value)), (Convert.ToDouble(fila.Cells[Table_productos.Columns["Table_Preciounitario"].Index].Value)), Convert.ToInt32(fila.Cells[Table_productos.Columns["Table_Cantidad"].Index].Value), iva));
                    
                }
            }
            

            fact.cargarDBFactura();
            Table_productos.Rows.Clear();
            txt_baseimponible0.Text = "";
            txt_baseimponible12.Text = "";
            txt_cliente.Text = "";
            txt_iva.Text = "";
            txt_numfact.Text= "";
            txt_Total.Text = "";
            


        }





    }
}
