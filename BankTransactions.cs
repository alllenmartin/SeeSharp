using System;
using System.ComponentModel;
namespace BankTransactions
{
    class Member
    {
        public string _Name = "Allen";
        public string _No="10224";
        public string _BnkAcc= "CH00056";

       
    }
    class BankAccount:Member
    {
        private double balance, Charges;
        private double _Amount;
        public const double maxAmount = 1000000;
        public const double chargePer = 0.45;

        //Accessing private amount
         public double Amount
        {
           get { return _Amount; }
           set
            {
                if(value <= 0){
                    throw new ArithmeticException("Amount can not be less than 0");
                }
                else{
                    _Amount = value;
                    
                }
            }
        }
        //Bank Deposit
         public double BankDeposit(double depositAmount)
            {
            if((depositAmount > 0) & (depositAmount  < maxAmount))
            {
                this.balance += depositAmount;
            } else { throw new ArithmeticException(depositAmount +" is not within the transaction range!"); }
             
             return balance;
          }
        //Bank withdrawals
        public double BankWithdrawal(double withdrawalAmount)
        {
            if(withdrawalAmount>0)
            {
                //Charges
                Charges = withdrawalAmount*chargePer;
                if(balance > (withdrawalAmount+Charges))
                {
                    this.balance -= withdrawalAmount;
                } else {
                    throw new ArithmeticException("You have insufficient account balance!"); 
                }
            } else { throw new ArithmeticException("You can not withdraw 0 bob!");}

            return balance;
        } 

        //Getter
        public double GetBalance()
        {
            return balance;
        }

        //Setter
        
        public void SetBalance(double amount)
        {
            if (amount <= 0) {
                throw new ArithmeticException("Amount must be more than 0");
            }
            else if(amount >= maxAmount)
            {
                throw new ArithmeticException("You have exceeded the limited deposit amount");
            }

           this.balance = amount;
        }
       
       
        }
        class Program {
            public static void Main(String [] args)
            {
                BankAccount bank = new();
                bank.SetBalance(100000);
                bank.BankDeposit(1000);
                bank.BankWithdrawal(50);

                Console.WriteLine("Member "+bank._Name+" of bank account number "+ bank._BnkAcc +" and account number "+ bank._No +" has a balance of "+bank.GetBalance());
                Console.Write("Press <Enter> to exit... ");
                while (Console.ReadKey().Key != ConsoleKey.Enter) {}
            }
        }
    
    
}
