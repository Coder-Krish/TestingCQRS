using MediatR;
using TestingLibrary.Models;

namespace TestingLibrary.Queries;

public record GetPersonListQuery : IRequest<List<Person>>;
