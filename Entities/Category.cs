using System.Text.Json.Serialization;

namespace SurvivorWebApi.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Competitor> Competitors { get; set; }
    }
}
