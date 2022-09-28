using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDoLibrary.DataAccess;
using ToDoLibrary.Models;

namespace ToDoAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ToDosController : ControllerBase
{
    private readonly IToDoData _data;    

    public ToDosController(IToDoData data)
    {
        _data = data;        
    }

    private int GetUserId()
    {
        var userIdText = User.Claims.FirstOrDefault(c =>
            c.Type == ClaimTypes.NameIdentifier)?.Value;
        return int.Parse(userIdText);
    }
    // GET: api/ToDos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ToDoModel>>> Get()
    {
        var output = await _data.GetAllAssigned(GetUserId());
        return Ok(output);
    }

    // GET api/<ToDos/5
    [HttpGet("{id}")]
    public ActionResult<ToDoModel> Get(int id)
    {
        throw new NotImplementedException();
    }

    // POST api/<ToDos
    [HttpPost]
    public IActionResult Post([FromBody] string value)
    {
        throw new NotImplementedException();
    }

    // PUT api/<ToDos/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] string value)
    {
        throw new NotImplementedException();
    }

    // PUT api/Todos/5/Complete
    [HttpPut("{id}/Complete")]
    public IActionResult Complete(int id)
    {
        throw new NotImplementedException();
    }

    // DELETE api/<ToDos/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        throw new NotImplementedException();
    }
}
