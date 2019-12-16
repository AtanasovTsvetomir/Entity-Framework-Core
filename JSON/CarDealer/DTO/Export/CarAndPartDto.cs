namespace CarDealer.DTO.Export
{
    using Newtonsoft.Json;

    public class CarAndPartDto
    {
        [JsonProperty("car")]
        public CarInfoDto Car { get; set; }

        [JsonProperty("parts")]
        public PartInfoDto Parts { get; set; }
    }
}
