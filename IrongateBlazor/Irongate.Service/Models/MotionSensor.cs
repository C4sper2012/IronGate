namespace Irongate.Service.Models
{
    public class MotionSensor
    {
        public int id { get; set; }

        public int entryID { get; set; }

        public int value { get; set; }

        public DateTime timeStamp { get; set; }
    }
}