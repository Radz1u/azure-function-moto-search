using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using NSubstitute;
using Radz1u.Configuration;
using Radz1u.Logic;
using Xunit;

namespace test {
    public class OlxAdsReaderTests {

        private OlxAdsReader _reader;
        private void Configure () {
            var config = Substitute.For<OlxConfiguration> ();
            config.Url.Returns ("https://www.olx.pl/motoryzacja/motocykle-skutery/q-street-triple/?search%5Bfilter_enum_mark%5D%5B0%5D=triumph&search%5Bfilter_float_price%3Ato%5D=15000&search%5Bfilter_float_year%3Afrom%5D=2009&search%5Bfilter_enum_condition%5D%5B0%5D=notdamaged");
            config.TodayPrefix.Returns ("dzisiaj");
            config.YesterdayPrefix.Returns ("wczoraj");
            config.CultureCode.Returns ("pl-PL");
            _reader = new OlxAdsReader(config);
        }

        [Fact]
        public async Task When_ReadAsync_Then_The_Collection_NotEmpty () {
            Configure();
            var items = await _reader.ReadAsync();
            Assert.NotEmpty(items);
        }
    }
}