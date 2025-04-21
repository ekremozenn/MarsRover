using FluentValidation;
using Nexum.MarsRover.Business.InputModels;
using Nexum.MarsRover.Business.Messages;
using System.Text.RegularExpressions;

namespace Nexum.MarsRover.Business.Validators
{
    public class RoverInputModelValidator : AbstractValidator<RoverInputModel>
    {
        public RoverInputModelValidator()
        {
            #region PlateauInput Validation

            RuleFor(x => x.PlateauInput)
                .NotEmpty().WithMessage(ValidationMessages.Plateau_Empty)
                .Matches(@"^\d+ \d+$").WithMessage(ValidationMessages.Plateau_Format);
            #endregion

            #region StartPositionInput Validation

            RuleFor(x => x.StartPositionInput)
                .NotEmpty().WithMessage(ValidationMessages.Start_Empty)
                .Matches(@"^\d+ \d+ [A-Z]$").WithMessage(ValidationMessages.Start_Format)
                .Custom((input, context) =>
                {
                           //Regex = Regular Expression :)
                    var match = Regex.Match(input ?? "", @"^\d+ \d+ (?<dir>[A-Z])$");
                    if (match.Success)
                    {
                        var dir = match.Groups["dir"].Value;
                        if (!new[] { "N", "E", "S", "W" }.Contains(dir))
                        {
                            context.AddFailure(string.Format(ValidationMessages.Start_InvalidDirection, dir));
                        }
                    }
                });

            #endregion

            #region CommandInput Validation

            RuleFor(x => x.CommandInput)
                .NotEmpty().WithMessage(ValidationMessages.Command_Empty)
                .Matches(@"^[LRM]+$").WithMessage(ValidationMessages.Command_Format);

            #endregion
        }
    }
}
