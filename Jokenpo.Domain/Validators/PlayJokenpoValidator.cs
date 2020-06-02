using FluentValidation;
using Jokenpo.Domain.Commands;

namespace Jokenpo.Domain.Validators
{
    public class PlayJokenpoValidator : AbstractValidator<PlayJokenpoCommand>
    {
        public PlayJokenpoValidator()
        {
            RuleFor(x => x.PlayerOne)
                .NotNull()
                .WithName("Jogada do Player 1")
                .WithMessage("{Property Name} deve ser informado")
                .IsInEnum()
                .WithMessage("{PropertyName} deve ter um valor válido");

            RuleFor(x => x.PlayerTwo)
                .NotNull()
                .WithName("Jogada do Player 2")
                .WithMessage("{Property Name} deve ser informado")
                .IsInEnum()
                .WithMessage("{PropertyName} deve ter um valor válido");
        }
    }
}