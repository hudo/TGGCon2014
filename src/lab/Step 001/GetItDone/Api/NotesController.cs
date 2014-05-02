using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GetItDone.Data;
using GetItDone.ViewModel;

namespace GetItDone.Api
{
    public class NotesController : ApiController
    {
        private readonly TicketsContext _db;

        public NotesController(TicketsContext db)
        {
            _db = db;
        }

        public IHttpActionResult Get(int ticketid)
        {
            var ticket = _db.Tickets.Find(ticketid);

            if (ticket == null) return NotFound();

            var model = ticket.TicketNotes.Select(Mapper.Map<NoteModel>);

            return Ok(model);
        }
    }
}