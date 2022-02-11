using AareonTechnicalTest.Models;
using AareonTechnicalTest.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AareonTechnicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : CustomBaseController
    {

        private readonly IPersonService _personServie;
        public PersonsController(IPersonService personService)
        {
            _personServie = personService;
        }

        [HttpGet("GetPerson/{id}")]
        public IActionResult GetPerson(int id)
        {
            if (CurrentUser == null) return Unauthorized();

            var result = _personServie.Get(x => x.Id == id, CurrentUser);
            if (result.IsSucceeded)
                return Ok(result);
            else
                return BadRequest(result.ExceptionMessages);
        }

        [HttpGet("GetAllPerson")]
        public IActionResult GetAllPerson()
        {
            if (CurrentUser == null) return Unauthorized();

            var result = _personServie.GetAll(person:CurrentUser);
            if (result.IsSucceeded)
                return Ok(result);
            else
                return BadRequest(result.ExceptionMessages);
        }

        [HttpPost("InsertPerson")]
        public IActionResult InsertPerson(Person entity)
        {
            if (CurrentUser == null) return Unauthorized();

            var result = _personServie.Add(entity, CurrentUser);
            if (result.IsSucceeded)
                return Ok(result);
            else
                return BadRequest(result.ExceptionMessages);
        }

        [HttpPut("UpdatePerson")]
        public IActionResult UpdatePerson(Person entity)
        {
            if (CurrentUser == null) return Unauthorized();

            var result = _personServie.Update(entity, CurrentUser);
            if (result.IsSucceeded)
                return Ok(result);
            else
                return BadRequest(result.ExceptionMessages);
        }

        [HttpDelete("DeletePerson")]
        public IActionResult DeletePerson(Person entity)
        {
            if (CurrentUser == null) return Unauthorized();

            if (!CurrentUser.IsAdmin) return BadRequest("Delete Action Can Only Be Used By The Admin!");

            var result = _personServie.Delete(entity, CurrentUser);
            if (result.IsSucceeded)
                return Ok(result);
            else
                return BadRequest(result.ExceptionMessages);
        }
    }
}
