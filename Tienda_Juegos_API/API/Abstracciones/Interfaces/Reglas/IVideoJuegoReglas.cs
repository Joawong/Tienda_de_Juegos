using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.Reglas
{
    public interface IVideoJuegoReglas
    {
        // Devuelve la lista de errores encontrados; lista vacía = válido
        List<string> Validar(VideoJuego videoJuego);
    }
}
