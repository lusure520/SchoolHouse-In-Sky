using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace SendEmail.Validation
{
    //A generate letter validation class.
    public class LetterValidatorBehavior : Behavior<Entry>
    {
        const string numberRegex = @"^[a-zA-Z]+$";//A simple pattern for letter validation.
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(bindable);
        }

        //A onchange method that only the letter  allow to input.
        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            if (!string.IsNullOrWhiteSpace(args.NewTextValue))
            {
                bool IsValid = (Regex.IsMatch(args.NewTextValue, numberRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
                ((Entry)sender).Text = IsValid ? args.NewTextValue : args.NewTextValue.Remove(args.NewTextValue.Length - 1);
            }
        }
    }
}

