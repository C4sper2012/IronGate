using System.Security.AccessControl;
using System.Security.Permissions;
using Irongate.Service.Models.Enum;
using Newtonsoft.Json;

namespace Irongate.Service.Models;

public class Humidity
{
    public int id { get; set; }

    public int value { get; set; }

    public DateTime timeStamp { get; set; }

    public int floor { get; set; }
}