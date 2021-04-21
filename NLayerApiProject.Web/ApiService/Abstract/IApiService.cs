using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NLayerApiProject.Web.ApiService.Abstract
{
    public interface IApiService<T>
    {
		string Method { get; set; }
		HttpClient HttpClient { get; set; }
		Task<T> AddAsync(T dto);
		Task<IEnumerable<T>> GetAllAsync();
		Task<bool> Remove(int id);
		Task<T> GetByIdAsync(int id);
		Task<bool> Update(T dto);
	}
}
