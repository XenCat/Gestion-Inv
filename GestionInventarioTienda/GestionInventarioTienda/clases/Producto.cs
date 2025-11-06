using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionInventarioTienda.clases
{
    public class Producto
    {
        public string G2_Nombre { get; set; }
        public string G2_Categoria { get; set; }
        public decimal G2_Precio { get; set; }
        public int G2_Cantidad { get; set; }
        public Producto(string G2_nombre, string G2_categoria, decimal G2_precio, int G2_cantidad)
        {
            G2_Nombre = G2_nombre;
            G2_Categoria = G2_categoria;
            G2_Precio = G2_precio;
            G2_Cantidad = G2_cantidad;
        }
    }
}
