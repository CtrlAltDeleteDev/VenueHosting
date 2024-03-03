using MediatR;
using VenueHosting.Module.Venue.Application.Common.Persistence;
using VenueHosting.Module.Venue.Application.Common.Specifications;
using VenueHosting.Module.Venue.Domain.Exceptions;

namespace VenueHosting.Module.Venue.Application.Features.OrganizeVenue;

internal sealed class OrganizeVenueCommandHandler : IRequestHandler<OrganizeVenueCommand, Domain.Aggregates.Venue.Venue>
{
    private readonly IVenueStore _venueStore;
    private readonly IPlaceStore _placeStore;
    private readonly IAtomicScope _atomicScope;

    public OrganizeVenueCommandHandler(
        IVenueStore venueStore,
        IAtomicScope atomicScope,
        IPlaceStore placeStore)
    {
        _venueStore = venueStore;
        _atomicScope = atomicScope;
        _placeStore = placeStore;
    }

    public async Task<Domain.Aggregates.Venue.Venue> Handle(OrganizeVenueCommand request, CancellationToken cancellationToken)
    {
        bool placeExist = await _placeStore.CheckIfPlaceExistAsync(new FindPlaceByPlaceIdSpecification(request.PlaceId),
            cancellationToken);

        if (!placeExist)
        {
            throw new PlaceNotFoundException();
        }

        var venue = Domain.Aggregates.Venue.Venue.Create(
            request.OwnerId,
            request.LesseeId,
            request.PlaceId,
            request.EventName,
            request.Description,
            request.Visibility,
            request.StartAtDateTime,
            request.EndAtDateTime);

        await _venueStore.AddAsync(venue);

        await _atomicScope.CommitAsync(cancellationToken);

        return venue;
    }
}