using Newtonsoft.Json;

namespace Ividence.Programmatic.Renderer.Core.Models
{
    public class ItemCategory : ModelBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
