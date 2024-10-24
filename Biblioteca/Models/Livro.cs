using Biblioteca.AutorDto;

namespace Biblioteca.Models
{
    public class Livro
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public Autor Autor { get; set; }

        public Livro(int id, string titulo)
        {
            Id = id;
            Titulo = titulo;
        }

        public void AddAutor(AutorCriacaoDto autor)
        {
            if(string.IsNullOrWhiteSpace(autor.Nome) && string.IsNullOrWhiteSpace(autor.Sobrenome))
            {
                Autor = new Autor()
                {
                    Nome = autor.Nome,
                    Sobrenome = autor.Sobrenome
                };
            }
            
        }
    }
}
