using MediatR;
using Microsoft.EntityFrameworkCore;
using TestingLibrary.DataAccess;
using TestingLibrary.Models;
using TestingLibrary.Queries;

namespace TestingLibrary.Handlers;

public class GetPersonByIdQueryHandler:IRequestHandler<GetPersonByIdQuery,Person>
{
    private readonly PersonDbContext _personDbContext;

    public GetPersonByIdQueryHandler(PersonDbContext _personDbContext)
    {
        this._personDbContext = _personDbContext;
    }
    public async Task<Person> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        var person = await _personDbContext.Persons.Where(a => a.PersonId.Equals(request.Id))
            .Include(a => a.PersonDetails).FirstOrDefaultAsync();
        return person;
    }
}