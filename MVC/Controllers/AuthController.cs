using Business.Abstract;
using Entities.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost("Login")]
        public IActionResult Login(LoginDTO loginDTO)
        {
            var userToLogin = _authService.Login(loginDTO);
            if (!userToLogin.Success)
            {
                return NotFound();
            }
            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                };
                Response.Cookies.Append("accessToken", result.Data.Token, cookieOptions);
                return RedirectToAction("Index", "Home");
            }
            return NotFound();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost("Register")]
        public IActionResult Register(RegisterDTO userForRegisterDTO)
        {
            var userExists = _authService.UserExist(userForRegisterDTO.Email);
            if(!userExists.Success)
            {
                return NotFound();
            }
            var registerResult = _authService.Register(userForRegisterDTO, userForRegisterDTO.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if(result.Success)
            {
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    //Expires = DateTime.Now.AddDays(1)
                };
                Response.Cookies.Append("accessToken", result.Data.Token, cookieOptions);
                return RedirectToAction("Index", "Home");
            }
            return NotFound();
        }
        
    }
}
