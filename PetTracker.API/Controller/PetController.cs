using Microsoft.AspNetCore.Mvc;
using PetTracker.API.Model;
using PetTracker.API.Service;

namespace PetTracker.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class PetController : ControllerBase
{
    private readonly IPetService _petService;

    public PetController(IPetService petService) => _petService = petService;

    [HttpGet]
    public IActionResult GetAllPets()
    {
        var petList = _petService.GetAllPets();
        return Ok(petList);
    }

    [HttpPost]
    public IActionResult AddPet(Pet pet)
    {
        _petService.CreateNewPet(pet);
        return Ok(pet);
    }
}