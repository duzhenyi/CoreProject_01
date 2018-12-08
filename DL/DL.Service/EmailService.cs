using DL.IService;
using System;
using System.Threading.Tasks;

namespace DL.Service
{
    public class EmailService : IEmailService
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Task.CompletedTask;
        }
    }
}
