using ChatGptTest.Service.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace ChatGptTest.Service.Services
{
    public class EnglishTutorService : IEnglishTutorService
    {
        private readonly HttpClient _httpClient;
        private readonly string _token = Environment.GetEnvironmentVariable("ChatGptSecretKey");
        private readonly string _host = Environment.GetEnvironmentVariable("ChatGptHost");

        public EnglishTutorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> RequestFromChatGpt(string request)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var resquestModel = CreateRequest(request);

            HttpResponseMessage response = await RequestFromOpenAi(resquestModel);

            var result = await response.Content.ReadFromJsonAsync<ChatGptResponseModel>();

            return BuildResponse(result);
        }

        private static string BuildResponse(ChatGptResponseModel? result)
        {
            var promptResponse = result?.Choices.First();
            return promptResponse.Text.Replace("\n", "").Replace("\t", "");
        }

        private async Task<HttpResponseMessage> RequestFromOpenAi(string resquestModel)
        {
            var content = new StringContent(resquestModel, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_host, content);
            return response;
        }

        private static string CreateRequest(string request)
        {
            var model = new ChatGptRequestModel()
            {
                Prompt = $"Correct this english phrase: {request}",
                Temperature = 0.2m,
                MaxTokens = 100,
                Model = "text-davinci-003"
            };

            return JsonSerializer.Serialize(model);
        }
    }
}
