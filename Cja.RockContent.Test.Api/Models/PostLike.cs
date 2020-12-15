using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cja.RockContent.Test.Api.Models
{
    public class PostLike
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }

        public long LikeCounter { get; private set; }

        public PostLike()
        {
            LikeCounter = 0;
        }

        public void Like()
        {
            LikeCounter++;
        }
    }
}
