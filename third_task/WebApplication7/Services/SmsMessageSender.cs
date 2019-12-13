using Microsoft.AspNetCore.Http;

namespace WebApplication7.Services
{
    public class SmsMessageSender : IMessageSender
    {
        private string text;

        public string Send(HttpContext context)
        {
            text = context.Request.Cookies["text"];
            return text ?? "text empty";
        }
    }
}