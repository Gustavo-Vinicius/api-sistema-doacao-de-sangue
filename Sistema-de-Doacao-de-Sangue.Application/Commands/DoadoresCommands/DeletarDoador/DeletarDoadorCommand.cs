using MediatR;

namespace Sistema_de_Doacao_de_Sangue.Application.Commands.DoadoresCommands.DeletarDoador
{
    public class DeletarDoadorCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}