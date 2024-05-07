using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Notely.Models.Entities;
using Notely.Models.Models;
using Notely.Services;
using Microsoft.AspNetCore.JsonPatch;

namespace Notely.API.Controllers
{
    [Route("api/notes")]
    [ApiController]
    public class NotesController(INotesRepository notesRepository, IMapper mapper) : ControllerBase
    {

        private readonly INotesRepository _notesRepository = notesRepository ?? throw new ArgumentNullException(nameof(notesRepository));
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotesDto>>> GetNotes() {
            var notes = await _notesRepository.GetNotesAsync();
            return Ok(_mapper.Map<IEnumerable<NotesDto>>(notes));
        }

        [HttpGet("{noteId}", Name ="Get Note")]
        public async Task<ActionResult<NotesDto>> GetNote(int noteId) {

            var note = await _notesRepository.GetNoteAsync(noteId);

            if(note == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<NotesDto>(note));
        }

        [HttpPost]
        public async Task<ActionResult<NotesDto>> CreateNote(NotesForCreationDto note) {
            var noteToCreate = _mapper.Map<Notes>(note);

            await _notesRepository.AddNoteAsync(noteToCreate);
            await _notesRepository.SaveChangesAsync();

            var noteToReturn = _mapper.Map<NotesDto>(noteToCreate);

            return CreatedAtRoute("Get Note", new
            {
                noteId = noteToReturn.Id,
            }, 
            noteToReturn);
        }

        [HttpPut("{noteId}")]
        public async Task<ActionResult<NotesDto>> UpdateNote(int noteId, NotesForUpdateDto noteToUpdateDto) {
            var note = await _notesRepository.GetNoteAsync(noteId);

            if(note == null)
            {
                return NotFound();
            }

            _mapper.Map(noteToUpdateDto, note);
            await _notesRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{noteId}")]
        public async Task<ActionResult<NotesDto>> PartiallyUpdateNote(int noteId, JsonPatchDocument<NotesForUpdateDto> patchDocument)
        {
            var note = await _notesRepository.GetNoteAsync(noteId);

            if (note == null)
            {
                return NotFound();
            }

            var noteToPatch =  _mapper.Map<NotesForUpdateDto>(note);

            patchDocument.ApplyTo(noteToPatch);

            if(!ModelState.IsValid || !TryValidateModel(noteToPatch))
            {
                return BadRequest();
            }

            _mapper.Map(noteToPatch, note);
            await _notesRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{noteId}")]
        public async Task<ActionResult> DeleteNote(int noteId) {
            var note = await _notesRepository.GetNoteAsync(noteId);

            if(note == null)
            {
                return NotFound();
            }

            _notesRepository.DeleteNote(note);
            await _notesRepository.SaveChangesAsync();

            return NoContent();
        }  
    }
}