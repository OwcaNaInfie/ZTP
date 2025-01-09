namespace Cwiczenie10
{
    public class BankAccount
    {
        // Właściciel konta
        public string AccountHolder { get; }

        // Aktualny stan konta
        private decimal balance;

        private List<IObserver> observers = new();

        public BankAccount(string accountHolder, decimal initialBalance)
        {
            AccountHolder = accountHolder;
            balance = initialBalance;
        }

        // Publiczna właściwość zwracająca aktualne saldo
        public decimal Balance
        {
            get
            {
                return balance;
            }
        }

        // Wpłacanie pieniędzy na konto
        public void Deposit(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Kwota wpłaty musi być większa od zera.");
            balance += amount;
            Console.WriteLine($"Wpłata: {amount:C}. Nowy stan konta: {balance:C}.");
            Notify(balance, amount, true);
        }

        // Wypłacanie pieniędzy z konta
        public void Withdraw(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Kwota wypłaty musi być większa od zera.");
            if (amount > balance) throw new InvalidOperationException("Brak wystarczających środków na koncie.");
            balance -= amount;
            Console.WriteLine($"Wypłata: {amount:C}. Nowy stan konta: {balance:C}.");
            Notify(balance, amount, false);
        }

        public void Subscribe(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer) 
        {
            observers.Remove(observer); 
        }

        private void Notify(decimal balance, decimal amount, bool increase)
        {
            foreach (IObserver observer in observers)
            {
                observer.Update(balance, amount, increase);
            }
        }
    }

}
