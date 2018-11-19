using System.Collections.Generic;
using PetShop.Core.Entity;

namespace PetShop.Core.Service
{
    public interface IPetService
    {
        Pet CreatePet(Pet pet);
        
        List<Pet> GetAllPets();
        
        List<Pet> GetFilteredPets(Filter filter);
        
        Pet GetPetById(int id);
        
        Pet DeletePet(int id);
        
        Pet UpdatePet(int id, Pet name);
    }
}