using Consumer.Models;
using DotNetCore.CAP;
using System.Text.Json;

namespace Consumer.Services
{
    public class CustomerAddedEventSubscriber : ICapSubscribe
    {
        [CapSubscribe("CustomerAdded")]
        public void Consumer(JsonElement customerData)
        {
            Console.WriteLine(customerData);
        }
    }
}
