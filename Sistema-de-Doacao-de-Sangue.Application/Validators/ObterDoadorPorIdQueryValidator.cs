using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Sistema_de_Doacao_de_Sangue.Application.Queries.DoadoresQueries.ObterDoadorPorId;

namespace Sistema_de_Doacao_de_Sangue.Application.Validators
{
    public class ObterDoadorPorIdQueryValidator : AbstractValidator<ObterDoadorPorIdQuery>
    {
        public ObterDoadorPorIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("O ID do doador deve ser maior que zero.");
        }
    }
}