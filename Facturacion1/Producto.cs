using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion1
{
    internal class Producto{
        private string Producto_nombre { get; set; }
        private double Preciounitario { get; set; }
        private int Cantidad { get; set; }
        private double subtotal { get; set; }
        private Boolean iva { get; set; }

        public Producto(string producto_nombre, double preciounitario, int cantidad, Boolean iva)
        {
            Producto_nombre = producto_nombre;
            Preciounitario = preciounitario;
            Cantidad = cantidad;
            subtotal = cantidad * preciounitario;
            this.iva = iva;
        }

        public void cargarDBProducto(int ID_Producto, int ID_Factura){
            try {    
            using (SqlConnection connection = new SqlConnection(Form1.connectionString)){
                connection.Open();
                Console.WriteLine("Conexión establecida exitosamente.");

                // Aquí puedes realizar operaciones en la base de datos, por ejemplo, insertar datos
                string query = "INSERT INTO PRODUCTOS (ID_facturaP, ID_producto, Nombreproducto, Preciounitario,Cantidad ,iva12, Subtotal) " +
                               "VALUES (@ID_facturaP, @ID_producto, @Nombreproducto, @Preciounitario, @Cantidad, @iva12, @subtotal)";

                using (SqlCommand command = new SqlCommand(query, connection)){
                    command.Parameters.AddWithValue("@ID_facturaP", ID_Factura);
                    command.Parameters.AddWithValue("@ID_producto", ID_Producto);
                    command.Parameters.AddWithValue("@Nombreproducto", Producto_nombre);
                    command.Parameters.AddWithValue("@Preciounitario", Preciounitario);
                    command.Parameters.AddWithValue("@Cantidad", Cantidad);
                    command.Parameters.AddWithValue("@iva12", iva);
                    command.Parameters.AddWithValue("@Subtotal", subtotal);
                    command.ExecuteNonQuery();
                    }
                    Console.WriteLine("Producto insertado correctamente.");
                }
            }catch (Exception ex){
                Console.WriteLine($"Error al conectar con la base de datos: {ex.Message}");
            }
        }

        public string getProducto_nombre() { return Producto_nombre; }
        public double getPreciounitario() { return Preciounitario; }
        public int getCantidad() { return Cantidad; }
        public Boolean getIva() { return iva; }
        public double getsubtotal() { return subtotal; }


        public void setID_FacturaProducto_nombre(string ID) { Producto_nombre = ID; }
        public void setPreciounitario(double precio) { Preciounitario = precio; }
        public void setCantidad(int Cantidades) { Cantidad = Cantidades; }
        public void setsubtotal(Double sub) { subtotal = sub; }


    }
}
