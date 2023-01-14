using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ApiAuth.Models;
using Microsoft.AspNetCore.Authorization;

namespace ApiAuth.Controllers
{   
    [ApiController]
    [Route("v1")]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() =>"Anônimo";

        [HttpGet]
        [Authorize]
        [Route("authenticated")]
        public string Autenticated() => $"Autenticado - {User.Identity.Name}";

        [HttpGet]
        [Authorize(Roles = "employee, manager")]
        [Route("employee")]
        public string Employee() => "Funcionário";

        [HttpGet]
        [Authorize(Roles = "manager")]
        [Route("manager")]
        public string Manager() => "Gerente";
    }
}
