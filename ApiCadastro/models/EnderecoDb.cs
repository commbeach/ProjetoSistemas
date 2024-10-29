using Microsoft.EntityFrameworkCore;


namespace TodoApi.models{
    class EnderecoDb : DbContext
    {
        public EnderecoDb(DbContextOptions<EnderecoDb> options)
            : base(options) { }

        public DbSet<Endereco> Enderecos => Set<Endereco>();
    }
}