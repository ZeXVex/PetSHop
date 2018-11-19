using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.Entity;
using PetShop.Core.Service;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<List<Pet>> Get([FromQuery] Filter filter)
        {
            return Ok(_petService.GetFilteredPets(filter));
            return _petService.GetAllPets();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            return _petService.GetPetById(id);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            try
            {
                return  Ok(_petService.CreatePet(pet));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Pet Put(int id, [FromBody] Pet pet)
        {
            return _petService.UpdatePet(id, pet);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public Pet Delete(int id)
        {
            return _petService.DeletePet(id);
        }
        
    }
}