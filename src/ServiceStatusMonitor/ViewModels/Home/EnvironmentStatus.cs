using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceStatusMonitor.ViewModels.Home
{
	public class EnvironmentStatus
	{
		public ServiceStatus Frontend { get; set; }

		public ServiceStatus Backend { get; set; }
	}
}
