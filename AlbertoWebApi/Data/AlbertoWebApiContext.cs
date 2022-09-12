using AlbertoWebApi.Entites;
using Microsoft.EntityFrameworkCore;

namespace AlbertoWebApi.Data
{
    public class AlbertoWebApiContext : DbContext
    {
        //Configurações de acesso ao banco ---

        public AlbertoWebApiContext(DbContextOptions<AlbertoWebApiContext> options) : base(options)

        {
        

        }

        //Refencia da classe como tabela

        public DbSet<Pessoa> Pessoas { get; set; }


    }





}
