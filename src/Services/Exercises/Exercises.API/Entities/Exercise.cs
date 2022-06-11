using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Exercises.API.Entities
{
    public class Exercise
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public List<MuscleGroup>? MuscleGroups { get; set; }
    }
}
