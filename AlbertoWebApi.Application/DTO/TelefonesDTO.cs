using AlbertoWebApi.Entites.Enuns;

namespace AlbertoWebApi.DTO
{
    public class TelefoneDTO
    {
        public int Id { get; set; }

        public int DDD { get; set; }

        public string Numero { get; set; }

        public TelefoneTipoEnum Tipo { get; set; }
    }
}

