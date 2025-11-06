using System;

namespace GestionInventarioTienda.clases
{
    public class Producto
    {
        public string G3_Nombre { get; set; }
        public string G3_Categoria { get; set; }
        public decimal G3_Precio { get; set; }
        public int G3_Cantidad { get; set; }

        public Producto(string G3_nombre, string G3_categoria, decimal G3_precio, int G3_cantidad)
        {
            G3_Nombre = G3_nombre;
            G3_Categoria = G3_categoria;
            G3_Precio = G3_precio;
            G3_Cantidad = G3_cantidad;
        }
    }
}
