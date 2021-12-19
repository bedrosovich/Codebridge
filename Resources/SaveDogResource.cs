using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;


namespace Codebridge.Resources
{
    public class SaveDogResource
    {
        [Required]
        [MaxLength(30)]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        [JsonProperty("color")]
        public string Color { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "tail_Length should be greater than or equal to 0")]
        [JsonProperty("tail_Length")]
        public int Tail_Length { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "weight should be greater than or equal to 0")]
        [JsonProperty("weight")]
        public int Weight { get; set; }
    }
}
