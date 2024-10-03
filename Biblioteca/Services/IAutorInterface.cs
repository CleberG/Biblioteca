using Biblioteca.Models;

namespace Biblioteca.Services
{
    public interface IAutorInterface
    {
        Task<ResponseModel<List<Autor>>> ListarAutores();

        Task<ResponseModel<Autor>> BuscarAutorPorId(int id);

        Task<ResponseModel<Autor>> BuscarAutorPorLivroId(int livroId);
    }
}
