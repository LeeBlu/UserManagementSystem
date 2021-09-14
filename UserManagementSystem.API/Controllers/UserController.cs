using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementSystem.API.Model.Interface;
using UserManagementSystem.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser UserRepository;


        public UserController(IUser _userRepository)
        {
            this.UserRepository = _userRepository;
        }

        // GET: api/<UserController>
        [HttpGet]
        [HttpGet("GetAllUsers")]
        public async Task<ActionResult> Get()
        {
            try
            {
                return Ok(await UserRepository.GetAllUsers());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving from the database");
            }
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                return Ok(await UserRepository.GetUser(id));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving from the database");
            }
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] User newUser)
        {
            try
            {
                if (newUser == null)
                 return BadRequest();
                

                var createdproduct = await UserRepository.CreateUser(newUser);
                return Ok(createdproduct);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // PUT api/<UserController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] User updateUser)
        {
            try
            {

                var userToUpdate = await UserRepository.GetUser(updateUser.Id);

                if (userToUpdate == null)
                {
                    return NotFound($"user not found");
                }

                return Ok(await UserRepository.UpdateUser(updateUser));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var userToDelete = await UserRepository.GetUser(id);

                if (userToDelete == null)
                   return NotFound($"Product not found");
                

                await UserRepository.DeleteUser(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}

