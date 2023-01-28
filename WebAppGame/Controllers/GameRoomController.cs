using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WebAppGame.Models;

namespace WebAppGame.Controllers
{
    public class GameRoomController : Controller
    {
        // GET: GameRoomController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GameRoom(string enemy, string myself)
        {
            return View(new UserDef() { MyName = myself, EnemyName = enemy});
        }
        // GET: GameRoomController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GameRoomController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GameRoomController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GameRoomController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GameRoomController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GameRoomController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GameRoomController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
