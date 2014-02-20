using BookManager.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BookManager.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {

        private BookDBContext bookDb = new BookDBContext();
        private ApplicationDbContext appDb = new ApplicationDbContext();

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Book book = bookDb.Books.Find(id); //lookup via supplied id
            if (book == null)
            {
                return HttpNotFound(); //no such book
            }
            return View(book);
        }

        private ApplicationUser GetCurrentUser()
        {
            UserManager<ApplicationUser> manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(appDb));
            ApplicationUser currentUser = manager.FindById(User.Identity.GetUserId());
            return currentUser;
        }

        public ActionResult Manage()
        {
            return View(GetCurrentUser().Books);
        }

        [HttpGet] //form for creating
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost] //process & insertion
        [ValidateAntiForgeryToken] //stop csrf
        public async Task<ActionResult> Create(Book bookModel)
        {
            if (ModelState.IsValid)
            {
                GetCurrentUser().Books.Add(bookModel);
                await appDb.SaveChangesAsync();
                return RedirectToAction("Manage", "Books");
            }

            return View(bookModel);

        }

        [HttpPost] //process & insertion
        [ValidateAntiForgeryToken] //stop csrf
        public async Task<ActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Book bookModel = (from d in GetCurrentUser().Books
                           where d.ID == id
                           select d).First();
            if (bookModel == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            GetCurrentUser().Books.Remove(bookModel);
            await appDb.SaveChangesAsync();
            return RedirectToAction("Manage", "Books");

        }

    }
}