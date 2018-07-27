using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.CopaMundo.Filmes.Domain
{
    public class Filme
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("PrimaryTitle")]
        public string primaryTitle { get; set; }
        [JsonProperty("Year")]
        public string year { get; set; }
        [JsonProperty("AverageRating")]
        public double averageRating { get; set; }

    }
}
