using NUnit.Framework;
using FinancialAccounts.Accounts;
using System;

namespace FinancialAccounts.Tests.Accounts
{
    public class AccountsServiceTests
    {
        private AccountsService _service;

        [SetUp]
        public void Setup()
        {
            _service = new AccountsService();
        }

        // TC1 - All conditions are valid
        [Test]
        public void TC1_ValidWithdrawal_ShouldReturnTrue()
        {
            var result = _service.CanWithdraw(500, 100, 300, true, false);
            Assert.IsTrue(result);
        }

        // TC2 - Inactive account
        [Test]
        public void TC2_InactiveAccount_ShouldReturnFalse()
        {
            var result = _service.CanWithdraw(500, 100, 300, false, false);
            Assert.IsFalse(result);
        }

        // TC3 - Insufficient balance
        [Test]
        public void TC3_InsufficientBalance_ShouldReturnFalse()
        {
            var result = _service.CanWithdraw(50, 100, 300, true, false);
            Assert.IsFalse(result);
        }

        // TC4 - Exceeds daily limit
        [Test]
        public void TC4_ExceedsDailyLimit_ShouldReturnFalse()
        {
            var result = _service.CanWithdraw(500, 400, 300, true, false);
            Assert.IsFalse(result);
        }

        // TC5 - Account blocked due to fraud
        [Test]
        public void TC5_AccountBlockedByFraud_ShouldReturnFalse()
        {
            var result = _service.CanWithdraw(500, 100, 300, true, true);
            Assert.IsFalse(result);
        }

        // TC6 - Amount is not a multiple of 10
        [Test]
        public void TC6_AmountNotMultipleOf10_ShouldReturnFalse()
        {
            var result = _service.CanWithdraw(500, 105, 300, true, false);
            Assert.IsFalse(result);
        }
    }
}
