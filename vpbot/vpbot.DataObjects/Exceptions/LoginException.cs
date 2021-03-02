using System;

namespace VPBot.DataObjects.Exceptions
{
    public class LoginException : Exception
    {
        public new const string Message = "The login prosses has failed.";
    }
}
