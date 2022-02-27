using MediatR;
using TestingLibrary.Models;

namespace TestingLibrary.Queries;

public record GetPersonByIdQuery(Guid Id) : IRequest<Person>;
