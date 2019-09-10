using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RestSharp;
using Sudo.Models;

namespace Sudo.Controllers
{
    public class SlackController : Controller
    {
        public IConfiguration _configuration { get; set; }
        public SlackController(IConfiguration config)
        {
            _configuration = config;
            Console.WriteLine("config: " + _configuration["slack:token"]);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult AddUser([FromForm]UserModel user)
        {
            //validate email
            if (!Regex.IsMatch(user.email, "^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$"))
            {
                return View(false);
            }

            Console.WriteLine("Recieved new slack user " + user.email);
            //unoficial slack api: https://github.com/ErikKalkoken/slackApiDoc
            var client = new RestClient("https://slack.com");
            var request = new RestRequest("/api/users.admin.invite", Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");

            var tmp = $"email={user.email}&token={_configuration["slack:token"]}&first_name={user.firstName}&last_name={user.lastName}";
            request.AddParameter("application/x-www-form-urlencoded", $"email={user.email}&token={_configuration["slack:token"]}&first_name={user.firstName}&last_name={user.lastName}", ParameterType.RequestBody);
            Console.WriteLine("Sending Post Request: " + user.email);
            var res = client.Execute(request);
            Console.WriteLine("recieved request: " + res.Content);

            if (res.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine($"Failed to invite {user.email} to Slack");
                //maybe return status in the future
                return View(false);
            }

            return View(true);
        }
    }
}