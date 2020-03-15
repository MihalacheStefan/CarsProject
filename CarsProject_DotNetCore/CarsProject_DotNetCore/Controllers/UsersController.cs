using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.Interfaces;

namespace CarsProject_DotNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService userService;


        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetAll()
        {
            return this.userService.GetUsers().ToList();
        }

        [HttpGet("{name}")]
        public ActionResult<UserDTO> Get(string name)
        {
            return this.userService.GetUser(name);
        }

        [HttpPost]
        public void Post([FromBody] UserDTO userDTO)
        {
            this.userService.InsertUser(userDTO);
        }

        [HttpPut]
        public void Put([FromBody] UserDTO userDTO)
        {
            this.userService.UpdateUser(userDTO);
        }

        [HttpDelete("{name}")]
        public void Delete(string name)
        {
            this.userService.DeleteUser(name);
        }

    }
}