using System;
using FsCheck;
using FsCheck.Xunit;
using PBTProjectForTesting.Models;

namespace Test
{
    public class UnitTest1
    {
        [Property]
        public Property Deposit(NonNegativeInt x, PositiveInt y)
        {
            var account = new Account { Balance = x.Get };
            account.Deposit(y.Get);
            return (account.Balance == x.Get + y.Get).ToProperty();
        }

        [Property]
        public Property WithDraw(NonNegativeInt x, PositiveInt y)
        {
            var account = new Account { Balance = x.Get };
            Func<bool> prop = () =>
            {
                account.Withdraw(y.Get);
                return account.Balance == x.Get - y.Get;
            };
            return prop.When(x.Get >= y.Get);
        }

        [Property]
        public Property WithDrawThrow(NonNegativeInt x, PositiveInt y)
        {
            var account = new Account { Balance = x.Get };
            return Prop.Throws<ArgumentException, int>(
                new Lazy<int>(() =>
                {
                    account.Withdraw(y.Get); return x.Get;
                }))
                .When(y.Get > x.Get);
        }

        [Property]
        public Property NoNegativeBalance(NonNegativeInt x, PositiveInt y)
        {
            var account = new Account { Balance = x.Get };
            try
            {
                account.Withdraw(y.Get);
            }
            catch (Exception)
            {
                // ignored
            }

            return (account.Balance >= 0).ToProperty();
        }
    }
}