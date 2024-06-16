using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Sistema_de_Doacao_de_Sangue.Application.Queries.DoadoresQueries.ObterDoacoesPorDoador;

namespace Sistema_de_Doacao_de_Sangue.Application.Validators
{
    public class ObterDoacoesPorDoadorQueryValidator : AbstractValidator<ObterDoacoesPorDoadorQuery>
    {
        public ObterDoacoesPorDoadorQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("O ID do doador deve ser maior que zero.");
        }
    }
}