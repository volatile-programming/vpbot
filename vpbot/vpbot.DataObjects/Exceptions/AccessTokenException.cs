using System;
using System.Collections.Generic;
using System.Text;

namespace VPBot.DataObjects.Exceptions
{
    public class AccessTokenException : Exception
    {
        public new const string Message = "access_token has expired.";
    }
}
