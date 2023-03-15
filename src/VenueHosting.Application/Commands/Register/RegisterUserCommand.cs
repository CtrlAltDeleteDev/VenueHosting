using MediatR;

namespace VenueHosting.Application.Commands.Register;

public record RegisterUserCommand(string FirstName, 
    string LastName, 
    string Email, 
    string Password) : IRequest<RegistrationResult>;