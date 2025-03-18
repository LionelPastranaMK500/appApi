using appApi.Model;
using Dapper;
using MySql.Data.MySqlClient;

namespace appApi.Data
{
    public class CRUDbenchmark : IBenchmark
    {
        Configuracion _conexion;
        public CRUDbenchmark(Configuracion conexion)
        {
            _conexion = conexion;
        }
        protected MySqlConnection Conectar()
        {
            return new MySqlConnection(_conexion.Conectar);
        }
        //metodo para listar todos los benchmarks
        public async Task<IEnumerable<Benchmark>> ListarBenchmark()
        {
            //instanciar la conexion a la base de datos
            var db = Conectar();
            String query = "SELECT * FROM Benchmark";
            //retornar todos los registros de la tabla Benchmark
            var resultado = await db.QueryAsync<Benchmark>(query, new { });
            db.Dispose();
            return resultado;
        }
        //metodo para mostrar un benchmark por id
        public async Task<Benchmark> MostrarBenchmark(int id)
        {
            //instanciar la conexion a la base de datos
            var db = Conectar();
            String query = "SELECT * FROM Benchmark WHERE id = @id";
            //retornar un registro de la tabla Benchmark por id
            var resultado = await db.QueryFirstAsync<Benchmark>(query, new { id });
            db.Dispose();
            return resultado;
        }
        //metodo para crear un benchmark
        public async Task<bool> AgregarBenchmark(Benchmark benchmark)
        {
            //instanciar la conexion a la base de datos
            var db = Conectar();
            String query = "INSERT INTO Benchmark (procesador_id, prueba, puntaje) VALUES (@procesador_id, @prueba, @puntaje)";
            //ejecutar la consulta para insertar un registro en la tabla Benchmark
            //retornar verdadero si se inserto el registro
            int n = await db.ExecuteAsync(query, new { 
                benchmark.procesador_id, 
                benchmark.prueba, 
                benchmark.puntaje });
            db.Dispose();
            return n > 0;
        }
        //metodo para actualizar un benchmark
        public async Task<bool> ActualizarBenchmark(Benchmark benchmark)
        {
            //instanciar la conexion a la base de datos
            var db = Conectar();
            String query = "UPDATE Benchmark SET prueba = @prueba, puntaje = @puntaje WHERE id = @id";
            //ejecutar la consulta para actualizar un registro en la tabla Benchmark
            int n = await db.ExecuteAsync(query, new {  benchmark.prueba, benchmark. puntaje, benchmark.id });
            db.Dispose();
            return n > 0;
        }
        //metodo para eliminar un benchmark
        public async Task<bool> EliminarBenchmark(int id)
        {
            //instanciar la conexion a la base de datos
            var db = Conectar();
            String query = "DELETE FROM Benchmark WHERE id = @ide";
            //ejecutar la consulta para eliminar un registro en la tabla Benchmark
            //retornar verdadero si se elimino el registro
            int n = await db.ExecuteAsync(query, new { ide = id });
            db.Dispose();
            return n > 0;
        }
    }
}
