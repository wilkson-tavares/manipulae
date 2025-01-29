using Manipulae.Exception;
using FluentValidation;
using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace Manipulae.Application.UseCases.Users
{
    public partial class PasswordValidator<T> : PropertyValidator<T, string>
    {
        private const string ERROR_MESSAGE_KEY = "ErrorMessage";
        public override string Name => "PasswordValidator";

        protected override string GetDefaultMessageTemplate(string errorCode)
        {
            return $"{{{ERROR_MESSAGE_KEY}}}";
        }

        public override bool IsValid(ValidationContext<T> context, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, "Invalid Password: Contains null value or white space");
                return false;
            }

            if (password.Length < 8)
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, "Invalid Password: Lenght less than 8");
                return false;
            }

            if (UpperCaseLetter().IsMatch(password) == false)
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, "Invalid Password: Missing upper case letter");
                return false;
            }

            if (LowerCaseLetter().IsMatch(password) == false)
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, "Invalid Password: Missing lower case letter");
                return false;
            }

            if (Numbers().IsMatch(password) == false)
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, "Invalid Password: Missing numbers");
                return false;
            }

            if (SpecialCharactere().IsMatch(password) == false)
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, "Invalid Password: Missing special charactere");
                return false;
            }

            return true;
        }

        #region Regex
        [GeneratedRegex(@"[A-Z]+")]
        private static partial Regex UpperCaseLetter();

        [GeneratedRegex(@"[a-z]+")]
        private static partial Regex LowerCaseLetter();
        [GeneratedRegex(@"[0-9]+")]
        private static partial Regex Numbers();

        [GeneratedRegex(@"[\!\?\*\.\@\#\$\%\&]+")]
        private static partial Regex SpecialCharactere();

        #endregion
    }
}
