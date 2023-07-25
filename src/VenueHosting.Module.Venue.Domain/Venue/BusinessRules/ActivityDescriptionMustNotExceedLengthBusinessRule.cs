using VenueHosting.Module.Venue.Domain.Exceptions;
using VenueHosting.SharedKernel.BLSpecifications;

namespace VenueHosting.Module.Venue.Domain.Venue.BusinessRules;

internal sealed class ActivityDescriptionMustNotExceedLengthBusinessRule : IBusinessRule
{
    private readonly string _description;

    public ActivityDescriptionMustNotExceedLengthBusinessRule(string description)
    {
        _description = description;
    }

    private const int MaxLengthLimit = 100;

    public void CheckIfSatisfied()
    {
        if (_description.Length > MaxLengthLimit)
        {
            throw new ActivityDescriptionMaxLengthException();
        }
    }
}