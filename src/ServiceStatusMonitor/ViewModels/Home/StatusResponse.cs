using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceStatusMonitor.ViewModels.Home
{
	public class StatusResponse
	{
		public EnvironmentStatus Dev { get; set; }

		public EnvironmentStatus Stage { get; set; }
	}
}
