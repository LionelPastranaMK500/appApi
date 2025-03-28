﻿using appApi.Model;
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
            //instanciar la conexion a la base de datos
            var db = Conectar();
            //crear la consulta para insertar un registro en la tabla Procesador
            string query = @"INSERT INTO procesadores 
                        (nombre, marca, nucleos, hilos, frecuencia_base, frecuencia_turbo, tdp, lanzamiento) 
                        VALUES (@nombr, @marc, @nucleo, @hilo, @frecuenciaBas, @frecuenciaTurb, @td, @lanzamient)";
            //ejecutar la consulta para insertar un registro en la tabla Procesador    
            int n = await db.ExecuteAsync(query, new
            {
                nombr = procesador.nombre,
                marc = procesador.marca,
                nucleo = procesador.nucleos,
                hilo = procesador.hilos,
                frecuenciaBas = procesador.frecuenciaBase,
                frecuenciaTurb = procesador.frecuenciaTurbo,
                td = procesador.tdp,
                lanzamient = procesador.lanzamiento
            });
            //cerrar la conexion a la base de datos
            db.Dispose();
            //retornar verdadero si se inserto el registro
            return n > 0;
        }
        //metodo para actualizar un procesador
        public async Task<bool> ActualizarProcesador(Procesador procesador)
        {
            //instanciar la conexion a la base de datos
            var db = Conectar();
            String query = "UPDATE procesadores SET nombre=@nombr, marca=@marc, nucleos=@nucleo, hilos=@hilo, frecuencia_base=@frecuenciaBas, frecuencia_turbo=@frecuenciaTurb, tdp=@td, lanzamiento=@lanzamient WHERE id=@ide";
            //ejecutar la consulta para actualizar un registro en la tabla Procesador
            //retornar verdadero si se actualizo el registro
            int n = await db.ExecuteAsync(query, new
            {
                nombr = procesador.nombre,
                marc = procesador.marca,
                nucleo = procesador.nucleos,
                hilo = procesador.hilos,
                frecuenciaBas = procesador.frecuenciaBase,
                frecuenciaTurb = procesador.frecuenciaTurbo,
                td = procesador.tdp,
                lanzamient = procesador.lanzamiento,
                ide = procesador.id
            });
            db.Dispose();
            return n > 0;
        }
        //metodo para eliminar un procesador
        public async Task<bool> EliminarProcesador(int id)
        {
            //instanciar la conexion a la base de datos
            var db = Conectar();
            //crear la consulta para eliminar un registro en la tabla Procesador
            string query = "DELETE FROM Procesadores WHERE id = @ide";
            //ejecutar la consulta para eliminar un registro en la tabla Procesador
            int n = await db.ExecuteAsync(query, new { ide = id });
            //cerrar la conexion a la base de datos
            db.Dispose();
            return n > 0;
        }
    }
}
