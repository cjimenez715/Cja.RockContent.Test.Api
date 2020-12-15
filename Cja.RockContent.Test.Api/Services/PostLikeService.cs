using Cja.RockContent.Test.Api.Communication;
using Cja.RockContent.Test.Api.Models;
using System.Threading.Tasks;

namespace Cja.RockContent.Test.Api.Services
{
    public class PostLikeService: IPostLikeService
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IRepository _repository;
        
        public PostLikeService(IMediatorHandler mediatorHandler, IRepository repository)
        {
            _mediatorHandler = mediatorHandler;
            _repository = repository;
        }

        public PostLike GetByIdAsync(string id)
        {
             return _repository.GetByIdAsync(id);
        }

        public async Task OnPostLike(string id, PostLike postLike)
        {
            postLike.Like();

            await _mediatorHandler.PublishEvent(new PostLikedEvent(postLike.LikeCounter));

            await _repository.OnPostLike(id, postLike);
        }

    }
}
