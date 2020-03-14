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

        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get(string id)
        {
            return this.userService.GetUser(Guid.Parse(id));
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

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            this.userService.DeleteUser(Guid.Parse(id));
        }

    }
}