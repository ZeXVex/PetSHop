using System.Collections.Generic;
using System.IO;
using System.Linq;
using PetShop.Core.Entity;

namespace PetShop.Core.Service
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;
        private readonly IOwnerService _ownerService;

        public PetService(IPetRepository petRepository, IOwnerService ownerService)
        {
            _petRepository = petRepository;
            _ownerService = ownerService;
        }
        
        public Pet CreatePet(Pet pet)
        {
            if (pet.PreviousOwner == null)
            {
                throw new InvalidDataException("No Previous Owner Assigned");
            }

            if (_ownerService.ReadById(pet.PreviousOwner.Id) == null)
            {
                throw new InvalidDataException("This owner doesn't exist please select an exiting owner");
            }

            return SavePet(pet);
        }

        public List<Pet> GetAllPets()
        {
            return _petRepository.ReadPets().ToList();
        }

        public List<Pet> GetFilteredPets(Filter filter)
        {
            var list = _petRepository.ReadPets();
            var query = list.OrderBy(pet => pet.Price);
            
            return query.Take(5).ToList();
        }

        public Pet GetPetById(int id)
        {
            var pet = _petRepository.ReadPets().FirstOrDefault(p => p.Id == id);
            
            return pet;
            
        }

        public Pet DeletePet(int id)
        {
            var deletePet = _petRepository.ReadById(id);
            
            return _petRepository.DeletePet(deletePet);
        }

        public Pet UpdatePet(int id, Pet pet)
        {
            pet.Id = id;
            return _petRepository.UpdatePet(pet);
        }
        
        public List<Pet> GetPetsByPrice()
        {
            var list = _petRepository.ReadPets();
            var query = list.OrderBy(pet => pet.Price);
            
            return query.ToList();
        }

        public List<Pet> GetPetsByType(string type)
        {
            var list = _petRepository.ReadPets();
            var query = list.Where(pet => pet.Type.ToLower().Equals(type.ToLower()));
            if (query.ToList().Count > 0)
            {
                return query.ToList();
            }

            return null;
        }

        Pet SavePet(Pet pet)
        {
            return _petRepository.AddPet(pet);
        }
    }
}