using appApi.Data;
using appApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace appApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProcesadorController : Controller
    {
        //declarar la variable global con el tipo de la interface
        private IProcesador _procesador;

        //inyectar constructor de la interface
        public ProcesadorController(IProcesador procesador)
        {
            _procesador = procesador;
        }
        //metodo que devuelve la lista de procesadores
        [HttpGet]
        public async Task<IActionResult> ListarProcesadores()
        {
            return Ok(await _procesador.ListarProcesadores());
        }
        //metodo que devuelve un procesador por id
        [HttpGet("{id}")]
        public async Task<IActionResult> MostrarProcesador(int id)
        {
            return Ok(await _procesador.MostrarProcesador(id));
        }
        //metodo que crea un procesador
        [HttpPost]
        public async Task<IActionResult> AgregarProcesador([FromBody] Procesador procesador)
        {
            if (procesador == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resgistro = await _procesador.AgregarProcesador(procesador);
            return Created("procesador agregado...", resgistro);
        }
        //metodo que actualiza un procesador
        [HttpPut]
        public async Task<IActionResult> ActualizarProcesador([FromBody] Procesador procesador)
        {
            if (procesador == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resgistro = await _procesador.ActualizarProcesador(procesador);
            return Created("procesador actualizado...", resgistro);
        }
        //metodo que elimina un procesador
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarProcesador(int id)
        {
            var resgistro = Ok(await _procesador.EliminarProcesador(id));
            return Created("procesador eliminado...", resgistro);
        }
    }
}
