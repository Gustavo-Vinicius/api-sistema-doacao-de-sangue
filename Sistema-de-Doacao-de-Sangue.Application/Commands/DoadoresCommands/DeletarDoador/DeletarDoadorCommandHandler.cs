using MediatR;
using Sistema_de_Doacao_de_Sangue.Core.Repositories;

namespace Sistema_de_Doacao_de_Sangue.Application.Commands.DoadoresCommands.DeletarDoador
{
    public class DeletarDoadorCommandHandler : IRequestHandler<DeletarDoadorCommand, Unit>
    {
        private readonly IDoadoresRepository _doadoresRepository;

        public DeletarDoadorCommandHandler(IDoadoresRepository doadoresRepository)
        {
            _doadoresRepository = doadoresRepository;
        }
        public async Task<Unit> Handle(DeletarDoadorCommand request, CancellationToken cancellationToken)
        {
            await _doadoresRepository.DeletarDoadorAsync(request.Id);

            return Unit.Value;
        }
    }
}