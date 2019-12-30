namespace RenewalLatterGenerator.Exceptions
{
    using System;

    public class InvitationNotGeneratedException : Exception
    {
        public InvitationNotGeneratedException(string message) : base(message)
        {
        }
    }
}
