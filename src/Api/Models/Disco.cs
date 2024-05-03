using Api.Enums;

namespace Api.Models
{
    public class Disco
    {
        public int Id { get; set; }
        public string NumeroCatalogo { get; set; }
        public string Titulo { get; set; }
        public DateTime DataLancamento { get; set; }
        public int PrecoLancamento { get; set; }
        public ETipoMedia TipoMedia { get; set; }

        public int IdLabel { get; set; }
        public Label Label { get; set; }

        public BarCode BarCode { get; set; }

        public List<Musica> Musicas { get; set; } = [];
    }
}
