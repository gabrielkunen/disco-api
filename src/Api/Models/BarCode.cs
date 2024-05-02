namespace Api.Models
{
    public class BarCode
    {
        public int Id { get; set; }
        public string Codigo { get; set; }

        public int IdDisco { get; set; }
        public Disco Disco { get; set; }
    }
}
