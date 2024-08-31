using System;
using CapaDatos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;

namespace CapaLogica
{
    public class ProductoRepository
    {
        ProductosDAL _productoDAL;

        public List<Productos> ObtenerTodos()
        {
            _productoDAL = new ProductosDAL();

            return _productoDAL.ObtenerTodos();
        }
        //Metodos para cargar el datagrid desde el segundo formulario simulando una ventana modal por que la pagina principal no se cierra
        public event EventHandler LlenarDataGridViewRequested;
        public Productos ObtenerPorID(int id)
        {
            _productoDAL = new ProductosDAL();

            return _productoDAL.ObtenerPorID(id);
        }

        public int EliminarProducto(int id)
        {
            _productoDAL = new ProductosDAL();

            return _productoDAL.EliminarProducto(id);
        }
        public int ActualizarProducto(Productos producto)
        {
            _productoDAL = new ProductosDAL();

            return _productoDAL.ActualizarProducto(producto);
        }
        public int GuardarProducto(Productos producto)
        {
            _productoDAL = new ProductosDAL();

            return _productoDAL.GuardarProducto(producto);
        }

        public List<Productos> FiltroNombre(string nombre)
        {
            _productoDAL = new ProductosDAL();

            return _productoDAL.FiltroNombre(nombre);
        }

        public List<Productos> FiltroCategoria(string nombre)
        {
            _productoDAL = new ProductosDAL();

            return _productoDAL.FiltroCategoria(nombre);
        }
        public List<Productos> FiltroFabricante(string nombre)
        {
            _productoDAL = new ProductosDAL();

            return _productoDAL.FiltroFabricante(nombre);
        }
    }
}
