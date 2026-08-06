using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideoJuegosController : ControllerBase
    {
        private readonly IVideoJuegoServicio _servicio;

        public VideoJuegosController(IVideoJuegoServicio servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VideoJuego>>> GetAll()
        {
            var juegos = await _servicio.ObtenerTodosAsync();
            return Ok(juegos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VideoJuego>> GetById(int id)
        {
            var juego = await _servicio.ObtenerPorIdAsync(id);
            if (juego == null) return NotFound(new { mensaje = $"No se encontró el videojuego con id {id}" });
            return Ok(juego);
        }

        [HttpPost]
        public async Task<ActionResult<VideoJuego>> Create([FromBody] VideoJuego videoJuego)
        {
            var (exito, errores, resultado) = await _servicio.CrearAsync(videoJuego);
            if (!exito) return BadRequest(new { errores });

            return CreatedAtAction(nameof(GetById), new { id = resultado!.Id }, resultado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] VideoJuego videoJuego)
        {
            if (id != videoJuego.Id) return BadRequest(new { mensaje = "El id no coincide" });

            var (exito, errores) = await _servicio.ActualizarAsync(videoJuego);
            if (!exito) return BadRequest(new { errores });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _servicio.EliminarAsync(id);
            if (!eliminado) return NotFound(new { mensaje = $"No se encontró el videojuego con id {id}" });

            return NoContent();
        }
    }
}
