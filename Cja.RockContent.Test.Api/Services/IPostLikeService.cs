using Cja.RockContent.Test.Api.Models;
using System.Threading.Tasks;

namespace Cja.RockContent.Test.Api.Services
{
    public interface IPostLikeService
    {
        PostLike GetByIdAsync(string id);
        Task OnPostLike(string id, PostLike postLike);
    }
}
