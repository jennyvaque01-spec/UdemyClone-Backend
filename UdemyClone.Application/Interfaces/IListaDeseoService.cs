using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyClone.Application.Models.DTOs;
using UdemyClone.Application.Models.Requests.Estudiante;

namespace UdemyClone.Application.Interfaces
{
    public interface IListaDeseoService
    {
        Task<List<ListaDeseoDto>> GetByEstudiante(int estudianteId);
        Task<ListaDeseoDto> Create(CreateListaDeseoRequest model);
        Task<bool> Delete(int cursoId, int estudianteId);;
    }
}
