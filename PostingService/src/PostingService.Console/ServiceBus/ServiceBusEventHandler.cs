using System;

namespace PostingService.Console.ServiceBus
{
    [AttributeUsage(AttributeTargets.Method)]

    public class ServiceBusEventHandlerAttribute : Attribute
    {
        private string eventName;

        public ServiceBusEventHandlerAttribute(string eventName)
        {
            this.eventName = eventName;
        }
    }
}
