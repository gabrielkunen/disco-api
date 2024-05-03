namespace Api.Models
{
    public class Cantor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Musica> Musicas { get; set; }
    }
}