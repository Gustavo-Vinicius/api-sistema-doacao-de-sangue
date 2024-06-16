using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Sistema_de_Doacao_de_Sangue.Application.Command.DoadoresCommands.CadastrarDoador;

namespace Sistema_de_Doacao_de_Sangue.Application.Validators
{
    public class CadastrarDoadorCommandValidator : AbstractValidator<CadastrarDoadorCommand>
    {
        public CadastrarDoadorCommandValidator()
    {
        RuleFor(x => x.CadastrarDoador.NomeCompleto)
            .NotEmpty().WithMessage("O nome completo é obrigatório.")
            .Length(2, 150).WithMessage("O nome completo deve ter entre 2 e 150 caracteres.");

        RuleFor(x => x.CadastrarDoador.Email)
            .NotEmpty().WithMessage("O email é obrigatório.")
            .EmailAddress().WithMessage("O email deve ser válido.");

        RuleFor(x => x.CadastrarDoador.DataNascimento)
            .NotEmpty().WithMessage("A data de nascimento é obrigatória.")
            .LessThan(DateTime.Now).WithMessage("A data de nascimento deve ser no passado.");

        // Adicione outras validações conforme necessário
    }
    }
}