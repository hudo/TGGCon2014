using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using GetItDone.Data;

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
            var tickets = await _db.Tickets.ToListAsync();
            return Ok(tickets);
        }
    }
}