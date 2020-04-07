namespace SGC.Business.Models.Entidades
{
    public class Pergunta : Entity
    {
        public string Descricao { get; set; }
        public Resposta Resposta { get; set; }
        public long CategoriaId { get; set; }
        public string OperadorId { get; set; }
    }
}