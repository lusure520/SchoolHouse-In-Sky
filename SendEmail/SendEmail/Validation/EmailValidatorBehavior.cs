using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace SendEmail.Validation
{
    //A generate email validation class.
    public class EmailValidatorBehavior : Behavior<Entry>
    {
        //A simple pattern for email validation.
        const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
            
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
            base.OnAttachedTo(bindable);
        }

        //A onchange method that check the email input value,if the value fetch pattern set font color to white, otherwise red. 
        void HandleTextChanged(object sender, TextChangedEventArgs args)
        {
            if (!string.IsNullOrWhiteSpace(args.NewTextValue))
            {
                bool IsValid = false;
                IsValid = (Regex.IsMatch(args.NewTextValue, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
                ((Entry)sender).TextColor = IsValid ? Color.White : Color.Red;
            }
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
            base.OnDetachingFrom(bindable);
        }
    }
}


