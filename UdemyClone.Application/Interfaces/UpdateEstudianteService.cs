using UdemyClone.Application.Models.Requests.Estudiante;

namespace UdemyClone.Application.Interfaces
{
    public interface UpdateEstudianteService
    {
        Task<bool> CreateEstudianteAsync(CreateEstudianteRequest request);
    }
}
