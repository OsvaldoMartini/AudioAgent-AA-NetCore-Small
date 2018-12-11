using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AudioAgentTest.Context;
using AudioAgentTest.Model;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> Get(string url)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var imageStorage = await _context.ImagesStorage.FindAsync(url);

            if (imageStorage == null)
            {
                return NotFound();
            }

            return Ok(imageStorage);
        }


    }
}
