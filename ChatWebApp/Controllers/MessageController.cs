using net_core_chat.Models;
using net_core_chat.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace net_core_chat.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController: ControllerBase
    {
        private readonly MessageService _messageService;

        public MessageController(MessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public ActionResult<List<Message>> Get() =>
            _messageService.Get();
        
        [HttpGet("{id:length(24)}", Name = "GetMessage")]
        public ActionResult<Message> Get(string id)
        {
            var message = _messageService.Get(id);

            if (message == null)
            {
                return NotFound();
            }

            return message;
        }

        [HttpPost]
        public ActionResult<Message> Create(Message message)
        {
            _messageService.Create(message);

            return CreatedAtRoute("GetMessage", new { id = message.Id.ToString() }, message);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Message messageIn)
        {
            var message = _messageService.Get(id);

            if (message == null)
            {
                return NotFound();
            }

            _messageService.Update(id, messageIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var message = _messageService.Get(id);

            if (message == null)
            {
                return NotFound();
            }

            _messageService.Remove(message.Id);

            return NoContent();
        }

        // [HttpGet("get-room-messages")]  // GET /api/get-room-messages      
        // public ActionResult<List<Message>> GetRoomMessages(string room)
        // {
        //     var messages = _messageService.GetRoomMessages(room);

        //     if (messages == null)
        //     {
        //         return NotFound();
        //     }

        //     return messages;
        // }

    }
}