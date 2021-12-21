using FsCheck;
using FsCheck.Xunit;
using PBTProjectForTesting.Models;
using Xunit;

namespace Test
{
    public class CounterTest
    {
        [Property]
        public Property ShouldFindBug()
        {
            return new CounterSpec()
                .ToProperty();
        }
    }

    public class CounterSpec : ICommandGenerator<Counter, int>
    {

        public Gen<Command<Counter, int>> Next(int value)
        {
            return Gen.Elements(new Command<Counter, int>[] { new Inc(), new Dec() });
        }

        public Counter InitialActual => new Counter();

        public int InitialModel => 0;

        private class Inc : Command<Counter, int>
        {
            public override Counter RunActual(Counter c)
            {
                c.Inc();
                return c;
            }

            public override int RunModel(int m) => m + 1;

            public override Property Post(Counter c, int m)
            {
                return (m == c.Get()).ToProperty();
            }

            public override string ToString() => "inc";
        }

        private class Dec : Command<Counter, int>
        {
            public override Counter RunActual(Counter c)
            {
                c.Dec();
                return c;
            }

            public override int RunModel(int m) => m - 1;

            public override Property Post(Counter c, int m)
            {
                return (m == c.Get()).ToProperty();
            }

            public override string ToString() => "dec";
        }
    }
}