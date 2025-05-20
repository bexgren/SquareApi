using SquareApi.Models;
using SquareApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace SquareApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SquareController : ControllerBase
{
    public SquareController()
    {
    }

    // GET all action
    [HttpGet]
    public ActionResult<IEnumerable<Square>> GetAll() =>
        Ok(SquareService.GetAll());
    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Square> Get(int id)
    {
        var square = SquareService.Get(id);

        return square == null ? NotFound() : Ok(square);
    }
    // POST action
    [HttpPost]
    public ActionResult<Square> Create(Square square)
    {
        square.Id = SquareService.GetAll().Max(s => s.Id) + 1;
        // This code will save the square and return a result
        SquareService.Add(square);
        return CreatedAtAction(nameof(Get), new { id = square.Id }, square);
    }
    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Square square)
    {
        // This code will update the square and return a result
         if (id != square.Id)
            return BadRequest();
           
        var existingSquare = SquareService.Get(id);
        if(existingSquare is null)
            return NotFound();
    
        SquareService.Update(square);           
    
        return NoContent();
    }
    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        // This code will delete the square and return a result
        var square = SquareService.Get(id);
   
        if (square is null)
            return NotFound();
        
        SquareService.Delete(id);
        
    
        return NoContent();
    }
}