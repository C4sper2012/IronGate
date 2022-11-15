using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Irongate.Repository.Domain.Models
{
	public class Climate
	{
		public int ID { get; set; }
		public DateTime TimeStamp { get; set; }
		public int Temperature { get; set; }
		public int Humidity { get; set; }
	}
}
