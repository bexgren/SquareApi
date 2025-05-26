using SquareApi.Models;
using SquareApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


namespace SquareApi.Controllers;

[ApiController]
[Route("api/[controller]")]
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
    public ActionResult<Square> Create([FromBody]Square square)
    {
        square.id = SquareService.GetAll().Max(s => s.id) + 1;
        // This code will save the square and return a result
        SquareService.Add(square);
        return CreatedAtAction(nameof(Get), new { id = square.id }, square);
    }
    // PUT action
    [HttpPut("{square}")]
    public IActionResult Update(Square square)
    {
        
        // This code will update the square and return a result
        if (square.id - 1 != 0)
        {
            return BadRequest();
        }
       var prevId = square.id - 1;
        var existingSquare = SquareService.Get(prevId);
        if(existingSquare is null)
            return NotFound();

        SquareService.Update(square);           
    
       return CreatedAtAction(nameof(Get), new { id = square.id }, square);
    }
    // Delete and replace action
    // [HttpPut]
    // public IActionResult DeleteList([FromBody] Square square)
    // {
    //     SquareService.DeleteAll(square);
    //      return CreatedAtAction(nameof(Get), new { id = square.id }, square);
    // }
    // DELETE action
    // [HttpDelete("{id}")]
    // public IActionResult Delete(int id)
    // {
    //     Console.WriteLine(id);
    //     // This code will delete the square
    //     var existingSquare = SquareService.Get(id);
    //     if(existingSquare is null)
    //         return NotFound();
    
       
    //     SquareService.Delete(id);

        
    
    //     return NoContent();
    // }
}