using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.Models
{
    public class TokenEnvio : BaseEntity
    {
        public string Token { get; set; }

        public bool Ativo { get; set; }

        public DateTime ExpiraEm { get; set; }
    }
}