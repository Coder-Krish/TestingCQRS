using System.Reflection;
using System.Reflection.Metadata;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Office.Interop.Word;
using TestingLibrary.Commands;
using TestingLibrary.Models;
using TestingLibrary.Queries;
using Document = Microsoft.Office.Interop.Word.Document;
using Range = Microsoft.Office.Interop.Word.Range;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController
{
    private readonly IMediator _mediator;

    public PersonController(IMediator _mediator)
    {
        this._mediator = _mediator;
    }
    
    /// <summary>
    /// Gets the list of Persons
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("GetPersons")]
    public async Task<List<Person>> GetPersons()
    {
        return await _mediator.Send(new GetPersonListQuery());
    }

    /// <summary>
    /// Gets the person by its Guid...
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("GetPersonsById{id}")]
    public async Task<Person> GetPersonsById(Guid id)
    {
        return await _mediator.Send(new GetPersonByIdQuery(id));
    }
    
    /// <summary>
    /// Adds persons with their informations...
    /// </summary>
    /// <param name="person"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("AddPersons")]
    public async Task<Person> AddPersons([FromBody] Person person)
    {
        return await _mediator.Send(new AddPersonsCommand(_person: person));
    }
    
}