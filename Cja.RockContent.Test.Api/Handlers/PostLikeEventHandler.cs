using Cja.RockContent.Test.Api.Communication;
using Cja.RockContent.Test.Api.SignalR;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using System.Threading;
using System.Threading.Tasks;

namespace Cja.RockContent.Test.Api.Handlers
{
    public class PostLikeEventHandler : INotificationHandler<PostLikedEvent>
    {
        private readonly IHubContext<LikedHub> _hubContext;

        public PostLikeEventHandler(IHubContext<LikedHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task Handle(PostLikedEvent notification, CancellationToken cancellationToken)
        {
            await _hubContext.Clients
                .Group("cristhian.jimenez")
                .SendAsync("LikeOnArticle", "cristhian.jimenez", notification.LikeCounter);
        }
    }
}
