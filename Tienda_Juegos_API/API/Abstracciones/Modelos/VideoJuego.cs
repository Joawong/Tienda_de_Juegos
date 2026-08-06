using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class VideoJuego
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Plataforma { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public DateTime FechaLanzamiento { get; set; }
    }
}
