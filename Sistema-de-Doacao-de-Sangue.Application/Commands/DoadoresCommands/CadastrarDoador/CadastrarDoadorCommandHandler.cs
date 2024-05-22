using MediatR;
using Sistema_de_Doacao_de_Sangue.Core.Interfaces;
using Sistema_de_Doacao_de_Sangue.Core.Repositories;

namespace Sistema_de_Doacao_de_Sangue.Application.Command.DoadoresCommands.CadastrarDoador
{
    public class CadastrarDoadorCommandHandler : IRequestHandler<CadastrarDoadorCommand, Unit>
    {
        private readonly IDoadoresRepository _doadoresRepository;
        private readonly IUnityOfWork _unityOfWork;

        public CadastrarDoadorCommandHandler(IDoadoresRepository doadoresRepository, IUnityOfWork unityOfWork)
        {
            _doadoresRepository = doadoresRepository;
            _unityOfWork = unityOfWork;
        }

        public async Task<Unit> Handle(CadastrarDoadorCommand request, CancellationToken cancellationToken)
        {
            if((await _unityOfWork.Doadores.GetAllAsync()).Any(d => d.Email == request.CadastrarDoador.Email))
            {
                throw new Exception("Email já cadastrado");
            }

            var idade =  DateTime.Now.Year - request.CadastrarDoador.DataNascimento.Year;
            if(DateTime.Now.DayOfYear < request.CadastrarDoador.DataNascimento.DayOfYear)
            {
                idade --;
            }
            if(idade < 18)
            {
                throw new Exception("Menor de idade não pode doar sangue");
            }
            if(request.CadastrarDoador.Peso < 50)
            {
                throw new Exception("Peso deve ser maior ou igual a 50KG");
            }

            await _doadoresRepository.AdicionarUmDoadorAsync(
                request.CadastrarDoador.NomeCompleto,
                request.CadastrarDoador.Email, 
                request.CadastrarDoador.DataNascimento,
                request.CadastrarDoador.Genero,
                request.CadastrarDoador.Peso,
                request.CadastrarDoador.TipoSanguineo,
                request.CadastrarDoador.FatorRh); 

            return Unit.Value;
        }
    }
}