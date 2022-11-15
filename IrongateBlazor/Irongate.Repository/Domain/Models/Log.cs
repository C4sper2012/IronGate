using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Irongate.Repository.Domain.Models
{
	public class Log
	{
		public int ID { get; set; }
		public string Message { get; set; }
		public DateTime TimeStamp { get; set; }
	}
}
