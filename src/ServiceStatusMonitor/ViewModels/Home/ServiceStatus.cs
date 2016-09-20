using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceStatusMonitor.ViewModels.Home
{
	public class ServiceStatus
	{
		public string Text { get; set; }

		public bool IsRunning { get; set; }
	}
}
