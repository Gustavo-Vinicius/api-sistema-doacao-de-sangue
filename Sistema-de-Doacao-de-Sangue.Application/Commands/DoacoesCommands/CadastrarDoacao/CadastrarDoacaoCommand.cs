using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Sistema_de_Doacao_de_Sangue.Application.InputModels;

namespace Sistema_de_Doacao_de_Sangue.Application.Commands.DoacoesCommands.CadastrarDoacao
{
    public class CadastrarDoacaoCommand : IRequest<Unit>
    {
        public CadastrarDoacaoCommand(CadastrarDoacaoInputModels cadastrarDoacao)
        {
            CadastrarDoacao = cadastrarDoacao;
        }

        public CadastrarDoacaoInputModels CadastrarDoacao { get; set; }
    }
}