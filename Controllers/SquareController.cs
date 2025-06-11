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
        SquareService.Add(square);
        return CreatedAtAction(nameof(Get), new { id = square.id }, square);
    }
    // PUT action
    [HttpPut("{square}")]
    public IActionResult Update(Square square)
    {
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
}