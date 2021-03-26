using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Transfer.cs;

namespace TransferApp
{
    public class BankApp
    {
        private static int userPin;

        private static string AccountNumber;

        // private static double Balance;

        public static double totalCharges;

        public static object Ammount { get; private set; }

        // private static int pin;
        // private static double newbalance;
        // private static string total;

        public static void UserPin()
        {
            Console.WriteLine("Welcome To F Z Bank");
            Console.WriteLine("How can we help you...???????????");
            Console.WriteLine();
            Console.WriteLine("Choose one of our following options");
            AccountHolderMenu();
        }


        private static void RegisterAccount()
        {

            Console.WriteLine("Enter your firstname: ");
            string Fname = Console.ReadLine();

            Console.WriteLine("Enter your lastname:");
           string Lname = Console.ReadLine();

            Console.WriteLine("Create pin");
            int pin = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Ammount To save");
            double Ammount = Convert.ToDouble(Console.ReadLine());
           
            Console.WriteLine("you have successfully Registerd");
            AnotherTransaction();

            string accountNumber = GenerateAccountNumber();

            //double _Balance = Save();

            // string[] myArray = {"mateen-09068929584-1234","teslim-09068929584-1234","quwam-09068929584-1234"};

            // List<string> testList = File.ReadAllLines("Filename.txt").ToList();

            string test = $"{Fname}-{Lname}-{pin}-{accountNumber}-{Ammount}";

            // testList.Add(test);

            File.WriteAllText("Requestinfo.txt", test);

        }

        private static void Transfer()
        {
            int trials = 3;

            string readtext = File.ReadAllText("Requestinfo.txt ");

            AccountHolder accountHolder = AccountHolder.Parse(readtext);

            Console.WriteLine("Enter your pin");
            int userpin = Convert.ToInt32(Console.ReadLine());


            if (userpin == accountHolder.Pin)
            {
                AmountToTransfer();
            }

            else
            {
                if (trials > 1)

                {
                    Console.WriteLine($"You have {--trials} trials left. ");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("invalid pin.... Account barred");
                    AnotherTransaction();
                }

            }



        }
        private static void AmountToTransfer()
        {
           double  Balance = 0;

            double amount;

            do
            {
                Console.WriteLine("Enter amount to transfer");
                amount = Convert.ToDouble(Console.ReadLine());
                double bankCharges = BankCharges(amount);

                double totalCharges = TotalCharges(amount, bankCharges);

                if (amount >= 50)
                {
                    if (amount >= Balance || totalCharges >= Balance)
                    {
                        Console.WriteLine("You have insufficient funds");
                        AnotherTransaction();
                    }
                    else
                    {
                        CkeckTransfer(amount, bankCharges);

                        string textread = File.ReadAllText("Requestinfo.txt ");

                        AccountHolder accountHolder = AccountHolder.Parse(textread);


                        Console.WriteLine("Enter Receipient Account Number: ");


                        string readtext = File.ReadAllText("Requestinfo.txt");
                        string userAccountNumber = Console.ReadLine();

                        Console.WriteLine(readtext);
                        if (!userAccountNumber.Equals(9) || !userAccountNumber.Equals(accountHolder.AccountNumber))
                        {
                            Console.WriteLine("Invalid Account Number..");
                        }
                        else
                        {
                            bool accountNumberCheck = CheckAccountNumberValidity(userAccountNumber);

                            if (accountNumberCheck)
                            {
                                double newBalance = DeductAmountFromBalance(amount, bankCharges);
                                Console.WriteLine($"you Have successfully Transfered {amount} to {AccountNumber}");
                                Console.WriteLine($"Your balance is: {newBalance}");
                                AnotherTransaction();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Account Number..");
                            }
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Invalid amount! Enter a valid amount");
                }

            } while (amount <= 0 || amount < 50);
        }


        public static void AccountHolderMenu()
        {
            Console.WriteLine("1. Register Account");
            Console.WriteLine("2. Save Money");
            Console.WriteLine("3. Transfer Money");
            Console.WriteLine("4. WithDraw");
            Console.WriteLine("5. Ckeck balance");
            Console.WriteLine("0. Exit");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    RegisterAccount();
                    break;

                case "2":
                   savior(Ammount);
                    break;

                case "3":
                    Transfer();
                    break;

                case "4":
                    myAccount(totalCharges);
                    break;

                case "5":
                    CheckBalance();
                    break;

                case "0":
                    break;
                default:
                    throw new Exception("failed");
            }
        }

        private static void savior(object ammount)
        {
            throw new NotImplementedException();
        }

        private static void CheckBalance()
        {
            throw new NotImplementedException();
        }

        private static void myAccount(double totalCharges)
        {
            double Balance = 0;
            Console.WriteLine("Enter amount to withdraw");
            int draw = Convert.ToInt32(Console.ReadLine());

            if (draw >= 50)
            {

                if (draw >= Balance || totalCharges >= Balance)
                {
                    Console.WriteLine("You have insufficient funds");
                }
                else
                {
                    Console.WriteLine($"You have Succesfully Withdrawed {draw}");
                    AnotherTransaction();
                }

            }
            else
            {
                Console.WriteLine("Invalid amount! Enter a valid amount");
            }
        }


        private static void WithDrawalMethod()
        {
            int trials = 3;

            string readtext = File.ReadAllText("Requestinfo.txt ");

            AccountHolder accountHolder = AccountHolder.Parse(readtext);

            Console.WriteLine("Enter your pin");
            int userpin = Convert.ToInt32(Console.ReadLine());


            if (userpin == accountHolder.Pin)
            {
                myAccount(totalCharges);
            }

            else
            {
                if (trials > 1)

                {
                    Console.WriteLine($"You have {--trials} trials left. ");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("invalid pin..... Account barred");
                    AnotherTransaction();
                }

            }

        }


        private static void CheckBalance(double newbalance)
        {

            string gone = File.ReadAllText("Requestinfo.txt ");

            AccountHolder accountHolder = AccountHolder.Parse(gone);

            Console.WriteLine($"your balance is {newbalance}");
            AnotherTransaction();
        }
        private static bool CheckAccountNumberValidity(string accountNumber)
        {
            bool accountNumberIsValid = true;
            if (accountNumber == null || accountNumber != AccountNumber)
            {
                accountNumberIsValid = false;
            }

            return accountNumberIsValid;
        }

        private static double BankCharges(double amount)
        {
            double bankCharges = amount * 1 / 100;

            return bankCharges;
        }

        private static double TotalCharges(double amount, double charges)
        {
            double totalCharges = amount + charges;

            return totalCharges;
        }

        private static double DeductAmountFromBalance(double amount, double charges)
        {
            double Balance = 0;
            double totalAmount = TotalCharges(amount, charges);

            double newBalance = Balance - totalAmount;

            return newBalance;
        }

        private static void CkeckTransfer(double amount, double charges)
        {
            double totalAmount = TotalCharges(amount, charges);
            Console.WriteLine("+=========================+");
            Console.WriteLine($"|Amount to transfer: {amount}  |");
            Console.WriteLine("+=========================+");

            Console.WriteLine($"|Bank Charges: {charges}       |");
            Console.WriteLine("+=========================+");

            Console.WriteLine($"|Total: {totalAmount}            |");
            Console.WriteLine("+=========================+");
        }
        private static double Save()
        {
            double Balance = 0;
            double Ammount = Convert.ToDouble(Balance);

            double newbalance = Ammount + Balance;

            return newbalance;
           
            // string fan = $"-{newbalance}";
            // File.WriteAllText("Filename.txt", fan);/
        }

        private static double savior(double Ammount)
        {
            double Balance = Ammount;
            Console.WriteLine("Enter Ammount To save");
            double MaxAmmount = Convert.ToDouble(Console.ReadLine());

            double newbalance = MaxAmmount + Ammount;

            // return newbalance;
    
            if (MaxAmmount >= Ammount || MaxAmmount <= Ammount) 
            {
                Console.WriteLine($"you have succesfully saved {MaxAmmount}");
                Console.WriteLine($"your new balance is {newbalance}");
            }

            return newbalance;
        }
        private static bool AnotherTransaction()
        {
            Console.WriteLine("Do u still Want to do some Transaction Y/N");
            string again = Console.ReadLine();
            switch (again)
            {
                case "Y":
                case "y":
                    AccountHolderMenu();
                    return true;

                case "N":
                case "n":
                    Console.WriteLine("Thank you for Banking us");
                    return false;


                default:
                    throw new Exception("failed");
            }
        }


        public static string GenerateAccountNumber()
        {
            Random random = new Random();

            string number1 = random.Next(1, 100000).ToString("00000");
            string number2 = random.Next(1, 10000).ToString("0000");

            string total = number1 + number2;

            return total;
        }


    }
}
