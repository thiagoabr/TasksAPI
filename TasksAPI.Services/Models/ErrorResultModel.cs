﻿using Newtonsoft.Json;

namespace TasksAPI.Services.Models
{
    public class ErrorResultModel
    {
        public int? StatusCode { get; set; }
        public string? Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
