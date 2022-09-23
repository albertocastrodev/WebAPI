namespace AlbertoWebApi.DTO
{
    public class PessoaRequestDTO
    {
        public int Id { get; set; }
     
        public string Nome { get; set; }

        public int Idade { get; set; }

        public int DepartamentoId { get; set; }


        public int EnderecoId { get; set; }

        public int TelefoneId { get; set; } 
    }
}
