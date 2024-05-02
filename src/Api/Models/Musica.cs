namespace Api.Models
{
    public class Musica
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public int IdDisco { get; set; }
        public Disco Disco { get; set; }
    }
}
