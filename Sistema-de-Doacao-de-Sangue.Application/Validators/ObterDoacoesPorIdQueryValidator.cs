using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Sistema_de_Doacao_de_Sangue.Application.Queries.DoacoesQueries.ObterDiacoesPorId;

namespace Sistema_de_Doacao_de_Sangue.Application.Validators
{
    public class ObterDoacoesPorIdQueryValidator : AbstractValidator<ObterDoacoesPorIdQuery>
    {
        public ObterDoacoesPorIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("O ID da doação deve ser maior que zero.");
        }
    }
}