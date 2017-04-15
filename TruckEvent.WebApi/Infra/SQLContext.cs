using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;
using System.Data.Entity;
using TruckEvent.WebApi.Infra.EntityConfig;

namespace TruckEvent.WebApi.Infra
{
    public class SQLContext : IdentityDbContext<Usuario>
    {
       
            public SQLContext()
                : base("DefaultConnection", throwIfV1Schema: false)
            {
            }

            public static SQLContext Create()
            {
                return new SQLContext();
            }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Properties<string>().Configure( p => p.HasMaxLength(250));

            modelBuilder.Entity<Usuario>().HasRequired(u => u.Tipo).WithMany(ut => ut.Usuarios).HasForeignKey(u => u.Id_usuario_tipo);

            //Configura nomes e campos de tabelas padroes identity
            modelBuilder.Entity<IdentityUser>().ToTable("usuario").Property(u => u.Id).HasColumnName("id");
            modelBuilder.Entity<Usuario>().ToTable("usuario").Property(u => u.Id).HasColumnName("id");
            modelBuilder.Entity<IdentityUserRole>().ToTable("usuario_regra");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("usuario_login");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("usuario_claims");
            modelBuilder.Entity<IdentityRole>().ToTable("regra");

            //Configura entitys
            modelBuilder.Configurations.Add(new ConsequenciaEntityConfig());
            modelBuilder.Configurations.Add(new Evento_UsuarioEntityConfig());
            modelBuilder.Configurations.Add(new EventoEntityConfig());
            modelBuilder.Configurations.Add(new FichaEntityConfig());
            modelBuilder.Configurations.Add(new Pagamento_TipoEntityConfig());
            modelBuilder.Configurations.Add(new Produto_CorEntityConfig());
            modelBuilder.Configurations.Add(new Produto_TipoEntityConfig());
            modelBuilder.Configurations.Add(new Produto_VariacaoEntityConfig());
            modelBuilder.Configurations.Add(new ProdutoEntityConfig());
            modelBuilder.Configurations.Add(new Usuario_TipoEntityConfig());
            modelBuilder.Configurations.Add(new VariacaoEntityConfig());
            modelBuilder.Configurations.Add(new Venda_PagamentoEntityConfig());
            modelBuilder.Configurations.Add(new Venda_Produto_VariacaoEntityConfig());
            modelBuilder.Configurations.Add(new Venda_ProdutoEntityConfig());
            modelBuilder.Configurations.Add(new VendaEntityConfig());


            base.OnModelCreating(modelBuilder);



        }


    }
}