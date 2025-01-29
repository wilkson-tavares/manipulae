using FluentValidation;
using Manipulae.Domain.Requests.Video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulae.Application.UseCases.Videos
{
    internal class VideoValidator : AbstractValidator<VideoRequest>
    {
        public VideoValidator()
        {
            RuleFor(expense => expense.Titulo)
                .NotEmpty()
                .WithMessage("Title Required");

            RuleFor(expense => expense.Autor)
                .NotEmpty()
                .WithMessage("Autor Required");

            RuleFor(expense => expense.Duracao)
                .NotEmpty()
                .WithMessage("Duration Required");

            RuleFor(expense => expense.DataCriacao)
                .NotEmpty()
                .WithMessage("Creation Date Required");

            RuleFor(expense => expense.Descricao)
               .NotEmpty()
                .WithMessage("Description Required");

            RuleFor(expense => expense.Canal)
                .NotEmpty()
                .WithMessage("Channel Required");
        }
    }
}
