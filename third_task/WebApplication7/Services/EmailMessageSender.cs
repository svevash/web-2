using System.Linq;
using Microsoft.AspNetCore.Http;

namespace WebApplication7.Services
{
    public class EmailMessageSender : IMessageSender
    {
        private string text;
        public string Send(HttpContext context)
        {
            text = context.Session.GetString("text");
            if (!context.Session.Keys.Contains("text"))
            {
                context.Session.SetString("text", "goodbye");
            }
            return text ?? "text empty";
        }
    }
}