using VenueHosting.Domain.Common.Models;
using VenueHosting.Domain.Place.ValueObjects;

namespace VenueHosting.Domain.Place.Entities;

public class Facility : Entity<FacilityId>
{
    private Facility(){}

    public Facility(FacilityId value, string name, string description, int quantity) : base(value)
    {
        Name = name;
        Description = description;
        Quantity = quantity;
    }

    public string Description { get; private set; }

    public string Name { get; private set; }

    public int Quantity { get; private set; }

    public Facility Create(string name, string description, int quantity)
    {
        return new Facility(FacilityId.CreateUnique(), name, description, quantity);
    }
}