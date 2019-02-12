namespace BugTracker.BL.Validation
{
    internal static class ErrorMessageGenerator
    {
        public static string AddErrorMessage(this string message, string newMessage)
        {
            if (message == null) message = string.Empty;
            if (message != string.Empty) message += "; ";
            if (string.IsNullOrEmpty(newMessage)) message += newMessage;

            return message;
        }
    }
}
