using FakeTestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeTestApp.Services
{
    public interface IDataService
    { 
        //метод для реализации добавление и сохранения записи
        Task Create(RequestData request);

        //мотед для реализации выборки в БД
        Task<RequestData> Get(string guid);
    }
}
