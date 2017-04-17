using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.Infra
{
    public class CreateDataBaseIni :  CreateDatabaseIfNotExists<SQLContext>
    {
        protected override void Seed(SQLContext context)
        {

            var usuarioTipodbSet = context.Set<Usuario_Tipo>();
            usuarioTipodbSet.Add(new Usuario_Tipo() { Descricao = "Admin", UserAdmin = true });
            usuarioTipodbSet.Add(new Usuario_Tipo() { Descricao = "Usuario Loja"});
            usuarioTipodbSet.Add(new Usuario_Tipo() { Descricao = "Principal Loja", UserAdmin = false, UserPrincipal = true });

            base.Seed(context);
        }
    }
}