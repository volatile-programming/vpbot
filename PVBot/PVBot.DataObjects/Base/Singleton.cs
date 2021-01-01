using System;

namespace PVBot.DataObjects.Base
{
    public abstract class Singleton<T> where T : class
    {
        private static readonly object _loocker = new object();

        private static T _instance;
        public static T Instance
        {
            get
            {
                lock (_loocker)
                {
                    return _instance ?? (_instance = Activator.CreateInstance<T>());
                }
            }
        }
    }
}
