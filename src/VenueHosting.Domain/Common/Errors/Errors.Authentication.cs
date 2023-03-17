using ErrorOr;

namespace VenueHosting.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Conflict("Auth.InvalidCredentials", "Invalid credentials.");
    }
}