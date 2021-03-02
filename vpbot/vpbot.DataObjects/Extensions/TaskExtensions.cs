using System;
using System.Threading.Tasks;

namespace VPBot.DataObjects.Extensions
{
    public static class TaskExtensions
    {
        public async static void RunSync(this Task task,
            Action completedCallback = null,
            Action<Exception> errorCallBack = null)
        {
            try
            {
                await task;
                completedCallback?.Invoke();
            }
            catch (Exception ex)
            {
                errorCallBack?.Invoke(ex);
            }
        }

        public async static Task<T> RunSync<T>(this Task<T> task,
            Action<T> completedCallback = null,
            Action<Exception> errorCallBack = null)
        {
            T result = default;

            try
            {
                result = await task;
                completedCallback?.Invoke(result);
                return result;
            }
            catch (Exception ex)
            {
                errorCallBack?.Invoke(ex);
                return result;
            }
        }
    }
}
