using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facturacion1
{
    internal class Factura{
        private int ID_Factura;
        private string Cliente;
        private DateTime fechafact;
        private double Baseimponible12;
        private double Baseimponible0;
        private double iva12;
        private double total;
        private List<Producto> Productos;
        



        public Factura(int iD_Factura, string cliente, DateTime fechafact, double baseimponible12, double baseimponible0, double iva12, double total){
            ID_Factura = iD_Factura;
            Cliente = cliente;
            this.fechafact = fechafact;
            Baseimponible12 = baseimponible12;
            Baseimponible0 = baseimponible0;
            this.iva12 = iva12;
            this.total = total;
            Productos = new List<Producto>();
        }

        public void addProducto(Producto producto){
            Productos.Add(producto);
         }

        public void cargarDBFactura(){
            try{
                using (SqlConnection connection = new SqlConnection(Form1.connectionString)){
                    connection.Open();
                    Console.WriteLine("Conexión establecida exitosamente.");
                    string query = "INSERT INTO FACTURA (ID_Factura,Nombre_cliente, fecha, baseimponible12, baseImponible0, iva12, total) " +
                                   "VALUES (@ID_Factura,@nombre_cliente, @fecha, @base_imponible_12, @base_imponible_0, @iva_12, @total)";

                    using (SqlCommand command = new SqlCommand(query, connection)){
                        command.Parameters.AddWithValue("@ID_Factura", ID_Factura);
                        command.Parameters.AddWithValue("@nombre_cliente", Cliente);
                        command.Parameters.AddWithValue("@fecha", fechafact);
                        command.Parameters.AddWithValue("@base_imponible_12", Baseimponible12);
                        command.Parameters.AddWithValue("@base_imponible_0", Baseimponible0);
                        command.Parameters.AddWithValue("@iva_12", iva12);
                        command.Parameters.AddWithValue("@total", total);

                        command.ExecuteNonQuery();
                    }
                    Console.WriteLine("Factura insertada correctamente.");
                }
                
            }
            catch (Exception ex){
                Console.WriteLine($"Error al conectar con la base de datos: {ex.Message}");
            }

            for (int i = 0; i < Productos.Count; i++){
                Productos[i].cargarDBProducto(i+1,ID_Factura);
            }
            MessageBox.Show("Datos agregados correctamente.");

        }


        public int getID_Factura() {  return ID_Factura; }
        public string getCliente() { return Cliente; } 
        public DateTime? getfechafact() { return fechafact; }
        public double getBaseimponible0() { return Baseimponible0; }
        public double getBaseimponible12( ) { return Baseimponible12; }
        public double getTotal() { return total; }
        public double getiva () { return iva12; }

        public void setID_Factura(int ID) {  ID_Factura = ID; }
        public void setCliente(string nombre) {  Cliente=nombre; }
        public void setfechafact(DateTime fecha ) {  fechafact= fecha; }
        public void setBaseimponible0(Double Base0 ) {  Baseimponible0= Base0; }
        public void setBaseimponible12(Double Base12) {  Baseimponible12 = Base12; }
        public void setTotal(Double totalidad) {  total=totalidad; }
        public void setiva(Double iva) {  iva12=iva; }
        public void setProductos(List<Producto> Productos2) { Productos = Productos2; }

    }
}
