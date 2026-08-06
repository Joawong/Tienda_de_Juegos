using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.Servicios
{
    public interface IVideoJuegoServicio
    {
        Task<IEnumerable<VideoJuego>> ObtenerTodosAsync();
        Task<VideoJuego?> ObtenerPorIdAsync(int id);
        Task<(bool exito, List<string> errores, VideoJuego? resultado)> CrearAsync(VideoJuego videoJuego);
        Task<(bool exito, List<string> errores)> ActualizarAsync(VideoJuego videoJuego);
        Task<bool> EliminarAsync(int id);
    }
}
