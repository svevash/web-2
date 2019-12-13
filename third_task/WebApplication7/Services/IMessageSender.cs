using Microsoft.AspNetCore.Http;

namespace WebApplication7.Services
{
    public interface IMessageSender
    {
        string Send(HttpContext context);
    }
}