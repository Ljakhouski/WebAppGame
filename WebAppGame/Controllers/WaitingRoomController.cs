using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Dynamic;
using WebAppGame.Models;

namespace WebAppGame.Controllers
{
    public class WaitingRoomController : Controller
    {
        // GET: WaitingRoomController
        public ActionResult Index(/*User user, RoomModel model*/)
        {
            /*dynamic mymodel = new ExpandoObject();
            mymodel.RoomModel = model;
            mymodel.Students = user;
            return View(mymodel);*/
            return View();
        }
        //*[HttpPost]
       /* public ActionResult WaitingRoom(string name)
        {
            //User u = mymodel.User;
            return View();
            //return View();
        }
        /*public ActionResult WaitingRoom(int S)
        {
            //User u = mymodel.User;
            return View(S);
            //return View();
        }*/



        // GET: WaitingRoomController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WaitingRoomController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WaitingRoomController/Create
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
        public string getUsers(string user)
        {
            return JsonConvert.SerializeObject(StaticData.RModel.Users);
        }
       
        public ActionResult chooseUser (string username1, string username2)
        {
            var u_ = from item in StaticData.RModel.Users where item.Name == username1 select item;
            var u = u_.FirstOrDefault();

            var c_ = from item in StaticData.RModel.Users where item.Name == username2 select item;
            var c = c_.FirstOrDefault();

            u.NeedToInvite = true;
            u.Caller = c;

            return Json( Url.Action("GameRoom", "Home", new { enemy = username1, myself = username2 }));

        }
        // user1 : selected user, user2 - it's me
        public ActionResult checkState(string user)
        {
            try
            {
                var u_ = from item in StaticData.RModel.Users where item.Name == user select item;
                if (u_ is null)
                    return Content("none");

                var u = u_.FirstOrDefault();
                if (u is null == false && u.NeedToInvite)
                {

                    return Json(Url.Action("GameRoom", "Home", new { enemy = u.Caller.Name, myself = u.Name }));
                }

                return Content("none");
            }
            catch(Exception e)
            {
                return Content("none");
            }
        }
    }
}
