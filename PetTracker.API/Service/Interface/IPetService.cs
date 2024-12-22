using PetTracker.API.Model;

namespace PetTracker.API.Service;

public interface IPetService
{
    Pet CreateNewPet(Pet pet);
    IEnumerable<Pet> GetAllPets();
    Pet? GetPetById(int id);
    IEnumerable<Pet> GetPetsByName(int name);
}