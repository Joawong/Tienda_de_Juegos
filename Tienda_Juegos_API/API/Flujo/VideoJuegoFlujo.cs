using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flujo
{
    public class VideoJuegoFlujo : IVideoJuegoFlujo
    {
        private readonly IVideoJuegoDA _da;
        private readonly IVideoJuegoReglas _reglas;

        public VideoJuegoFlujo(IVideoJuegoDA da, IVideoJuegoReglas reglas)
        {
            _da = da;
            _reglas = reglas;
        }

        public Task<IEnumerable<VideoJuego>> ObtenerTodosAsync() => _da.ObtenerTodosAsync();

        public Task<VideoJuego?> ObtenerPorIdAsync(int id) => _da.ObtenerPorIdAsync(id);

        public async Task<(bool exito, List<string> errores, VideoJuego? resultado)> CrearAsync(VideoJuego videoJuego)
        {
            var errores = _reglas.Validar(videoJuego);
            if (errores.Count > 0) return (false, errores, null);

            var creado = await _da.CrearAsync(videoJuego);
            return (true, errores, creado);
        }

        public async Task<(bool exito, List<string> errores)> ActualizarAsync(VideoJuego videoJuego)
        {
            var errores = _reglas.Validar(videoJuego);
            if (errores.Count > 0) return (false, errores);

            var actualizado = await _da.ActualizarAsync(videoJuego);
            if (!actualizado) errores.Add($"No se encontró el videojuego con id {videoJuego.Id}.");

            return (actualizado, errores);
        }

        public Task<bool> EliminarAsync(int id) => _da.EliminarAsync(id);
    }
}
