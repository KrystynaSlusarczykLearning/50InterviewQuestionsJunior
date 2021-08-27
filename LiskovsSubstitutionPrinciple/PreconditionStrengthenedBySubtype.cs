using System;

namespace LiskovSubstitutionPrinciple
{
    class BankAccount
    {
        public virtual void WithdrawMoney(int amount)
        {
            if (amount < 10000)
            {
                Console.WriteLine($"Withdrawing money (amount: {amount})");
            }
            else
            {
                Console.WriteLine($"Withdrawing sum of {amount} requires extra authorization.");
            }
        }
    }

    class ChildBankAccount : BankAccount
    {
        public override void WithdrawMoney(int amount)
        {
            if (amount < 1000)
            {
                Console.WriteLine($"Withdrawing money (amount: {amount})");
            }
            else
            {
                Console.WriteLine($"Withdrawing sum of {amount} requires extra authorization.");
            }
        }
    }

    class CashMachine
    {
        public void WithdrawFromAccount(BankAccount bankAccount, int amount)
        {
            bankAccount.WithdrawMoney(amount);
        }
    }
}
