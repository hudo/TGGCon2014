using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Antlr.Runtime;
using AutoMapper.QueryableExtensions;
using GetItDone.Data;
using GetItDone.Domain;
using GetItDone.ViewModel;

namespace GetItDone.Api
{
    public class TicketsController : ApiController
    {
        private readonly TicketsContext _db;

        public TicketsController(TicketsContext db)
        {
            _db = db;
        }

        public async Task<IHttpActionResult> Get()
        {
            var tickets = await _db.Tickets
                .Project().To<TicketModel>()
                .ToListAsync();

            return Ok(tickets);
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var ticket = await _db.Tickets
                .Project().To<TicketModel>()
                .FirstOrDefaultAsync(x => x.TicketId == id);

            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }

        public async Task<HttpResponseMessage> Put(TicketModel inputModel)
        {
            return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
        }

        public async Task<HttpResponseMessage> Post(TicketModel model)
        {
            var me = await _db.Users.FirstAsync();
            
            var ticket = new Ticket(model.Title, TicketPriority.Medium, me);

            _db.Tickets.Add(ticket);
            await _db.SaveChangesAsync();

            var response = new HttpResponseMessage(HttpStatusCode.Created);
            response.Headers.Location = new Uri("/api/tickets/" + ticket.TicketId, UriKind.Relative);

            return response;
        }
    }
}