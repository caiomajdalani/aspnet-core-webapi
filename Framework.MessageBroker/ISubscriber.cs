using System;
using System.Threading.Tasks;

namespace Framework.MessageBroker
{
    public interface ISubscriber
    {
        IExchangeOptions StartConsume<T>(Func<T, bool> factory, Func<BaseMessage, T> msgBinder = null, ushort limit = 0) where T : BaseMessage;
    }
}