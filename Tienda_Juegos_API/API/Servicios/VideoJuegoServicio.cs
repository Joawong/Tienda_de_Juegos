using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class VideoJuegoServicio : IVideoJuegoServicio
    {
        private readonly IVideoJuegoFlujo _flujo;

        public VideoJuegoServicio(IVideoJuegoFlujo flujo)
        {
            _flujo = flujo;
        }

        public Task<IEnumerable<VideoJuego>> ObtenerTodosAsync() => _flujo.ObtenerTodosAsync();
        public Task<VideoJuego?> ObtenerPorIdAsync(int id) => _flujo.ObtenerPorIdAsync(id);
        public Task<(bool exito, List<string> errores, VideoJuego? resultado)> CrearAsync(VideoJuego videoJuego) => _flujo.CrearAsync(videoJuego);
        public Task<(bool exito, List<string> errores)> ActualizarAsync(VideoJuego videoJuego) => _flujo.ActualizarAsync(videoJuego);
        public Task<bool> EliminarAsync(int id) => _flujo.EliminarAsync(id);
    }
}
