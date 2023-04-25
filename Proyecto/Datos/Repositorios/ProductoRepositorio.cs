using Dapper;
using Datos.Interfaces;
using Modelos;
using MySql.Data.MySqlClient;

namespace Datos.Repositorios
{
    //HEREDAMOS DE LA INTERFAZ IProductoRepositorio
    public class ProductoRepositorio : IProductoRepositorio
    {
        private string CadenaConexion; //variable para la conexión

        //CONSTRUCTOR
        public ProductoRepositorio(string _cadenaConexion)
        {
            CadenaConexion = _cadenaConexion;  //pasamos la cadena de conexion
        }

        //METODO PARA LA CONEXION DE MySQL
        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexion);
        }

        //METODO PARA ACTUALIZAR REGISTRO
        public async Task<bool> ActualizarAsync(Producto producto)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection _conexion = Conexion(); //llamamos el metodo de conexion
                await _conexion.OpenAsync(); //abre la conexion asincrona
                string sql = @"UPDATE producto SET Descripcion = @Descripcion, Existencia = @Existencia, Precio = @Precio,
                                Foto = @Foto, EstaActivo = @EstaActivo WHERE Codigo = @Codigo;";
                resultado = Convert.ToBoolean(await _conexion.ExecuteAsync(sql, producto));

            }
            catch (Exception)
            {
            }
            return resultado;
        }

        //METODO PARA ELIMINAR REGISTRO
        public async Task<bool> EliminarAsync(string codigo)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection _conexion = Conexion(); //llamamos el metodo de conexion
                await _conexion.OpenAsync(); //abre la conexion asincrona
                string sql = "DELETE FROM producto WHERE Codigo = @Codigo;";
                resultado = Convert.ToBoolean(await _conexion.ExecuteAsync(sql, new { codigo }));
            }
            catch (Exception)
            {
            }
            return resultado;
        }

        //METODO PARA DEVOLVER TODOS LOS REGISTROS DE PRODUCTO
        public async Task<IEnumerable<Producto>> GetListaAsync()
        {
            IEnumerable<Producto> lista = new List<Producto>();
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = "SELECT * FROM producto;";
                lista = await _conexion.QueryAsync<Producto>(sql);
            }
            catch (Exception)
            {
            }
            return lista;
        }

        //METODO PARA DEVOLVER PRODUCTO POR CODIGO
        public async Task<Producto> GetPorCodigoAsync(string codigo)
        {
            //Declaramos un objeto y lo instanciamos
            Producto producto = new Producto();
            try
            {
                using MySqlConnection _conexion = Conexion(); //llamamos el metodo de conexion
                await _conexion.OpenAsync(); //abre la conexion asincrona
                string sql = "SELECT * FROM producto WHERE Codigo = @Codigo;";
                producto = await _conexion.QueryFirstAsync<Producto>(sql, new { codigo }); //QueryFirstAsync solo retorna un solo resultado 
            }
            catch (Exception)
            {
            }
            return producto;
        }

        //METODO PARA CREAR UN NUEVO REGISTRO DE PRODUCTO
        public async Task<bool> NuevoAsync(Producto producto)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection _conexion = Conexion(); //llamamos el metodo de conexion
                await _conexion.OpenAsync(); //abre la conexion asincrona
                string sql = @"INSERT INTO producto (Codigo,Descripcion,Existencia,Precio,Foto,EstaActivo) 
                                VALUES (@Codigo,@Descripcion,@Existencia,@Precio,@Foto,@EstaActivo);";
                resultado = Convert.ToBoolean(await _conexion.ExecuteAsync(sql, producto));
            }
            catch (Exception)
            {
            }
            return resultado;
        }
    }
}
