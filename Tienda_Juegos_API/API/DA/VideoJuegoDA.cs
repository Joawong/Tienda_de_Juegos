using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class VideoJuegoDA : IVideoJuegoDA
    {
        private readonly TiendaDbContext _context;

        public VideoJuegoDA(TiendaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VideoJuego>> ObtenerTodosAsync() =>
            await _context.VideoJuegos.ToListAsync();

        public async Task<VideoJuego?> ObtenerPorIdAsync(int id) =>
            await _context.VideoJuegos.FindAsync(id);

        public async Task<VideoJuego> CrearAsync(VideoJuego videoJuego)
        {
            _context.VideoJuegos.Add(videoJuego);
            await _context.SaveChangesAsync();
            return videoJuego;
        }

        public async Task<bool> ActualizarAsync(VideoJuego videoJuego)
        {
            var existente = await _context.VideoJuegos.FindAsync(videoJuego.Id);
            if (existente == null) return false;

            existente.Titulo = videoJuego.Titulo;
            existente.Plataforma = videoJuego.Plataforma;
            existente.Genero = videoJuego.Genero;
            existente.Precio = videoJuego.Precio;
            existente.Stock = videoJuego.Stock;
            existente.FechaLanzamiento = videoJuego.FechaLanzamiento;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var videoJuego = await _context.VideoJuegos.FindAsync(id);
            if (videoJuego == null) return false;

            _context.VideoJuegos.Remove(videoJuego);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
