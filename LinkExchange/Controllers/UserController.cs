﻿using LinkExchange.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LinkExchange.Controllers
{
    public class UserController : Controller
    {
        public UserController()
        {

        }

        public IActionResult Profile(int id)
        {
            var user = DataBase.Instance.GetUserById(id);
            return View(user);
        }

    }
}
