namespace TruckEvent.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class confirmacaoSMSFicha : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.consequencia",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Descricao = c.String(maxLength: 250, unicode: false),
                        CriadoEm = c.DateTime(),
                        CriadoPor = c.String(maxLength: 250, unicode: false),
                        DeletadoEm = c.DateTime(),
                        DeletadoPor = c.String(maxLength: 250, unicode: false),
                        AtualizadoEm = c.DateTime(),
                        AtualizadoPor = c.String(maxLength: 250, unicode: false),
                        Deletado = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.produto_variacao",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Descricao = c.String(maxLength: 250, unicode: false),
                        Valor = c.Double(),
                        Id_consequencia = c.Guid(nullable: false),
                        Id_usuario = c.String(maxLength: 250, unicode: false),
                        CriadoEm = c.DateTime(),
                        CriadoPor = c.String(maxLength: 250, unicode: false),
                        DeletadoEm = c.DateTime(),
                        DeletadoPor = c.String(maxLength: 250, unicode: false),
                        AtualizadoEm = c.DateTime(),
                        AtualizadoPor = c.String(maxLength: 250, unicode: false),
                        Deletado = c.Boolean(),
                        Usuario_Id = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.consequencia", t => t.Id_consequencia)
                .ForeignKey("dbo.usuario", t => t.Usuario_Id)
                .Index(t => t.Id_consequencia)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.usuario",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 250, unicode: false),
                        Email = c.String(maxLength: 256, unicode: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(maxLength: 250, unicode: false),
                        SecurityStamp = c.String(maxLength: 250, unicode: false),
                        PhoneNumber = c.String(maxLength: 250, unicode: false),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256, unicode: false),
                        Nome = c.String(maxLength: 250, unicode: false),
                        Sobrenome = c.String(maxLength: 250, unicode: false),
                        RazaoSocial = c.String(maxLength: 250, unicode: false),
                        Telefone1 = c.String(maxLength: 250, unicode: false),
                        Telefone2 = c.String(maxLength: 250, unicode: false),
                        Documento = c.String(maxLength: 250, unicode: false),
                        DataNascimento = c.DateTime(),
                        UserAdmin = c.Boolean(),
                        UserPrincipal = c.Boolean(),
                        Organizador = c.Boolean(),
                        Id_usuario_tipo = c.Guid(),
                        Id_Usuario_Principal = c.String(maxLength: 250, unicode: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.usuario_tipo", t => t.Id_usuario_tipo)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Id_usuario_tipo);
            
            CreateTable(
                "dbo.usuario_claims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 250, unicode: false),
                        ClaimType = c.String(maxLength: 250, unicode: false),
                        ClaimValue = c.String(maxLength: 250, unicode: false),
                        IdentityUser_Id = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.usuario", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.evento",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Descricao = c.String(maxLength: 250, unicode: false),
                        DataInicio = c.DateTime(),
                        DataFim = c.DateTime(),
                        TotalValorVendido = c.Double(),
                        TotalProdutosVendidos = c.Int(),
                        Id_usuario_organizador = c.String(nullable: false, maxLength: 250, unicode: false),
                        CriadoEm = c.DateTime(),
                        CriadoPor = c.String(maxLength: 250, unicode: false),
                        DeletadoEm = c.DateTime(),
                        DeletadoPor = c.String(maxLength: 250, unicode: false),
                        AtualizadoEm = c.DateTime(),
                        AtualizadoPor = c.String(maxLength: 250, unicode: false),
                        Deletado = c.Boolean(),
                        id_evento = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.usuario", t => t.Id_usuario_organizador)
                .ForeignKey("dbo.evento_usuario", t => t.id_evento)
                .Index(t => t.Id_usuario_organizador)
                .Index(t => t.id_evento);
            
            CreateTable(
                "dbo.ficha",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Codigo = c.String(maxLength: 250, unicode: false),
                        NomeCliente = c.String(maxLength: 250, unicode: false),
                        TelefoneCliente = c.String(maxLength: 250, unicode: false),
                        EnviarConfirmacaoSMS = c.Boolean(),
                        Senha = c.Int(),
                        Saldo = c.Double(),
                        Id_Evento = c.Guid(nullable: false),
                        CriadoEm = c.DateTime(),
                        CriadoPor = c.String(maxLength: 250, unicode: false),
                        DeletadoEm = c.DateTime(),
                        DeletadoPor = c.String(maxLength: 250, unicode: false),
                        AtualizadoEm = c.DateTime(),
                        AtualizadoPor = c.String(maxLength: 250, unicode: false),
                        Deletado = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.evento", t => t.Id_Evento)
                .Index(t => t.Id_Evento);
            
            CreateTable(
                "dbo.venda",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Data = c.DateTime(),
                        TotalVenda = c.Double(),
                        Troco = c.Double(),
                        NomeCliente = c.String(maxLength: 250, unicode: false),
                        Cancelada = c.Boolean(nullable: false),
                        Id_evento = c.Guid(nullable: false),
                        CriadoEm = c.DateTime(),
                        CriadoPor = c.String(maxLength: 250, unicode: false),
                        DeletadoEm = c.DateTime(),
                        DeletadoPor = c.String(maxLength: 250, unicode: false),
                        AtualizadoEm = c.DateTime(),
                        AtualizadoPor = c.String(maxLength: 250, unicode: false),
                        Deletado = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.evento", t => t.Id_evento)
                .Index(t => t.Id_evento);
            
            CreateTable(
                "dbo.venda_pagamento",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Valor = c.Double(),
                        Id_venda = c.Guid(nullable: false),
                        Id_pagamento_tipo = c.Guid(nullable: false),
                        CriadoEm = c.DateTime(),
                        CriadoPor = c.String(maxLength: 250, unicode: false),
                        DeletadoEm = c.DateTime(),
                        DeletadoPor = c.String(maxLength: 250, unicode: false),
                        AtualizadoEm = c.DateTime(),
                        AtualizadoPor = c.String(maxLength: 250, unicode: false),
                        Deletado = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.pagamento_tipo", t => t.Id_pagamento_tipo)
                .ForeignKey("dbo.venda", t => t.Id_venda)
                .Index(t => t.Id_venda)
                .Index(t => t.Id_pagamento_tipo);
            
            CreateTable(
                "dbo.pagamento_tipo",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Descricao = c.String(maxLength: 250, unicode: false),
                        CriadoEm = c.DateTime(),
                        CriadoPor = c.String(maxLength: 250, unicode: false),
                        DeletadoEm = c.DateTime(),
                        DeletadoPor = c.String(maxLength: 250, unicode: false),
                        AtualizadoEm = c.DateTime(),
                        AtualizadoPor = c.String(maxLength: 250, unicode: false),
                        Deletado = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.venda_produto",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Id_produto = c.Guid(nullable: false),
                        Id_Venda = c.Guid(nullable: false),
                        Quantidade = c.Int(),
                        Total = c.Double(),
                        CriadoEm = c.DateTime(),
                        CriadoPor = c.String(maxLength: 250, unicode: false),
                        DeletadoEm = c.DateTime(),
                        DeletadoPor = c.String(maxLength: 250, unicode: false),
                        AtualizadoEm = c.DateTime(),
                        AtualizadoPor = c.String(maxLength: 250, unicode: false),
                        Deletado = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.produto", t => t.Id_produto)
                .ForeignKey("dbo.venda", t => t.Id_Venda)
                .Index(t => t.Id_produto)
                .Index(t => t.Id_Venda);
            
            CreateTable(
                "dbo.produto",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Descricao = c.String(maxLength: 250, unicode: false),
                        Valor = c.Double(),
                        Numero = c.Int(),
                        Id_produto_cor = c.Guid(nullable: false),
                        Id_produto_tipo = c.Guid(nullable: false),
                        CriadoEm = c.DateTime(),
                        CriadoPor = c.String(maxLength: 250, unicode: false),
                        DeletadoEm = c.DateTime(),
                        DeletadoPor = c.String(maxLength: 250, unicode: false),
                        AtualizadoEm = c.DateTime(),
                        AtualizadoPor = c.String(maxLength: 250, unicode: false),
                        Deletado = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.produto_cor", t => t.Id_produto_cor)
                .ForeignKey("dbo.produto_tipo", t => t.Id_produto_tipo)
                .Index(t => t.Id_produto_cor)
                .Index(t => t.Id_produto_tipo);
            
            CreateTable(
                "dbo.produto_cor",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Descricao = c.String(maxLength: 250, unicode: false),
                        Cor = c.String(maxLength: 250, unicode: false),
                        CriadoEm = c.DateTime(),
                        CriadoPor = c.String(maxLength: 250, unicode: false),
                        DeletadoEm = c.DateTime(),
                        DeletadoPor = c.String(maxLength: 250, unicode: false),
                        AtualizadoEm = c.DateTime(),
                        AtualizadoPor = c.String(maxLength: 250, unicode: false),
                        Deletado = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.produto_tipo",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Descricao = c.String(maxLength: 250, unicode: false),
                        CriadoEm = c.DateTime(),
                        CriadoPor = c.String(maxLength: 250, unicode: false),
                        DeletadoEm = c.DateTime(),
                        DeletadoPor = c.String(maxLength: 250, unicode: false),
                        AtualizadoEm = c.DateTime(),
                        AtualizadoPor = c.String(maxLength: 250, unicode: false),
                        Deletado = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.venda_produto_variacao",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Id_produto_variacao = c.Guid(nullable: false),
                        Id_venda_produto = c.Guid(nullable: false),
                        CriadoEm = c.DateTime(),
                        CriadoPor = c.String(maxLength: 250, unicode: false),
                        DeletadoEm = c.DateTime(),
                        DeletadoPor = c.String(maxLength: 250, unicode: false),
                        AtualizadoEm = c.DateTime(),
                        AtualizadoPor = c.String(maxLength: 250, unicode: false),
                        Deletado = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.produto_variacao", t => t.Id_produto_variacao)
                .ForeignKey("dbo.venda_produto", t => t.Id_venda_produto)
                .Index(t => t.Id_produto_variacao)
                .Index(t => t.Id_venda_produto);
            
            CreateTable(
                "dbo.usuario_login",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 250, unicode: false),
                        ProviderKey = c.String(nullable: false, maxLength: 250, unicode: false),
                        UserId = c.String(nullable: false, maxLength: 250, unicode: false),
                        IdentityUser_Id = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.usuario", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.usuario_regra",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 250, unicode: false),
                        RoleId = c.String(nullable: false, maxLength: 250, unicode: false),
                        IdentityUser_Id = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.regra", t => t.RoleId)
                .ForeignKey("dbo.usuario", t => t.IdentityUser_Id)
                .Index(t => t.RoleId)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.usuario_tipo",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Descricao = c.String(maxLength: 250, unicode: false),
                        UserAdmin = c.Boolean(),
                        UserPrincipal = c.Boolean(),
                        Organizador = c.Boolean(),
                        CriadoEm = c.DateTime(),
                        CriadoPor = c.String(maxLength: 250, unicode: false),
                        DeletadoEm = c.DateTime(),
                        DeletadoPor = c.String(maxLength: 250, unicode: false),
                        AtualizadoEm = c.DateTime(),
                        AtualizadoPor = c.String(maxLength: 250, unicode: false),
                        Deletado = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.evento_usuario",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Id_Usuario = c.String(maxLength: 250, unicode: false),
                        Id_Evento = c.Guid(),
                        UsuarioConfirmado = c.Boolean(),
                        CriadoEm = c.DateTime(),
                        CriadoPor = c.String(maxLength: 250, unicode: false),
                        DeletadoEm = c.DateTime(),
                        DeletadoPor = c.String(maxLength: 250, unicode: false),
                        AtualizadoEm = c.DateTime(),
                        AtualizadoPor = c.String(maxLength: 250, unicode: false),
                        Deletado = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.regra",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 250, unicode: false),
                        Name = c.String(nullable: false, maxLength: 256, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.usuario_regra", "IdentityUser_Id", "dbo.usuario");
            DropForeignKey("dbo.usuario_login", "IdentityUser_Id", "dbo.usuario");
            DropForeignKey("dbo.usuario_claims", "IdentityUser_Id", "dbo.usuario");
            DropForeignKey("dbo.usuario_regra", "RoleId", "dbo.regra");
            DropForeignKey("dbo.evento", "id_evento", "dbo.evento_usuario");
            DropForeignKey("dbo.produto_variacao", "Usuario_Id", "dbo.usuario");
            DropForeignKey("dbo.usuario", "Id_usuario_tipo", "dbo.usuario_tipo");
            DropForeignKey("dbo.venda_produto_variacao", "Id_venda_produto", "dbo.venda_produto");
            DropForeignKey("dbo.venda_produto_variacao", "Id_produto_variacao", "dbo.produto_variacao");
            DropForeignKey("dbo.venda_produto", "Id_Venda", "dbo.venda");
            DropForeignKey("dbo.venda_produto", "Id_produto", "dbo.produto");
            DropForeignKey("dbo.produto", "Id_produto_tipo", "dbo.produto_tipo");
            DropForeignKey("dbo.produto", "Id_produto_cor", "dbo.produto_cor");
            DropForeignKey("dbo.venda_pagamento", "Id_venda", "dbo.venda");
            DropForeignKey("dbo.venda_pagamento", "Id_pagamento_tipo", "dbo.pagamento_tipo");
            DropForeignKey("dbo.venda", "Id_evento", "dbo.evento");
            DropForeignKey("dbo.evento", "Id_usuario_organizador", "dbo.usuario");
            DropForeignKey("dbo.ficha", "Id_Evento", "dbo.evento");
            DropForeignKey("dbo.produto_variacao", "Id_consequencia", "dbo.consequencia");
            DropIndex("dbo.regra", "RoleNameIndex");
            DropIndex("dbo.usuario_regra", new[] { "IdentityUser_Id" });
            DropIndex("dbo.usuario_regra", new[] { "RoleId" });
            DropIndex("dbo.usuario_login", new[] { "IdentityUser_Id" });
            DropIndex("dbo.venda_produto_variacao", new[] { "Id_venda_produto" });
            DropIndex("dbo.venda_produto_variacao", new[] { "Id_produto_variacao" });
            DropIndex("dbo.produto", new[] { "Id_produto_tipo" });
            DropIndex("dbo.produto", new[] { "Id_produto_cor" });
            DropIndex("dbo.venda_produto", new[] { "Id_Venda" });
            DropIndex("dbo.venda_produto", new[] { "Id_produto" });
            DropIndex("dbo.venda_pagamento", new[] { "Id_pagamento_tipo" });
            DropIndex("dbo.venda_pagamento", new[] { "Id_venda" });
            DropIndex("dbo.venda", new[] { "Id_evento" });
            DropIndex("dbo.ficha", new[] { "Id_Evento" });
            DropIndex("dbo.evento", new[] { "id_evento" });
            DropIndex("dbo.evento", new[] { "Id_usuario_organizador" });
            DropIndex("dbo.usuario_claims", new[] { "IdentityUser_Id" });
            DropIndex("dbo.usuario", new[] { "Id_usuario_tipo" });
            DropIndex("dbo.usuario", "UserNameIndex");
            DropIndex("dbo.produto_variacao", new[] { "Usuario_Id" });
            DropIndex("dbo.produto_variacao", new[] { "Id_consequencia" });
            DropTable("dbo.regra");
            DropTable("dbo.evento_usuario");
            DropTable("dbo.usuario_tipo");
            DropTable("dbo.usuario_regra");
            DropTable("dbo.usuario_login");
            DropTable("dbo.venda_produto_variacao");
            DropTable("dbo.produto_tipo");
            DropTable("dbo.produto_cor");
            DropTable("dbo.produto");
            DropTable("dbo.venda_produto");
            DropTable("dbo.pagamento_tipo");
            DropTable("dbo.venda_pagamento");
            DropTable("dbo.venda");
            DropTable("dbo.ficha");
            DropTable("dbo.evento");
            DropTable("dbo.usuario_claims");
            DropTable("dbo.usuario");
            DropTable("dbo.produto_variacao");
            DropTable("dbo.consequencia");
        }
    }
}
