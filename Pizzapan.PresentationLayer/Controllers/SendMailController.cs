using Microsoft.AspNetCore.Mvc;
using Pizzapan.PresentationLayer.Models;
using MimeKit;
using MailKit.Net.Smtp;

namespace Pizzapan.PresentationLayer.Controllers
{
    public class SendMailController : Controller
    {
        private InternetAddress mailboxAddressFrom;

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "zehraisbr@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAdressTo = new MailboxAddress("User", mailRequest.ReceiverMail);
            mimeMessage.To.Add(mailboxAdressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mailRequest.MessageContent;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = mailRequest.Subject;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("zehraisbr@gmail.com ", "awdcrpcyfsavjpjb");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);
            return View();
        }
        }
    }

