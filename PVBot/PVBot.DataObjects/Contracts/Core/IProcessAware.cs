using System;

namespace PVBot.DataObjects.Contracts.Core
{
    public interface IProcessAware
    {
        bool IsLoading { get; set; }
        Action<string> ErrorCallBack { get; }
    }
}
