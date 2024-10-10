using Biblioteca.AutorDto;
using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Services.Autores
{
    public class AutorService : IAutorService
    {
        private readonly AppDbContext _context;

        public AutorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<Autor>> BuscarAutorPorId(int id)
        {
            var response = new ResponseModel<Autor>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(x => x.Id == id);
                if (autor == null)
                {
                    response.Mensagem = "nenhum autor foi encontrado.";
                    return response;
                }
                response.Dados = autor;
                response.Mensagem = "Autor Localizado.";

                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<Autor>> BuscarAutorPorLivroId(int livroId)
        {
            var response = new ResponseModel<Autor>();

            try
            {
                var autor = await _context.Livros
                    .Include(inlude => inlude.Autor)
                    .Select(s => s.Autor)
                    .FirstOrDefaultAsync(x => x.Id == livroId);
                if (autor == null)
                {
                    response.Mensagem = "nenhum autor foi encontrado.";
                    return response;
                }
                response.Dados = autor;
                response.Mensagem = "Autor Localizado.";

                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<Autor>>> CriarAutor(AutorCriacaoDto autorCriacaoDto)
        {
            var response = new ResponseModel<List<Autor>>();
            try
            {
                var autor = new Autor()
                {
                    Nome = autorCriacaoDto.Nome,
                    Sobrenome = autorCriacaoDto.Sobrenome
                };
                _context.Add(autor);
                await _context.SaveChangesAsync();
                var autores = await _context.Autores.ToListAsync();
                response.Dados = autores;
                response.Mensagem = "Autor criado com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<Autor>>> EditarAutor(AutorCriacaoDto autorCriacaoDto)
        {
            var response = new ResponseModel<List<Autor>>();
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(f => f.Id == autorCriacaoDto.Id);
                if (autor == null)
                {
                    response.Mensagem = "Nenhum autor foi encontrado";
                    response.Status = false;
                    return response;
                }

                autor.Nome = autorCriacaoDto.Nome;
                autor.Sobrenome = autorCriacaoDto.Sobrenome;

                _context.Autores.Update(autor);

                await _context.SaveChangesAsync();
                var autores = await _context.Autores.ToListAsync();
                response.Dados = autores;
                response.Mensagem = "Autor alterado com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }

        }

        public async Task<ResponseModel<List<Autor>>> ExcluirAutor(int id)
        {
            var response = new ResponseModel<List<Autor>>();
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(f => f.Id == id);
                if (autor == null)
                {
                    response.Mensagem = "Nenhum autor foi encontrado";
                    response.Status = false;
                    return response;
                }

                _context.Autores.Remove(autor);
                await _context.SaveChangesAsync();

                var autores = await _context.Autores.ToListAsync();
                response.Dados = autores;
                response.Mensagem = "Autor excluido com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<Autor>>> ListarAutores()
        {
            var response = new ResponseModel<List<Autor>>();
            try
            {
                var autores = await _context.Autores.ToListAsync();
                response.Dados = autores;
                response.Mensagem = "Todos os autores foram coletados";
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
