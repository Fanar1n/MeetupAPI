using FluentValidation;
using Meetup.API.ViewModels.Event;
using System;

namespace Meetup.API.Validator
{
    public class EventValidator : AbstractValidator<ShortEventViewModel>
    {
        public EventValidator()
        {
            RuleFor(x => x.Name).Length(2, 50).NotNull();
            RuleFor(x => x.Description).Length(2, 100).NotNull();
            RuleFor(x => x.Plan).Length(2, 100).NotNull();
            RuleFor(x => x.DateTimeOfThe).Must(BeAValidateDate).NotNull();
            RuleFor(x => x.Place).Length(4, 50).NotNull();
            RuleFor(x => x.Organizer).Length(2, 50).NotNull();
            RuleFor(x => x.Speaker).Length(2, 50).NotNull();
        }

        private bool BeAValidateDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}
