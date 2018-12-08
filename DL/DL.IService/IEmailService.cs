using System;
using System.Threading.Tasks;

namespace DL.IService
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
