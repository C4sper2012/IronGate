using uPLibrary.Networking.M2Mqtt;

namespace Irongate.Service.Interfaces;

public interface IMQTTService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="broker"></param>
    /// <param name="port"></param>
    /// <param name="clientId"></param>
    /// <param name="topic"></param>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <param name="item"></param>
    public void Init(string broker, int port, string clientId, string topic, string username, string password, string item);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="broker"></param>
    /// <param name="port"></param>
    /// <param name="clientId"></param>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public MqttClient ConnectMQTT(string broker, int port, string clientId, string username, string password);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="client"></param>
    /// <param name="topic"></param>
    /// <param name="message"></param>
    public void Publish(MqttClient client, string topic, string message);

}