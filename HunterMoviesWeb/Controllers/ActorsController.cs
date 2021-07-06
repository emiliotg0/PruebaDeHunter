using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HunterMoviesWeb.Controllers
{
    public class ActorsController : Controller
    {
        // GET: ActorsController
        public ActionResult Index()
        {
            return View();
        }

    }
}
