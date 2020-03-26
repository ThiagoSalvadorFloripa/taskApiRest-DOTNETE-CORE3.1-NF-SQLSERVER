using System.Collections.Generic;
using System.Linq;
//para trabalhar de forma assincrona
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using taskApiRest.Data;
using taskApiRest.Models;

namespace taskApiRest.Controllers
{
    [ApiController]
    [Route("api/tickets")]
    public class TaskController : ControllerBase
    {
        private readonly DataContext _context;

        public TaskController(DataContext context){
            _context = context;
        }


        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Ticket>>> Get([FromServices] DataContext services)
        {
            var tickets = await services.Tickets.ToListAsync();
            return tickets;

        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Ticket>> Post([FromBody] Ticket ticket)
        {
            //valida objeto
            if(ModelState.IsValid)
            {
                _context.Tickets.Add(ticket);
                await _context.SaveChangesAsync();
                return ticket;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        //: força para um inteiro caso não receba um inteiro da notfound
        [Route("{id:int}")]
        public async Task<ActionResult<Ticket>> GetById(int id)
        {
            var ticketsResult = await _context.Tickets.FindAsync(id);

            if(ticketsResult == null )
            {
                return NotFound();
            }

            return ticketsResult;
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult> Put(int id, Ticket ticket)
        {
            if(id != ticket.Id)
            {
                return BadRequest();
            }
            _context.Entry(ticket).State = EntityState.Modified;
           
            try
            {
                await _context.SaveChangesAsync();
            }

            catch(DbUpdateConcurrencyException)
            {
                if(!TicketExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }
            return NoContent();
        }

        [HttpDelete ("{id:int}")]
        public async  Task<ActionResult<Ticket>> delete(int id)
        {
            var ticketsResult = await _context.Tickets.FindAsync(id);
            if(ticketsResult == null)
            {
                return NotFound();
            }

            _context.Tickets.Remove(ticketsResult);
            
            await _context.SaveChangesAsync();

            return ticketsResult;
        }


         private bool TicketExists(int id)
         {
            return _context.Tickets.Any(e => e.Id == id);
         }


        
        
    }
}