using Newtonsoft.Json;

namespace Ividence.Programmatic.Renderer.Core.Models
{
    public class ItemProvider : ModelBase
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("logoUrl")]
        public string LogoUrl { get; set;}
    }
}
