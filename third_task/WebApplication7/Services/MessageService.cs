using Microsoft.AspNetCore.Http;

namespace WebApplication7.Services
{
    public class MessageService : IMessageSender
    {
        IMessageSender _sender;
        public MessageService(IMessageSender sender)
        {
            _sender = sender;
        }
        public string Send(HttpContext context)
        {
            return _sender.Send(context);
        }
    }
}