using GameManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameManager.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public JsonResult Login(string username, string password)
        {
            using (var con = new GameManagementContext())
            {
                var player = con.Players.FirstOrDefault(x => x.Username == username);
                if (player == null)
                {
                    return Json(new { auth = false });
                }

                if (player.Password == password)
                {

                    PlayerSessionKey psk = new PlayerSessionKey()
                    {
                        FkPlayerId = player.PkPlayerId,
                        IssueDt = DateTime.Now,
                        SessionKey = Guid.NewGuid()
                    };
                    con.PlayerSessionKeys.Add(psk);
                    con.SaveChanges();



                    return Json(new { auth = true, sessionKey = psk.SessionKey });
                }

            }
            return Json(new { auth = false });
        }
    }
}
