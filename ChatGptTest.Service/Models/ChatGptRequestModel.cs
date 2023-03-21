using System.Text.Json.Serialization;

namespace ChatGptTest.Service.Models
{
    public class ChatGptRequestModel
    {
        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("prompt")]
        public string Prompt { get; set;
        }
        [JsonPropertyName("max_tokens")]
        public int MaxTokens { get; set; }

        [JsonPropertyName("temperature")]
        public decimal Temperature { get; set; }
    }
}
