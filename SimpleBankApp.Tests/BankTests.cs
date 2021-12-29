using System;
using FluentAssertions;
using Xunit;

namespace SimpleBankApp.Tests
{
    public class BankTests
    {
        [Theory]
        [InlineData(10,0,10)]
        [InlineData(40,0,40)]
        public void Deposit_WhenBalanceZero(decimal money, decimal balance, decimal expected)
        {
            // Arrange
            var sut = new SimpleBank(new CurrencyService())
            {
                Balance = balance
            };

            // Act
            var result = sut.Deposit(money);

            // Assert
            result.Should().Be(expected);
        }
        
        
        [Theory]
        [InlineData(40,40,80)]
        [InlineData(40,-40,0)]
        public void Deposit_WhenBalanceIsNotZero(decimal money,decimal balance, decimal expected)
        {
            // Arrange
            var sut = new SimpleBank(new CurrencyService())
            {
                Balance = balance
            };

            // Act
            var result = sut.Deposit(money);

            // Assert
            result.Should().Be(expected);
        }
        
        [Theory]
        [InlineData(-40,40,-40)]
        [InlineData(-20,40,-20)]
        public void Deposit_ShouldThrowException_WhenMoneyIsNegative(decimal money, decimal balance, decimal negative)
        {            
            // Arrange
            var sut = new SimpleBank(new CurrencyService())
            {
                Balance = balance
            };

            //Act
            Action action = () => sut.Deposit(money);

            // Assert
            action.Should().Throw<Exception>().
                WithMessage($"A negative amount is not possible {negative}");
        }
        
        
        [Theory]
        [InlineData(10,100,90)]
        [InlineData(50,100,50)]
        [InlineData(120,100,-20)]
        [InlineData(80,0,-80)]
        [InlineData(90,20,-70)]
        [InlineData(50,-20,-70)]
        public void Debit_WhenBalanceIsBiggerThanDeductionAndDebitIsNotExceeded(decimal money, decimal balance, decimal expected)
        {
            // Arrange
            var sut = new SimpleBank(new CurrencyService())
            {
                Balance = balance
            };

            // Act
            var result = sut.Debit(money);
            
            // Assert
            result.Should().Be(expected);
        }        
        
        
        [Theory]
        [InlineData(120,0,0)]
        [InlineData(80,-40,-40)]
        public void Debit_ShouldThrowException_WhenDeductionExceedDebit(decimal money, decimal balance,decimal expected)
        {
            // Arrange
            var sut = new SimpleBank(new CurrencyService())
            {
                Balance = balance
            };

            // Act
            Action action = () => sut.Debit(money);
        
            // Assert
            action.Should().Throw<Exception>().
                WithMessage($"Deduction is exceeding the Debit: {expected}");
        }
    }
}