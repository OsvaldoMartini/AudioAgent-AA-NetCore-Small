using System;
using System.Net;
using System.Threading.Tasks;
using AudioAgentTest.Context;
using AudioAgentTest.Validations;
using Microsoft.AspNetCore.Mvc;

namespace AudioAgentTest.Controller
{
    [Route("v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ImagesStorageController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ImagesStorageController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: v1/ImagesStorage/5
        //[Route("/v1/{controlle}/{url}")]
        [HttpGet("{url}")]
        [Produces("application/json")]
        public async Task<IActionResult> Get(string url)
        {

            if (!ModelState.IsValid)
            {
                var errorList = ValidationFields.GetModelStateErrors(ModelState);
                return Ok(new { success = false, statusText = "Request Fail", errors = errorList, responseText = "<strong>" + "Request Error" + "</strong>" });
            }

            try
            {
                var imageStorage = await _context.ImagesStorage.FindAsync(url);

                if (imageStorage == null)
                {
                    return NotFound();
                }

                return Ok(imageStorage);
            }
            catch (Exception e)
            {
                return Ok(new { HttpStatusCode.InternalServerError, message = "Something went wrong.", error = e.Message });
            }

        }
    }
}
