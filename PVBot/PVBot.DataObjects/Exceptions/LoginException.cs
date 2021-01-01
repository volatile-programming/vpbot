using System;

namespace PVBot.DataObjects.Exceptions
{
    public class LoginException : Exception
    {
        public new const string Message = "The login prosses has failed.";
    }
}
