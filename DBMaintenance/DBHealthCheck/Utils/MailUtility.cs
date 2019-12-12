using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace DBHealthCheck.Utils
{
    public interface IMailConfig
    {
        string DisplayName { get; }
        string EmailFrom { get; }
        string MailServer { get; }
        int MailServerPort { get; }
        string UserName { get; }
        string Password { get; }
        string MailTo { get; }
    }

    public class MailUtility
    {
        private SmtpClient mailClient;
        private string displayName;
        private string emailFrom;
        private string mailTo;

        public MailUtility(IMailConfig config)
        {
            mailClient = new SmtpClient();

            mailClient.UseDefaultCredentials = false;
            mailClient.Host = config.MailServer;
            if (config.MailServerPort != 0)
                mailClient.Port = config.MailServerPort;
            mailClient.Credentials = new NetworkCredential(config.UserName, config.Password);

            displayName = config.DisplayName;
            emailFrom = config.EmailFrom;
            mailTo = config.MailTo;
        }

        public void SendMail(string body, string subject, string fileName = "", bool async = true)
        {
            try
            {
                MailMessage Message = new MailMessage();

                Message.From = new MailAddress(emailFrom, displayName);

                string[] Tos = mailTo.Split(',');
                foreach (string To in Tos)
                    Message.To.Add(To);

                Message.Subject = subject;
                Message.Body = body;

                Message.Priority = MailPriority.Normal;
                Message.IsBodyHtml = true;
                if(!String.IsNullOrEmpty(fileName))
                    Message.Attachments.Add(new Attachment(fileName, new System.Net.Mime.ContentType("text/plain")));

                if (async)
                {
                    //wire up the event for when the Async send is completed
                    object userState = Message;
                    mailClient.SendCompleted += new SendCompletedEventHandler(SmtpClient_OnCompleted);

                    mailClient.SendAsync(Message, userState);
                }
                else
                    mailClient.Send(Message);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void SmtpClient_OnCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //Get the Original MailMessage object
            MailMessage mail = (MailMessage)e.UserState;

            //write out the subject
            string subject = mail.Subject;

            if (e.Error != null)
            {
                Debug.WriteLine("Error {1} occurred when sending mail [{0}] ", subject, e.Error.ToString());
            }
            else
            {
                Debug.WriteLine("Message [{0}] sent.", subject);
            }
        }
    }
}
