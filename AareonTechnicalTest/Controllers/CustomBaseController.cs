using AareonTechnicalTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AareonTechnicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        public Person CurrentUser
        {
            get
            {
                if (string.IsNullOrEmpty(Request.Cookies["signedUser"])) return null;
                {
                    var user = JsonConvert.DeserializeObject<Person>(Request.Cookies["signedUser"]);
                    return user;
                }
            }
        }
    }
}
