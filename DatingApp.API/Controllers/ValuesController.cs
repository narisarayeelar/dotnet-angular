using System.Collections.Generic;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DatingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {

        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var result = await _context.Values.ToListAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetValue(int id){
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(value);
        }
    }
}