using AlbertoWebApi.Application.Interfaces;
using AlbertoWebApi.DTO;
using AlbertoWebApi.Entites;
using AlbertoWebApi.Infra.Interfaces;

namespace AlbertoWebApi.Application.Applications
{
    public class PessoaAplication : IPessoaApplication
    {
        private readonly IPessoaRepository _pessoaRepository;
        public PessoaAplication(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public void Delete(int id)
        {
            var pessoa = _pessoaRepository.GetById(id);
            _pessoaRepository.Delete(pessoa);
        }

        public List<PessoaResponseDTO> GetAll()
        {
            return _pessoaRepository.GetAll().Select(pessoa => new PessoaResponseDTO
            {
                Nome = pessoa.Nome,
                Idade = pessoa.Idade,
                Id = pessoa.Id,

                Departamento = new DepartamentoDTO
                {
                    Nome = pessoa.Departamento?.Nome,
                    Id = pessoa.DepartamentoId
                },

                Endereco = new EnderecoDTO
                {
                    Logradouro = pessoa?.Enderecos?.FirstOrDefault()?.Logradouro,
                    Numero = pessoa?.Enderecos?.FirstOrDefault()?.Numero,
                    Bairro = pessoa?.Enderecos?.FirstOrDefault()?.Bairro,
                    Cidade = pessoa?.Enderecos?.FirstOrDefault()?.Cidade,
                    Cep = pessoa?.Enderecos?.FirstOrDefault()?.Cep,
                    UF = pessoa?.Enderecos?.FirstOrDefault()?.UF
                },

                Telefones = new TelefoneDTO
                {
                    Id = pessoa.Telefones != null && pessoa.Telefones.Count >0 ? pessoa.Telefones.FirstOrDefault().Id:0,
                    Tipo = pessoa.Telefones != null && pessoa.Telefones.Count > 0 ? pessoa.Telefones.FirstOrDefault().Tipo : 0,
                    DDD = pessoa.Telefones != null && pessoa.Telefones.Count > 0 ? pessoa.Telefones.FirstOrDefault().DDD : 0,
                    Numero = pessoa?.Telefones?.FirstOrDefault()?.Numero
                }
            }).ToList(); 
        }

        public void Insert(PessoaRequestDTO pessoaRequestDTO)
        {
            var pessoa = new Pessoa
            {
                Idade = pessoaRequestDTO.Idade,
                Nome = pessoaRequestDTO.Nome,
                EnderecoId = pessoaRequestDTO.EnderecoId,
                DepartamentoId = pessoaRequestDTO.DepartamentoId,
                TelefonesId = pessoaRequestDTO.TelefoneId,
            };

           _pessoaRepository.Insert(pessoa);
        }

        public void Update(PessoaRequestDTO pessoaDTO)
        {
            var pessoaASerAlterada = _pessoaRepository.GetById(pessoaDTO.Id);
            pessoaASerAlterada.Nome = pessoaDTO.Nome;
            pessoaASerAlterada.Idade = pessoaDTO.Idade;
            pessoaASerAlterada.EnderecoId = pessoaDTO.DepartamentoId;
            pessoaASerAlterada.DepartamentoId = pessoaDTO.DepartamentoId;
            pessoaASerAlterada.TelefonesId = pessoaDTO.DepartamentoId;
            _pessoaRepository.Update(pessoaASerAlterada);
        }
    }
}
