using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotesApi.Models;
using NotesApi.Services;

namespace NotesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly NotesService _service;

        public NotesController(NotesService service)
        {
            _service = service;
        }

        // GET api/notes
        [HttpGet]
        public ActionResult<List<Note>> GetAllNotes()
        {
            try
            {
                return Ok(_service.GetAllNotes());
            }
            catch (System.Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET api/notes/1
        [HttpGet("{id}")]
        public ActionResult<Note> GetNote(int id)
        {
            try
            {
                return Ok(_service.GetNote(id));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/notes
        [HttpPost]
        public ActionResult<Note> AddNote([FromBody] NoteInput newNote)
        {
            return _service.AddNote(newNote);
        }

        // PUT api/notes/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }

        // DELETE api/notes/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                _service.DeleteNote(id);
                return StatusCode((int)HttpStatusCode.NoContent);
            }
            catch (System.Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
