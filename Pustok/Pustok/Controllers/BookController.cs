using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.DAL;


namespace Pustok.Controllers
{
    public class BookController : Controller
    {
        private readonly PustokDbContext _context;

        public BookController(PustokDbContext context)
        {
            _context = context;
        }

        public IActionResult GetBookModal(int id)
        {
            var book = _context.Books
                .Include(x=>x.Genre)
                .Include(x => x.Author)
                .Include(x => x.BookImages)
                .FirstOrDefault(x=>x.Id == id);

            return PartialView("_BookModalPartial",book);
        }
        public IActionResult Detail(int id)
        {

            var book = _context.Books.
                Include(x=> x.Genre).
                Include(x => x.Author).
                Include(x => x.BookImages).
                FirstOrDefault(x=>x.Id == id);
            return View(book);
        }
    }
}
