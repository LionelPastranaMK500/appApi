using appApi.Model;

namespace appApi.Data
{
    public interface IBenchmark
    {
        //definir metodos asincronos a implementar
        Task<IEnumerable<Benchmark>> ListarBenchmark();
        Task<Benchmark> MostrarBenchmark(int id);
        Task<bool> AgregarBenchmark(Benchmark benchmark);
        Task<bool> ActualizarBenchmark(Benchmark benchmark);
        Task<bool> EliminarBenchmark(int id);
    }
}
