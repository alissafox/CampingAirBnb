using Camping.Data;
using Camping.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;



namespace Camping.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private DataContext _data;
        public UserController (DataContext data)
        {
            this._data = data;
        }

        [HttpPost("login")]

        public IActionResult LogIn (LogInUser login)
        {
            var users = _data.GetAllUsers();
            var checkUser = users.FirstOrDefault(e_user => e_user.Email == login.Email && e_user.Password == login.Password);
            if (checkUser != null)
            {
                return Ok(checkUser);
            }
            else
            {
                return Unauthorized("Wrong username or password");
            }
        }
        [HttpPost("register")]
        
        public IActionResult UserRegistr(User user)
        {
            _data.UserRegestration(user);
            return Ok("Regestration successful");
        }
        [HttpGet("all")]
       
        public IActionResult GetAll()
        {
            var users = _data.GetAllUsers();
            return Ok(users);
        }
        [HttpGet("getUsId/{userId}")]
       
        public IActionResult Get(int userId)
        {
            var user = _data.GetUserById(userId);
            return Ok(user);
        }
        [HttpPut("putUsId/{userId}")]
        public IActionResult Update(int userId,User user)
        {
            var existingUser = _data.GetUserById(userId);
            if (existingUser == null)
            {
                return NotFound("User not found");
            }
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            var users = _data.Users;
            users.Update(existingUser);
            return Ok("Information updated successfully");
        }
      
    }
}
