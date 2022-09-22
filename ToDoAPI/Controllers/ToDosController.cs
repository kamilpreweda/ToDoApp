using Microsoft.AspNetCore.Mvc;

namespace ToDoAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ToDosController : ControllerBase
{
    // GET: api/ToDos
    [HttpGet]
    public IEnumerable<string> Get()
    {
        throw new NotImplementedException();
    }

    // GET api/<ToDos/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        throw new NotImplementedException();
    }

    // POST api/<ToDos
    [HttpPost]
    public void Post([FromBody] string value)
    {
        throw new NotImplementedException();
    }

    // PUT api/<ToDos/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
        throw new NotImplementedException();
    }

    // PUT api/Todos/5/Complete
    [HttpPut("{id}/Complete")]
    public void Complete(int id)
    {
        throw new NotImplementedException();
    }

    // DELETE api/<ToDos/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}
