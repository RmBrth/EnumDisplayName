using EnumDisplayName.Data;
using EnumDisplayName.Helpers;
using System.Globalization;
using System.Threading;
using Xunit;

namespace EnumDisplayName
{
    public class UnitTest
    {
        [Fact]
        public void LocalizationDefault()
        {
            string result = Properties.Resources.Monday;
            Assert.Equal("Lundi", result); // As my system culture is fr-FR
        }

        [Fact]
        public void LocalizationFr()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("fr-FR");
            string result = Properties.Resources.Monday;
            Assert.Equal("Lundi", result);
        }

        [Fact]
        public void LocalizationDe()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");
            string result = Properties.Resources.Monday;
            Assert.Equal("Montag", result);
        }

        [Fact]
        public void LocalizationJp()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("jp-JP");
            string result = Properties.Resources.Monday;
            Assert.Equal("Monday", result);
        }

        [Fact]
        public void Montag()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");
            string result = Days.Monday.GetDisplayName();
            Assert.Equal("Montag", result);
        }

        [Fact]
        public void Dienstag()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");
            string result = Days.Tuesday.GetDisplayName();
            Assert.Equal("Dienstag", result);
        }

        [Fact]
        public void Mittwoch()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");
            string result = Days.Wednesday.GetDisplayName();
            Assert.Equal("Mercredi", result); // Resources aren't used, "Mercredi" is set as Name in Wednesday data attribute
        }
    }
}
