using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.Entity;
using PetShop.Core.Service;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<List<Owner>> Get()
        {
            return _ownerService.GetAllOwners();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            return _ownerService.ReadById(id);
        }

        // POST api/values
        [HttpPost]
        public Owner Post([FromBody] Owner owner)
        {
            return _ownerService.CreateOwner(owner);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Owner Put(int id, [FromBody] Owner owner)
        {
            return _ownerService.UpdateOwner(owner, id);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _ownerService.DeleteOwner(id);
        }
        
    }
}