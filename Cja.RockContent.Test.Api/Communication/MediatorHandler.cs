using MediatR;
using System.Threading.Tasks;

namespace Cja.RockContent.Test.Api.Communication
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;
        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task PublishEvent<T>(T message)
        {
           await _mediator.Publish(message);
        }
    }
}
