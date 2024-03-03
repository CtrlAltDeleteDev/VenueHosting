using VenueHosting.Module.Venue.Domain.Aggregates.Venue.Entities;
using VenueHosting.Module.Venue.Domain.Exceptions;
using VenueHosting.SharedKernel.BLSpecifications;

namespace VenueHosting.Module.Venue.Domain.Aggregates.Venue.BusinessRules;

internal sealed class VenueActivityMustNotContainDuplicateBusinessRule : IBusinessRule
{
    private readonly IList<Activity> _currentActivities;

    private readonly Activity _addingActivity;

    public VenueActivityMustNotContainDuplicateBusinessRule(IList<Activity> currentActivities, Activity addingActivity)
    {
        _currentActivities = currentActivities;
        _addingActivity = addingActivity;
    }

    public void CheckIfSatisfied()
    {
        if (_currentActivities.Contains(_addingActivity))
        {
            throw new VenueActivityDuplicateFoundException();
        }
    }
}