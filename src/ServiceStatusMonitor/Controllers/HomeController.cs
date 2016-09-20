using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceStatusMonitor.ViewModels.Home;

namespace ServiceStatusMonitor.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Status()
		{
			StatusResponse response = new StatusResponse
			{
				Dev = new EnvironmentStatus
				{
					Frontend = await this.GetServiceStatus( @"http://example.com" ),
					Backend = await this.GetServiceStatus( @"http://example.com" )
				},
				Stage = new EnvironmentStatus
				{
					Frontend = await this.GetServiceStatus( @"http://example.com" ),
					Backend = await this.GetServiceStatus( @"http://notexist.example.com" )
				}
			};
			return Json( response );
		}

		public IActionResult Error()
		{
			return View();
		}

		private async Task<ServiceStatus> GetServiceStatus( string url )
		{
			try
			{
				HttpClient client = new HttpClient();
				HttpResponseMessage responseMessage = await client.GetAsync( url );

				return responseMessage.IsSuccessStatusCode
					? new ServiceStatus
					{
						Text = "Running",
						IsRunning = true
					}
					: new ServiceStatus
					{
						Text = "Down",
						IsRunning = false
					};
			}
			catch
			{
				return new ServiceStatus
				{
					Text = "Down",
					IsRunning = false
				};
			}

		}
	}
}
