using ChatGptTest.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChatGptTest.API.Controllers
{
    [ApiController]
    [Route("api/english-tutor")]
    public class EnglishTutorController : Controller
    {
        private readonly IEnglishTutorService _englishTutorService;

        public EnglishTutorController(IEnglishTutorService englishTutorService)
        {
            _englishTutorService = englishTutorService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string text)
        {
            var result = await _englishTutorService.RequestFromChatGpt(text);
            return Ok(result);
        }
    }
}
