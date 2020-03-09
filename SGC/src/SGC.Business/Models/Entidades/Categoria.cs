namespace SGC.Business.Models.Entidades
{

    //TODO: CLASSE BASE ADICIONAR OPERADOR!
    public class Categoria : Entity
    {
        public string OperadorId { get; set; }
        public string DescricaoCategoria { get; set; }
        public string NomeCategoria { get; set; }

    }
}