using System;
using System.Globalization;

namespace Radz1u.Logic
{
    public class OlxDateParser
    {
        private const string polishCultureCode = "pl-PL";
        private const string todayPrefix = "dzisiaj";
        private CultureInfo dateTimeCulture;

        public OlxDateParser(){
            dateTimeCulture = CultureInfo.CreateSpecificCulture(polishCultureCode);
        }
        
        public DateTime Parse(string date){
            if(date.Contains(todayPrefix))
                {
                    return ParseToday(date);
                }

            return DateTime.Parse(date,dateTimeCulture);
        }

        public DateTime ParseToday(string date)
        {
            var today = DateTime.Today;
            return DateTime.Parse(date.Replace(todayPrefix, today.ToString("dd MMM")));
        }
    }
}