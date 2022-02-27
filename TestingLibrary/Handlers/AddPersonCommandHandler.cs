using MediatR;
using Microsoft.EntityFrameworkCore;
using TestingLibrary.Commands;
using TestingLibrary.DataAccess;
using TestingLibrary.Models;

namespace TestingLibrary.Handlers;

public class AddPersonCommandHandler : IRequestHandler<AddPersonsCommand, Person>
{
    private readonly PersonDbContext _personDbContext;

    public AddPersonCommandHandler(PersonDbContext _personDbContext)
    {
        this._personDbContext = _personDbContext;
    }
    public async Task<Person> Handle(AddPersonsCommand request, CancellationToken cancellationToken)
    {
        Person _person = new();
        _person = request._person;
        _personDbContext.Add(_person);
        await _personDbContext.SaveChangesAsync();
        return _person;
    }
}