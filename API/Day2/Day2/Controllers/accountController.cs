using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Day2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class accountController : ControllerBase
    {
        [HttpGet]
        public ActionResult login(string username, string password)
        {
            if (username == "admin" && password == "123")
            {
                #region claims

                List<Claim> userdata = new List<Claim>();
                userdata.Add(new Claim("username", "admin"));
                userdata.Add(new Claim("isAdmin", "true"));
                userdata.Add(new Claim("isStudent", "false"));


                userdata.Add(new Claim(ClaimTypes.MobilePhone, "01064111685"));
                userdata.Add(new Claim(ClaimTypes.Role, "admins"));
                userdata.Add(new Claim(ClaimTypes.Role, "students"));

                #endregion
                #region secret key
                string key = "welcome to my secret key iti Alex";
                var secertkey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));

                #endregion

                var signingcer = new SigningCredentials(secertkey, SecurityAlgorithms.HmacSha256);
                #region generate token 
                //header =>hashing algo
                //payload=>claims,expiredate
                //signture => secertkey
                var token = new JwtSecurityToken(
                    claims: userdata,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: signingcer
                    );

                //token object => encoded string
                //var tokenobjhand = new JwtSecurityTokenHandler();
                //var finaltoken= tokenobjhand.WriteToken(token);
                var tokenstring = new JwtSecurityTokenHandler().WriteToken(token);
                #endregion

                return Ok(tokenstring);

            }
            else
                return Unauthorized();
        }

        [HttpPost]
        [Authorize]
        public ActionResult add()
        {
            return Ok();
        }
    }
    
}
