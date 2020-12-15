
namespace Cja.RockContent.Test.Api.Models
{
    public class PostLikedataseSettings : IPostLikedataseSettings
    {
        public string PostLikeCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IPostLikedataseSettings
    {
        public string PostLikeCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
