using System;
using Xamarin.Forms;
using System.Net.Mail;

namespace SendEmail
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var toEmail = EmailEntry.Text;

            String signUpSucc = "Welcome to Join us," + firstName.Text +" "+ lastName.Text +". \nYou will get more detail from email!";
            try
            {
                SmtpClient mySmtpClient = new SmtpClient("smtp.gmail.com", 587)
                {

                    // set smtp-client with basicAuthentication
                    UseDefaultCredentials = false
                };
                System.Net.NetworkCredential basicAuthenticationInfo = new
                    System.Net.NetworkCredential("dengyuanlu", "WOcaonim2");
                mySmtpClient.Credentials = basicAuthenticationInfo;

                // add from,to mailaddresses
                MailAddress from = new MailAddress("deng@51any.com", "TestFromName");
                MailAddress to = new MailAddress(toEmail, "TestToName");
                MailMessage myMail = new System.Net.Mail.MailMessage(from, to);

                // add ReplyTo
                MailAddress replyto = new MailAddress("dengyuanlu+test1@gmail.com");
                myMail.ReplyToList.Add(replyto);

                // set subject and encoding
                myMail.Subject = "Test message";
                myMail.SubjectEncoding = System.Text.Encoding.UTF8;

                // set body-message and encoding
                myMail.Body = "<b>Test Mail</b><br>using <b>HTML</b>.";
                myMail.BodyEncoding = System.Text.Encoding.UTF8;
                // text or html
                myMail.IsBodyHtml = true;
                mySmtpClient.EnableSsl = true;
                mySmtpClient.Send(myMail);
            }

            catch (SmtpException ex)
            {
                throw new ApplicationException
                  ("SmtpException has occured: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            DisplayAlert("Notification", signUpSucc, "Ok");
        }
    }
}
