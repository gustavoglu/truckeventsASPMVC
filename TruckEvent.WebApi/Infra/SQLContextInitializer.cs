using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.Infra
{
    public class SQLContextInitializer : DropCreateDatabaseAlways<SQLContext>
    {
        protected override void Seed(SQLContext context)
        {
            //Produto_Cores
            List<Produto_Cor> Produto_CoresPadrao = new List<Produto_Cor>()
            {
                new Produto_Cor() { Cor = "#9d9a92", Descricao = "Cor 1", CriadoPor = "Admin", CriadoEm = DateTime.Now},
                new Produto_Cor() { Cor = "#dfc370", Descricao = "Cor 2", CriadoPor = "Admin", CriadoEm = DateTime.Now},
                new Produto_Cor() { Cor = "#718b7c", Descricao = "Cor 3", CriadoPor = "Admin", CriadoEm = DateTime.Now},
                new Produto_Cor() { Cor = "#c9cfd3", Descricao = "Cor 4", CriadoPor = "Admin", CriadoEm = DateTime.Now},
                new Produto_Cor() { Cor = "#6e4e60", Descricao = "Cor 5", CriadoPor = "Admin", CriadoEm = DateTime.Now},
                new Produto_Cor() { Cor = "#ffcccc", Descricao = "Cor 6", CriadoPor = "Admin", CriadoEm = DateTime.Now},
                new Produto_Cor() { Cor = "#404040", Descricao = "Cor 7", CriadoPor = "Admin", CriadoEm = DateTime.Now},
                new Produto_Cor() { Cor = "#b4eeb4", Descricao = "Cor 8", CriadoPor = "Admin", CriadoEm = DateTime.Now},
                new Produto_Cor() { Cor = "#ff4040", Descricao = "Cor 9", CriadoPor = "Admin", CriadoEm = DateTime.Now},
                new Produto_Cor() { Cor = "#990000", Descricao = "Cor 10", CriadoPor = "Admin" , CriadoEm = DateTime.Now},
                new Produto_Cor() { Cor = "#008000", Descricao = "Cor 11", CriadoPor = "Admin" , CriadoEm = DateTime.Now},
                new Produto_Cor() { Cor = "#440e68", Descricao = "Cor 12", CriadoPor = "Admin" , CriadoEm = DateTime.Now},
                new Produto_Cor() { Cor = "#008080", Descricao = "Cor 13", CriadoPor = "Admin" , CriadoEm = DateTime.Now},
                new Produto_Cor() { Cor = "#666666", Descricao = "Cor 14", CriadoPor = "Admin" , CriadoEm = DateTime.Now},
                new Produto_Cor() { Cor = "#003366", Descricao = "Cor 15", CriadoPor = "Admin" , CriadoEm = DateTime.Now},
                new Produto_Cor() { Cor = "#f6546a", Descricao = "Cor 16", CriadoPor = "Admin" , CriadoEm = DateTime.Now},
                new Produto_Cor() { Cor = "#7fffd4", Descricao = "Cor 17", CriadoPor = "Admin" , CriadoEm = DateTime.Now},
                new Produto_Cor() { Cor = "#ffd700", Descricao = "Cor 18", CriadoPor = "Admin" , CriadoEm = DateTime.Now},
                new Produto_Cor() { Cor = "#40e0d0", Descricao = "Cor 19", CriadoPor = "Admin" , CriadoEm = DateTime.Now},
                new Produto_Cor() { Cor = "#000000", Descricao = "Cor 20", CriadoPor = "Admin" , CriadoEm = DateTime.Now},
                new Produto_Cor() { Cor = "#84c539", Descricao = "Cor 21", CriadoPor = "Admin" , CriadoEm = DateTime.Now},
                new Produto_Cor() { Cor = "#fff68f", Descricao = "Cor 22", CriadoPor = "Admin" , CriadoEm = DateTime.Now},
                new Produto_Cor() { Cor = "#3399ff", Descricao = "Cor 23", CriadoPor = "Admin" , CriadoEm = DateTime.Now},
                new Produto_Cor() { Cor = "#6dc066", Descricao = "Cor 24", CriadoPor = "Admin" , CriadoEm = DateTime.Now},

            };
            foreach (var cor in Produto_CoresPadrao)
            {
                context.Produto_Cores.Add(cor);
            }

            //Pagamento Tipos
            List<Pagamento_Tipo> Pagamento_Tipos = new List<Pagamento_Tipo>()
            {
                new Pagamento_Tipo(){ Descricao = "Dinheiro" ,CriadoPor = "Admin", CriadoEm = DateTime.Now},
                new Pagamento_Tipo(){ Descricao = "Ficha" ,CriadoPor = "Admin", CriadoEm = DateTime.Now},
                new Pagamento_Tipo(){ Descricao = "Débito" ,CriadoPor = "Admin", CriadoEm = DateTime.Now},
                new Pagamento_Tipo(){ Descricao = "Crédito" ,CriadoPor = "Admin", CriadoEm = DateTime.Now},
                new Pagamento_Tipo(){ Descricao = "Alimentação" ,CriadoPor = "Admin", CriadoEm = DateTime.Now},
                new Pagamento_Tipo(){ Descricao = "Voucher" ,CriadoPor = "Admin", CriadoEm = DateTime.Now},
            };
            foreach (var tipo in Pagamento_Tipos)
            {
                context.Pagamento_Tipos.Add(tipo);
            }

            //Consequencias
            List<Consequencia> Consequencias = new List<Consequencia>()
            {
                new Consequencia(){Descricao = "Acrescenta no Valor" ,CriadoPor = "Admin", CriadoEm = DateTime.Now},
                new Consequencia(){Descricao = "Retira no Valor" ,CriadoPor = "Admin", CriadoEm = DateTime.Now},
                new Consequencia(){Descricao = "Nenhuma" ,CriadoPor = "Admin", CriadoEm = DateTime.Now}
            };
            foreach (var consequencia in Consequencias)
            {
                context.Consequencias.Add(consequencia);
            }

            //Produto_Tipos
            List<Produto_Tipo> Produto_Tipos = new List<Produto_Tipo>()
            {
                new Produto_Tipo(){Descricao = "Salgado" ,CriadoPor = "Admin", CriadoEm = DateTime.Now},
                new Produto_Tipo(){Descricao = "Doce" ,CriadoPor = "Admin", CriadoEm = DateTime.Now},
                 new Produto_Tipo(){Descricao = "Bebida" ,CriadoPor = "Admin", CriadoEm = DateTime.Now},
            };
            foreach (var tipo in Produto_Tipos)
            {
                context.Produto_Tipos.Add(tipo);
            }

            //Usuario_Tipos
            List<Usuario_Tipo> Usuario_Tipos = new List<Usuario_Tipo>()
            {
                new Usuario_Tipo(){Descricao = "Admin" ,CriadoPor = "Admin", CriadoEm = DateTime.Now, UserAdmin = true},
                new Usuario_Tipo(){Descricao = "Principal Loja" ,CriadoPor = "Admin", CriadoEm = DateTime.Now, UserPrincipal = true},
                new Usuario_Tipo(){Descricao = "Funcionario Loja" ,CriadoPor = "Admin", CriadoEm = DateTime.Now, UserPrincipal = false},
                new Usuario_Tipo(){Descricao = "Caixa do Organizador" ,CriadoPor = "Admin", CriadoEm = DateTime.Now},
                new Usuario_Tipo(){Descricao = "Organizador" ,CriadoPor = "Admin", CriadoEm = DateTime.Now, Organizador = true},
            };
            foreach (var tipo in Usuario_Tipos)
            {
                context.Usuario_Tipos.Add(tipo);
            }
            
            base.Seed(context);
            
        }
    }
}