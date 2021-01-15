using System.Collections.Generic;
using BussinessLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;

namespace DemoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminBL adminBL;
        public AdminController(IAdminBL adminBL)
        {
            this.adminBL = adminBL;

        }
        // GET api/values
        [HttpGet("Admins")]
        public ActionResult<IEnumerable<string>> Get()
        {
            var result = this.adminBL.GetAllEmployee();
            if (result.Count != 0)
            {
                return this.Ok(new { success = true, Message = "Get All Users successfully", Data = result });
            }
            else
            {
                return this.NotFound(new { success = false, Message = "Get All Users unsuccessfully" });
            }
        }

       

        // POST api/values
        [HttpPost("Admin")]
        public IActionResult Post([FromBody] Admin user)
        {
            if (adminBL.Register(user))
            {
                return this.Ok(new { success = true, Message = "Admin registered successfully" });
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { success = false, Message = "Admin not added " });
            }
        }

        // PUT api/values
        [HttpPut("update")]
        public IActionResult Put( [FromBody] Admin admin)
        {
            if (adminBL.Update(admin))
            {
                return this.Ok(new { success = true, Message = "Admin Updated successfully" });
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { success = false, Message = "Admin not updated " });
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (adminBL.Delete(id))
            {
                return this.Ok(new { success = true, Message = "Admin Deleted successfully" });
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { success = false, Message = "Admin not Deleted " });
            }
        }
        [HttpPut("login/{adminName}/{adminPassword}")]
        public IActionResult Login(string adminName,string adminPassword)
        {
            if (adminBL.Login(adminName, adminPassword))
            {
                return this.Ok(new { success = true, Message = "Admin Login successfully" });
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { success = false, Message = "Login unsuccessful" });
            }
        }

    }
}
