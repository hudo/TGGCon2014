using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper.QueryableExtensions;
using GetItDone.Data;
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
    }
}