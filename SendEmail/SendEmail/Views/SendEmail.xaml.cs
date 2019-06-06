using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace SendEmail
{
    public partial class SendEmail : ContentPage
    {
        const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
        public string messages;
        public SendEmail()
        {
            InitializeComponent();
        }

        public Boolean checkAllRight(){
            String notify = "";
            Boolean check = !string.IsNullOrWhiteSpace(firstName.Text)
                            && !string.IsNullOrWhiteSpace(lastName.Text)
                            && !string.IsNullOrWhiteSpace(phoneNumber.Text)
                            && !string.IsNullOrWhiteSpace(EmailEntry.Text);
            if (!check)
            {
                notify = "Please enter your details!";
            }

            if (check && !CheckEmailValid(EmailEntry.Text))
            {
                check = false;
                notify = "Please enter a valid email!";
            }
            messages = notify;
            return check;
        }

        public void notification(String text){
            DisplayAlert("Notification", text, "OK");
        }

        public bool CheckEmailValid(String emailInput)
        {
            bool IsValid = false;
            IsValid = (Regex.IsMatch(emailInput, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
            return IsValid;
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
            }
            //reset all input fields.
            firstName.Text = string.Empty;
            lastName.Text = string.Empty;
            EmailEntry.Text = string.Empty;
            phoneNumber.Text = string.Empty;

            notification(messages);
        }
    }
}
