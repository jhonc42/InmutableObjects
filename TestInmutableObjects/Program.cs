using System;

namespace TestInmutableObjects
{
    class Program
    {
        static bool IsHappyHour { get; set; }

        // Este metodo no deberiba ser responsabilidad del consumidor o del cliente, deberia ser la clase en si, la responsable.
        // Por lo anterior el método se mueve para su propia clase.
        //static MoneyAmount Scale(MoneyAmount moneyAmount, decimal factor) =>
        //    new MoneyAmount(moneyAmount.Amount * factor, moneyAmount.CurrencySymbol);

        static MoneyAmount Reserve(MoneyAmount cost)
        {
            // MoneyAmount newCost = cost;

            // Esta sería una forma de construir el nuevo objeto pero es mejor la que le sigue, donde se construye un método
            // llamado Scale que nos devuelve el objeto ya construido, es decir se encarga de construir el objeto
            //if (IsHappyHour)
            //    newCost = new MoneyAmount(cost.Amount * .5M, cost.CurrencySymbol);

            //if (IsHappyHour)
            //    newCost = Scale(cost, .5M);

            decimal factor = 1;
            if (IsHappyHour)
                factor = .5M;

            Console.WriteLine("\nReserving an item that costs {0}.", cost);

            return cost.Scale(factor);
        }

        static void Buy(MoneyAmount wallet, MoneyAmount cost)
        {

            bool enoughMoney = wallet.Amount >= cost.Amount;

            var finalCost = Reserve(cost);

            bool finalEnough = wallet.Amount >= finalCost.Amount;

            if (enoughMoney && finalEnough)
                Console.WriteLine("You will pay {0} with your {1}.", cost, wallet);
            else if (finalEnough)
                Console.WriteLine("This time, {0} will be enough to pay {1}.", wallet, finalCost);
            else
                Console.WriteLine("You cannot pay {0} with your {1}.", cost, wallet);
        }

        static void Main(string[] args)
        {
            //Buy(new MoneyAmount() { Amount = 12, CurrencySymbol = "USD" },
            //    new MoneyAmount() { Amount = 10, CurrencySymbol = "USD" });

            //Buy(new MoneyAmount() { Amount = 7, CurrencySymbol = "USD" },
            //    new MoneyAmount() { Amount = 10, CurrencySymbol = "USD" });

            //IsHappyHour = true;

            //Buy(new MoneyAmount() { Amount = 7, CurrencySymbol = "USD" },
            //    new MoneyAmount() { Amount = 10, CurrencySymbol = "USD" });

            // Con la nueva implementación, the code of the client or consumer will be simplier.

            Buy(new MoneyAmount(12, "USD"),
                new MoneyAmount(10, "USD")
                );

            Buy(new MoneyAmount(7, "USD"),
                new MoneyAmount(10, "USD"));

            IsHappyHour = true;

            Buy(new MoneyAmount(7, "USD"),
                new MoneyAmount(10, "USD"));

            Console.ReadLine();
        }
    }
}
