using FBLibros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FBLibros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {

        private readonly AplicationDbContext _context;
        public LibroController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<LibroController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listLibro = await _context.Libro.ToListAsync();
                return Ok(listLibro);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET api/<LibroController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LibroController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Libro libros)
        {
            try
            {
                _context.Add(libros);
                await _context.SaveChangesAsync();
                return Ok(libros);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<LibroController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Libro libros)
        {
            try
            {
                if (id != libros.Id)
                {
                    return NotFound();

                }
                _context.Update(libros);
                await _context.SaveChangesAsync();
                return Ok(new { message = "El libro fue actualizado con exito!" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

        // DELETE api/<LibroController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var libro = await _context.Libro.FindAsync(id);

                if (libro == null)
                {
                    return NotFound();
                }

                _context.Libro.Remove(libro);
                await _context.SaveChangesAsync();
                return Ok(new { message = "El libro fue eliminado  con exito" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
