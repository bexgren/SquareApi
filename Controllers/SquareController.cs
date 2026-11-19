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
        square.Id = SquareService.GetAll().Max(s => s.Id) + 1;
        SquareService.Add(square);
        return CreatedAtAction(nameof(Get), new { id = square.Id }, square);
    }
    // PUT action - change first square
    [HttpPut("{square}")]
    public IActionResult Update(Square square)
    {
        if (square.Id - 1 != 0)
        {
            return BadRequest();
        }
       var prevId = square.Id - 1;
        var existingSquare = SquareService.Get(prevId);
        if(existingSquare is null)
            return NotFound();

        SquareService.Update(square);           
    
       return CreatedAtAction(nameof(Get), new { id = square.Id }, square);
    }
      [HttpPut("deleteall")]
    public IActionResult DeleteAll([FromBody]Square square)
    {
        var incomingSquare = square;
        if(square.Id > 0)
        {
            return BadRequest();
        }
        SquareService.DeleteAll(square);
       return CreatedAtAction(nameof(Get), new { id = square.Id }, square);
    }
}