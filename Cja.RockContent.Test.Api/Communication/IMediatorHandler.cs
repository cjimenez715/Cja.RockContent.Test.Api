using System.Threading.Tasks;

namespace Cja.RockContent.Test.Api.Communication
{
    public interface IMediatorHandler 
    {
        Task PublishEvent<T>(T message);
    }
}
