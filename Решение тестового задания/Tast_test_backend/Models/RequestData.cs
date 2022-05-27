﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeTestApp.Models
{
    public class RequestData
    {
        //Наша таблица в БД представлена этим классом
        public int Id { get; set; }
        public UserStatisticRequest UserData { get; set; } 
        public DateTime RequestLocalTime { get; set; }
        public string QueryId { get; set; }
    }
}
