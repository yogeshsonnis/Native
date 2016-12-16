using Newtonsoft.Json;

namespace Ividence.Programmatic.Renderer.Core.Models
{

    public class Item : ModelBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("cta")]
        public string CallToAction { get; set; }

        [JsonProperty("clickUrl")]
        public string ClickUrl { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("merchant")]
        public Merchant Merchant { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("brand")]
        public ItemBrand Brand { get; set; }

        [JsonProperty("category")]
        public ItemCategory Category { get; set; }

        [JsonProperty("provider")]
        public ItemProvider ProviderInfo {  get; set; }
    }
}