using Cja.RockContent.Test.Api.Models;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

namespace Cja.RockContent.Test.Api.Services
{
    public class Repository: IRepository
    {
        private readonly IMongoCollection<PostLike> _postLike;

        public Repository(IPostLikedataseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _postLike = database.GetCollection<PostLike>(settings.PostLikeCollectionName);
        }

        public PostLike GetByIdAsync(string id)
        {
            return _postLike.Find(p => p.Id == id).FirstOrDefault();
        }

        public async Task OnPostLike(string id, PostLike postLike)
        {
            await _postLike.ReplaceOneAsync(p => p.Id == id, postLike);
        }
    }
}
