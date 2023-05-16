using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TVTestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "OK";
        }

        private static DateTime _lastRequestTime;


        [HttpPost]
        public IActionResult Post([FromBody] MyRequest request)
        {
            // Check if the client has sent more than one request in 3 seconds
            var currentTime = DateTime.Now;
            var timeSinceLastRequest = currentTime - _lastRequestTime;
            if (timeSinceLastRequest < TimeSpan.FromSeconds(3))
            {
                return StatusCode(429, new { Message = "Too many requests. Try again later." });
            }

            // Process
            _lastRequestTime = currentTime;

            // Return the email and the time it was received
            return Ok(new MyResponse { Email = request.Email, ReceivedAt = currentTime });
        }
    }
    public class MyRequest
    {
        [Required, RegularExpression("\\w+([-+.\']\\w+)*@\\w+([-.]\\w+)*\\.+\\w+([-.]\\w+)*")]
        public string Email { get; set; }
    }
    public class MyResponse : MyRequest
    {
        public DateTime ReceivedAt { get; set; }
    }
}