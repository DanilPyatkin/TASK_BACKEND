using System;
using System.Text.Json.Serialization;

namespace FakeTestApp.Models
{
    public class UserStatisticRequest
    {
        //Класс передачи в Post запрос
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
        [JsonPropertyName("timeFrom")]
        public DateTime TimeFrom { get; set; } 
        [JsonPropertyName("timeTo")]
        public DateTime TimeTo { get; set; }
    }
}
