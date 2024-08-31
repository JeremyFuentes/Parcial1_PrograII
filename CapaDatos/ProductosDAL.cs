using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaDatos
{
    public class ProductosDAL
    {
        public List<Productos> ObtenerTodos()
        {
            using (var conexion = DBConectar.GetSqlConnection())
            {
                String selectFrom = "";

                selectFrom = selectFrom + "SELECT [IdProducto] " + "\n";
                selectFrom = selectFrom + "      ,[Nombre] " + "\n";
                selectFrom = selectFrom + "      ,[Descripcion] " + "\n";
                selectFrom = selectFrom + "      ,[Precio] " + "\n";
                selectFrom = selectFrom + "      ,[Cantidad] " + "\n";
                selectFrom = selectFrom + "      ,[Fabricante] " + "\n";
                selectFrom = selectFrom + "      ,[Categoria] " + "\n";
                selectFrom = selectFrom + "  FROM [Productos]";

                using (SqlCommand comando = new SqlCommand(selectFrom, conexion))
                {
                    SqlDataReader reader = comando.ExecuteReader();

                    List<Productos> Productos = new List<Productos>();

                    while (reader.Read())
                    {
                        var producto = LeerDelDataReader(reader);
                        Productos.Add(producto);
                    }

                    return Productos;
                }
            }
        }

        public Productos LeerDelDataReader(SqlDataReader reader)
        {
            Productos producto = new Productos();

            producto.IdProducto = reader["IdProducto"] == DBNull.Value ? 0 : (int)reader["IdProducto"];
            producto.Nombre = reader["Nombre"] == DBNull.Value ? "" : (String)reader["Nombre"];
            producto.Descripcion = reader["Descripcion"] == DBNull.Value ? "" : (String)reader["Descripcion"];
            producto.Precio = reader["Precio"] == DBNull.Value ? 0 : (decimal)reader["Precio"];
            producto.Cantidad = reader["Cantidad"] == DBNull.Value ? 0 : (int)reader["Cantidad"];
            producto.Fabricante = reader["Fabricante"] == DBNull.Value ? "" : (String)reader["Fabricante"];
            producto.Categoria = reader["Categoria"] == DBNull.Value ? "" : (String)reader["Categoria"];

            return producto;
        }

        public Productos ObtenerPorID(int id)
        {
            using (var conexion = DBConectar.GetSqlConnection())
            {
                String selectForID = "";

                selectForID = selectForID + "SELECT [IdProducto] " + "\n";
                selectForID = selectForID + "      ,[Nombre] " + "\n";
                selectForID = selectForID + "      ,[Descripcion] " + "\n";
                selectForID = selectForID + "      ,[Precio] " + "\n";
                selectForID = selectForID + "      ,[Cantidad] " + "\n";
                selectForID = selectForID + "      ,[Fabricante] " + "\n";
                selectForID = selectForID + "      ,[Categoria] " + "\n";
                selectForID = selectForID + "  FROM [Productos]";
                selectForID = selectForID + "  Where IdProducto = @id";

                using (SqlCommand comando = new SqlCommand(selectForID, conexion))
                {
                    comando.Parameters.AddWithValue("Id", id);

                    var reader = comando.ExecuteReader();

                    Productos producto = null;

                    if (reader.Read())
                    {
                        producto = LeerDelDataReader(reader);
                    }

                    return producto;
                }
            }
        }

        public int EliminarProducto(int id)
        {
            using (var conexion = DBConectar.GetSqlConnection())
            {
                String EliminarProducto = "";

                EliminarProducto = EliminarProducto + "DELETE FROM [dbo].[Productos] " + "\n";
                EliminarProducto = EliminarProducto + "      WHERE IdProducto = @Id";

                using (SqlCommand comando = new SqlCommand(EliminarProducto, conexion))
                {
                    comando.Parameters.AddWithValue("@Id", id);

                    int eliminados = comando.ExecuteNonQuery();

                    return eliminados;
                }
            }
        }

        public int ActualizarProducto(Productos producto)
        {
            using (var conexion = DBConectar.GetSqlConnection())
            {
                String ActualizarProductoPorID = "";

                ActualizarProductoPorID = ActualizarProductoPorID + "UPDATE [dbo].[Productos] " + "\n";
                ActualizarProductoPorID = ActualizarProductoPorID + "   SET [Nombre] = @Nombre " + "\n";
                ActualizarProductoPorID = ActualizarProductoPorID + "      ,[Descripcion] = @Descripcion " + "\n";
                ActualizarProductoPorID = ActualizarProductoPorID + "      ,[Precio] = @Precio " + "\n";
                ActualizarProductoPorID = ActualizarProductoPorID + "      ,[Cantidad] = @Cantidad " + "\n";
                ActualizarProductoPorID = ActualizarProductoPorID + "      ,[Fabricante] = @Fabricante " + "\n";
                ActualizarProductoPorID = ActualizarProductoPorID + "      ,[Categoria] = @Categoria " + "\n";
                ActualizarProductoPorID = ActualizarProductoPorID + " WHERE IdProducto = @Id";

                using (var comando = new SqlCommand(ActualizarProductoPorID, conexion))
                {
                    int actualizados = parametrosProducto(producto, comando);
                    return actualizados;
                }
            }
        }

        public int parametrosProducto(Productos producto, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("Id", producto.IdProducto);
            comando.Parameters.AddWithValue("Nombre", producto.Nombre);
            comando.Parameters.AddWithValue("Descripcion", producto.Descripcion);
            comando.Parameters.AddWithValue("Precio", producto.Precio);
            comando.Parameters.AddWithValue("Cantidad", producto.Cantidad);
            comando.Parameters.AddWithValue("Fabricante", producto.Fabricante);
            comando.Parameters.AddWithValue("Categoria", producto.Categoria);

            var insertados = comando.ExecuteNonQuery();
            return insertados;
        }

        public int GuardarProducto(Productos producto)
        {
            using (var conexion = DBConectar.GetSqlConnection())
            {
                String insertInto = "";

                insertInto = insertInto + "INSERT INTO [dbo].[Productos] " + "\n";

                insertInto = insertInto + "           ([Nombre] " + "\n";
                insertInto = insertInto + "           ,[Descripcion] " + "\n";
                insertInto = insertInto + "           ,[Precio] " + "\n";
                insertInto = insertInto + "           ,[Cantidad] " + "\n";
                insertInto = insertInto + "           ,[Fabricante] " + "\n";
                insertInto = insertInto + "           ,[Categoria]) " + "\n"; // El paréntesis de cierre aquí

                insertInto = insertInto + "     VALUES " + "\n";
                insertInto = insertInto + "           (@Nombre " + "\n";
                insertInto = insertInto + "           ,@Descripcion " + "\n";
                insertInto = insertInto + "           ,@Precio " + "\n";
                insertInto = insertInto + "           ,@Cantidad " + "\n";
                insertInto = insertInto + "           ,@Fabricante " + "\n";
                insertInto = insertInto + "           ,@Categoria)"; // El paréntesis de cierre aquí

                using (var comando = new SqlCommand(insertInto, conexion))
                {
                    int insertados = parametrosProducto(producto, comando);
                    return insertados;
                }
            }
        }
    }
}