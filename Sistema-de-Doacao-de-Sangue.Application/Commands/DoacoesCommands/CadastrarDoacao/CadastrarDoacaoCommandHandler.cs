using MediatR;
using Sistema_de_Doacao_de_Sangue.Core.Repositories;

namespace Sistema_de_Doacao_de_Sangue.Application.Commands.DoacoesCommands.CadastrarDoacao
{
    public class CadastrarDoacaoCommandHandler : IRequestHandler<CadastrarDoacaoCommand, Unit>
    {
        private readonly IDoacaoRepository _doacaoRepository;

        public CadastrarDoacaoCommandHandler(IDoacaoRepository doacaoRepository)
        {
            _doacaoRepository = doacaoRepository;
        }

        public async Task<Unit> Handle(CadastrarDoacaoCommand request, CancellationToken cancellationToken)
        {
            await _doacaoRepository.AdicionarDoacaoAsync(request.CadastrarDoacao.DoadorId, request.CadastrarDoacao.DataDoacao, request.CadastrarDoacao.QuantidadeML);

            return Unit.Value;
        }
    }
}