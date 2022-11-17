using Irongate.Service.Interfaces;
using uPLibrary.Networking.M2Mqtt;

namespace Irongate.Service.Services
{
    public class WindowService : IWindowService
    {
        public void Init(string broker, int port, string clientId, string topic, string username, string password, string item)
        {
            string message = $"{item}";
            Console.WriteLine(message);
            MqttClient client = ConnectMQTT(broker, port, clientId, username, password);
            Publish(client, topic, message);
        }

        public MqttClient ConnectMQTT(string broker, int port, string clientId, string username, string password)
        {
            MqttClient client = new MqttClient(broker, port, false, MqttSslProtocols.None, null, null);
            client.Connect(clientId, username, password);
            if (client.IsConnected)
            {
                Console.WriteLine("Connected to MQTT Broker");
            }
            else
            {
                Console.WriteLine("Failed to connect");
            }
            return client;
        }

        public void Publish(MqttClient client, string topic, string message)
        {
            //System.Threading.Thread.Sleep(1*20000);
            client.Publish(topic, System.Text.Encoding.UTF8.GetBytes(message));
            Console.WriteLine($"Send {message} to topic `{topic}`");
        }
    
    }
}