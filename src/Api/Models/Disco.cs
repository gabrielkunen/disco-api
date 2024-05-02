namespace Api.Models
{
    public class Disco
    {
        public int Id { get; set; }
        public string NumeroCatalogo { get; set; }
        public string Titulo { get; set; }

        public int IdLabel { get; set; }
        public Label Label { get; set; }
        public List<Musica> Musicas { get; set; } = [];
        public List<Performer> Performers { get; set; } = [];
    }
}
