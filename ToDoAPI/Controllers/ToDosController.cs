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
    private readonly ILogger<ToDosController> _logger;

    public ToDosController(IToDoData data, ILogger<ToDosController> logger)
    {
        _data = data;
        _logger = logger;
    }

    private int GetUserId()
    {
        var userIdText = User.Claims.FirstOrDefault(c =>
            c.Type == ClaimTypes.NameIdentifier)?.Value;
        return int.Parse(userIdText);
    }
    // GET: api/ToDos
    [HttpGet]
    public async Task<ActionResult<List<ToDoModel>>> Get()
    {
        _logger.LogInformation("GET: api/ToDos");
        try
        {            
            var output = await _data.GetAllAssigned(GetUserId());
            return Ok(output);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "The GET call to api/ToDos failed.");
            return BadRequest();
        }
    }

    // GET api/ToDos/5
    [HttpGet("{todoId}")]
    public async Task<ActionResult<ToDoModel>> Get(int todoId)
    {
        _logger.LogInformation("GET: api/ToDos/{ToDoId}", todoId);
        try
        {
            var output = await _data.GetOneAssigned(GetUserId(), todoId);
            return Ok(output);
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "The GET call to {ApiPath} failed. The Id was {ToDoId}",
                $"api/ToDos/Id",
                todoId);
            return BadRequest();
        }
    }

    // POST api/ToDos
    [HttpPost]
    public async Task<ActionResult<ToDoModel>> Post([FromBody] string task)
    {
        _logger.LogInformation("POST: api/ToDos (Task: {Task})", task);
        try
        {
            var output = await _data.Create(GetUserId(), task);
            return Ok(output);
        }
        catch (Exception ex) 
        {
            _logger.LogError(ex, "The POST call to api/ToDos failed. Task value was {Task}", task);
            return BadRequest();            
        }
    }

    // PUT api/ToDos/5
    [HttpPut("{todoId}")]
    public async Task<IActionResult> Put(int todoId, [FromBody] string task)
    {
        _logger.LogInformation("PUT: api/ToDos/{ToDoId} (Task: {Task})", todoId, task);
        try
        {
            await _data.UpdateTask(GetUserId(), todoId, task);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "The PUT call to api/ToDos/{ToDoId} failed. Task value was {Task}", todoId, task);
            return BadRequest();
        }
    }

    // PUT api/Todos/5/Complete
    [HttpPut("{todoId}/Complete")]
    public async Task<IActionResult> Complete(int todoId)
    {
        _logger.LogInformation("PUT: api/ToDos/{ToDoId}/Complete failed.", todoId);
        try
        {
            await _data.CompleteToDo(GetUserId(), todoId);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "The PUT call to api/ToDos/{ToDoId}/Complete failed.", todoId);
            return BadRequest();
        }
    }

    // DELETE api/<ToDos/5
    [HttpDelete("{todoId}")]
    public async Task<IActionResult> Delete(int todoId)
    {
        _logger.LogInformation("DELETE: api/ToDos/{ToDoId} failed.", todoId);
        try
        {
            await _data.Delete(GetUserId(), todoId);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "The DELETE call to api/ToDos/{ToDoId} failed.", todoId);
            return BadRequest();
        }
    }
}
