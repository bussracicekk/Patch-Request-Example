using Newtonsoft.Json;

namespace PatchRequest.Model
{
   
    [JsonObject(MemberSerialization.OptIn)]
    public partial class Movie
    {
        [JsonProperty(PropertyName = "id")]
        public virtual int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public virtual string Name { get; set; }

        [JsonProperty(PropertyName = "director")]
        public virtual string Director { get; set; }

        [JsonProperty(PropertyName = "releasedate")]
        public virtual DateTime? ReleaseDate { get; set; }

        public Movie(int id, string title, string director, DateTime? releaseDate)
        {
            Id = id;
            Name = title;
            Director = director;
            ReleaseDate = releaseDate;
        }
    }
}
