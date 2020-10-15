using System;
using System.Globalization;
using Radz1u.Configuration;

namespace Radz1u.Logic
{
    public class OlxDateParser
    {
        private readonly string _todayPrefix;
        private readonly CultureInfo _dateTimeCulture;

        public OlxDateParser(OlxConfiguration configuration){
            _todayPrefix  = configuration.TodayPrefix;
            _dateTimeCulture = CultureInfo.CreateSpecificCulture(configuration.CultureCode);
        }
        
        public DateTime Parse(string date){
            if(date.Contains(_todayPrefix))
                {
                    return ParseToday(date);
                }

            return DateTime.Parse(date,_dateTimeCulture);
        }

        public DateTime ParseToday(string date)
        {
            var today = DateTime.Today;
            return DateTime.Parse(date.Replace(_todayPrefix, today.ToString("dd MMM")));
        }
    }
}