using Microsoft.AspNetCore.Mvc;
using Fiver.Security.Bearer.Models.Token;
using Fiver.Security.Bearer.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace Fiver.Security.Bearer.Controllers
{
    [Route("token")]
    [AllowAnonymous]
    public class TokenController : Controller
    {
        [HttpPost]
        public IActionResult Create([FromBody]LoginInputModel inputModel)
        {
            if (inputModel.Username != "james" && inputModel.Password != "bond")
                return Unauthorized();

            var token = new JwtTokenBuilder()
                                .AddSecurityKey(JwtSecurityKey.Create("fiver-secret-key"))
                                .AddSubject("james bond")
                                .AddIssuer("Fiver.Security.Bearer")
                                .AddAudience("Fiver.Security.Bearer")
                                .AddClaim("MembershipId", "111")
                                .AddExpiry(2)
                                .Build();

            //return Ok(token);
            return Ok(token.Value);
        }
    }
}
