using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reglas
{
    public class VideoJuegoReglas : IVideoJuegoReglas
    {
        public List<string> Validar(VideoJuego videoJuego)
        {
            var errores = new List<string>();

            if (string.IsNullOrWhiteSpace(videoJuego.Titulo))
                errores.Add("El título es obligatorio.");

            if (string.IsNullOrWhiteSpace(videoJuego.Plataforma))
                errores.Add("La plataforma es obligatoria.");

            if (videoJuego.Precio <= 0)
                errores.Add("El precio debe ser mayor a 0.");

            if (videoJuego.Stock < 0)
                errores.Add("El stock no puede ser negativo.");

            return errores;
        }
    }
}
