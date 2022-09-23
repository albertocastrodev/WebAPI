using AlbertoWebApi.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlbertoWebApi.Data.Configuration
{
    public class TelefoneConfiguration : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.HasOne(c => c.Pessoa)
                .WithMany(c => c.Telefones)
                .HasForeignKey(c => c.PessoaId);
        }
    }
}
