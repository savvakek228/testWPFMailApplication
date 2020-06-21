using System;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace TestApp
{
    class WPFEmailer
    {
        enum SendUsing
        {
            Network,
            PickupDirectory,
            SpecifiedPickupDirectory
        }
        enum AuthenticationMode
        {                
            PlainText,
            NoAuthentication,
            NTLMAuthentication
        }
        static string From, To, User, Password, Subject, Body, AttachmentPath, CC;
        static WPFEmailer EmailerInstance;
        public readonly string Host = "127.0.0.1";
        public readonly int Port = 25;
        bool IsHtml = false;
        SendUsing sendMethod = SendUsing.Network;
        bool UseSSL = true;
        AuthenticationMode authMode = AuthenticationMode.PlainText;

        public static WPFEmailer getEmailerInstance(string from, string to, string user, string password, string subject, string body)
        {
            if (EmailerInstance == null)
                EmailerInstance = new WPFEmailer(from, to, user, password, subject, body);
            return EmailerInstance;
        }

        protected WPFEmailer(string from,string to,string user,string password,string subject,string body)
        {
            From = from;
            To = to;
            User = user;
            Password = password;
            Subject = subject;
            Body = body;
        }
        public async void SendEmail()
        {
            await Task.Run(() => SendMessage());
        }
        /// <summary>
        /// Send Email Message method.
        /// </summary>
        private void SendMessage()
        {
            try
            {
                MailMessage oMessage = new MailMessage();
                SmtpClient smtpClient = new SmtpClient(Host);
                oMessage.From = new MailAddress(From);
                oMessage.To.Add(To);
                oMessage.Subject = Subject;
                oMessage.IsBodyHtml = IsHtml;
                oMessage.Body = Body;
                smtpClient.Port = Port;
                smtpClient.EnableSsl = UseSSL;

                if (CC != string.Empty)
                    oMessage.CC.Add(CC);

                switch (sendMethod)
                {
                    case SendUsing.PickupDirectory:
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
                        break;
                    case SendUsing.SpecifiedPickupDirectory:
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                        break;
                    default:
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        break;
                }
                if (authMode > 0)
                {
                    smtpClient.Credentials = new NetworkCredential(User, Password);
                }
                // Create and add the attachment
                if (AttachmentPath != string.Empty)
                {
                    oMessage.Attachments.Add(new Attachment(AttachmentPath));
                }     
                // Deliver the message    
                smtpClient.Send(oMessage);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}

