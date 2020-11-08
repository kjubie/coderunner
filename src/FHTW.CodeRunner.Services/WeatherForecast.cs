// <copyright file="WeatherForecast.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;

namespace FHTW.CodeRunner.Services
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(this.TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
