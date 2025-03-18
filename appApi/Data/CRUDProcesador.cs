using appApi.Model;
using Dapper;
using MySql.Data.MySqlClient;

namespace appApi.Data
{
    public class CRUDProcesador : IProcesador
    {
        Configuracion _conexion;

        public CRUDProcesador(Configuracion conexion)
        {
            _conexion = conexion;
        }

        protected MySqlConnection Conectar()
        {
            return new MySqlConnection(_conexion.Conectar);
        }

        //metodo para listar todos los procesadores
        public async Task<IEnumerable<Procesador>> ListarProcesadores()
        {
            //instanciar la conexion a la base de datos
            var db = Conectar();
            String query = "SELECT * FROM Procesadores";
            //retornar todos los registros de la tabla Procesador
            var resultado = await db.QueryAsync<Procesador>(query, new { });
            db.Dispose();
            return resultado;
        }

        //metodo para mostrar un procesador por id
        public async Task<Procesador> MostrarProcesador(int id)
        {
            //instanciar la conexion a la base de datos
            var db = Conectar();
            String query = "SELECT * FROM Procesadores WHERE id = @id";
            //retornar un registro de la tabla Procesador por id
            var resultado = await db.QueryFirstAsync<Procesador>(query, new { id });
            db.Dispose();
            return resultado;
        }

        //metodo para crear un procesador
        public async Task<bool> AgregarProcesador(Procesador procesador)
        {
            var db = Conectar();
            string query = "INSERT INTO procesadores VALUES (@nombre, @marca, @nucleos, @hilos, @frecuenciaBase, @frecuenciaTurbo, @tdp, @lanzamiento)";

            int n = await db.ExecuteAsync(query, new
            {
                procesador.nombre,
                procesador.marca,
                procesador.nucleos,
                procesador.hilos,
                procesador.frecuenciaBase,
                procesador.frecuenciaTurbo,
                procesador.tdp,
                procesador.lanzamiento
            });

            db.Dispose();
            return n > 0;
        }
        //metodo para actualizar un procesador
        public async Task<bool> ActualizarProcesador(Procesador procesador)
        {
            //instanciar la conexion a la base de datos
            var db = Conectar();
            String query = "UPDATE procesadores SET nombre=@nombre, marca=@marca, nucleos=@nucleos, hilos=@hilos, frecuencia_base=@frecuenciaBase, frecuencia_turbo=@frecuenciaTurbo, tdp=@tdp, lanzamiento=@lanzamiento WHERE id=@id";
            //ejecutar la consulta para actualizar un registro en la tabla Procesador
            //retornar verdadero si se actualizo el registro
            int n = await db.ExecuteAsync(query, new { 
                procesador.nombre, 
                procesador.marca, 
                procesador.nucleos, 
                procesador.hilos, 
                procesador.frecuenciaBase, 
                procesador.frecuenciaTurbo, 
                procesador.tdp, 
                procesador.lanzamiento, 
                procesador.id });
            db.Dispose();
            return n > 0;
        }
        //metodo para eliminar un procesador
        public async Task<bool> EliminarProcesador(int id)
        {
            //instanciar la conexion a la base de datos
            var db = Conectar();
            String query = "DELETE FROM Procesadores WHERE id = @id";
            //ejecutar la consulta para eliminar un registro en la tabla Procesador
            //retornar verdadero si se elimino el registro
            int n = await db.ExecuteAsync(query, new { id });
            db.Dispose();
            return n > 0;
        }
    }
}
