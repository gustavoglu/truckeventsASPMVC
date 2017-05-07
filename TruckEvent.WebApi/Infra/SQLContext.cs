using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;
using System.Data.Entity;
using TruckEvent.WebApi.Infra.EntityConfig;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TruckEvent.WebApi.Infra
{
    public class SQLContext : IdentityDbContext<Usuario>
    {

        public SQLContext() : base("SQLAzureHomlogacao", throwIfV1Schema: false)
        {
        }

        public DbSet<Consequencia> Consequencias { get; set; }
        public DbSet<Evento_Usuario> Evento_Usuarios { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Ficha> Fichas { get; set; }
        public DbSet<Pagamento_Tipo> Pagamento_Tipos { get; set; }
        public DbSet<Produto_Cor> Produto_Cores { get; set; }
        public DbSet<Produto_Tipo> Produto_Tipos { get; set; }
        public DbSet<Produto_Variacao> Produto_Variacoes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario_Tipo> Usuario_Tipos { get; set; }
        public DbSet<Venda_Pagamento> Venda_Pagamentos { get; set; }
        public DbSet<Venda_Produto_Variacao> Venda_Produto_Variacoes { get; set; }
        public DbSet<Venda_Produto> Venda_Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Ficha_Produto> Ficha_Produtos { get; set; }
        public DbSet<TokenEnvio> TokenEnvios { get; set; }

        public static SQLContext Create()
        {
            return new SQLContext();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Remove Conventions
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //Configura nomes e campos de tabelas padroes identity
            modelBuilder.Entity<IdentityUser>().ToTable("usuario").Property(u => u.Id).HasColumnName("id");
            modelBuilder.Entity<Usuario>().ToTable("usuario").Property(u => u.Id).HasColumnName("id");
            modelBuilder.Entity<IdentityUserRole>().ToTable("usuario_regra");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("usuario_login");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("usuario_claims");
            modelBuilder.Entity<IdentityRole>().ToTable("regra");



            //Configura entitys
            modelBuilder.Configurations.Add(new EventoEntityConfig());

            modelBuilder.Entity<Usuario>()
                .HasOptional(u => u.Usuario_Organizador)
                .WithMany(uu => uu.Caixas)
                .HasForeignKey(u => u.id_usuario_organizador);

            modelBuilder.Entity<Usuario>()
                .HasOptional(u => u.Usuario_Principal)
                .WithMany(uu => uu.Lojas)
                .HasForeignKey(u => u.Id_Usuario_Principal);

            modelBuilder.Configurations.Add(new VendaEntityConfig());
            modelBuilder.Configurations.Add(new Usuario_TipoEntityConfig());
            modelBuilder.Configurations.Add(new ConsequenciaEntityConfig());
            modelBuilder.Configurations.Add(new Evento_UsuarioEntityConfig());

            modelBuilder.Configurations.Add(new FichaEntityConfig());
            modelBuilder.Configurations.Add(new Pagamento_TipoEntityConfig());
            modelBuilder.Configurations.Add(new Produto_CorEntityConfig());
            modelBuilder.Configurations.Add(new Produto_TipoEntityConfig());
            modelBuilder.Configurations.Add(new Produto_VariacaoEntityConfig());
            modelBuilder.Configurations.Add(new ProdutoEntityConfig());
            modelBuilder.Configurations.Add(new Venda_PagamentoEntityConfig());
            modelBuilder.Configurations.Add(new Venda_Produto_VariacaoEntityConfig());
            modelBuilder.Configurations.Add(new Venda_ProdutoEntityConfig());
           
            modelBuilder.Configurations.Add(new Ficha_ProdutoEntityConfig());
            modelBuilder.Configurations.Add(new TokenEnvioEntityConfig());

            //Configura Tamanho de strings e tipo
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(250));
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));


        }

        public override int SaveChanges()
        {

            var Criados = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity && e.State == EntityState.Added);

            var Atualizados = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity && e.State == EntityState.Modified);

            if (Criados.Any())
            {
                foreach (var item in Criados)
                {

                    if (!((BaseEntity)item.Entity).Id.HasValue)
                    {
                        ((BaseEntity)item.Entity).Id = Guid.NewGuid();
                    }
                    
                    ((BaseEntity)item.Entity).CriadoEm = DateTime.Now;
                    ((BaseEntity)item.Entity).Deletado = false;

                    // Utilizado Try para não dar erro ao utilizar o Seed para adicionar entitys no banco
                    try
                    {
                        if (HttpContext.Current.User.Identity.IsAuthenticated)
                        {
                            ((BaseEntity)item.Entity).CriadoPor = HttpContext.Current.User.Identity.Name ?? null;
                        }
                    }
                    catch { }
                }

            }

            if (Atualizados.Any())
            {
                foreach (var item in Atualizados)
                {
                    ((BaseEntity)item.Entity).AtualizadoEm = DateTime.Now;

                    // Utilizado Try para não dar erro ao utilizar o Seed para adicionar entitys no banco
                    try
                    {
                        if (HttpContext.Current.User.Identity.IsAuthenticated)
                        {
                            ((BaseEntity)item.Entity).AtualizadoPor = null;
                        }
                    }
                    catch { }

                }
            }

            return base.SaveChanges();

        }

    }
}