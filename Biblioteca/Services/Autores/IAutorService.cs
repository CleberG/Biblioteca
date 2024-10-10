using Biblioteca.AutorDto;
using Biblioteca.Models;

namespace Biblioteca.Services.Autores
{
    public interface IAutorService
    {
        Task<ResponseModel<List<Autor>>> ListarAutores();

        Task<ResponseModel<Autor>> BuscarAutorPorId(int id);

        Task<ResponseModel<Autor>> BuscarAutorPorLivroId(int livroId);

        Task<ResponseModel<List<Autor>>> CriarAutor(AutorCriacaoDto autorCriacaoDto);

        Task<ResponseModel<List<Autor>>> EditarAutor(AutorCriacaoDto autorCriacaoDto);

        Task<ResponseModel<List<Autor>>> ExcluirAutor(int id);

    }
}
