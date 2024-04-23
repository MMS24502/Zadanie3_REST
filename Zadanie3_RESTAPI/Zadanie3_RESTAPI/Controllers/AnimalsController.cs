using Microsoft.AspNetCore.Mvc;
using Zadanie3_RESTAPI.Models;
using Zadanie3_RESTAPI.Repositories;

namespace Zadanie3_RESTAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalsController : ControllerBase
{
    private IAnimalsRepository _animalsRepository;

    public AnimalsController(IAnimalsRepository animalsService)
    {
        _animalsRepository = animalsService;
    }

    [HttpGet]
    public IActionResult GetAnimals(String orderBy)
    {
        var animals = _animalsRepository.GetAnimals(orderBy);
        return Ok(animals);
    }
    
    [HttpPost]
    public IActionResult PostAnimal([FromBody] Animal animal)
    {
        var result = _animalsRepository.AddAnimal(animal);
        if (result > 0)
            return CreatedAtAction(nameof(GetAnimals), new { id = animal.IdAnimal }, animal);
        else
            return BadRequest();
    }

    [HttpPut("{idAnimal}")]
    public IActionResult PutAnimal(int idAnimal, [FromBody] Animal animal)
    {
        if (idAnimal != animal.IdAnimal)
            return BadRequest("ID mismatch");

        var result = _animalsRepository.UpdateAnimal(animal);
        if (result > 0)
            return NoContent();
        else
            return NotFound();
    }

    [HttpDelete("{idAnimal}")]
    public IActionResult DeleteAnimal(int idAnimal)
    {
        var result = _animalsRepository.DeleteAnimal(idAnimal);
        if (result > 0)
            return NoContent();
        else
            return NotFound();
    }
}