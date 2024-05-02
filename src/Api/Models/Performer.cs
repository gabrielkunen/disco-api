namespace Api.Models
{
    public class Performer
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Disco> Discos { get; set; } = [];
    }
}
