using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Cja.RockContent.Test.Api.SignalR
{
    public class LikedHub: Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "cristhian.jimenez");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "cristhian.jimenez");
            await base.OnDisconnectedAsync(exception);
        }
    }
}
