using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;
namespace SendEmail
{
    public class InputValidation : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += Bindable_TextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);

            bindable.TextChanged -= Bindable_TextChanged;
        }

        void Bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            var email = e.NewTextValue;

            //var emailPattern = "^(?(\")(\".+?(?<!\\\\)\"@)|(([0 - 9a - z]((\\.(?!\\.))|[-!#\\$%&\'\\*\\+/=\\?\\^`\\{\\}\\|~\\w])*)(?<=[0-9a-z])@))(?(\\[)(\\[(\\d{1,3}\\.){3}\\d{1,3}\\])|(([0-9a-z][-\\w]*[0-9a-z]*\\.)+[a-z0-9][\\-a-z0-9]{0,22}[a-z0-9]))$";

            var emailPattern = "^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$";
            var emailEntry = sender as Entry;

            if (Regex.IsMatch(email, emailPattern))
            {
                emailEntry.BackgroundColor = Color.Transparent;
            }
            else{
                emailEntry.BackgroundColor = Color.Yellow;
            }
        }
    }
}
