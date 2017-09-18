namespace Web.Controllers
{
    using System;
    using System.Linq;

    using Core;

    using Microsoft.AspNetCore.Mvc;

    using Services;

    using Web.Dto.Request;
    using Web.Mapping;

    [Route("api/notes")]
    public class NotesController : Controller
    {
        private readonly INoteService _notesService;

        public NotesController(INoteService notesService)
        {
            _notesService = notesService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var responseData = _notesService.GetAll()
                .OrderByDescending(t => t.CreateDateTime)
                .Where(t => t.IsAlreadyExpired() == false)
                .ToDto();
            return Json(responseData);
        }

        [HttpGet(template: "{id}")]
        public IActionResult GetNoteById(string id)
        {
            JsonResult result;
            if (string.IsNullOrEmpty(id) == false)
            {
                var item = _notesService.GetById(id);

                if (item == null)
                {
                    return NotFound();
                }

                if (item.IsAlreadyExpired())
                {
                    return NotFound();
                }

                var dto = item.ToDto();
                result = Json(dto);
            }
            else
            {
                return BadRequest("id cannot be equal null");
            }

            return result;
        }

        [HttpPost]
        public IActionResult PostMethod([FromBody] NewNoteRequestDto model)
        {
            if (ModelState.IsValid)
            {
                var dateTimeOffset = NotesService.GetDateTimeOffsetValue(model.Lifetime);

                var item = new NoteRepositoryItem
                               {
                                   Id = NotesService.GenerateId(),
                                   Title = model.Title,
                                   Text = model.NoteText,
                                   CreateDateTime = DateTime.UtcNow,
                                   Lifetime = dateTimeOffset
                               };

                try
                {
                    _notesService.Add(item);
                }
                catch (Exception exception)
                {
                    // todo: log exception
                    return BadRequest("Can't add the note. Server error.");
                }

                var result = item.ToDto();

                return Ok(result);
            }

            return BadRequest(ModelState);
        }
    }
}