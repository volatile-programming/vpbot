using System;
using System.Collections.Generic;
using System.Text;

namespace PVBot.DataObjects.Exceptions
{
    public class AccessTokenException : Exception
    {
        public new const string Message = "access_token has expired.";
    }
}
