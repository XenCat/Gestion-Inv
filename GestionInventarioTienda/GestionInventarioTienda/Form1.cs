using GestionInventarioTienda.clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionInventarioTienda;

namespace GestionInventarioTienda
{
    public partial class Form1 : Form
    {
        private List<Producto> G2_productos = new List<Producto>();
        private List<Categoria> G2_categorias = new List<Categoria>();
        public Form1()
        {
            InitializeComponent();
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtCategoria.Text) || !decimal.TryParse(txtPrecio.Text, out decimal precio) ||!int.TryParse(txtCantidad.Text, out int cantidad))
            {
                MessageBox.Show("Por favor, complete todos los campos correctamente.");
                return;
            }

            if (G2_productos.Any(p => p.G2_Nombre.Equals(txtNombre.Text, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show($"Ya existe un producto con el nombre '{txtNombre.Text}'. Por favor, elija un nombre diferente o edite el producto existente.");
                return;
            }

            Producto nuevoProducto = new Producto(txtNombre.Text, txtCategoria.Text, precio, cantidad);
            G2_productos.Add(nuevoProducto);

            var categoria = G2_categorias.FirstOrDefault(c => c.G2_Nombre == nuevoProducto.G2_Categoria);
            if (categoria == null)
            {
                categoria = new Categoria { G2_Nombre = nuevoProducto.G2_Categoria };
                G2_categorias.Add(categoria);
            }
            categoria.AgregarProducto(nuevoProducto);

            txtNombre.Clear();
            txtCategoria.Clear();
            txtPrecio.Clear();
            txtCantidad.Clear();
            ActualizarListaProductos();
            MessageBox.Show("Producto registrado exitosamente.");
        }
        private void ActualizarListaProductos()
        {
            lstProductos.Items.Clear();
            foreach (var producto in G2_productos)
            {
                lstProductos.Items.Add($"Nombre: {producto.G2_Nombre}  |  Cantidad: {producto.G2_Cantidad}  |  Precio: {producto.G2_Precio:C}  |  Categoría: {producto.G2_Categoria}");
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombreBusqueda = txtBuscar.Text.ToLower();
            var productosEncontrados = G2_productos.Where(p => p.G2_Nombre.ToLower().Contains(nombreBusqueda)).ToList();

            lstProductos.Items.Clear();
            foreach (var producto in productosEncontrados)
            {
                lstProductos.Items.Add($"Nombre: {producto.G2_Nombre}  |  Cantidad: {producto.G2_Cantidad}  |  Precio: {producto.G2_Precio:C}  |  Categoría: {producto.G2_Categoria}");
            }
            txtNombre.Clear();
            txtCategoria.Clear();
            txtPrecio.Clear();
            txtCantidad.Clear();
        }
        private void btnOrdenarAsc_Click(object sender, EventArgs e)
        {
            var productosOrdenados = G2_productos.OrderBy(p => p.G2_Precio).ToList();
            lstProductos.Items.Clear();
            foreach (var producto in productosOrdenados)
            {
                lstProductos.Items.Add($"Nombre: {producto.G2_Nombre}  |  Cantidad: {producto.G2_Cantidad}  |  Precio: {producto.G2_Precio:C}  |  Categoría: {producto.G2_Categoria}");
            }
        }
        private void btnOrdenarDesc_Click(object sender, EventArgs e)
        {
            var productosOrdenados = G2_productos.OrderByDescending(p => p.G2_Precio).ToList();
            lstProductos.Items.Clear();
            foreach (var producto in productosOrdenados)
            {
                lstProductos.Items.Add($"Nombre: {producto.G2_Nombre}  |  Cantidad: {producto.G2_Cantidad}  |  Precio: {producto.G2_Precio:C}  | Categoría: {producto.G2_Categoria}");
            }
        }
        private void btnStockTotal_Click(object sender, EventArgs e)
        {
            lstProductos.Items.Clear();
            foreach (var categoria in G2_categorias)
            {
                lstProductos.Items.Add($"{categoria.G2_Nombre}: {categoria.CalcularStockTotal()} unidades");
            }
            txtNombre.Clear();
            txtCategoria.Clear();
            txtPrecio.Clear();
            txtCantidad.Clear();
        }

    }
}
