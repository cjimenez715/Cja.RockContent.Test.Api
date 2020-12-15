using MediatR;

namespace Cja.RockContent.Test.Api.Communication
{
    public class PostLikedEvent: INotification
    {
        public long LikeCounter { get; private set; }

        public PostLikedEvent(long likeCounter)
        {
            LikeCounter = likeCounter;
        }
    }
}
