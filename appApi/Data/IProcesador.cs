using appApi.Model;

namespace appApi.Data
{
    public interface IProcesador
    {
        //definir metodos asincronos a implementar
        Task<IEnumerable<Procesador>> ListarProcesadores();
        Task<Procesador> MostrarProcesador(int id);
        Task<bool> AgregarProcesador(Procesador procesador);
        Task<bool> ActualizarProcesador(Procesador procesador);
        Task<bool> EliminarProcesador(int id);

    }
}