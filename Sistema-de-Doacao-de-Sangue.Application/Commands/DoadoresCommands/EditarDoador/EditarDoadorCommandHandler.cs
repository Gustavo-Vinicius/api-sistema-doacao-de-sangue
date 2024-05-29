using MediatR;
using Sistema_de_Doacao_de_Sangue.Core.Repositories;

namespace Sistema_de_Doacao_de_Sangue.Application.Commands.DoadoresCommands.EditarDoador
{
    public class EditarDoadorCommandHandler : IRequestHandler<EditarDoadorCommand, Unit>
    {
        private readonly IDoadoresRepository _doadoresRepository;
        public EditarDoadorCommandHandler(IDoadoresRepository doadoresRepository)
        {
            _doadoresRepository = doadoresRepository;
        }
        public async Task<Unit> Handle(EditarDoadorCommand request, CancellationToken cancellationToken)
        {
            await _doadoresRepository.EditarDoadorAsync(request.Id, request.doadorDTO);

            return Unit.Value;
        }
    }
}