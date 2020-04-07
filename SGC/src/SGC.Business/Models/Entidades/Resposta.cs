namespace SGC.Business.Models.Entidades
{
    public class Resposta : Entity
    {
        public long PerguntaId { get; set; }
        public string Descricao { get; set; }

        public Pergunta Pergunta { get; set; }
    }
}