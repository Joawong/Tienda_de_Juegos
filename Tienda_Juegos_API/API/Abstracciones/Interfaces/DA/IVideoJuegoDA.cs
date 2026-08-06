using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.DA
{
    public interface IVideoJuegoDA
    {
        Task<IEnumerable<VideoJuego>> ObtenerTodosAsync();
        Task<VideoJuego?> ObtenerPorIdAsync(int id);
        Task<VideoJuego> CrearAsync(VideoJuego videoJuego);
        Task<bool> ActualizarAsync(VideoJuego videoJuego);
        Task<bool> EliminarAsync(int id);
    }
}
