namespace Api.Models
{
    public class Label
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Regiao { get; set; }
        public string Descricao { get; set; }

        public ICollection<Disco> Discos { get; set; } = [];
    }
}
