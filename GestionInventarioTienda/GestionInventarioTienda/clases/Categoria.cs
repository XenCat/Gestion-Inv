using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionInventarioTienda.clases
{
    public class Categoria
    {
        public string G2_Nombre { get; set; }
        public List<Producto> Productos { get; set; } = new List<Producto>();

        public void AgregarProducto(Producto producto)
        {
            Productos.Add(producto);
        }

        public int CalcularStockTotal()
        {
            return Productos.Sum(p => p.G2_Cantidad);
        }
    }
}
