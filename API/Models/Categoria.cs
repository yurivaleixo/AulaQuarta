using System;

namespace API.Models
{
    public class Categoria
    {
        //Construtor
        public Categoria() => CriadoEm = DateTime.Now;

        //Atributos
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime CriadoEm { get; set; }

       // public List<Produto> Categorias { get; set }

    }
}