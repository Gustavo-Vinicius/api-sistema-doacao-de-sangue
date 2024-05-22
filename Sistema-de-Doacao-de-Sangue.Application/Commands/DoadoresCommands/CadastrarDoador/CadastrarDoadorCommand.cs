using MediatR;
using Sistema_de_Doacao_de_Sangue.Application.InputModels;

namespace Sistema_de_Doacao_de_Sangue.Application.Command.DoadoresCommands.CadastrarDoador
{
    public class CadastrarDoadorCommand : IRequest<Unit>
    {
        public CadastrarDoadorCommand(CadastrarDoadorInputModels cadastrarDoador)
        {
            CadastrarDoador = cadastrarDoador;
        }

        public CadastrarDoadorInputModels CadastrarDoador { get; set; }
    }
}