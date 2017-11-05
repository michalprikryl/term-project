using Microsoft.AspNetCore.Mvc;
using Database;

namespace WebAPI.Controllers
{
    /// <summary>
    /// trida, ktera zajistuje konstruktor s db kontextem pro ostatni controllery
    /// </summary>
    public class APIController : Controller
    {
        protected readonly TermProjectContext _db;

        public APIController(TermProjectContext db)
        {
            _db = db;
        }
    }
}