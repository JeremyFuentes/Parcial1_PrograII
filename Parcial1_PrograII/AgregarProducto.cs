using CapaEntidades;
using CapaLogica;
using CapaDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial1_PrograII
{
    public partial class AgregarProducto : Form
    {
        ProductoRepository _productoRepository;
        int id;
        private Form1 _form1;

        public AgregarProducto(Form1 form1, int _id = 0)
        {
            InitializeComponent();
            id = _id;

            if (id > 0)
            {
                CargarCampos(id);
            }
            else
            {
                productosBindingSource.MoveLast();
                productosBindingSource.AddNew();

                Productos producto = new Productos();
                productosBindingSource.DataSource = producto;
            }
        }

        private void CargarCampos(int id)
        {
            _productoRepository = new ProductoRepository();
            productosBindingSource.DataSource = _productoRepository.ObtenerPorID(id);
        }

        private void productosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productosBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.parcial1_PrograIIDataSet);

        }

        //Metodos para cargar el datagrid desde el segundo formulario simulando una ventana modal por que la pagina principal no se cierra
        public event EventHandler LlenarDataGridViewRequested;

        private void AgregarProducto_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'parcial1_PrograIIDataSet.Productos' Puede moverla o quitarla según sea necesario.
            this.productosTableAdapter.Fill(this.parcial1_PrograIIDataSet.Productos);

        }

        private void OnLlenarDataGridViewRequested()
        {
            LlenarDataGridViewRequested?.Invoke(this, EventArgs.Empty);
        }

        private bool ValidarCampos()
        {
            bool camposValidos = true;

            // Validación del nombre del producto
            if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                MessageBox.Show("Se requiere el nombre del producto. ¡Este campo es obligatorio!", "Tienda | Registro Producto",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                txtNombre.BackColor = Color.LightYellow;
                camposValidos = false;
                return camposValidos;
            }

            // Validación de la descripción del producto
            if (string.IsNullOrEmpty(txtDescripcion.Text.Trim()))
            {
                MessageBox.Show("Se requiere la descripción del producto. ¡Este campo es obligatorio!", "Tienda | Registro Producto",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                txtDescripcion.BackColor = Color.LightYellow;
                camposValidos = false;
                return camposValidos;
            }

            // Validación del precio del producto
            if (string.IsNullOrEmpty(txtPrecio.Text.Trim()) || !decimal.TryParse(txtPrecio.Text.Trim(), out _))
            {
                MessageBox.Show("Se requiere un precio válido para el producto. ¡Este campo es obligatorio!", "Tienda | Registro Producto",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecio.Focus();
                txtPrecio.BackColor = Color.LightYellow;
                camposValidos = false;
                return camposValidos;
            }

            // Validación del stock del producto
            if (string.IsNullOrEmpty(txtCantidad.Text.Trim()) || !int.TryParse(txtCantidad.Text.Trim(), out _))
            {
                MessageBox.Show("Se requiere una cantidad válida de stock para el producto. ¡Este campo es obligatorio!", "Tienda | Registro Producto",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidad.Focus();
                txtCantidad.BackColor = Color.LightYellow;
                camposValidos = false;
                return camposValidos;
            }

            // Validación de la marca del producto
            if (string.IsNullOrEmpty(txtFabricante.Text.Trim()))
            {
                MessageBox.Show("Se requiere la marca del producto. ¡Este campo es obligatorio!", "Tienda | Registro Producto",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFabricante.Focus();
                txtFabricante.BackColor = Color.LightYellow;
                camposValidos = false;
                return camposValidos;   
            }

            // Validación de la categoría del producto
            if (string.IsNullOrEmpty(txtCategoria.Text.Trim()))
            {
                MessageBox.Show("Se requiere la categoría del producto. ¡Este campo es obligatorio!", "Tienda | Registro Producto",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategoria.Focus();
                txtCategoria.BackColor = Color.LightYellow;
                camposValidos = false;
                return camposValidos;
            }

            return camposValidos; // Si todos los campos son válidos, se devuelve true.
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            GuardarProducto();
        }

        private void GuardarProducto()
        {
            _productoRepository = new ProductoRepository();
            try
            {
                if (!ValidarCampos())
                {
                    return; // Si los campos no son válidos, salir del método
                }


                int resultado;
                //debemo indicar si es una actualizacion o es un nuevo producto

                if (id > 0)
                {
                    productosBindingSource.EndEdit();
                    Productos producto;
                    producto = (Productos)productosBindingSource.Current;
                    resultado = _productoRepository.ActualizarProducto(producto);
                    if (resultado > 0)
                    {
                        txtNombre.Clear();
                        txtDescripcion.Clear();
                        txtPrecio.Clear();
                        txtCantidad.Clear();
                        txtCategoria.Clear();
                        txtFabricante.Clear();
                        MessageBox.Show("Producto actualizado con exito", "| Registro Producto",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se logro actualizar el producto", "| Registro Producto",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    productosBindingSource.EndEdit();

                    Productos producto;
                    producto = (Productos)productosBindingSource.Current;

                    resultado = _productoRepository.GuardarProducto(producto);

                    if (resultado > 0)
                    {
                        txtNombre.Clear();
                        txtDescripcion.Clear();
                        txtPrecio.Clear();
                        txtCantidad.Clear();
                        txtCategoria.Clear();
                        txtFabricante.Clear();
                        MessageBox.Show("Producto agregado con exito", "| Registro Producto",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se logro guardar el Producto", "| Registro Producto",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                OnLlenarDataGridViewRequested();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrio un Error: {ex}", "| Registro Producto",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}