using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TestTask7.Controllers;

[Route("api")]
public class InputCommandsController : ControllerBase
{
    private readonly InputCommandContext _context;

    public InputCommandsController(InputCommandContext context)
    {
        _context = context;
    }

    [Route("getHistory")]
    public Task<List<InputCommand>> GetCommandHistory()
    {
        return _context.Commands.ToListAsync();
    }
    
    [Route("toExecute")]
    public async Task<string> PostCommandToProcess([FromBody] string input)
    { 
        var itemToDataBase = new InputCommand { Input = input};
        _context.Commands.Add(itemToDataBase);
        await _context.SaveChangesAsync();
        var output = await ProcessToExecute.RunСommandAsync(input);
        return output;
    }
}