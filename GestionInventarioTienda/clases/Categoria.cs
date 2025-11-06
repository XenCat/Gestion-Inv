using System;
using System.Collections.Generic;

namespace GestionInventarioTienda.clases
{
    public class Categoria
    {
        public string G3_Nombre { get; set; }
        public List<Producto> G3_Productos { get; set; } = new List<Producto>();

        public void AgregarProducto(Producto G3_producto)
        {
            G3_Productos.Add(G3_producto);
        }

        // Cálculo recursivo del stock total
        public int CalcularStockTotal()
        {
            return CalcularStockTotalRec(0);
        }

        private int CalcularStockTotalRec(int indice)
        {
            if (indice >= G3_Productos.Count) return 0;
            return G3_Productos[indice].G3_Cantidad + CalcularStockTotalRec(indice + 1);
        }
    }
}
