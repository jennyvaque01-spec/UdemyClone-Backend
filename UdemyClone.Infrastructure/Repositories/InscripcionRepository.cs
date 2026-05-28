using Microsoft.EntityFrameworkCore;
using UdemyClone.Domain.Database;
using UdemyClone.Domain.Entities;
using UdemyClone.Domain.Interfaces;

namespace UdemyClone.Infrastructure.Repositories
{
    public class InscripcionRepository(UdemyCloneContext context) : IInscripcionRepository
    {
        public async Task<List<Inscripcion>> GetByEstudiante(int estudianteId)
            => await context.Inscripciones
                .Include(i => i.Estudiante)
                .Include(i => i.Curso)
                .Where(i => i.EstudianteId == estudianteId).ToListAsync();

        public async Task<Inscripcion?> GetById(int id)
            => await context.Inscripciones
                .Include(i => i.Estudiante)
                .Include(i => i.Curso)
                .FirstOrDefaultAsync(i => i.InscripcionId == id);

        public async Task<Inscripcion> Create(Inscripcion inscripcion)
        {
            context.Inscripciones.Add(inscripcion);
            await context.SaveChangesAsync();
            return inscripcion;
        }

        public async Task<bool> Delete(int id)
        {
            var insc = await context.Inscripciones.FindAsync(id);
            if (insc is null) return false;
            context.Inscripciones.Remove(insc);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> YaInscrito(int estudianteId, int cursoId)
            => await context.Inscripciones
                .AnyAsync(i => i.EstudianteId == estudianteId && i.CursoId == cursoId);
    }
}

