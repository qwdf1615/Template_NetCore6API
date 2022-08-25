using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCore6API_Sample.Data;
using NetCore6API_Sample.Models;

namespace NetCore6API_Sample.Controllers
{
    /// <summary>
    /// 參考 https://docs.microsoft.com/zh-tw/aspnet/core/web-api/action-return-types?view=aspnetcore-6.0
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SampleAPIController : ControllerBase
    {
        private readonly SampleDBContext _context;

        public SampleAPIController(SampleDBContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<TblItem>> Get()
        {
            return await _context.TblItems.ToListAsync();            
        }

        [HttpGet("id")]
        [ProducesResponseType(typeof(TblItem), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _context.TblItems.FindAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(TblItem), StatusCodes.Status201Created)] // Create Http Code = 201
        public async Task<IActionResult> Create(TblItem tblItem)
        {
            await _context.TblItems.AddAsync(tblItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = tblItem.Id}, tblItem);
        }

        [HttpPut("id")]
        [ProducesResponseType(typeof(TblItem), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(TblItem), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, TblItem tblItem)
        {
            // check key or Role
            if (id != tblItem.Id)
                return BadRequest();

            _context.Entry(tblItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("id")]
        [ProducesResponseType(typeof(TblItem), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(TblItem), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var dataToDelete = await _context.TblItems.FindAsync(id);
            if (dataToDelete == null)
                return NotFound();

            _context.TblItems.Remove(dataToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
    }
}
