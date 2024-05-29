using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Sistema_de_Doacao_de_Sangue.Core.DTOs;

namespace Sistema_de_Doacao_de_Sangue.Application.Commands.DoadoresCommands.EditarDoador
{
    public class EditarDoadorCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public DoadorDTO doadorDTO { get; set; }
    }
}