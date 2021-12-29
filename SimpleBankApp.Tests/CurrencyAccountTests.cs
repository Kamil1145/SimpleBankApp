using Xunit;
using FluentAssertions;
using Moq;

namespace SimpleBankApp.Tests
{
    public class CurrencyAccountTests
    {
        [Theory]
        [InlineData("dollar", 400,1632)]
        public void MakeCurrencyTransfer_ForDollars(string currency, decimal amount, decimal expected)
        {
            var currencyServiceMoq = new Mock<CurrencyService>();
            currencyServiceMoq.Setup(x => x.GetCurrencyRate(currency))
                .Returns(4.08m);
            
            var sut = new SimpleBank(currencyServiceMoq.Object);
            
            var result = sut.MakeCurrencyTransfer(currency, amount);

            result.Should().Be(expected);
        }
        
        [Theory]
        [InlineData("euro", 400,1852)]
        public void MakeCurrencyTransfer_ForEuros(string currency, decimal amount, decimal expected)
        {
            var currencyServiceMoq = new Mock<CurrencyService>();
            currencyServiceMoq.Setup(x => x.GetCurrencyRate(currency))
                .Returns(4.63m);
            
            var sut = new SimpleBank(currencyServiceMoq.Object);
            
            var result = sut.MakeCurrencyTransfer(currency, amount);

            result.Should().Be(expected);
        }
        
        [Theory]
        [InlineData("pound", 400,2176)]
        public void MakeCurrencyTransfer_ForPounds(string currency, decimal amount, decimal expected)
        {
            var currencyServiceMoq = new Mock<CurrencyService>();
            currencyServiceMoq.Setup(x => x.GetCurrencyRate(currency))
                .Returns(5.44m);
            
            var sut = new SimpleBank(currencyServiceMoq.Object);
            
            var result = sut.MakeCurrencyTransfer(currency, amount);

            result.Should().Be(expected);
        }
    }
}