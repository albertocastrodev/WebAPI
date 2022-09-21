namespace AlbertoWebApi.DTO
{
    public class PessoaResponseDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public int Idade { get; set; }

        public int DepartamentoId { get; set; }

        public DepartamentoDTO Departamento { get; set; }


        public int EnderecoId { get; set; }

        public  EnderecoDTO Endereco { get; set; }
    }
}
