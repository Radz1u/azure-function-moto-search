using System;
using System.Globalization;
using Radz1u.Configuration;

namespace Radz1u.Logic {
    public class OlxDateParser {
        private readonly string _todayPrefix;
        private readonly string _yesterdayPrefix;
        private readonly CultureInfo _dateTimeCulture;

        public OlxDateParser (OlxConfiguration configuration) {
            _todayPrefix = configuration.TodayPrefix;
            _yesterdayPrefix = configuration.YesterdayPrefix;
            _dateTimeCulture = CultureInfo.CreateSpecificCulture (configuration.CultureCode);
        }

        public DateTime Parse (string date) {
            if (date.Contains (_todayPrefix)) {
                return ParseToday (date);
            } else if (date.Contains (_yesterdayPrefix)) {
                return ParseYesterday (date);
            }

            return DateTime.Parse (date, _dateTimeCulture);
        }

        public DateTime ParseToday (string date) {
            var today = date.Replace (_todayPrefix, DateTime.Today.ToString ("dd MMM",_dateTimeCulture));
            
            return DateTime.ParseExact(today,"dd MMM HH:mm",_dateTimeCulture);
        }

        public DateTime ParseYesterday (string date) {
            var yesterdayDateTime = DateTime.Today.AddDays (-1);
            var yesterday = date.Replace (_yesterdayPrefix, yesterdayDateTime.ToString ("dd MMM",_dateTimeCulture));
            return DateTime.ParseExact(yesterday,"dd MMM HH:mm",_dateTimeCulture);
        }
    }
}