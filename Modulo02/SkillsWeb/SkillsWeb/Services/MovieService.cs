using Newtonsoft.Json;
using SkillsMVC.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace SkillsWeb.Services
{
	public class MovieService
	{

		public async Task<T> GetAsync<T>(string url)
		{

			using (HttpClient httpClient = new HttpClient())
			{

				return JsonConvert.DeserializeObject<T>(
					await httpClient.GetStringAsync(url)
				);
			}
		}

		public async Task<HttpResponseMessage> DeleteAsync(string url)
		{

			using (HttpClient httpClient = new HttpClient())
			{

				return await httpClient.DeleteAsync(url);

			}
		}


		/*public async Task<T> PostAsync<T>(string url)
		{

			using (HttpClient httpClient = new HttpClient())
			{

				return JsonConvert.DeserializeObject<T>(
					await httpClient.PostAsync.GetStringAsync(uri)
				);
			}
		}*/
	}
}