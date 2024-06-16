using FluentValidation;
using Sistema_de_Doacao_de_Sangue.Application.Commands.DoadoresCommands.EditarDoador;

namespace Sistema_de_Doacao_de_Sangue.Application.Validators
{
    public class EditarDoadorCommandValidator : AbstractValidator<EditarDoadorCommand>
    {
        public EditarDoadorCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("O ID do doador deve ser maior que zero.");

            RuleFor(x => x.doadorDTO.NomeCompleto)
                .NotEmpty().WithMessage("O nome completo é obrigatório.")
                .Length(2, 150).WithMessage("O nome completo deve ter entre 2 e 150 caracteres.");

            RuleFor(x => x.doadorDTO.Email)
                .NotEmpty().WithMessage("O email é obrigatório.")
                .EmailAddress().WithMessage("O email deve ser válido.");

            // Adicione outras validações conforme necessário
        }
    }
}