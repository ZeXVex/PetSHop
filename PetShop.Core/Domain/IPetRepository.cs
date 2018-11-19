using System.Collections.Generic;
using PetShop.Core.Entity;

namespace PetShop.Core
{
    public interface IPetRepository
    {
        Pet AddPet(Pet pet);
        
        IEnumerable<Pet> ReadPets(Filter filter = null);

        Pet ReadById(int id);

        Pet UpdatePet(Pet pet);

        Pet DeletePet(Pet deletePet);
    }
}