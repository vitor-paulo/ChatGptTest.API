namespace ChatGptTest.Service.Services
{
    public interface IEnglishTutorService
    {
        Task<string> RequestFromChatGpt(string request);
    }
}
