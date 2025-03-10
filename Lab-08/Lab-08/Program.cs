using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace Lab_08
{
    public delegate void WithdrawalHandler(string s);
    public delegate void TransferHandler(string s);
    public delegate void NotEnoughBalance(string s);
    public class Account
    {
        public int TotalMoney;
        public Account(int totalMoney)
        {
            this.TotalMoney = totalMoney;
        }

        public override string ToString()
        {
            return $"Số tiền trong tài khoản là : {this.TotalMoney}";
        }

        public event WithdrawalHandler OnWithdrawalHandler;
        public event TransferHandler OnTransferHandler;
        public event NotEnoughBalance OnNotEnoughBalance;

        public void Withdrawal(int money)
        {
            if (money > this.TotalMoney)
            {
                OnNotEnoughBalance("Số dư tài khoản không đủ");
            }
            else
            {
                this.TotalMoney -= money;   
                if (OnWithdrawalHandler != null)
                {
                    OnWithdrawalHandler($"Đã rút {money} VND");
                }
            }
        }

        public void Transfer (int money)
        {
            if (money > this.TotalMoney)
            {
                OnNotEnoughBalance("Số dư tài khoản không đủ");
            }
            else
            {
                this.TotalMoney -= money;
                if (OnTransferHandler != null)
                {
                    OnTransferHandler($"Đã chuyển {money} VND");
                }
            }
        }
    }

    
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; 
            Account account = new Account(500000);
            Console.WriteLine(account.ToString());
            Console.WriteLine("______________________________");
            account.OnWithdrawalHandler += Account_OnWithdrawalHandler;
            account.OnTransferHandler += Account_OnTransferHandler;
            account.OnNotEnoughBalance += Account_OnNotEnoughBalance;

            account.Withdrawal(30000);
            Console.WriteLine(account.ToString());
            Console.WriteLine("______________________________");
            account.Transfer(40000);
            Console.WriteLine(account.ToString());
            Console.WriteLine("______________________________");
            account.Withdrawal(600000);
            Console.WriteLine(account.ToString());
            
            Console.ReadKey();

        }

        private static void Account_OnNotEnoughBalance(string s)
        {
            Console.WriteLine(s);
        }

        private static void Account_OnTransferHandler(string s)
        {
            Console.WriteLine(s);
        }

        private static void Account_OnWithdrawalHandler(string s)
        {
            Console.WriteLine(s);
        }
    }

   

    

    
}
