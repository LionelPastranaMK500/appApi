using appApi.Data;
using appApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace appApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BenchmarkController : Controller
    {
        //declarar la variable global con el tipo de la interface
        private IBenchmark _benchmark;

        //inyectar constructor de la interface
        public BenchmarkController(IBenchmark benchmark)
        {
            _benchmark = benchmark;
        }
        //metodo que devuelve la lista de procesadores
        [HttpGet]
        public async Task<IActionResult> ListarBenchmark()
        {
            return Ok(await _benchmark.ListarBenchmark());
        }
        //metodo que devuelve un procesador por id
        [HttpGet("{id}")]
        public async Task<IActionResult> MostrarBenchmark(int id)
        {
            return Ok(await _benchmark.MostrarBenchmark(id));
        }
        //metodo que crea un procesador
        [HttpPost]
        public async Task<IActionResult> AgregarBenchmark([FromBody] Benchmark benchmark)
        {
            if (benchmark == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resgistro = await _benchmark.AgregarBenchmark(benchmark);
            return Created("Benchmarck agregado...", resgistro);
        }
        //metodo que actualiza un procesador
        [HttpPut]
        public async Task<IActionResult> ActualizarProcesador([FromBody] Benchmark benchmark)
        {
            if (benchmark == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resgistro = await _benchmark.ActualizarBenchmark(benchmark);
            return Created("benchmark actualizado...", resgistro);
        }
        //metodo que elimina un procesador
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarProcesador(int id)
        {
            var resgistro = Ok(await _benchmark.EliminarBenchmark(id));
            return Created("benchmark eliminado...", resgistro);
        }
    }
}
