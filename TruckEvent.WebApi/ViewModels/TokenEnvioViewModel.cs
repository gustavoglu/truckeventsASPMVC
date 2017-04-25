using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.ViewModels
{
    public class TokenEnvioViewModel
    {
        public TokenEnvioViewModel()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Token { get; set; }

        public bool Ativo { get; set; }

        public DateTime ExpiraEm { get; set; }

    }
}