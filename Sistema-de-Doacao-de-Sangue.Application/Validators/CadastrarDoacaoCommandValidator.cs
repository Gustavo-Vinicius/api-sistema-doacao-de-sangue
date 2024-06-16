using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Sistema_de_Doacao_de_Sangue.Application.Commands.DoacoesCommands.CadastrarDoacao;

namespace Sistema_de_Doacao_de_Sangue.Application.Validators
{
    public class CadastrarDoacaoCommandValidator : AbstractValidator<CadastrarDoacaoCommand>
    {
        public CadastrarDoacaoCommandValidator()
        {
            RuleFor(x => x.CadastrarDoacao.DoadorId)
                .GreaterThan(0).WithMessage("O ID do doador deve ser maior que zero.");

            RuleFor(x => x.CadastrarDoacao.DataDoacao)
                .NotEmpty().WithMessage("A data da doação é obrigatória.");

            RuleFor(x => x.CadastrarDoacao.QuantidadeML)
                .InclusiveBetween(420, 470).WithMessage("A quantidade de sangue doada deve ser entre 420ml e 470ml.");
        }
    }
}