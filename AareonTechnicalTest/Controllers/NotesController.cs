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
    public class NotesController : CustomBaseController
    {
        private readonly INoteService _noteServie;
        public NotesController(INoteService noteService)
        {
            _noteServie = noteService;
        }

        [HttpGet("GetNote/{id}")]
        public IActionResult GetNote(int id)
        {
            if (CurrentUser == null) return Unauthorized();

            var result = _noteServie.Get(x => x.Id == id, CurrentUser);
            if (result.IsSucceeded)
                return Ok(result);
            else
                return BadRequest(result.ExceptionMessages);
        }

        [HttpGet("GetAllNote")]
        public IActionResult GetAllNote()
        {
            if (CurrentUser == null) return Unauthorized();

            var result = _noteServie.GetAll(person:CurrentUser);
            if (result.IsSucceeded)
                return Ok(result);
            else
                return BadRequest(result.ExceptionMessages);
        }

        [HttpPost("InsertNote")]
        public IActionResult InsertNote(Note entity)
        {
            if (CurrentUser == null) return Unauthorized();

            var result = _noteServie.Add(entity, CurrentUser);
            if (result.IsSucceeded)
                return Ok(result);
            else
                return BadRequest(result.ExceptionMessages);
        }

        [HttpPut("UpdateNote")]
        public IActionResult UpdateNote(Note entity)
        {
            if (CurrentUser == null) return Unauthorized();

            var result = _noteServie.Update(entity, CurrentUser);
            if (result.IsSucceeded)
                return Ok(result);
            else
                return BadRequest(result.ExceptionMessages);
        }

        [HttpDelete("DeleteNote")]
        public IActionResult DeleteNote(Note entity)
        {
            if (CurrentUser == null) return Unauthorized();

            if (!CurrentUser.IsAdmin) return BadRequest("Delete Action Can Only Be Used By The Admin!");

            var result = _noteServie.Delete(entity, CurrentUser);
            if (result.IsSucceeded)
                return Ok(result);
            else
                return BadRequest(result.ExceptionMessages);
        }
    }
}
