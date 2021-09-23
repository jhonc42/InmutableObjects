using System;
namespace TestInmutableObjects
{
    // This is an inmutable class that produces inmutable objects:
    public class MoneyAmount
    {
        //public decimal Amount { get; set; }
        //public string CurrencySymbol { get; set; }

        public decimal Amount { get; }
        public string CurrencySymbol { get; }

        public MoneyAmount( decimal amount, string currencySymbol)
        {
            if (amount < 0)
                throw new ArgumentException("Money amount must be non-negative.", nameof(amount));

            Amount = amount;
            CurrencySymbol = currencySymbol;
        }

        public MoneyAmount Scale(decimal factor) =>
            new MoneyAmount(this.Amount * factor, this.CurrencySymbol);

        public override string ToString() => $"{this.Amount} {this.CurrencySymbol}";
    }
}
