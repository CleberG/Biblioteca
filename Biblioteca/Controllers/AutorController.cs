using Biblioteca.AutorDto;
using Biblioteca.Models;
using Biblioteca.Services.Autores;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorService _autorInterface;

        public AutorController(IAutorService autorInterface)
        {
            _autorInterface = autorInterface;
        }

        [HttpGet("listar-autores")]
        public async Task<ActionResult<ResponseModel<List<Autor>>>> ListarAutores()
        {
            return Ok(await _autorInterface.ListarAutores());
        }

        [HttpGet("buscar-autor-por-id/{id}")]
        public async Task<ActionResult<ResponseModel<Autor>>> BuscarAutorPorId(int id)
        {
            return Ok(await _autorInterface.BuscarAutorPorId(id));
        }

        [HttpGet("buscar-autor-por-livroId/{livroId}")]
        public async Task<ActionResult<ResponseModel<Autor>>> BuscarAutorPorLivroId(int livroId)
        {
            return Ok(await _autorInterface.BuscarAutorPorLivroId(livroId));
        }

        [HttpPost("add")]
        public async Task<ActionResult<ResponseModel<Autor>>> CriarAutor(AutorCriacaoDto autorCriacaoDto)
        {
            return Ok(await _autorInterface.CriarAutor(autorCriacaoDto));
        }

        [HttpPut("editar-autor")]
        public async Task<ActionResult<ResponseModel<List<Autor>>>> EditarAutor(AutorCriacaoDto autorCriacaoDto)
        {
            var autores = await _autorInterface.EditarAutor(autorCriacaoDto);
            return Ok(autores);
        }

        [HttpDelete("remover-autor/{id}")]
        public async Task<ActionResult<ResponseModel<Autor>>> ExcluirAutor(int id)
        {
            return Ok(await _autorInterface.ExcluirAutor(id));
        }
    }
}
