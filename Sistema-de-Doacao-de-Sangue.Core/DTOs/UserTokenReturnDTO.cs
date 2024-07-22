using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Doacao_de_Sangue.Core.DTOs
{
    public class UserTokenReturnDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}