using System;
using System.Collections.Generic;
using System.Text;

namespace PVBot.DataObjects.Exceptions
{
    public class RefreshTokenException : Exception
    {
        public new const string Message = "refresh_token has expired.";
    }
}
