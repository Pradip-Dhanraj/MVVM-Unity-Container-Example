using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PCSApplication.Services.WebServices
{
    public interface IWebServices
    {
        Task<T> GetLoginDetailsAsync<T>(string _userData);
        Task<List<T>> GetListHomeMenuAsync<T>();
        Task<List<T>> GetListSubHomeMenuAsync<T>(string param);
        Task<List<T>> GetListDetailsAsync<T>(string param) where T : new();
    }
}
