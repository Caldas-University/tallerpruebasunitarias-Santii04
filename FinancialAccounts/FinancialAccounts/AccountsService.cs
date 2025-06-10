using System;

namespace FinancialAccounts.Accounts
{
    public class AccountsService
    {
        public bool CanWithdraw(decimal balance, decimal amount, decimal dailyLimit, bool activeAccount, bool blockedAccount)
        {
            if (!activeAccount) return false;
            if (blockedAccount) return false;
            if (balance < amount) return false;
            if (amount > dailyLimit) return false;
            if (amount % 10 != 0) return false;

            return true;
        }
    }
}