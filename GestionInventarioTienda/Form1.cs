using GestionInventarioTienda.clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;

namespace GestionInventarioTienda
{
    public partial class Form1 : Form
    {
        private List<Producto> G3_productos = new List<Producto>();
        private List<Categoria> G3_categorias = new List<Categoria>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text?.Trim();
            string categoria = txtCategoria.Text?.Trim();
            string precioText = txtPrecio.Text?.Trim();
            string cantidadText = txtCantidad.Text?.Trim();

            if (string.IsNullOrWhiteSpace(nombre)
                || string.IsNullOrWhiteSpace(categoria)
                || !decimal.TryParse(precioText, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.CurrentCulture, out decimal precio)
                || !int.TryParse(cantidadText, NumberStyles.Integer, CultureInfo.CurrentCulture, out int cantidad))
            {
                MessageBox.Show("Por favor, complete todos los campos correctamente.");
                return;
            }

            if (G3_productos.Any(p => p.G3_Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show($"Ya existe un producto con el nombre '{nombre}'. Por favor, elija un nombre diferente o edite el producto existente.");
                return;
            }

            Producto nuevoProducto = new Producto(nombre, categoria, precio, cantidad);
            G3_productos.Add(nuevoProducto);

            var categoriaObj = G3_categorias.FirstOrDefault(c => c.G3_Nombre == nuevoProducto.G3_Categoria);
            if (categoriaObj == null)
            {
                categoriaObj = new Categoria { G3_Nombre = nuevoProducto.G3_Categoria };
                G3_categorias.Add(categoriaObj);
            }
            categoriaObj.AgregarProducto(nuevoProducto);

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
            foreach (var producto in G3_productos)
            {
                lstProductos.Items.Add($"Nombre: {producto.G3_Nombre}  |  Cantidad: {producto.G3_Cantidad}  |  Precio: {producto.G3_Precio:C}  |  Categoría: {producto.G3_Categoria}");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombreBusqueda = txtBuscar.Text.ToLower();
            var productosEncontrados = G3_productos.Where(p => p.G3_Nombre.ToLower().Contains(nombreBusqueda)).ToList();

            lstProductos.Items.Clear();
            foreach (var producto in productosEncontrados)
            {
                lstProductos.Items.Add($"Nombre: {producto.G3_Nombre}  |  Cantidad: {producto.G3_Cantidad}  |  Precio: {producto.G3_Precio:C}  |  Categoría: {producto.G3_Categoria}");
            }
            txtNombre.Clear();
            txtCategoria.Clear();
            txtPrecio.Clear();
            txtCantidad.Clear();
        }

        private void btnOrdenarAsc_Click(object sender, EventArgs e)
        {
            var productosOrdenados = G3_productos.OrderBy(p => p.G3_Precio).ToList();
            lstProductos.Items.Clear();
            foreach (var producto in productosOrdenados)
            {
                lstProductos.Items.Add($"Nombre: {producto.G3_Nombre}  |  Cantidad: {producto.G3_Cantidad}  |  Precio: {producto.G3_Precio:C}  |  Categoría: {producto.G3_Categoria}");
            }
        }

        private void btnOrdenarDesc_Click(object sender, EventArgs e)
        {
            var productosOrdenados = G3_productos.OrderByDescending(p => p.G3_Precio).ToList();
            lstProductos.Items.Clear();
            foreach (var producto in productosOrdenados)
            {
                lstProductos.Items.Add($"Nombre: {producto.G3_Nombre}  |  Cantidad: {producto.G3_Cantidad}  |  Precio: {producto.G3_Precio:C}  | Categoría: {producto.G3_Categoria}");
            }
        }

        private void btnStockTotal_Click(object sender, EventArgs e)
        {
            lstProductos.Items.Clear();
            foreach (var categoria in G3_categorias)
            {
                lstProductos.Items.Add($"{categoria.G3_Nombre}: {categoria.CalcularStockTotal()} unidades");
            }
            txtNombre.Clear();
            txtCategoria.Clear();
            txtPrecio.Clear();
            txtCantidad.Clear();
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void lstProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
