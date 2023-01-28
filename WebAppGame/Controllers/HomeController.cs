using FormApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Dynamic;
using WebAppGame.Models;

namespace WebAppGame.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            /*if (TempData["model"] is null)
            {
                TempData["model"] = JsonConvert.SerializeObject( new RoomModel() { Users = new List<User>()});
            }*/

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (model.Name.Length > 0)
            {
                // var m = TempData["model"] as RoomModel;
                WaitingRoomModel m = StaticData.RModel; //JsonConvert.DeserializeObject<RoomModel>((string)TempData["model"]);
                m.Users.Add(new Models.User() { Name = model.Name });
                var u = new User() { Name = model.Name };
                //m.Users.Add(u);
               
                return RedirectToAction("WaitingRoom", "Home", new { name = model.Name });
                //return RedirectToAction(/*"Print", "HelloPage"*/ "WaitingRoom", "Home", /*myModel*/ 111);
                //return Redi
                //return WaitingRoom(1234323);
                //return RedirectToAction(/*"Print", "HelloPage"*/ "WaitingRoom", /*myModel new { mmm=myModel}*/ /*new { m = serializeWaitingRoom(myModel) }*/);
                //return Redirect(/*"Print", "HelloPage"*/"Home/WaitingRoom" /*myModel*/ );
            }
            else
                return View(model);
        }
      

        public ActionResult WaitingRoom(string name)
        {
            //WaitingRoomModel wrm = deserializeWaitingRoom(m);
            //return View(/*mymodel*/ new WaitingRoomModel() { User = new Models.User() { Name = "123123" }, RoomModel = new RoomModel() { Users = new List<User>() { new Models.User() { Name = "123123" } } } });

            //return View(/*mymodel*/ new WaitingRoomModel() { User = new Models.User() { Name = "123123" }, RoomModel = new RoomModel() { Users = new List<User>() { new Models.User() { Name = "123123" } } } });


            return View(new User() { Name = name});
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string serializeWaitingRoom(WaitingRoomModel m)
        {
            return JsonConvert.SerializeObject(m);            
        }

        private WaitingRoomModel deserializeWaitingRoom(string s)
        {
            return JsonConvert.DeserializeObject<WaitingRoomModel>(s);
        }

        public ActionResult GameRoom(string enemy, string myself)
        {
            return View(new UserDef() { EnemyName = enemy, MyName = myself});
        }
    }

}