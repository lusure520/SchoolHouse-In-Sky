using System;
using System.Net.Mail;
using Xamarin.Forms;

namespace SendEmail
{
    public partial class SendEmail : ContentPage
    {
        public string messages;
        public SendEmail()
        {
            InitializeComponent();
        }

        public Boolean checkAllRight(){
            String notify = "";
            Boolean check = true;
            if (string.IsNullOrWhiteSpace(firstName.Text))
            {
                check = false;
            }

            if (string.IsNullOrWhiteSpace(lastName.Text))
            {
                check = false;
            }

            if (string.IsNullOrWhiteSpace(phoneNumber.Text))
            {
                check = false;
            }

            if (string.IsNullOrWhiteSpace(EmailEntry.Text))
            {
                check = false;
            }

            if(!check)
            {
                notify = "Please enter your details!";
            }
            messages = notify;
            return check;
        }

        public void notification(String text){
            DisplayAlert("Notification", text, "OK");
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {

            if(checkAllRight()){

                var userEmail = EmailEntry.Text;
                var user = firstName.Text + " " + lastName.Text;
                var contactNumber = phoneNumber.Text;

                String signUpSucc = "Welcome to Join us," + firstName.Text + " " + lastName.Text + ". \nYou will get more detail from email!";
                try
                {
                    SmtpClient mySmtpClient = new SmtpClient("smtp.gmail.com", 587)
                    {

                        // set smtp-client with basicAuthentication
                        UseDefaultCredentials = false
                    };
                    System.Net.NetworkCredential basicAuthenticationInfo = new
                        System.Net.NetworkCredential("himalayanmembers", "Himalayan37");
                    mySmtpClient.Credentials = basicAuthenticationInfo;

                    // add from,to mailaddresses - for user
                    MailAddress from = new MailAddress("himalayanmembers@gmail.com", "R&D Development Team");
                    MailAddress to = new MailAddress(userEmail, user);
                    MailMessage myMail = new System.Net.Mail.MailMessage(from, to);

                    // add from,to mailaddresses - for Himalayan Trust
                    MailAddress fromH = new MailAddress("himalayanmembers@gmail.com", "R&D Development Team");
                    MailAddress toH = new MailAddress("himalayanmembers@gmail.com", "User Sign Up");
                    MailMessage myMailH = new System.Net.Mail.MailMessage(fromH, toH);


                    // add ReplyTo - for user
                    MailAddress replyto = new MailAddress("himalayanmembers@gmail.com");
                    myMail.ReplyToList.Add(replyto);

                    // set subject and encoding - for user
                    myMail.Subject = "Himalayan Trust";
                    myMail.SubjectEncoding = System.Text.Encoding.UTF8;

                    // set subject and encoding - for Himalayan Trust
                    myMailH.Subject = "User Sign Up";
                    myMailH.SubjectEncoding = System.Text.Encoding.UTF8;

                    // set body-message and encoding - for user
                    myMail.Body = "<b>Hi," + user + "</b><br><b>"
                        + "Thanks for Signing up to our email newsletter today and we will provide all the latest news,"
                        + " updates, information and ways to get involved straight to your inbox!</b>."
                        + "<br><b>To visited Our website to get more Information:</b>"
                        + "http://himalayantrust.org/";
                    myMail.BodyEncoding = System.Text.Encoding.UTF8;

                    // set body-message and encoding - for Himalayan Trust
                    myMailH.Body = "<b>A new sign up</b>"
                        + "<br><b>Name:</b>" + user
                        + "<br><b>Contact Number:</b>" + contactNumber
                        + "<br><b>Email Address:</b>" + userEmail;
                    myMailH.BodyEncoding = System.Text.Encoding.UTF8;

                    // text or html
                    myMail.IsBodyHtml = true;
                    myMailH.IsBodyHtml = true;
                    mySmtpClient.EnableSsl = true;
                    mySmtpClient.Send(myMailH);
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

                messages = signUpSucc;
                //notification(messages);
                //DisplayAlert("Notification", signUpSucc, "OK");
            }
            notification(messages);
        }
    }
}
