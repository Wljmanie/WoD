using Microsoft.AspNetCore.Identity.UI.Services;

namespace WoD.Services.Interfaces
{
    public interface IWoDEmailSender : IEmailSender
    {
        Task SendContactEmailAsync(string emailFrom, string name, string subject, string htmlMessage);
    }
}
