using Biblioteca.AutorDto;
using Biblioteca.Models;

namespace Biblioteca.Services.Livros
{
    public class LivroService : ILivroService
    {
        public async Task<ResponseModel<Livro>> CriarLivro(LivroDto livroDto)
        {

        }

        public async Task<ResponseModel<Livro>> Editar(LivroDto livroDto)
        {

        }

        public async Task<ResponseModel<List<Livro>>> BuscarLivroPorId(LivroDto livroDto)
        {

        }

        public async Task<ResponseModel<List<Livro>>> BuscarLivroPorAutorId(LivroDto livroDto)
        {

        }

        public async Task<ResponseModel<List<Livro>>> ExcluirLivro(LivroDto livroDto)
        {

        }

    }
}
