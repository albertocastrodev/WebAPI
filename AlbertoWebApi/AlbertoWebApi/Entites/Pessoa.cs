namespace AlbertoWebApi.Entites
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public int Idade { get; set; }

        public int DepartamentoId { get; set; }

        public virtual Departamento Departamento { get; set; }

        public int EnderecoId { get; set; }

        public virtual Endereco Endereco { get; set; }
    }
}