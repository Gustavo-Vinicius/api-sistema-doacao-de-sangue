using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema_de_Doacao_de_Sangue.Core.Entities;

namespace Sistema_de_Doacao_de_Sangue.Core.Interfaces.Services
{
    public interface ITokenService

    {
        string GenerateToken(User user);
    }
}