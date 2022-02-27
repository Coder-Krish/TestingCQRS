using MediatR;
using Microsoft.EntityFrameworkCore;
using TestingLibrary.DataAccess;
using TestingLibrary.Models;
using TestingLibrary.Queries;

namespace TestingLibrary.Handlers;

public class GetPersonListQueryHandler:IRequestHandler<GetPersonListQuery, List<Person>>
{
    private readonly PersonDbContext _personDbContext;
    public GetPersonListQueryHandler(PersonDbContext _personDbContext)
    {
        this._personDbContext = _personDbContext;
    }
    public async Task<List<Person>> Handle(GetPersonListQuery request, CancellationToken cancellationToken)
    {
        return await _personDbContext.Persons.Include(a => a.PersonDetails).ToListAsync();
    }
}