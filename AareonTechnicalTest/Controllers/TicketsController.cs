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
    public class TicketsController : CustomBaseController
    {

        private readonly ITicketService _ticketServie;
        public TicketsController(ITicketService ticketService)
        {
            _ticketServie = ticketService;
        }

        [HttpGet("GetTicket/{id}")]
        public IActionResult GetTicket(int id)
        {
            if (CurrentUser == null) return Unauthorized();

            var result = _ticketServie.Get(x => x.Id == id, CurrentUser);
            if (result.IsSucceeded)
                return Ok(result);
            else
                return BadRequest(result.ExceptionMessages);
        }

        [HttpGet("GetAllTicket")]
        public IActionResult GetAllTicket()
        {
            if (CurrentUser == null) return Unauthorized();

            var result = _ticketServie.GetAll(person:CurrentUser);
            if (result.IsSucceeded)
                return Ok(result);
            else
                return BadRequest(result.ExceptionMessages);
        }

        [HttpPost("InsertTicket")]
        public IActionResult InsertTicket(Ticket entity)
        {
            if (CurrentUser == null) return Unauthorized();

            var result = _ticketServie.Add(entity, CurrentUser);

            if (result.IsSucceeded)
                return Ok(result);
            else
                return BadRequest(result.ExceptionMessages);
        }

        [HttpPut("UpdateTicket")]
        public IActionResult UpdateTicket(Ticket entity)
        {
            if (CurrentUser == null) return Unauthorized();

            var result = _ticketServie.Update(entity, CurrentUser);
            if (result.IsSucceeded)
                return Ok(result);
            else
                return BadRequest(result.ExceptionMessages);
        }

        [HttpDelete("DeleteTicket")]
        public IActionResult DeleteTicket(Ticket entity)
        {
            if (CurrentUser == null) return Unauthorized();

            if (!CurrentUser.IsAdmin) return BadRequest("Delete Action Can Only Be Used By The Admin!");

            var result = _ticketServie.Delete(entity, CurrentUser);
            if (result.IsSucceeded)
                return Ok(result);
            else
                return BadRequest(result.ExceptionMessages);
        }
    }
}
