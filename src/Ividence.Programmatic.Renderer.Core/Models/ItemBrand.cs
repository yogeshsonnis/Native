using Newtonsoft.Json;

namespace Ividence.Programmatic.Renderer.Core.Models
{
    public class ItemBrand : ModelBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("logoUrl")]
        public string LogoUrl { get; set; }
    }
}
