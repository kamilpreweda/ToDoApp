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
    [HttpGet("{todoId}")]
    public async Task<ActionResult<ToDoModel>> Get(int todoId)
    {
        var output = await _data.GetOneAssigned(GetUserId(), todoId);
        return Ok(output);
    }

    // POST api/<ToDos
    [HttpPost]
    public async Task<ActionResult<ToDoModel>> Post([FromBody] string task)
    {
        var output = await _data.Create(GetUserId(), task);
        return Ok(output);
    }

    // PUT api/<ToDos/5
    [HttpPut("{todoId}")]
    public async Task<IActionResult> Put(int todoId, [FromBody] string task)
    {
        await _data.UpdateTask(GetUserId(), todoId, task);
        return Ok();
    }

    // PUT api/Todos/5/Complete
    [HttpPut("{todoId}/Complete")]
    public async Task<IActionResult> Complete(int todoId)
    {
        await _data.CompleteToDo(GetUserId(), todoId);
        return Ok();
    }

    // DELETE api/<ToDos/5
    [HttpDelete("{todoId}")]
    public async Task<IActionResult> Delete(int todoId)
    {
        await _data.Delete(GetUserId(), todoId);
        return Ok();
    }
}
