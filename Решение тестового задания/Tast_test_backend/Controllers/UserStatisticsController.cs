using FakeTestApp.Models;
using FakeTestApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeTestApp.Controllers
{
    [ApiController]
    public class UserStatisticsController : ControllerBase
    {
        private IDataService _dataService;
        private DurationSetup durationSetup;

        public UserStatisticsController(IDataService dataService, DurationSetup durationSetup)
        {
            _dataService = dataService;
            this.durationSetup = durationSetup;
        }

        [Route("report/user_statistics")]
        [HttpPost]
        public async Task<JsonResult> Post(UserStatisticRequest data)
        {
            //Проверка ввода данных в POst запрос
            if (data == null
                || string.IsNullOrWhiteSpace(data.UserId)
                || data.TimeFrom >= data.TimeTo)
                //Если не корректные данные выводим пустой json
                return new JsonResult(new object());
            //Если правильные то присваем GUID
            string query = Guid.NewGuid().ToString();
            //Создаем экземпляр с данными
            RequestData request = new() {
                UserData = data,
                RequestLocalTime = DateTime.Now,
                QueryId = query
            };
            //Сохраняем экземпляр в Базу данных
            await _dataService.Create(request);
            //Выводим GUID
            return new JsonResult(query);
        }

        [Route("report/info")]
        [HttpGet]
        public async Task<JsonResult> Get(string query)
        {
            //Проверка идентификатора
            if (string.IsNullOrWhiteSpace(query))
                //если не корректен выводим пустой JSON
                return new JsonResult(new object());
            //Заносим пользователя в переменную с таким JSON
            var linkedRequest = await _dataService.Get(query);
            //если такого пользователя нет выводим пустой json
            if (linkedRequest == null)
                return new JsonResult(new object());
            //Время создание пост запроса
            int timeSpend = (int)DateTime.Now.Subtract(linkedRequest.RequestLocalTime).TotalMilliseconds;
            //Определение процента времени
            int percent = timeSpend > durationSetup.MaxTime 
                ? 100 
                : (100 * timeSpend / durationSetup.MaxTime);
            //если прошло 60 сек добавляем UserInfo
            ResponseData info = new(query, percent, percent == 100 
                ? new UserInfoData(linkedRequest.UserData.UserId, "12") 
                : null);
            // вывод данных
            return new JsonResult(info);
        }
    }
}
