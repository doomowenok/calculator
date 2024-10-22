using Infrastructure.MVP;

namespace Core.Features.Info
{
    public sealed class InfoShowParams : IShowParams
    {
        public string Message { get; private set; }

        public InfoShowParams(string message)
        {
            Message = message;
        }
    }
}