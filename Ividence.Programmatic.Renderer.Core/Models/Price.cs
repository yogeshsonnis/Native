using Newtonsoft.Json;

namespace Ividence.Programmatic.Renderer.Core.Models
{    
    public class Price : ModelBase
    {
        [JsonProperty("value")]
        public double Value { get; set; }

        [JsonProperty("shippingCost")]
        public double ShippingCost { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonIgnore]
        public double Total => Value + ShippingCost;
    }
}
