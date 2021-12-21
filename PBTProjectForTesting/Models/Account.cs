using System;

namespace PBTProjectForTesting.Models
{
    public class Account
    {
        public int Balance { get; set; }
        public string Owner { get; set; }
        public Guid Id { get; set; }

        public void Withdraw(int amount)
        {
            if (amount > Balance)
            {
                throw new ArgumentException("Cannot withdraw a higher amount than the balance");
            }

            Balance -= amount;
        }

        public void Deposit(int amount)
        {
            Balance += amount;
        }
    }
}