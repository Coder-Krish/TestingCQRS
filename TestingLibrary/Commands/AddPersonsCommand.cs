using MediatR;
using TestingLibrary.Models;

namespace TestingLibrary.Commands;

public record AddPersonsCommand(Person _person):IRequest<Person>;