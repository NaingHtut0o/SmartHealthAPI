using System.Net.Mail;

namespace SmartHealthAPI.Utilities
{
    public static class Validator
    {
        // Email Validation
        public static bool ValidateEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
