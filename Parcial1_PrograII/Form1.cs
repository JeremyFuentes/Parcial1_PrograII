using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial1_PrograII
{
    public partial class Form1 : Form
    {
        ProductoRepository _productoRepository;

        public Form1()
        {
            InitializeComponent();
            CargarProductos();

            _productoRepository = new ProductoRepository();
        }

        private void CargarProductos()
        {
            _productoRepository = new ProductoRepository();

            productosDataGrid.DataSource = _productoRepository.ObtenerTodos();
        }

        private void productosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productosBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.parcial1_PrograIIDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'parcial1_PrograIIDataSet.Productos' Puede moverla o quitarla según sea necesario.
            this.productosTableAdapter.Fill(this.parcial1_PrograIIDataSet.Productos);
            // TODO: esta línea de código carga datos en la tabla 'parcial1_PrograIIDataSet.Productos' Puede moverla o quitarla según sea necesario.
            this.productosTableAdapter.Fill(this.parcial1_PrograIIDataSet.Productos);
            // TODO: esta línea de código carga datos en la tabla 'parcial1_PrograIIDataSet.Productos' Puede moverla o quitarla según sea necesario.
            this.productosTableAdapter.Fill(this.parcial1_PrograIIDataSet.Productos);

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarProducto objRegistroProducto = new AgregarProducto(this);
            objRegistroProducto.LlenarDataGridViewRequested += Form1_LlenarDataGridViewRequested;
            objRegistroProducto.ShowDialog();
        }

        private void productosBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.productosBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.parcial1_PrograIIDataSet);

        }

        private void productosBindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            this.Validate();
            this.productosBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.parcial1_PrograIIDataSet);

        }

        private void Form1_LlenarDataGridViewRequested(object sender, EventArgs e)
        {
            // Actualizar el DataGridView
            CargarProductos();
        }

        private void productosDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (productosDataGrid.Columns[e.ColumnIndex].Name == "btnEditar")
            {
                //Esta linea de abajo creo que no esta haciendo nada pero me da miedo borrarla XD
                int Id = Convert.ToInt32(productosDataGrid.CurrentRow.Cells["Id"].Value.ToString());

                AgregarProducto objRegistroProducto = new AgregarProducto(this, Id);
                objRegistroProducto.LlenarDataGridViewRequested += Form1_LlenarDataGridViewRequested;
                objRegistroProducto.Show();
            }
            else if (productosDataGrid.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                int Id = Convert.ToInt32(productosDataGrid.CurrentRow.Cells["Id"].Value.ToString());
                _productoRepository = new ProductoRepository();
                _productoRepository.EliminarProducto(Id);
                int resultado = _productoRepository.EliminarProducto(Id);

                if (resultado == 0)
                {
                    MessageBox.Show("Producto eliminado con exito", "| Registro Producto",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("No se logro eliminar el Producto", "| Registro Producto",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                CargarProductos();
            }
        }
    }
}
