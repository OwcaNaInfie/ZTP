namespace Cwiczenie10
{

    public class Program
    {
        public static void Main(string[] args)
        {
            var account = new BankAccount("Jan Kowalski", 3000);

            CreditCardModule credit = new CreditCardModule();
            DepositModule deposit = new DepositModule();
            SafetyModule safety = new SafetyModule();
            LoanModule loan = new LoanModule();

            account.Subscribe(deposit);
            account.Subscribe(safety);
            account.Subscribe(loan);
            account.Subscribe(credit);

            account.Deposit(500);
            account.Withdraw(2000);
            account.Withdraw(1450);
            account.Deposit(15000);
            account.Withdraw(100);
            account.Withdraw(300);
            account.Withdraw(500);
            account.Withdraw(50);
            account.Withdraw(100);
            account.Withdraw(200);
            account.Withdraw(500);
            account.Withdraw(1000);
            account.Withdraw(100);

            Console.WriteLine($"\nKońcowy stan konta: {account.Balance:C}");
        }
    }

}
