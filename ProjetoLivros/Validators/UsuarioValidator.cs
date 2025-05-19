using FluentValidation;
using ProjetoLivros.Models;

namespace ProjetoLivros.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.NomeCompleto)
                .NotEmpty()
                .WithMessage("O nome completo é obrigatório.")
                .MinimumLength(3)
                .WithMessage("O nome completo deve ter no mínimo 3 caracteres.")
                .MaximumLength(100)
                .WithMessage("O nome completo deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O e-mail é obrigatório.")
                .EmailAddress()
                .WithMessage("O e-mail informado é inválido.");

            RuleFor(x => x.Senha)
                .NotEmpty()
                .WithMessage("A senha é obrigatória.")
                .MinimumLength(6)
                .WithMessage("A senha deve ter no mínimo 6 caracteres.");

            RuleFor(x => x.Telefone)
                .MaximumLength(20)
                .WithMessage("O telefone deve ter no máximo 20 caracteres.")
                .When(x => !string.IsNullOrEmpty(x.Telefone));

            RuleFor(x => x.DataCadastro)
                .NotEmpty()
                .WithMessage("A data de cadastro é obrigatória.")
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("A data de cadastro não pode ser futura.");

            RuleFor(x => x.DataAtualizacao)
                .NotEmpty()
                .WithMessage("A data de atualização é obrigatória.")
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("A data de atualização não pode ser futura.");

            RuleFor(x => x.TipoUsuarioId)
                .GreaterThan(0)
                .WithMessage("O tipo de usuário é obrigatório e deve ser maior que zero.");
        }
    }
}
