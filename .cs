using System;
// Custom exception class for Exercise 1
public class AgeOutOfRangeException : Exception
{
    public AgeOutOfRangeException(string message) : base(message)
    {
    }
}

// Custom exception classes for Exercise 2
public class InsufficientFundsException : Exception
{
    public InsufficientFundsException(string message) : base(message)
    {
    }
}

public class NegativeAmountException : Exception
{
    public NegativeAmountException(string message) : base(message)
    {
    }
}

public class BankAccount
{
    private decimal balance;

    public decimal Balance
    {
        get { return balance; }
    }

    public void Deposit(decimal amount)
    {
        if (amount < 0)
        {
            throw new NegativeAmountException("Không thể gửi tiền âm.");
        }
        balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount < 0)
        {
            throw new NegativeAmountException("Không thể rút tiền âm.");
        }
        if (balance - amount < 0)
        {
            throw new InsufficientFundsException("Tài khoản không đủ tiền.");
        }
        balance -= amount;
    }
}
class Program
{
    static void Main(string[] args)
    {
        int choice;
        do
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Đây là bài tập lý thuyết ngày 6/6/2024 gồm 2 bài.");
            Console.WriteLine("1. Custom Validation Exception.");
            Console.WriteLine("2. Bank Account Exception Handling.");
            Console.WriteLine("0.Exit.");
            choice = int.Parse(Console.ReadLine());
            switch (choice) { 
                case 1:
                    Exercise1();
                    break;
                case 2:
                    Exercise2();
                    break;
                case 0:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Mời chọn lại (1,2,0).");
                    break;
            }
        }while (choice!=0);
    }
    static void Exercise1()
    {
        try
        {
            Console.Write("Nhập tuổi của sinh viên: ");
            int age = int.Parse(Console.ReadLine());

            if (age < 18 || age > 25)
            {
                throw new AgeOutOfRangeException("Tuổi phải từ 18-25.");
            }

            Console.WriteLine("Sinh viên đủ điều kiện nhập học.");
        }
        catch (AgeOutOfRangeException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Đã xảy ra lỗi: " + e.Message);
        }
    }
    static void Exercise2()
    {
        BankAccount account = new BankAccount();

        try
        {
            Console.Write("Nhập số tiền cần gửi: ");
            decimal depositAmount = decimal.Parse(Console.ReadLine());
            account.Deposit(depositAmount);
            Console.WriteLine("Gửi tiền thành công, số dư hiện tại là: " + account.Balance);

            Console.Write("Nhập số tiền cần rút: ");
            decimal withdrawAmount = decimal.Parse(Console.ReadLine());
            account.Withdraw(withdrawAmount);
            Console.WriteLine("Rút tiền thành công số dư hiện tại là: " + account.Balance);
        }
        catch (NegativeAmountException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (InsufficientFundsException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Đã xảy ra lỗi: " + e.Message);
        }
    }
}