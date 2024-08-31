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
        public Form1()
        {
            InitializeComponent();
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
            AgregarProducto objRegistroCategoria = new AgregarProducto();
            objRegistroCategoria.ShowDialog();
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
    }
}
