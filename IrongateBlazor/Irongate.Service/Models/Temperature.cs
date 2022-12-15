using Irongate.Service.Models.Enum;
using Newtonsoft.Json;

namespace Irongate.Service.Models;

public class Temperature
{
    public int id { get; set; }
    
    public int value { get; set; }
    
    public DateTime timeStamp { get; set; }
    
    public int floor { get; set; }
}