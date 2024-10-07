using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Text.Json.Serialization;
namespace SurvivorWebApi.Entities
{
    public class Competitor : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CategoryId { get; set; }
       
        [JsonIgnore]
        public Category Category { get; set; }
    }
}



