using FluentValidation;
using Meetup.API.ViewModels.Event;
using System;

namespace Meetup.API.Validator
{
    public class EventValidator : AbstractValidator<ShortEventViewModel>
    {
        public EventValidator()
        {
            RuleFor(x => x.Name).Length(2, 50);
            RuleFor(x => x.Description).Length(2, 100);
            RuleFor(x => x.Plan).Length(2, 100);
            RuleFor(x => x.DateTimeOfThe).Must(BeAValidateDate);
            RuleFor(x => x.Place).Length(4, 50);
            RuleFor(x => x.Organizer).Length(2, 50);
            RuleFor(x => x.Speaker).Length(2, 50);
        }

        private bool BeAValidateDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}
