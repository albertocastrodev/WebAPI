using AlbertoWebApi.Entites.Enuns;

namespace AlbertoWebApi.Entites
{
    public class Telefone
    {
        public int Id { get; set; }

        public int DDD { get; set; }

        public string Numero { get; set; }

        public TelefoneTipoEnum Tipo { get; set; }

        public int PessoaId { get; set; }

        public Pessoa Pessoa { get; set; }
    }
}