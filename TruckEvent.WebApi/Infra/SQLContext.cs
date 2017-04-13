using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

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
        
    }
}