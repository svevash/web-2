using Microsoft.AspNetCore.Http;

namespace WebApplication7.Services
{
    public class EmailMessageSender : IMessageSender
    {
        private string text;
        public string Send(HttpContext context)
        {
            text = context.Session.GetString("text");
            return text ?? "text empty";
        }
    }
}