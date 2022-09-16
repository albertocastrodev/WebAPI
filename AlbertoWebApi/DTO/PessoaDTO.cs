namespace AlbertoWebApi.DTO
{
    public class PessoaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public int Idade { get; set; }

        public int DepartamentoId { get; set; }

        public DepartamentoDTO Departamento { get; set; }
    }
}
