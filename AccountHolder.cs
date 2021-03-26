namespace Transfer.cs
{
    public class AccountHolder
    {

        public string Name { get; set; }

        public int PhoneNumber { get; set; }

        public int Pin { get; set; }

        public int AccountNumber { get; set; }

        public double Ammount { get; set; }

        public AccountHolder(string name, int phoneNumber, int pin, int accountNumber, double ammount)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Pin = pin;
            AccountNumber = accountNumber;
            Ammount = ammount;
        }

        public static AccountHolder Parse(string accountHolderText)
        {
            string[] text = accountHolderText.Split("-");
            AccountHolder accountHolder = new AccountHolder(text[0], int.Parse(text[1]), int.Parse(text[2]), int.Parse(text[3]), double.Parse(text[4]));
            return accountHolder;
        }

    }
}